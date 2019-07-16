using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLPApp.Models
{
    public class DeviceLog
    {
        public int Id { get; set; }
        public Device Device { get; set; }
        public DateTime Timestamp { get; set; }
        // log type?
        public string Notes { get; set; }
    }
}
