using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//using LLPApp.Validators;
//using PhoneNumbers;

namespace LLPApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // TODO enforce uniqueness?? Repeat loaner??
        [Display(Name = "Student ID")]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Student ID must be 9 digits.")]
        public string StudentId { get; set; }

        
        [Display(Name = "Phone Number")]
        [Remote(action:"IsValidPhoneNumber", controller:"Validation", HttpMethod ="POST", ErrorMessage = "Must be a valid 10-digit US phone number.")]
        public string PhoneNum { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var phoneNumberUtil = PhoneNumberUtil.GetInstance();
        //    try
        //    {
        //        PhoneNumber testnum = phoneNumberUtil.Parse(PhoneNum, "US");
        //        yield return new ValidationResult(phoneNumberUtil.IsValidNumber(testnum);
        //    }
        //    catch (NumberParseException)
        //    {
        //        return false;
        //    }
        //}
    }
}
