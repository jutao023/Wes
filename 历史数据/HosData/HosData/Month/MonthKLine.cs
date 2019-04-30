﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    public class MonthKLine
    {
        public int beginDay { get; set; }

        public int endDay { get; set; }

        public int year { get; set; }

        public int month { get; set; }

        public string type { get; set; }

        public double high { get; set; }

        public double low { get; set; }

        public double open { get; set; }

        public double close { get; set; }
    }
}
