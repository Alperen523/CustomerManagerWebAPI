using CustomerManagerWebApiByAlp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public interface IEmailRepository
    {
        Task<IEnumerable<Email>> GetAllEmailsAsync();
        Task<Email> GetEmailByIdAsync(int id);
        Task<IEnumerable<Email>> GetEmailsByCustomerIdAsync(int customerId);
        Task CreateEmailAsync(Email email);
        Task<bool> UpdateEmailAsync(Email email);
        Task<bool> DeleteEmailAsync(int id);
    }
}
