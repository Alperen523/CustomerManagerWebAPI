namespace CustomerManagerWebAPI.Models
{
    public class MobilePhoneDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public bool SmsPermission { get; set; }
        public bool CallPermission { get; set; }
        public int CustomerId { get; set; }
    }

}