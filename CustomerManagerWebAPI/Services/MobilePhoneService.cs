using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        private readonly IMobilePhoneRepository _mobilePhoneRepository;

        public MobilePhoneService(IMobilePhoneRepository mobilePhoneRepository)
        {
            _mobilePhoneRepository = mobilePhoneRepository;
        }

        public async Task<IEnumerable<MobilePhone>> GetAllMobilePhonesAsync()
        {
            return await _mobilePhoneRepository.GetAllMobilePhonesAsync();
        }

        public async Task<MobilePhone> GetMobilePhoneByIdAsync(int id)
        {
            return await _mobilePhoneRepository.GetMobilePhoneByIdAsync(id);
        }

        public async Task<IEnumerable<MobilePhone>> GetMobilePhonesByCustomerIdAsync(int customerId)
        {
            return await _mobilePhoneRepository.GetMobilePhonesByCustomerIdAsync(customerId);
        }

        public async Task CreateMobilePhoneAsync(MobilePhone mobilePhone)
        {
            await _mobilePhoneRepository.CreateMobilePhoneAsync(mobilePhone);
        }

        public async Task<bool> UpdateMobilePhoneAsync(MobilePhone mobilePhone)
        {
            return await _mobilePhoneRepository.UpdateMobilePhoneAsync(mobilePhone);
        }

        public async Task<bool> DeleteMobilePhoneAsync(int id)
        {
            return await _mobilePhoneRepository.DeleteMobilePhoneAsync(id);
        }
    }
}
