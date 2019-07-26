 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public enum DeviceStatus
    {
        Available = 0,
        Assigned = 1,
        Reserve = 2,
        //[Display(Name = "Checked Out")]
        //CheckedOut = 3,
        Maintenance = 3,
        Retired = 4
    }

    public class Device
    {
        public int Id { get; set; }

        [Display(Name = "RTC Barcode Number")]
        public int RTCNum { get; set; }

        // Reusable, short identifier for practical distinction
        [Display(Name = "Device Number")]
        [Remote(action:"IsDeviceNumAvailable", controller:"Validation", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessage = "Device number is already in use.")]
        [Range(1, int.MaxValue)]
        public int? DeviceNum { get; set; }

        // Default to Available?
        public DeviceStatus Status { get; set; }

        [StringLength(40)]
        [Required]
        public string Make { get; set; }

        [StringLength(40)]
        [Required]
        public string Model { get; set; }

        [StringLength(40)]
        [Required]
        public string ModelNum { get; set; }

        // TODO: add image url

        [Display(Name = "Serial Number")]
        [StringLength(100)]
        [Required]
        [Remote(action: "IsSerialNumAvailable", controller: "Validation", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessage = "A device already has that serial number.")]
        public string SerialNum { get; set; }

        [Display(Name = "Operating System")]
        [StringLength(40)]
        [Required]
        public string OperatingSystem { get; set; }
        
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Retired")]
        public DateTime? DateRetired { get; set; }

        // 
        // public ICollection<DeviceLog> DeviceLogs { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
