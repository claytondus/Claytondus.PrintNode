using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.PrintNode.Models
{
    public class Scale
    {
        public Tuple<int, int> mass { get; set; }
        public int computerId { get; set; }
        public string vendor { get; set; }
        public string product { get; set; }
        public int vendorId { get; set; }
        public int deviceId { get; set; }
        public string port { get; set; }
        public string deviceName { get; set; }
        public int deviceNum { get; set; }
        public int count { get; set; }
        public dynamic measurement { get; set; }
        public DateTime clientReportedCreateTimestamp { get; set; }
        public int ntpOffset { get; set; }
        public int ageOfData { get; set; }
    }


}
