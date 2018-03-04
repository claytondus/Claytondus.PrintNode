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
        public async Task PrintJobBase64CreateTest()
        {
            var job = new PrintJob
            {
                printerId = 274556,
                title = $"Test {DateTime.Now}",
                contentType = "raw_base64",
                content = Convert.ToBase64String(Encoding.ASCII.GetBytes(File.ReadAllText("test.zpl"))),
                source = "test"
            };
            var created = await _client.CreatePrintJobAsync(job);
            Assert.NotNull(created);
        }

        [Fact]
        public async Task PrintJobUriZplCreateTest()
        {
            var job = new PrintJob
            {
                printerId = 274556,
                title = $"Test {DateTime.Now}",
                contentType = "raw_uri",
                content = "https://easypost-files.s3-us-west-2.amazonaws.com/files/postage_label/20170807/0a4c06b8b97c4edbb6fa37126cf414cf.zpl",
                source = "test"
            };
            var created = await _client.CreatePrintJobAsync(job);
            Assert.True(created > 0);
        }

        [Fact]
        public async Task PrintJobUriEpl2CreateTest()
        {
            var job = new PrintJob
            {
                printerId = 67163,
                title = $"Test {DateTime.Now}",
                contentType = "raw_uri",
                content = "https://easypost-files.s3-us-west-2.amazonaws.com/files/postage_label/20170807/05bf2acc50b544f38df5ab1cb232513d.epl2",
                source = "test"
            };
            var created = await _client.CreatePrintJobAsync(job);
            Assert.True(created > 0);
        }

        [Fact]
        public async Task PrintJobEnvelopeTest()
        {
            var job = new PrintJob
            {
                printerId = 67164,
                title = $"Test {DateTime.Now}",
                contentType = "raw_uri",
                content = "https://easypost-files.s3-us-west-2.amazonaws.com/files/postage_label/20170807/32ac6e77127045e1a70e8d217ddfe44e.png",
                source = "test"
            };
            var created = await _client.CreatePrintJobAsync(job);
            Assert.True(created > 0);
        }

        [Fact]
        public async Task PrintJobViewTest()
        {
            var jobs = await _client.GetPrintJobsAsync();
            Assert.NotNull(jobs);
        }


    }
}
