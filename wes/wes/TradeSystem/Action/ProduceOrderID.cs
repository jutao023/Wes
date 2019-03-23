using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{



    class ProduceOrderID
    {

        private static char[] constant =
        {
            '0','1','2','3','4','5','6','7','8','9'
                ,
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'
                ,
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };

        static Random random = new Random();
        static string currentTime = DateTime.Now.AddSeconds(-10).ToString("yyyyMMddHHmmss");
        static int requestCount = 1;
        static int tmp = 1;
        static char at = 'a';

        private const string BUY_HEAD  = "11"; //表示购买
        private const string SELL_HEAD = "12"; //表示转让

        private static string GetSysTime()
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            if(currentTime == time)
            {
                requestCount = requestCount + tmp;
            }
            else
            {
                currentTime = time;
                requestCount = random.Next(0, 500);
                tmp = random.Next(1, 10);
                at = constant[random.Next(0, constant.Length)];
            }
            return time;
        }

        public static string GetOrderID(EnumBuySellType iDType)
        {
            string time = GetSysTime();

            string orderId = "";
            if(iDType == EnumBuySellType.购买)
            {
                orderId = BUY_HEAD + time;
            }
            else
            {
                orderId = SELL_HEAD + time;
            }

            string q = requestCount.ToString();
            string insert = "";
            if(q.Length < 3)
            {
                if (q.Length == 1)
                    insert = "00";
                else
                    insert = "0";
            }
            orderId = orderId + at + insert + q;
            return orderId;
        }
    }
}
