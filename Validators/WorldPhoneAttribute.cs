using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PhoneNumbers;

namespace LLPApp.Validators
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Parameter | System.AttributeTargets.Property, AllowMultiple = false)]
    public sealed class WorldPhoneAttribute : ValidationAttribute
    {
        public WorldPhoneAttribute() { }

        public override bool IsValid(object value)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber testnum = phoneNumberUtil.Parse(value.ToString(), "US");
                return phoneNumberUtil.IsValidNumber(testnum);
            }
            catch (NumberParseException)
            {
                return false;
            }
        }
    }
}
