using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class ProductCate
    {
        /// <summary>
        /// 分类描述
        /// </summary>
        public string cateDesc { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string cateName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string createUser { get; set; }

        /// <summary>
        /// 主键
        /// </summary>
        public long id { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public string sorts { get; set; }

        /// <summary>
        /// 分类状态 0-可用1-禁用 
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public string updateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public string updateUser { get; set; }
    }
}
