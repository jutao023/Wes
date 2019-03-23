using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class SYAttrbute : SYBase
    {
        #region 子类重写
        public override void OnInit()
        {
            base.OnInit();
        }
        public override void OnTimer()
        {
            base.OnTimer();
        }
        #endregion

        #region 下单

        #endregion

        /// <summary>
        /// 加载交易信息
        /// </summary>
        public sealed override void Load()
        {

        }

        private int more = 1;                   //开仓倍数

        private string coinSymbol = "XDFYX";    //产品编号

        CoinSymbolMarket coinSymbolMarket;      //当日交易允许的最高、最低价。


    }
}
