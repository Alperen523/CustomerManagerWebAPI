using CustomerManagerWebApiByAlp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public interface IMobilePhoneRepository
    {
        Task<IEnumerable<MobilePhone>> GetAllMobilePhonesAsync();
        Task<MobilePhone> GetMobilePhoneByIdAsync(int id);
        Task<IEnumerable<MobilePhone>> GetMobilePhonesByCustomerIdAsync(int customerId);
        Task CreateMobilePhoneAsync(MobilePhone mobilePhone);
        Task<bool> UpdateMobilePhoneAsync(MobilePhone mobilePhone);
        Task<bool> DeleteMobilePhoneAsync(int id);
    }
}
