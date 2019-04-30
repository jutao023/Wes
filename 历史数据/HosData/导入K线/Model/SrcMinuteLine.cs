using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    class SrcMinuteLine
    {
        public int year { get; set; }

        public int month { get; set; }

        public int day { get; set; }

        public int hour { get; set; }

        public int minute { get; set; }

        public string symbol { get; set; }

        public string type { get; set; }

        public double high { get; set; }

        public double low { get; set; }

        public double open { get; set; }

        public double close { get; set; }
    }
}
