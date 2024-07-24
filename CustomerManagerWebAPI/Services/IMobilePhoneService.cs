using CustomerManagerWebApiByAlp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface IMobilePhoneService
    {
        Task<IEnumerable<MobilePhone>> GetAllMobilePhonesAsync();
        Task<MobilePhone> GetMobilePhoneByIdAsync(int id);
        Task<IEnumerable<MobilePhone>> GetMobilePhonesByCustomerIdAsync(int customerId);
        Task CreateMobilePhoneAsync(MobilePhone mobilePhone);
        Task<bool> UpdateMobilePhoneAsync(MobilePhone mobilePhone);
        Task<bool> DeleteMobilePhoneAsync(int id);
    }
}
