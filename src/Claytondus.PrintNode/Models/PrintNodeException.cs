using System;
using System.Net;
using Newtonsoft.Json;

namespace Claytondus.PrintNode.Models
{
    public class PrintNodeException : Exception
    {
        [JsonConstructor]
        public PrintNodeException(string type, string message) : base(message)
		{
            PrintNodeType = type;
            ResponseBody = message;
        }

        public string PrintNodeType { get; set; }
        public string? RequestBody { get; set; }
        public string ResponseBody { get; set; }

        public HttpStatusCode? HttpStatus { get; set; }

        public string? Method { get; set; }
        public string? Resource { get; set; }
        public string? HttpMessage { get; set; }



    }
}
