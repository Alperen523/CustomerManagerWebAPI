using CustomerManagerWebApiByAlp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface IEmailService
    {
        Task<IEnumerable<Email>> GetAllEmailsAsync();
        Task<Email> GetEmailByIdAsync(int id);
        Task<IEnumerable<Email>> GetEmailsByCustomerIdAsync(int customerId);
        Task CreateEmailAsync(Email email);
        Task<bool> UpdateEmailAsync(Email email);
        Task<bool> DeleteEmailAsync(int id);
    }
}
