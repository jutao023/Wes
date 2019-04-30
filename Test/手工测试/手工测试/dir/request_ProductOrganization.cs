using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class request_ProductOrganization
    {
        /// <summary>
        /// 机构名称 
        /// </summary>
        public string organizationName { get; set; }

        /// <summary>
        /// id集合
        /// </summary>
        public int[] productOrganizationIds { get; set; }

        /// <summary>
        /// 机构状态 0-可用 1-禁用
        /// </summary>
        public string status { get; set; }
        public const string status_ENABLE   = "0";  //可用
        public const string status_UNENABLE = "1";  //禁用
    }
}
