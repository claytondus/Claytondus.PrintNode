using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.PrintNode.Models
{
    public class PrintJob
    {
        public int id { get; set; }
        public Printer printer { get; set; }
        public int printerId { get; set; }
        public string title { get; set; }
        public string contentType { get; set; }
        public string content { get; set; }
        public string source { get; set; }
        public PrintJobOptions options { get; set; }
        public int expireAfter { get; set; }
        public int qty { get; set; }
        public Authentication authentication { get; set; }
        public string state { get; set; }
        public DateTime? createTimestamp { get; set; }
    }

    public class Authentication
    {
        public string type { get; set; }
        public Credentials credentials { get; set; }
    }

    public class Credentials
    {
        public string user { get; set; }
        public string pass { get; set; }
    }

    public class PrintJobOptions
    {
        public string bin { get; set; }
        public bool collate { get; set; }
        public int copies { get; set; }
        public string dpi { get; set; }
        public string duplex { get; set; }
        public bool fit_to_page { get; set; }
        public string media { get; set; }
        public int nup { get; set; }
        public string pages { get; set; }
        public string paper { get; set; }
        public int rotate { get; set; }
    }

    public class PrintJobState
    {
        public int printJobId { get; set; }
        public string state { get; set; }
        public string message { get; set; }
        public string data { get; set; }
        public DateTime createTimestamp { get; set; }
        public int age { get; set; }
    }
}
