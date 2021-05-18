using System.Threading.Tasks;
using Xunit;

namespace Claytondus.PrintNode.Test
{
    public class PrintersTest
    {
        private readonly PrintNodeClient _client;

        public PrintersTest()
        {
            _client = new PrintNodeClient(Configuration.GetSetting("apiKey"));
        }

 
        [Fact]
        public async Task GetPrintersTest()
        {
            var jobs = await _client.GetPrintersAsync();
            Assert.NotNull(jobs);
        }


    }
}
