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
        Reserved = 1,
        [Display(Name = "Checked Out")]
        CheckedOut = 2,
        Maintenance = 3,
        Retired = 4
    }

    public class Device
    {
        public int Id { get; set; }

        // Barcode identifier
        [Display(Name = "RTC Barcode Number")]
        public int RTCNum { get; set; }

        // Reusable, short identifier for practical distinction between devices
        [Display(Name = "Device Number")]
        [Remote(action:"IsDeviceNumAvailable", controller:"Validation", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessage = "Device number is already in use.")]
        [Range(1, int.MaxValue)]
        public int? DeviceNum { get; set; }

        // Default to Available?
        public DeviceStatus Status { get; set; }

        // e.g. Dell, HP, Toshiba...
        [StringLength(40)]
        [Required]
        public string Make { get; set; }

        // e.g. Inspiron, EliteBook, Presario, Pavilion...
        [StringLength(40)]
        [Required]
        public string Model { get; set; }

        // e.g. 450, D71ST, 9480m, x360 Convertible...
        [StringLength(40)]
        [Required]
        public string ModelNum { get; set; }

        // TODO: add image url

        // unique serial number
        [Display(Name = "Serial Number")]
        [StringLength(100)]
        [Required]
        [Remote(action: "IsSerialNumAvailable", controller: "Validation", AdditionalFields = nameof(Id), HttpMethod = "POST", ErrorMessage = "A device already has that serial number.")]
        public string SerialNum { get; set; }

        // e.g. Windows 10 Professional...
        [Display(Name = "Operating System")]
        [StringLength(40)]
        [Required]
        public string OperatingSystem { get; set; }
        
        // creation timestamp
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }
        // starts out null
        [Display(Name = "Date Retired")]
        public DateTime? DateRetired { get; set; }        
    }
}
