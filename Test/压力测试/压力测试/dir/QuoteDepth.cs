using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class QuoteDepth
    {
        /// <summary>
        /// 盘口深度中报价数量最小是多少。
        /// </summary>
        public decimal? minAmount { get; set; }

        /// <summary>
        /// 盘口中最高报价
        /// </summary>
        public decimal? highestPrice { get; set; }

        /// <summary>
        /// 盘口中最低报价
        /// </summary>
        public decimal? lowestPrice { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string symbol { get; set; }

        /// <summary>
        /// 盘口深度中报价数量最大是多少。
        /// </summary>
        public decimal maxAmount { get; set; }

        /// <summary>
        /// 盘口深度中的每一项
        /// </summary>
        public List<QuoteItem> items { get; set; }

        /// <summary>
        /// 盘口方向
        /// </summary>
        public string direction { get; set; }
    }
}
