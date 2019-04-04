using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class Program
    {
        static void Main(string[] args)
        {

            Example exa01 = new Example();

            exa01.coinSymbol = "XDFYX";
            exa01.userId = 200;

            Console.WriteLine("选择测试方式:");
            Console.WriteLine("1 、 卖吃买, 1个线程请求1000次");
            Console.WriteLine("2 、 买吃卖, 1个线程请求1000次");
            Console.WriteLine("3 、 卖吃买, 10个线程，每个线程请求100次");
            Console.WriteLine("4 、 买吃卖, 10个线程，每个线程请求100次");
            Console.WriteLine("5 、 撤销所有报单");
            Console.Write("请输入:");

            string rdata = Console.ReadLine();
            if(rdata =="1")
            {
                exa01.test01_buy();
            }
            else if(rdata =="2")
            {
                exa01.test01_sell();
            }
            else if (rdata == "3")
            {
                exa01.test_More_Buy();
            }
            else if (rdata == "4")
            {
                exa01.test_More_Sell();
            }
            else if(rdata == "5")
            {
                exa01.cancelAllOrder();
            }
        }
    }
}
