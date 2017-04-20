using System;
using System.Collections.Generic;
using System.Text;

namespace Claytondus.PrintNode.Models
{
    public class WhoAmI
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string canCreateSubAccounts { get; set; }
        public string creatorEmail { get; set; }
        public string creatorRef { get; set; }
        public List<string> childAccounts { get; set; }
        public string credits { get; set; }
        public string numComputers { get; set; }
        public int? totalPrints { get; set; }
        public List<string> versions { get; set; }
        public List<string> connected { get; set; }
        public List<string> Tags { get; set; }
        public string state { get; set; }
        public List<string> permissions { get; set; }
    }
}
