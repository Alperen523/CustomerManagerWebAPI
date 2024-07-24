using System.Collections.Generic;

namespace CustomerManagerWebApiByAlp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }

        // Navigation properties
        public ICollection<Email> Emails { get; set; }
        public ICollection<MobilePhone> MobilePhones { get; set; }
    }
}
