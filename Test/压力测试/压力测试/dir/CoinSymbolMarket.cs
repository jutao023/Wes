using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    /// <summary>
    /// 品种当日 最高价，最低价
    /// </summary>
    class CoinSymbolMarket
    {
        /// <summary>
        /// T日开盘价
        /// </summary>
        public decimal? beginPrice { get; set; }

        /// <summary>
        /// T日涨停价
        /// </summary>
        public decimal? maxPrice { get; set; }

        /// <summary>
        /// T日跌停价
        /// </summary>
        public decimal? minPrice { get; set; }

        /// <summary>
        /// 查询时间
        /// </summary>
        public string dateTime { get; set; }

        /// 产品编码
        /// </summary>
        public string productCode { get; set; }
    }
}
