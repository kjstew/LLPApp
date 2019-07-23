using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LLPApp.Data;
using Microsoft.AspNetCore.Mvc;
using PhoneNumbers;

namespace LLPApp.Controllers
{
    //[ApiController]
    public class ValidationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValidationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult IsDeviceNumAvailable(int? deviceNum, int? id)
            {
            // DeviceNum set to null (unassigned)
            if (deviceNum == null)
                return Json(true);
            // editing/creating device, DeviceNum not found in existing devices
            else if (!_context.Devices.Any(d => d.DeviceNum == deviceNum))
                return Json(true);
            // editing device, unchanged DeviceNum
            else if (id != null && _context.Devices.Find(id).DeviceNum == deviceNum)
                return Json(true); 
            // if none pass, not valid DeviceNum
            else
                return Json(false);
        }

        [HttpPost]
        public JsonResult IsSerialNumAvailable(string serialNum, int id)
        {
            // if no matches OR match but is same device
            if (!_context.Devices.Any(d => d.SerialNum == serialNum) || _context.Devices.Find(id).SerialNum == serialNum)
                return Json(true);
            else
                return Json(false);
        }

        [HttpPost]
        public JsonResult IsValidPhoneNumber(string phoneNum)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber parsedNum = phoneNumberUtil.Parse(phoneNum, "US");
                if (phoneNumberUtil.IsValidNumber(parsedNum))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (NumberParseException)
            {
                return Json(false);
            }
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}