using CustomerManagerWebApiByAlp.Models;
using System.ComponentModel.DataAnnotations;

public class Email
{
    public int Id { get; set; }
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }
    public bool EmailPermission { get; set; }

    // Foreign key
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
}
