using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    /// <summary>
    /// 用户持仓信息
    /// </summary>
    class Position
    {
        
        /// <summary>
        /// 均价
        /// </summary>
        public decimal? averagePrice { get; set; }

        /// <summary>
        /// 可用数量
        /// </summary>
        public decimal? balance { get; set; }

        /// <summary>
        /// 冻结数量
        /// </summary>
        public decimal? frozenBalance { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public long? id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long? memberId { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string prodSymbol{ get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string prodName { get; set; }

        /// <summary>
        /// 转让价
        /// </summary>
        public decimal? sellPrice { get; set; }

        /// <summary>
        /// 待释放数量
        /// </summary>
        public decimal? toReleased { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { get; set; }
    }
}
