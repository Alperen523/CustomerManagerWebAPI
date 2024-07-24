using Microsoft.AspNetCore.Mvc;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebAPI.Models;

namespace CustomerManagerWebApiByAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public EmailController(ApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetAllEmails()
        {
            var emails = await _emailService.GetAllEmailsAsync();
            return Ok(emails);
        }

        [HttpGet("ByCustomerId/{customerId}")]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmailsByCustomerId(int customerId)
        {
            var emails = await _emailService.GetEmailsByCustomerIdAsync(customerId);
            return Ok(emails);
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult> CreateEmail(int customerId, Email email)
        {
            email.CustomerId = customerId;
            await _emailService.CreateEmailAsync(email);
            return CreatedAtAction(nameof(GetEmailsByCustomerId), new { id = email.Id }, email);
        }
        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateEmail(int customerId, [FromBody] EmailDto emailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = await _context.Emails.FindAsync(emailDto.Id);
            if (email == null)
            {
                return NotFound();
            }

            if (email.CustomerId != customerId)
            {
                return BadRequest("CustomerId mismatch.");
            }

            email.EmailAddress = emailDto.EmailAddress;

            _context.Emails.Update(email);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{customerId}/{id}")]
        public async Task<ActionResult> DeleteEmail(int customerId, int id)
        {
            var deleted = await _emailService.DeleteEmailAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
