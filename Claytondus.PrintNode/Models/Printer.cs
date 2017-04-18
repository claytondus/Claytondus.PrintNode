using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Claytondus.PrintNode.Models
{
    public class Printer
    {
        public string id { get; set; }
        public Computer computer { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string capabilities { get; set; }

        [JsonProperty("default")]
        public string Default { get;set;}

        public DateTime? createTimestamp { get; set; }
        public string state { get; set; }
    }
}
