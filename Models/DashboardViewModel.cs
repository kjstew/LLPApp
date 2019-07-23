using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public class DashboardViewModel
    {
        // Loan
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Device
        public string DeviceNum { get; set; }
        public int RTCNum { get; set; }
        public DeviceStatus DeviceStatus { get; set; }
        public string DeviceMakeModelNum { get; set; }
        public string DeviceSerialNum { get; set; }
        public string DeviceOS { get; set; }
        public DateTime DeviceDateAdded { get; set; }
        public DateTime? DeviceDateRetired { get; set; }

        // Student
        public string StudentName { get; set; }
        public string StudentIdNum { get; set; }
        public string PhoneNum { get; set; }
        public string EmailAddress { get; set; }
    }
}
