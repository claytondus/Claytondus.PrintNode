using System.IO;
using Newtonsoft.Json;

namespace Claytondus.PrintNode.Test
{
    public class Configuration
    {
        private static readonly dynamic _config;

        static Configuration()
        {
            using (var reader = File.OpenText("appsettings.json"))
            {
                _config = JsonConvert.DeserializeObject(reader.ReadToEnd());
            }
        }

        public static string GetSetting(string name)
        {
            return _config[name];
        }
    }
}
