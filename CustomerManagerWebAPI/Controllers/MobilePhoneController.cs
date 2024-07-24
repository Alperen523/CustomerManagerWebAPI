using Microsoft.AspNetCore.Mvc;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CustomerManagerWebApiByAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobilePhoneController : ControllerBase
    {
        private readonly IMobilePhoneService _mobilePhoneService;

        public MobilePhoneController(IMobilePhoneService mobilePhoneService)
        {
            _mobilePhoneService = mobilePhoneService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobilePhone>>> GetAllMobilePhones()
        {
            var mobilePhones = await _mobilePhoneService.GetAllMobilePhonesAsync();
            return Ok(mobilePhones);
        }

        [HttpGet("ByCustomerId/{customerId}")]
        public async Task<ActionResult<IEnumerable<MobilePhone>>> GetMobilePhonesByCustomerId(int customerId)
        {
            var mobilePhones = await _mobilePhoneService.GetMobilePhonesByCustomerIdAsync(customerId);
            return Ok(mobilePhones);
        }

        [HttpPost("{customerId}")]
        public async Task<ActionResult> CreateMobilePhone(int customerId, MobilePhone mobilePhone)
        {
            mobilePhone.CustomerId = customerId;
            await _mobilePhoneService.CreateMobilePhoneAsync(mobilePhone);
            return CreatedAtAction(nameof(GetMobilePhonesByCustomerId), new { id = mobilePhone.Id }, mobilePhone);
        }

        [HttpPut("{customerId}/{id}")]
        public async Task<ActionResult> UpdateMobilePhone(int customerId, int id, MobilePhone mobilePhone)
        {
            if (id != mobilePhone.Id || customerId != mobilePhone.CustomerId)
            {
                return BadRequest();
            }

            var updated = await _mobilePhoneService.UpdateMobilePhoneAsync(mobilePhone);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{customerId}/{id}")]
        public async Task<ActionResult> DeleteMobilePhone(int customerId, int id)
        {
            var deleted = await _mobilePhoneService.DeleteMobilePhoneAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
