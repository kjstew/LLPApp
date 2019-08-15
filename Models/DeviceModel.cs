using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public enum DeviceType
    {
        Laptop,
        Tablet
    }

    // this refers to the model of a device (i.e. HP Pavilion, Lenovo Thinkpad, etc.)
    public class DeviceModel
    {
        public int Id { get; set; }

        [Display(Name = "Device Type")]
        public DeviceType Type { get; set; }

        [StringLength(40)]
        [Required]
        public string Brand { get; set; }

        [Display(Name = "Model Name")]
        [StringLength(40)]
        [Required]
        public string ModelName { get; set; }

        [Display(Name = "Model Number")]
        [StringLength(40)]
        public string ModelNum { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        public List<Device> Devices { get; set; }
    }
}
