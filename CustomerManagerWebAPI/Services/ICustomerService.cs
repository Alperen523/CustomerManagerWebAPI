using System.Collections.Generic;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}