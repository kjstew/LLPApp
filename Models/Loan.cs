using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public Device Device { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
