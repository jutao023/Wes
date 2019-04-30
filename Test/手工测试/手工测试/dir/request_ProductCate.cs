using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class request_ProductCate
    {
        /// <summary>
        ///  产品分类名称
        /// </summary>
        public string cateName { get; set; }

        /// <summary>
        /// 产品分类ID集合 
        /// </summary>
        public int[] productCateIds { get; set; }

        /// <summary>
        /// 产品分类状态 0-可用1-禁用
        /// </summary>
        public string status { get; set; }
        public const string status_ENABLE   = "0";  //可用
        public const string status_UNENABLE = "1";  //禁用
    }
}
