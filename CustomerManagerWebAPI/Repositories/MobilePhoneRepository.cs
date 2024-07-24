using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public class MobilePhoneRepository : IMobilePhoneRepository
    {
        private readonly ApplicationDbContext _context;

        public MobilePhoneRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MobilePhone>> GetAllMobilePhonesAsync()
        {
            return await _context.MobilePhones.ToListAsync();
        }

        public async Task<MobilePhone> GetMobilePhoneByIdAsync(int id)
        {
            return await _context.MobilePhones.FindAsync(id);
        }

        public async Task<IEnumerable<MobilePhone>> GetMobilePhonesByCustomerIdAsync(int customerId)
        {
            return await _context.MobilePhones.Where(m => m.CustomerId == customerId).ToListAsync();
        }

        public async Task CreateMobilePhoneAsync(MobilePhone mobilePhone)
        {
            _context.MobilePhones.Add(mobilePhone);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateMobilePhoneAsync(MobilePhone mobilePhone)
        {
            _context.Entry(mobilePhone).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobilePhoneExists(mobilePhone.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteMobilePhoneAsync(int id)
        {
            var mobilePhone = await _context.MobilePhones.FindAsync(id);
            if (mobilePhone == null)
            {
                return false;
            }

            _context.MobilePhones.Remove(mobilePhone);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool MobilePhoneExists(int id)
        {
            return _context.MobilePhones.Any(m => m.Id == id);
        }
    }
}
