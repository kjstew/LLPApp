using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public class DeviceModelCreateViewModel
    {
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
        [DataType(DataType.Upload)]
        //[FileExtensions(Extensions = "jpg,png,gif,jpeg,bmp")]
        public IFormFile Image { get; set; }
    }
}
