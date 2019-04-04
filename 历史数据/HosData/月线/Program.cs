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
            MonthCreate ml = new MonthCreate();
            List<MonthKLine> virKLines = ml.CreateMonthLine_12(1000.22, 0.13, 0.01);
            foreach (MonthKLine vk in virKLines)
            {
                Console.WriteLine(vk.type.ToString() + vk.close);
            }
            Console.Read();
        }
    }
}
