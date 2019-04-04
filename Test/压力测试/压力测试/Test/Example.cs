using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wes
{
    class Example
    {
   //     public string coinSymbol = "XDFYX";
   //     public long userId = 100;

        public string coinSymbol { get; set; }
        public long userId { get; set; }
        public string thread_number { get; set; }
        public int cancelCount { get; set; }

        private string fileName { get; set; }
        Thread th_s;


        public void cancelAllOrder()
        {
            List<Order> orders = SYRequest.OureyAllOrder(userId, coinSymbol);
            foreach (var order in orders)
            {
                if (SYRequest.QureyCancelOrder(userId, order.orderId))
                {
                    Console.WriteLine("撤单成功!");
                }
            }
        }



        public void test01_sell()
        {
            fileName = "1个线程_买吃卖.txt";
            List<Order> orders = SYRequest.OureyAllOrder(userId, coinSymbol);
            foreach (var order in orders)
            {
                if (SYRequest.QureyCancelOrder(userId, order.orderId))
                {
                    Console.WriteLine("撤单成功!");
                }
            }
            object obj  = SYRequest.QureySell(userId, coinSymbol, "1000", "102.60");
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            File.AppendAllText(".\\TradeTest\\" + fileName, "1000手买单已经准备完成。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "开始吃盘口，分1000笔吃每次吃一手。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "起始时间:" + time + "\r\n");

            cancelCount = 1000;
            th_s = new Thread(new ParameterizedThreadStart(FunTest01_sell));
            th_s.Start(this);
        }
        public static void FunTest01_sell(object o)
        {
            Example exp = o as Example;
            int i = exp.cancelCount;
            int cnt = 0;

            double milSum = 0;
            double secSum = 0;
            while (i-- > 0)
            {
                cnt++;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码运行时间

                var resObj = SYRequest.QureyBuy(exp.userId, exp.coinSymbol, "1", "102.70");

                stopwatch.Stop(); //  停止监视
                TimeSpan timespan = stopwatch.Elapsed;      //  获取当前实例测量得出的总时间
                double hours = timespan.TotalHours;       // 总小时
                double minutes = timespan.TotalMinutes;     // 总分钟
                double seconds = timespan.TotalSeconds;     //  总秒数
                double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
                Console.WriteLine("第一" + cnt + "次请求,总毫秒数:" + milliseconds);

                milSum += milliseconds;
                secSum += seconds;
            }
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程" + exp.thread_number + "结束时间:" + time + "\r\n");

            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程数量:1个线程\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "累计耗时:" + milSum + "毫秒\r\n\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "累计耗时:" + secSum + "秒\r\n\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "平均:" + milSum /exp.cancelCount + "毫秒/笔\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "平均:" + exp.cancelCount / secSum + "笔/每秒\r\n");
        }



        public void test01_buy()
        {
            fileName = "1个线程_卖吃买.txt";
            List<Order> orders = SYRequest.OureyAllOrder(userId, coinSymbol);
            foreach (var order in orders)
            {
                if (SYRequest.QureyCancelOrder(userId, order.orderId))
                {
                    Console.WriteLine("撤单成功!");
                }
            }
            object obj = SYRequest.QureyBuy(userId, coinSymbol, "1000", "102.60");
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            File.AppendAllText(".\\TradeTest\\" + fileName, "1000手买单已经准备完成。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "开始吃盘口，分1000笔吃每次吃一手。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "起始时间:" + time + "\r\n");

            cancelCount = 1000;
            th_s = new Thread(new ParameterizedThreadStart(FunTest01_buy));
            th_s.Start(this);
        }
        public static void FunTest01_buy(object o)
        {
            Example exp = o as Example;
            int i = exp.cancelCount;
            int cnt = 0;

            double milSum = 0;
            double secSum = 0;
            while (i-- > 0)
            {
                cnt++;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码运行时间

                var resObj = SYRequest.QureySell(exp.userId, exp.coinSymbol, "1", "102.50");

                stopwatch.Stop(); //  停止监视
                TimeSpan timespan = stopwatch.Elapsed;      //  获取当前实例测量得出的总时间
                double hours = timespan.TotalHours;       // 总小时
                double minutes = timespan.TotalMinutes;     // 总分钟
                double seconds = timespan.TotalSeconds;     //  总秒数
                double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
                Console.WriteLine("第一" + cnt + "次请求,总毫秒数:" + milliseconds);

                milSum += milliseconds;
                secSum += seconds;
            }

            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程" + exp.thread_number + "结束时间:" + time + "\r\n");

            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程数量:1个线程\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "累计耗时:" + milSum + "毫秒\r\n\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "累计耗时:" + secSum + "秒\r\n\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "平均:" + milSum / exp.cancelCount + "毫秒/笔\r\n");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "平均:" + exp.cancelCount / secSum + "笔/每秒\r\n");

        }




        public void test_More_Sell()
        {
            int maxValue = 1000;
            fileName = "10个线程_买吃卖.txt";
            List<Order> orders = SYRequest.OureyAllOrder(userId, coinSymbol);
            foreach (var order in orders)
            {
                if (SYRequest.QureyCancelOrder(userId, order.orderId))
                {
                    Console.WriteLine("撤单成功!");
                }
            }
            object obj = SYRequest.QureySell(userId, coinSymbol, ""+maxValue, "102.60");
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            File.AppendAllText(".\\TradeTest\\" + fileName,  maxValue +"手买单已经准备完成。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "开始吃盘口，分"+maxValue+"笔吃每次吃一手。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "起始时间:" + time + "\r\n");
            cancelCount = maxValue / 10;
            for(int i = 1; i <= 10; i++)
            {
                th_s = new Thread(new ParameterizedThreadStart(test_More_Sell));
                th_s.Start(this);
            }
        }
        public static void test_More_Sell(object o)
        {
            Example exp = o as Example;
            int i = exp.cancelCount;
            int cnt = 0;

            double milSum = 0;
            double secSum = 0;
            while (i-- > 0)
            {
                cnt++;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码运行时间

                var resObj = SYRequest.QureyBuy(exp.userId, exp.coinSymbol, "1", "102.70");

                stopwatch.Stop(); //  停止监视
                TimeSpan timespan = stopwatch.Elapsed;      //  获取当前实例测量得出的总时间
                double hours = timespan.TotalHours;       // 总小时
                double minutes = timespan.TotalMinutes;     // 总分钟
                double seconds = timespan.TotalSeconds;     //  总秒数
                double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
                Console.WriteLine("第一" + cnt + "次请求,总毫秒数:" + milliseconds);

                milSum += milliseconds;
                secSum += seconds;
            }
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程" + exp.thread_number + "结束时间:" + time + "\r\n");
        }


        public void test_More_Buy()
        {
            int maxValue = 1000;
            fileName = "10个线程_卖吃买.txt";
            List<Order> orders = SYRequest.OureyAllOrder(userId, coinSymbol);
            foreach (var order in orders)
            {
                if (SYRequest.QureyCancelOrder(userId, order.orderId))
                {
                    Console.WriteLine("撤单成功!");
                }
            }
            object obj = SYRequest.QureyBuy(userId, coinSymbol, "" + maxValue, "102.60");
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            File.AppendAllText(".\\TradeTest\\" + fileName, maxValue + "手买单已经准备完成。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "开始吃盘口，分" + maxValue + "笔吃每次吃一手。\r\n");
            File.AppendAllText(".\\TradeTest\\" + fileName, "起始时间:" + time + "\r\n");
            cancelCount = maxValue / 10;
            for (int i = 1; i <= 10; i++)
            {
                th_s = new Thread(new ParameterizedThreadStart(test_More_Buy));
                th_s.Start(this);
            }
        }
        public static void test_More_Buy(object o)
        {
            Example exp = o as Example;
            int i = exp.cancelCount;
            int cnt = 0;

            double milSum = 0;
            double secSum = 0;
            while (i-- > 0)
            {
                cnt++;
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start(); //  开始监视代码运行时间

                var resObj = SYRequest.QureySell(exp.userId, exp.coinSymbol, "1", "102.50");

                stopwatch.Stop(); //  停止监视
                TimeSpan timespan = stopwatch.Elapsed;      //  获取当前实例测量得出的总时间
                double hours = timespan.TotalHours;       // 总小时
                double minutes = timespan.TotalMinutes;     // 总分钟
                double seconds = timespan.TotalSeconds;     //  总秒数
                double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
                Console.WriteLine("第一" + cnt + "次请求,总毫秒数:" + milliseconds);

                milSum += milliseconds;
                secSum += seconds;
            }
            string time = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            File.AppendAllText(".\\TradeTest\\" + exp.fileName, "线程" + exp.thread_number + "结束时间:" + time + "\r\n");
        }
    }
}
