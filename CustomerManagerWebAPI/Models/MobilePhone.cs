using CustomerManagerWebApiByAlp.Models;

public class MobilePhone
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public bool SmsPermission { get; set; }
    public bool CallPermission { get; set; }
    // Foreign key
    public int CustomerId { get; set; }

    // Navigation property
    public Customer Customer { get; set; }
}
