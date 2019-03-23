using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{

    class request_OrderLimit
    {
        /// <summary>
        /// 数量
        /// </summary>
        public string amount { get; set; }

        /// <summary>
        /// "ROBOT"
        /// CUSTUMER用户 
        /// ROBOT做市商
        /// </summary>
        public string orderMemberType { get; set; }
        public const string orderMemberType_ROBOT = "ROBOT";

        /// <summary>
        /// 基准编码 cny
        /// </summary>
        public string baseSymbol { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string coinSymbol { get; set; }

        /// <summary>
        /// 订单方向 
        /// BUY-买 SELL-卖 = ['BUY', 'SELL']
        /// </summary>
        public string direction { get; set; }
        public const string direction_BUY = "BUY";  //买入
        public const string direction_SELL = "SELL"; //卖出

        /// <summary>
        /// 用户ID
        /// </summary>
        public long memberId { get; set; }

        /// <summary>
        /// //订单类型订单类型 
        /// MERCHANT_GIVING商家赠送 
        /// PANIC_BUYING 抢购, 
        /// EXCHANGE 兑换 
        /// TRADE交易订单
        /// </summary>
        public string orderCate { get; set; }
        public const string orderCate_TRADE = "TRADE";

        /// <summary>
        /// 订单ID
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// 价格 做市商必传, 用户不传
        /// </summary>
        public string price { get; set; }

        /// <summary>
        /// 产品交易对
        /// </summary>
        public string symbol { get; set; }

        /// <summary>
        /// 类型 
        /// MARKET_PRICE-市价
        /// LIMIT_PRICE-限价
        /// </summary>
        public string type { get; set; }
        public const string type_MARKET = "MARKET_PRICE";
        public const string type_LIMIT = "LIMIT_PRICE";
    }
}
