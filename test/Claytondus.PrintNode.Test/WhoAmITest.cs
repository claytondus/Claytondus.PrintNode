using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Claytondus.PrintNode.Models;
using Xunit;

namespace Claytondus.PrintNode.Test
{
    public class WhoAmITest
    {
        private readonly PrintNodeClient _client;

        public WhoAmITest()
        {
            _client = new PrintNodeClient(Configuration.GetSetting("apiKey"));
        }

        [Fact]
        public async Task WhoAmIExists()
        {
            var whoami = await _client.GetWhoAmIAsync();
            Assert.NotNull(whoami);
        }
    }
}
