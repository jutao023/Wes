using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    public class DayLine
    {
        public int month { get; set; }

        public int day { get; set; }

        public string type { get; set; }
        /// <summary>
        /// 阳线
        /// </summary>
        public const string type_RISE = "阳线";    //阳线
        /// <summary>
        /// 阴线
        /// </summary>
        public const string type_FALL = "阴线";    //阴线

        public double high { get; set; }

        public double low { get; set; }

        public double open { get; set; }

        public double close { get; set; }

    }
}
