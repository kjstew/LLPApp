using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LLPApp.Data;
using LLPApp.Models;

namespace LLPApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<DashboardViewModel> dashboardList = new List<DashboardViewModel>();

            var leftouterjoin = (from loan in _context.Loans
                                 join dvc in _context.Devices on loan.Device.Id equals dvc.Id into ld
                                 from ldnew in ld.DefaultIfEmpty()
                                 select new
                                 {
                                     LoanId = loan.Id,
                                     DeviceId = ldnew == null ? 0 : ldnew.Id
                                 }).ToList();
            var rightouterjoin = (from dvc in _context.Devices
                                 join loan in _context.Loans on dvc.Id equals loan.Device.Id into ld
                                 from ldnew in ld.DefaultIfEmpty()
                                 select new
                                 {
                                     LoanId = ldnew == null ? 0 : ldnew.Id,
                                     DeviceId = dvc.Id,
                                 }).ToList();
            var fullouterjoin = leftouterjoin.Concat(rightouterjoin);

            var datalist = (from loan in _context.Loans
                            join dvc in _context.Devices on loan.Device.Id equals dvc.Id
                            join std in _context.Students on loan.Student.Id equals std.Id
                            select new {    
                                loan.StartDate,
                                loan.EndDate,
                                dvc.DeviceNum,
                                dvc.RTCNum,
                                dvc.Status,
                                dvc.SerialNum,
                                dvc.OperatingSystem,
                                std.FName,
                                std.LName,
                                std.StudentIdNum,
                                std.PhoneNum,
                                std.Email
                            }).ToList();

            foreach (var item in datalist)
            {
                DashboardViewModel dvm = new DashboardViewModel();
                dvm.StartDate = item.StartDate;
                dvm.EndDate = item.EndDate;
                dvm.DeviceNum = item.DeviceNum != null ? item.DeviceNum.ToString() : "Unassigned";
                dvm.RTCNum = item.RTCNum;
                dvm.DeviceStatus = item.Status;
                //dvm.DeviceMakeModelNum = $"{item.Make} + {item.Model} + {item.ModelNum}";
                dvm.DeviceSerialNum = item.SerialNum;
                dvm.DeviceOS = item.OperatingSystem;
                dvm.StudentName = $"{item.FName} {item.LName}";
                dvm.StudentIdNum = item.StudentIdNum;
                dvm.PhoneNum = item.PhoneNum;
                dvm.Email = item.Email;
                dashboardList.Add(dvm);
            }
            
            return View(dashboardList);
        }
    }
}