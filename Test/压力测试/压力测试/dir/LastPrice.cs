using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class LastPrice
    {

        public decimal? amount { get; set; }

        public string buyOrderId { get; set; }

        public decimal? buyTurnover { get; set; }

        public string direction { get; set; }

        public decimal? price { get; set; }

        public string sellOrderId { get; set; }

        public decimal? sellTurnover { get; set; }

        public string symbol { get; set; }

        public long? time { get; set; }
    }
}
