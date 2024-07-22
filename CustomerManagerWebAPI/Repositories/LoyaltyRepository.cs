using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Repositories;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public class LoyaltyRepository : ILoyaltyRepository
    {
        private readonly ApplicationDbContext _context;

        public LoyaltyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LoyaltyProgram>> GetAllLoyaltyProgramsAsync()
        {
            return await _context.LoyaltyPrograms.ToListAsync();
        }

        public async Task<LoyaltyProgram> GetLoyaltyProgramByIdAsync(int id)
        {
            return await _context.LoyaltyPrograms.FindAsync(id);
        }

        public async Task CreateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
        {
            _context.LoyaltyPrograms.Add(loyaltyProgram);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
        {
            _context.Entry(loyaltyProgram).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LoyaltyProgramExists(loyaltyProgram.Id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<bool> DeleteLoyaltyProgramAsync(int id)
        {
            var loyaltyProgram = await _context.LoyaltyPrograms.FindAsync(id);
            if (loyaltyProgram == null)
            {
                return false;
            }
            _context.LoyaltyPrograms.Remove(loyaltyProgram);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> LoyaltyProgramExists(int id)
        {
            return await _context.LoyaltyPrograms.AnyAsync(e => e.Id == id);
        }
    }
}
