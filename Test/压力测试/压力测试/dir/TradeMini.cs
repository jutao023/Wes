using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class TradeItem
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// 成交价
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal? amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? turnover { get; set; }

        /// <summary>
        /// 手续费 
        /// </summary>
        public decimal? fee { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }
    }
}
