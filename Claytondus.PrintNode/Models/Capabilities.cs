using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.PrintNode.Models
{
    public class Capabilities
    {
        public List<string> bins { get; set; }
        public bool collate { get; set; }
        public int copies { get; set; }
        public bool color { get; set; }
        public string dpis { get; set; }
        public bool duplex { get; set; }
        public List<Tuple<int, int>> extent { get; set; }
        public List<string> medias { get; set; }
        public List<int> nup { get; set; }
        public Dictionary<string, Tuple<int, int>> papers { get; set; }
        public PrintRate printrate { get; set; }
        public bool supports_custom_paper_size { get; set; }
    }

    public class PrintRate
    {
        public string unit { get; set; }
        public int rate { get; set; }
    }
}
