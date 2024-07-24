using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Utilities
{
    public class CustomerDataSeeder
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public CustomerDataSeeder(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiUrl = configuration.GetValue<string>("ApiSettings:BaseUrl") + "/api/customer";
        }

        public async Task SeedCustomerDataAsync(int numberOfRecords)
        {
            for (int i = 0; i < numberOfRecords; i++)
            {
                var firstName = RandomDataGenerator.GetRandomFirstName();
                var lastName = RandomDataGenerator.GetRandomLastName();

                var customer = new Customer
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = RandomDataGenerator.GetRandomDateOfBirth(),
                    Address = RandomDataGenerator.GetRandomStreet()
                };

                var response = await _httpClient.PostAsJsonAsync(_apiUrl, customer);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
