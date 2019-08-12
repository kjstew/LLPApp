using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public enum DeviceLogType
    {
        Activated = 0,
        Retired = 1,
        SoftwareUpdate = 2,
        ReturnInspection = 3
    }

    public class DeviceLog
    {
        // logs may be recorded between loans or during a loan. Views should be capable of
        // displaying relevant information if the log was recorded during a loan.

        public int Id { get; set; }
        public Device Device { get; set; }
        public DateTime Timestamp { get; set; }
        public DeviceLogType DeviceLogType { get; set; }
        public string Notes { get; set; }
    }
}
