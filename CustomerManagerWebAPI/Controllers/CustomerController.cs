using CustomerManagerWebApiByAlp.Data;
using CustomerManagerWebApiByAlp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagerWebApiByAlp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var allCustomers = await _context.Customers.ToListAsync();
            return Ok(allCustomers);
        }

        [HttpPost("seed-customers/{numberOfRecords}")]
        public async Task<IActionResult> SeedCustomers(int numberOfRecords)
        {
            if (numberOfRecords <= 0)
            {
                return BadRequest("Number of records must be greater than 0.");
            }

            var customers = GenerateRandomCustomers(numberOfRecords);

            await _context.Customers.AddRangeAsync(customers);
            await _context.SaveChangesAsync();

            return Ok($"{numberOfRecords} customers seeded successfully.");
        }

        private List<Customer> GenerateRandomCustomers(int numberOfRecords)
        {
            var customers = new List<Customer>();
            var random = new Random();

            for (int i = 0; i < numberOfRecords; i++)
            {
                var customer = new Customer
                {
                    FirstName = GetRandomString(5, random),
                    LastName = GetRandomString(7, random),
                    DateOfBirth = GetRandomDate(random),
                    Address = $"{GetRandomNumber(1000, 9999, random)} {GetRandomString(10, random)} St"
                };
                customers.Add(customer);
            }
            return customers;
        }

        private string GetRandomString(int length, Random random)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }

        private DateTime GetRandomDate(Random random)
        {
            int year = random.Next(1950, 2010);
            int month = random.Next(1, 13);
            int day = random.Next(1, 29); // basitlik açısından 28 günle sınırlıyoruz
            return new DateTime(year, month, day);
        }

        private int GetRandomNumber(int min, int max, Random random)
        {
            return random.Next(min, max);
        }
    }
}
