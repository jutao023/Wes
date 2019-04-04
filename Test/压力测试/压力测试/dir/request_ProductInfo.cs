using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class request_ProductInfo
    {
        /// <summary>
        ///  每页数量
        /// </summary>
        public int limit { get; set; }

        /// <summary>
        /// 热门标识 0-是 1-否
        /// </summary>
        public string orHot { get; set; }
        public const string orHot_YES = "0";   // 是
        public const string orHot_NO  = "1";   // 否

        /// <summary>
        /// 订购状态 0-可用1-禁用
        /// </summary>
        public string orderStatus { get; set; }
        public const string orderStatus_ENABLE   = "0";    //可用
        public const string orderStatus_UNENABLE = "1";    //禁用

        /// <summary>
        /// 机构ID集合
        /// </summary>
        public int[] organizationIds { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string proName { get; set; }

        /// <summary>
        /// 产品编码集合
        /// </summary>
        public int[] proNums { get; set; }

        /// <summary>
        /// 分类ID集合
        /// </summary>
        public int[] productCates { get; set; }

        /// <summary>
        /// 产品ID集合 
        /// </summary>
        public int[] productIds { get; set; }

        /// <summary>
        ///  产品状态 0-可用 1-禁用
        /// </summary>
        public string status { get; set; }
        public const string status_ENABLE   = "0";  //可用
        public const string status_UNENABLE = "1";  //禁用

    }
}
