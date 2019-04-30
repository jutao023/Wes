using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    class response_LastLine
    {        
        /// <summary>
        /// 响应码
        /// </summary>
        public int? code { get; set; }

        /// <summary>
        /// 响应数据
        /// </summary>
        public List<DesMinuteLine> data { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 总数量
        /// </summary>
        public string totalElement { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public string totalPage { get; set; }

    }
}
