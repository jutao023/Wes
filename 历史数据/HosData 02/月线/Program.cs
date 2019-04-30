using Bar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 月线
{
    class Program
    {
        static void Main(string[] args)
        {
            int Year = 2018;
            int maxRange = 10000;
            double minPrice = 1.0;

            MonthCreate ml = new MonthCreate();

            List<MonthKLine> virKLines = ml.CreateMonthLine_12(Year, 100.22 * maxRange, 0.13, minPrice);
            List<DayLine> virDayLines = new List<DayLine>();
            List<MinuteLine> minutes = new List<MinuteLine>();

            foreach (MonthKLine vk in virKLines)
            {
                Console.WriteLine("月份：" +vk.month+ " 类型:" +vk.type +" open = " + vk.open /maxRange  + "  ,close = " + vk.close / maxRange);
                
                DayCreate dc = new DayCreate();
                virDayLines = dc.CreateDayLines(Year, vk.month, vk.open, vk.close, minPrice);
                foreach(DayLine dl in virDayLines)
                {
                    Console.WriteLine("日:" +dl.day+ dl.type+ " open = " + dl.open / maxRange + "  ,close = " + dl.close / maxRange);

                    MinuteCreate mc = new MinuteCreate();
                    minutes = mc.CreateMinuteLines(dl.year, dl.month, dl.day, dl.open, dl.close, minPrice);
                    foreach(MinuteLine mll in minutes)
                    {
                        Console.WriteLine(" 开：" + mll.open / maxRange + "  ,收盘：" + mll.close / maxRange + "  ,高：" + mll.high / maxRange + "  ,低：" + mll.low / maxRange);
                    }
                }
            }
            Console.Read();
        }
    }
}
