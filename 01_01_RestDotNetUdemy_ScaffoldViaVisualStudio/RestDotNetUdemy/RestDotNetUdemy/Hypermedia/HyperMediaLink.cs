using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestDotNetUdemy.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; } = string.Empty;
        private string? href;
        public string Href { get; set; } = string.Empty;
        public string Type
        {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set
            {
                href = value;
            }
        }
        public string Action { get; set; } = string.Empty;

    }
}