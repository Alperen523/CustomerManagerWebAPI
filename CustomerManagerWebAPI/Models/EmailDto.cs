using System.ComponentModel.DataAnnotations;

namespace CustomerManagerWebAPI.Models
{
    public class EmailDto
    {
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        public bool EmailPermission { get; set; }
        public int CustomerId { get; set; }
    }


}
