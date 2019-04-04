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
        int[] mintick = new int[] { 1, 1, 1, 2, 2, 3 };
        public List<MonthKLine> CreateMonthLine_12( double _edPrice, double _rate, double _minPrice)
        {
            double ed = _edPrice;
            double st = _edPrice - _edPrice * _rate;
            double max = Math.Round((ed - st) * 0.33, 2);
            double min = Math.Round((ed - st) * 0.1, 2);
            List<MonthKLine> virList = new List<MonthKLine>();

            double openPrice = Math.Round(st, 2);

            for(int i = 0; i < 12; i++)
            {
                MonthKLine vk = new MonthKLine();
                vk.open = openPrice;
                vk.type = 获取是阳线还是阴线();
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
                return MonthKLine.type_RISE;
            }
            else
            {
                //   Console.WriteLine(EnumLineType.阴线.ToString());
                return MonthKLine.type_FALL;
            }
        }
        
        /// <returns>index 1 = close,2 = low , 3 = high</returns>
        public void OCHL(double minRang,double maxRang,ref MonthKLine vk)
        {
            int max = (int)maxRang * 100;
            int min = (int)minRang * 100;

            int value = getRandom(min, max);

            //获取一个随机数
            int rang = getRandom(0, 100);

            double final = value / 100;
            //满阴 满阳
            if (rang < 10)
            {
                if(vk.type == MonthKLine.type_RISE)
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
                double l = getRandom(0, vtm) / 100;
                double h = getRandom(0, vtm) / 100;

                if(vk.type == MonthKLine.type_RISE)
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
