using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;
using Xunit;

namespace Claytondus.PrintNode.Test
{
    public class PrintJobsTest
    {
        private readonly PrintNodeClient _client;

        public PrintJobsTest()
        {
            _client = new PrintNodeClient(Configuration.GetSetting("apiKey"));
        }

        [Fact]
        public async Task PrintJobCreateTest()
        {
            var job = new PrintJob
            {
                printerId = 67163,
                title = $"Test {DateTime.Now}",
                contentType = "raw_base64",
                content = Convert.ToBase64String(Encoding.ASCII.GetBytes(File.ReadAllText("test.zpl"))),
                source = "test"
            };
            var created = await _client.CreatePrintJobAsync(job);
            Assert.NotNull(created);
        }

        [Fact]
        public async Task PrintJobViewTest()
        {
            var jobs = await _client.GetPrintJobsAsync();
            Assert.NotNull(jobs);
        }


    }
}
