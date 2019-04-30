using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    /// <summary>
    /// 查询用户的订单在队列中的状态
    /// </summary>
    class Order
    {

        public long? id { get; set; }
        public string orderId { get; set; }
        public long? memberId { get; set; }
        public string orderMemberType { get; set; }
        public string orderCate { get; set; }
        public string type { get; set; }
        public decimal? amount { get; set; }
        public string symbol { get; set; }
        public decimal? tradedAmount { get; set; }
        public decimal? turnover { get; set; }
        public string coinSymbol { get; set; }
        public string baseSymbol { get; set; }
        public string status { get; set; }

        public string direction { get; set; }
        public const string direction_BUY  = "BUY";
        public const string direction_SELL = "SELL";

        public decimal? price { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long? time { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long? completedTime { get; set; }
        /// <summary>
        /// 时间戳
        /// </summary>
        public long? canceledTime { get; set; }
        public List<TradeItem> detail { get; set; }
        public bool? completed { get; set; }

    }
}
