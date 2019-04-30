using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    class DesMinuteLine
    {
        public string symbol { get; set; }
        
        public string openPrice { get; set; }

        public string highestPrice { get; set; }

        public string lowestPrice { get; set; }

        public string closePrice { get; set; }

        public string time { get; set; }

        public string count { get; set; }

        public string volume { get; set; }

        public string turnover { get; set; }

        public string period { get; set; } //1day 1min 30min 1min 1week 1month
    }
}
