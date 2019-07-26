using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Student ID")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Student ID must be 9 digits.")]
        [Remote("IsValidStudentIdNum", "Validation", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessage = "Student ID is already in use.")]
        public string StudentIdNum { get; set; }
                
        [Display(Name = "Phone Number")]
        [Remote("IsValidPhoneNumber", "Validation", HttpMethod ="POST", ErrorMessage = "Must be a valid 10-digit US phone number.")]
        public string PhoneNum { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
