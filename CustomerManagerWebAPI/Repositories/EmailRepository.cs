using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await _context.Emails.ToListAsync();
        }

        public async Task<Email> GetEmailByIdAsync(int id)
        {
            return await _context.Emails.FindAsync(id);
        }

        public async Task<IEnumerable<Email>> GetEmailsByCustomerIdAsync(int customerId)
        {
            return await _context.Emails.Where(e => e.CustomerId == customerId).ToListAsync();
        }

        public async Task CreateEmailAsync(Email email)
        {
            _context.Emails.Add(email);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateEmailAsync(Email email)
        {
            _context.Entry(email).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(email.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteEmailAsync(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return false;
            }

            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.Id == id);
        }
    }
}
