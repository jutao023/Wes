using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    public class MinuteCreate
    {

        int[] mintick = new int[] { 0, 1, 1, 1, 2, 2, 3 };
        public List<MinuteLine> CreateMinuteLines(string _sym,DayLine ldl, double _minPrice)
        {
            int beginMinute = 0;
            int endMinute   = 1439;
   
            double ed = ldl.close;
            double st = ldl.open;
            double max = Math.Round((ed - st) * 0.055, 2);
            double min = Math.Round((ed - st) * 0.015, 2);
            List<MinuteLine> virList = new List<MinuteLine>();
            double openPrice = Math.Round(st, 2);

            int fall = (int)(0.30 * endMinute - beginMinute);
            for (int i = beginMinute; i <= endMinute; i++)
            {
                MinuteLine vk = new MinuteLine();
                vk.symbol = _sym;
                vk.open = openPrice;
                vk.year = ldl.year;
                vk.month = ldl.month;
                vk.day = ldl.day;
                vk.hour = i / 60;
                vk.minute = i % 60;
                vk.type = 获取是阳线还是阴线();
                if (vk.type == LineType.type_FALL)
                {
                    fall--;
                }
                if (fall <= 0)
                {
                    vk.type = LineType.type_RISE;
                }

                OCHL(min, max, ref vk);
                double ocr = mintick[getRandom(0, mintick.Length)] * _minPrice;
                if (getRandom(0, 100) < 50)
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

            if (rand % 2 == 0)
            {
                return LineType.type_RISE;
            }
            else
            {
                return LineType.type_FALL;
            }
        }

        /// <returns>index 1 = close,2 = low , 3 = high</returns>
        public void OCHL(double minRang, double maxRang, ref MinuteLine vk)
        {
            int    int_rangmuti = 1000;
            double dub_rangmuti = 1000.0;

            int max = (int)(maxRang * int_rangmuti);
            int min = (int)(minRang * int_rangmuti);

            int value = min;
            if (min >= 1 && max > min)
            {
                value = getRandom(min, max);
            }

            //获取一个随机数
            int rang = getRandom(0, 100);

            double final = value / dub_rangmuti;
            //满阴 满阳
            if (rang < 30)
            {
                if (vk.type == LineType.type_RISE)
                {
                    vk.close = vk.open + final;
                    vk.high = vk.close;
                    vk.low = vk.open;
                }
                else
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
                double l = 0;
                double h = 0;
                if (vtm > 0)
                {
                    l = getRandom(0, vtm) / dub_rangmuti;
                    h = getRandom(0, vtm) / dub_rangmuti;
                }

                if (vk.type == LineType.type_RISE)
                {
                    vk.close = vk.open + final - l - h;
                    vk.low = vk.open - l;
                    vk.high = vk.close + h;
                }
                else
                {
                    vk.close = vk.open - (final - (l + h));
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
