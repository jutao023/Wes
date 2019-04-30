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
            double minPrice = 0.001;
            MonthCreate ml = new MonthCreate();
            List<MonthKLine> virKLines = ml.CreateMonthLine_12(Year, 100.22, 0.13, minPrice);
            List<DayLine> virDayLines = new List<DayLine>();
            foreach (MonthKLine vk in virKLines)
            {
                Console.WriteLine("月份：" +vk.month+ " 类型:" +vk.type +" open = " + vk.open + "  ,close = " + vk.close);
                
                DayCreate dc = new DayCreate();
                virDayLines = dc.CreateDayLines(Year, vk.month, vk.open, vk.close, minPrice);
                foreach(DayLine dl in virDayLines)
                {
                    Console.WriteLine("日:" +dl.day+ " open = " + dl.open + "  ,close = " + dl.close);
                }
            }

            Console.Read();
        }
    }
}
