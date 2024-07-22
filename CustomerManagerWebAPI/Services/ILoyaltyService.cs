using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface ILoyaltyService
    {
        Task<IEnumerable<LoyaltyProgram>> GetAllLoyaltyProgramsAsync();
        Task<LoyaltyProgram> GetLoyaltyProgramByIdAsync(int id);
        Task CreateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram);
        Task<bool> UpdateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram);
        Task<bool> DeleteLoyaltyProgramAsync(int id);
    }
}
