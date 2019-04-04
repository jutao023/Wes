using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class ProductCateRelation
    {

        public string cateId { get; set; }         // (string, optional): 分类ID ,
        public string cateName { get; set; }       // (string, optional): 分类名称 ,
        public string convertTime { get; set; }    // (string, optional): 兑换结束时间 ,
        public string createTime { get; set; }     // (string, optional): 创建时间 ,
        public string createUser { get; set; }     // (string, optional): 创建人 ,
        public double downRate { get; set; }       // (number, optional): 跌停比例 ,
        public double guidePrice { get; set; }     // (number, optional): 指导价 ,
        public long id { get; set; }               // (integer, optional): 主键ID ,
        public int initAmount { get; set; }        // (integer, optional): 初始发售数量 ,
        public double initPrice { get; set; }      // (number, optional): 开盘价 ,
        public long marketMaker { get; set; }      // (integer, optional): 做市商ID ,
        public string orHot { get; set; }          // (string, optional): 热门标识 0-是 1-否 ,
        public string orderStatus { get; set; }    // (string, optional): 是否禁用订购 0-否1-是 ,
        public string organId { get; set; }        // (string, optional): 机构ID ,
        public string organName { get; set; }      // (string, optional): 机构名称 ,
        public string pic { get; set; }            // (string, optional): 图片URL ,
        public string proDesc { get; set; }        // (string, optional): 产品描述 ,
        public string proName { get; set; }        // (string, optional): 产品名称 ,
        public string proNum { get; set; }         // (string, optional): 产品编号 ,
        public string remark { get; set; }         // (string, optional): 备注 ,
        public string rushEnd { get; set; }        // (string, optional): 抢购结束时间 ,
        public double rushPrice { get; set; }      // (number, optional): 抢购价 ,
        public string rushTime { get; set; }       // (string, optional): 抢购开始时间 ,
        public string sorts { get; set; }          // (string, optional): 排序 ,
        public string status { get; set; }         // (string, optional): 状态 0-上架1-下架 ,
        public double transferRate { get; set; }   // (number, optional): 转让手续费比例 ,
        public string transferTime { get; set; }   // (string, optional): 交易结束时间 ,
        public double upRate { get; set; }         // (number, optional): 涨停比例 ,
        public string updateTime { get; set; }     // (string, optional): 修改时间 ,
        public string updateUser { get; set; }     // (string, optional): 修改人
    }
}
