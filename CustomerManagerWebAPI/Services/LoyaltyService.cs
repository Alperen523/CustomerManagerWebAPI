using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Repositories;
using CustomerManagerWebApiByAlp.Services;

namespace CustomerManagerWebApiByAlp.Services
{
    public class LoyaltyService : ILoyaltyService
    {
        private readonly ILoyaltyRepository _loyaltyRepository;

        public LoyaltyService(ILoyaltyRepository loyaltyRepository)
        {
            _loyaltyRepository = loyaltyRepository;
        }

        public async Task<IEnumerable<LoyaltyProgram>> GetAllLoyaltyProgramsAsync()
        {
            return await _loyaltyRepository.GetAllLoyaltyProgramsAsync();
        }

        public async Task<LoyaltyProgram> GetLoyaltyProgramByIdAsync(int id)
        {
            return await _loyaltyRepository.GetLoyaltyProgramByIdAsync(id);
        }

        public async Task CreateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
        {
            await _loyaltyRepository.CreateLoyaltyProgramAsync(loyaltyProgram);
        }

        public async Task<bool> UpdateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
        {
            return await _loyaltyRepository.UpdateLoyaltyProgramAsync(loyaltyProgram);
        }

        public async Task<bool> DeleteLoyaltyProgramAsync(int id)
        {
            return await _loyaltyRepository.DeleteLoyaltyProgramAsync(id);
        }
    }
}
