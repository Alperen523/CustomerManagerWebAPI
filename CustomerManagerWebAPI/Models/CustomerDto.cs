using CustomerManagerWebAPI.Models;

namespace CustomerManagerWebApiByAlp.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public List<EmailDto> Emails { get; set; }
        public List<MobilePhoneDto> MobilePhones { get; set; }

    }
}