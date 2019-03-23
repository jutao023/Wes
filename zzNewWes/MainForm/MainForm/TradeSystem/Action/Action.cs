using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class Action
    {

        /// <summary>
        /// 把json 格式行情转对象
        /// </summary>
        /// <param name="_lastPrice"> 行情Json 串</param>
        /// <returns></returns>
        public static LastPrice JsonToLastPrice(string _lastPrice)
        {
            try
            {
                string json = _lastPrice;
                LastPrice lp = JsonConvert.DeserializeObject<LastPrice>(json);
                if (lp != null)
                {
                    return lp;
                }
                return null;
            }catch
            {
                return null;
            }
        }


        /// <summary>
        /// 把 json 格式的盘口深度转成对象
        /// </summary>
        /// <param name="_quoteDepth">盘口Json 串</param>
        /// <returns></returns>
        public static QuoteDepth JsonToQuoteDepth(string _quoteDepth)
        {
            try
            {
                string json = _quoteDepth;
                QuoteDepth qd = JsonConvert.DeserializeObject<QuoteDepth>(json);
                if(qd != null)
                {
                    return qd;
                }
                return null;
            }catch
            {
                return null;
            }
        }

    }
}
