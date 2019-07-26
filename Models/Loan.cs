using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public enum LoanStatus
    {
        Applicant = 0,
        Rejected = 1,
        Approved = 2
    }
    public class Loan
    {
        public int Id { get; set; }

        [Required]
        public Student Student { get; set; }

        // nullable, but must be assigned if today's date is betw. start/end date
        public Device Device { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // active state of loan from checking today's date against start/end or against device's status?
    }
}
