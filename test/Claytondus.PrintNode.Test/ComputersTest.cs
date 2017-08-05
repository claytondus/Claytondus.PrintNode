using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;
using Xunit;

namespace Claytondus.PrintNode.Test
{
    public class ComputersTest
    {
        private readonly PrintNodeClient _client;

        public ComputersTest()
        {
            _client = new PrintNodeClient(Configuration.GetSetting("apiKey"));
        }

 
        [Fact]
        public async Task GetComputersTest()
        {
            var computers = await _client.GetComputersAsync();
            Assert.NotNull(computers);
        }

        [Fact]
        public async Task GetScalesTest()
        {
            var computers = await _client.GetScalesAsync(27642);
            Assert.NotNull(computers);
        }


    }
}
