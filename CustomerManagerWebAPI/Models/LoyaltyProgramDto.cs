using CustomerManagerWebApiByAlp.Models;
using System;

namespace CustomerManagerWebApiByAlp.Models
{
    public class LoyaltyProgramDto
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public string Benefits { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; } 
    }
}
