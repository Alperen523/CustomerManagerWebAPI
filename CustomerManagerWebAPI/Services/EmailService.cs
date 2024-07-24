using CustomerManagerWebApiByAlp.Models;
using CustomerManagerWebApiByAlp.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await _emailRepository.GetAllEmailsAsync();
        }

        public async Task<Email> GetEmailByIdAsync(int id)
        {
            return await _emailRepository.GetEmailByIdAsync(id);
        }

        public async Task<IEnumerable<Email>> GetEmailsByCustomerIdAsync(int customerId)
        {
            return await _emailRepository.GetEmailsByCustomerIdAsync(customerId);
        }

        public async Task CreateEmailAsync(Email email)
        {
            await _emailRepository.CreateEmailAsync(email);
        }

        public async Task<bool> UpdateEmailAsync(Email email)
        {
            return await _emailRepository.UpdateEmailAsync(email);
        }

        public async Task<bool> DeleteEmailAsync(int id)
        {
            return await _emailRepository.DeleteEmailAsync(id);
        }
    }
}
