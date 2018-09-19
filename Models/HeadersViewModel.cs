using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeaderDisplay.Models
{
    public class HeadersViewModel
    {
        public Dictionary<string, string> Headers { get; set; }
        public HeadersViewModel()
        {
            Headers = new Dictionary<string, string>();
        }
    }
}