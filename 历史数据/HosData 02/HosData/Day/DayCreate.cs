using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bar
{
    public class DayCreate
    {

        int[] mintick = new int[] { 1, 1, 1, 2, 2, 3 };
        public List<DayLine> CreateDayLines(int _year,int _month, double _beginPrice, double _endPrice, double _minPrice)
        {
            int dayCount = 30;
            switch(_month)
            {
                case 2:
                    if (_year == 2018)
                        dayCount = 29;
                    else
                        dayCount = 28;
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayCount = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayCount = 30;
                    break;
            }
            double ed = _endPrice;
            double st = _beginPrice;
            double max = Math.Round((ed - st) * 0.11, 2);
            double min = Math.Round((ed - st) * 0.03, 2);
            List<DayLine> virList = new List<DayLine>();
            double openPrice = Math.Round(st, 2);

            int fall = (int)(0.35 * dayCount);
            for (int i = 1; i <= dayCount; i++)
            {
                DayLine vk = new DayLine();
                vk.open = openPrice;
                vk.year = _year;
                vk.month = _month;
                vk.day = i;
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

            if (rand > 30)
            {
                return LineType.type_RISE;
            }
            else
            {
                return LineType.type_FALL;
            }
        }

        public void OCHL(double minRang, double maxRang, ref DayLine vk)
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
            if (rang < 10)
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
                if(vtm > 0)
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
