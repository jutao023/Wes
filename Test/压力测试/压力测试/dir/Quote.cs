using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class Quote
    {

        /// <summary>
        /// 卖盘
        /// </summary>
        public QuoteDepth ask { get; set; }

        /// <summary>
        /// 买盘
        /// </summary>
        public QuoteDepth bid { get; set; }
    }
}
