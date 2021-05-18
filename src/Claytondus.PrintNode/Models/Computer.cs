using System;

namespace Claytondus.PrintNode.Models
{
    public class Computer
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? inet { get; set; }
        public string? inet6 { get; set; }
        public string? hostname { get; set; }
        public string? version { get; set; }
        public string? jre { get; set; }
        public DateTime? createTimestamp { get; set; }
        public string? state { get; set; }
    }
}
