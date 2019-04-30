using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bar
{
    public class MonthCreate
    {
        public int startYear { get; set; }
        public int endYear { get; set; }

        public int startMonth { get; set; }
        public int endMonth { get; set; }

        public int startDay { get; set; }
        public int endDay { get; set; }

        int[] mintick = new int[] { 1, 1, 1, 2, 2, 3 };
        public List<MonthKLine> CreateMonthLine_12(int _year, double _endPrice, double _rate, double _minPrice)
        {
            double ed = _endPrice;
            double st = _endPrice - _endPrice * _rate;
            double max = Math.Round((ed - st) * 0.33, 4);
            double min = Math.Round((ed - st) * 0.1, 4);
            List<MonthKLine> virList = new List<MonthKLine>();
            double openPrice = Math.Round(st, 4);

            int fall = (int)(0.35 * 12);
            for(int i = 1; i <= 12; i++)
            {
                MonthKLine vk = new MonthKLine();
                vk.open = openPrice;
                vk.year = _year;
                vk.month = i;
                vk.type = 获取是阳线还是阴线();
                if(vk.type == LineType.type_FALL)
                {
                    fall--;
                }
                if(fall <= 0)
                {
                    vk.type = LineType.type_RISE;
                }

                OCHL(min, max, ref vk);
                double ocr =  mintick[getRandom(0, mintick.Length)] * _minPrice;
                if(getRandom(0, 100) < 50)
                {
                    ocr = ocr * -1;
                }
                openPrice = ocr + vk.close;
                virList.Add(vk);
            }
            return virList;
        }

        public string 获取是阳线还是阴线()
        {
            int rand = getRandom(0, 100);
            
            if(rand > 30)
            {
              //  Console.WriteLine("    " + EnumLineType.阳线.ToString());
                return LineType.type_RISE;
            }
            else
            {
                //   Console.WriteLine(EnumLineType.阴线.ToString());
                return LineType.type_FALL;
            }
        }
        
        /// <returns>index 1 = close,2 = low , 3 = high</returns>
        public void OCHL(double minRang,double maxRang,ref MonthKLine vk)
        {
            int    int_rangmuti = 1000;
            double dub_rangmuti = 1000.0;

            int max = (int)(maxRang * int_rangmuti);
            int min = (int)(minRang * int_rangmuti);

            int value = min;
            if(min >=1 && max > min)
            {
                value = getRandom(min, max);
            }

            //获取一个随机数
            int rang = getRandom(0, 100);

            double final = value / dub_rangmuti;
            //满阴 满阳
            if (rang < 10)
            {
                if(vk.type == LineType.type_RISE)
                {
                    vk.close = vk.open + final;
                    vk.high = vk.close;
                    vk.low = vk.open;
                }else
                {
                    vk.close = vk.open - final;
                    vk.low = vk.close;
                    vk.high = vk.open;
                }
            }
            //阴阳适中
             else
            {
                int vtm = (int)(value * 0.35);
                double l = getRandom(0, vtm) / dub_rangmuti;
                double h = getRandom(0, vtm) / dub_rangmuti;

                if(vk.type == LineType.type_RISE)
                {
                    vk.close = vk.open + final - l - h;
                    vk.low = vk.open - l;
                    vk.high = vk.close + h;
                }
                else
                {
                    vk.close = vk.open -( final - (l + h));
                    vk.high = vk.open + h;
                    vk.low = vk.close - l;
                }
            }
        }

        int getRandom(int min, int max)
        {
            return MyRandom.getRandom(min, max);
        }
    }
}
