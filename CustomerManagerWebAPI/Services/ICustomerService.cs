using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task CreateCustomerAsync(CustomerDto customerDto);
        Task<bool> UpdateCustomerAsync(CustomerDto customerDto);
        Task<bool> DeleteCustomerAsync(int id);
    }
}
