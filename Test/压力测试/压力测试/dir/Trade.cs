using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    /// <summary>
    /// 查询具体的某个订单的信息
    /// </summary>
    class Trade
    {
        /// <summary>
        /// 成交数量
        /// </summary>
        public decimal? amount { get; set; }

        /// <summary>
        /// 买单ID,卖出单关联的买入单ID 
        /// </summary>
        public string buyOrderId { get; set; }

        /// <summary>
        /// 买入价,卖出单原来的买入价
        /// </summary>
        public decimal? buyPrice { get; set; }

        /// <summary>
        /// 成交时间,Long型时间戳
        /// </summary>
        public long? createTime { get; set; }

        /// <summary>
        /// 订单日期 格式yyyyMMdd
        /// </summary>
        public string createTimeStr { get; set; }

        /// <summary>
        /// 订单方向,0-买1-卖
        /// </summary>
        public int? direction { get; set; }

        /// <summary>
        /// 手续费 
        /// </summary>
        public decimal? fee { get; set; }

        /// <summary>
        /// 主键ID
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 用户身份标识 0-用户1-做市商
        /// </summary>
        public int? memberFlag { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long? memberId { get; set; }

        /// <summary>
        /// //订单类型订单类型 
        /// MERCHANT_GIVING商家赠送 
        /// PANIC_BUYING 抢购, 
        /// EXCHANGE 兑换 
        /// TRADE交易订单
        /// </summary>
        public string orderCate { get; set; }

        /// <summary>
        /// 订单ID
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// 成交单价
        /// </summary>
        public decimal? price { get; set; }

        /// <summary>
        /// 产品名称 
        /// </summary>
        public string proName { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string productCode { get; set; }

        /// <summary>
        /// 关联订单ID,买入单且已经卖出时有值
        /// </summary>
        public string relatedOrderId { get; set; }

    }
}
