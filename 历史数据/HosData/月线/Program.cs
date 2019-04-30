using Bar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 月线
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxRange = 10000;
            double minPrice = 1.0;
            double begp = 1009.202;
            string coinSymbol = "XRS002";
            string symbol = coinSymbol + "/CNY";

            MonthCreate ml = new MonthCreate();
            ml.startYear = 2018;
            ml.startMonth = 4;
            ml.startDay = 15;

            List<MonthKLine> virKLines = ml.CreateMonthLine_12( begp * maxRange, minPrice);
            List<DayLine> virDayLines = new List<DayLine>();
            List<MinuteLine> minuteLines = new List<MinuteLine>();

            double lasClose = 0;
            foreach (MonthKLine vk in virKLines)
            {
                Console.WriteLine("月份：" + vk.month + " 类型:" + vk.type + " open = " + vk.open / maxRange + "  ,close = " + vk.close / maxRange);

                DayCreate dc = new DayCreate();
                virDayLines = dc.CreateDayLines(vk, minPrice);
                foreach (DayLine dl in virDayLines)
                {
                    Console.WriteLine("日:" + dl.day + dl.type + " open = " + dl.open / maxRange + "  ,close = " + dl.close / maxRange);

                    MinuteCreate mc = new MinuteCreate();
                    List<MinuteLine> minutes = mc.CreateMinuteLines(symbol , dl, minPrice);
                    foreach (MinuteLine mll in minutes)
                    {
                        lasClose = mll.close;
                        Console.WriteLine(" 开：" + mll.open / maxRange + "  ,收盘：" + mll.close / maxRange + "  ,高：" + mll.high / maxRange + "  ,低：" + mll.low / maxRange);
                        minuteLines.Add(mll);
                    }
                }
            }

            Console.WriteLine("价格差 = " +( begp - lasClose / maxRange));
            Console.WriteLine("\r\ny：修复，n:放弃");
            double tmpbeg = begp * maxRange - lasClose;
            string value = Console.ReadLine();
            if(value !="y")
                return;

            foreach(MinuteLine mil in minuteLines)
            {
                double open  = mil.open + tmpbeg;
                double close = mil.close + tmpbeg;
                double low   = mil.low + tmpbeg;
                double high  = mil.high + tmpbeg;


                mil.open  = Math.Round(open / maxRange, 4);
                mil.close = Math.Round(close / maxRange, 4);
                mil.low   = Math.Round(low / maxRange, 4);
                mil.high  = Math.Round(high /maxRange, 4);

                Console.WriteLine(" 开：" + mil.open + "  ,收盘：" + mil.close + "  ,高：" + mil.high + "  ,低：" + mil.low);
            }

            Console.WriteLine("\r\n修复完成. . .\r\n\r\ny：保存到文件，n:放弃");
            value = Console.ReadLine();
            if (value != "y")
                return;

            string filepath = ".\\Bar\\" + coinSymbol + ".txt";
            if(File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write);
            StreamWriter swrite = new StreamWriter(fs);
            foreach (MinuteLine mil in minuteLines)
            {
                string lineJson = JsonConvert.SerializeObject(mil);
                swrite.WriteLine(lineJson);
            }
            swrite.Flush();
            swrite.Close();
            fs.Close();
            Console.WriteLine("写入完成。");
            Console.ReadLine();
        }
    }
}
