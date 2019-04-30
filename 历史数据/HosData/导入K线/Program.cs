using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BarImport
{
    class Program
    {
        static void Main(string[] args)
        {

            string coinSymbol  = "XRS004";
            string symbol      = coinSymbol + "/CNY";
            string filepath    = ".\\Bar\\" + coinSymbol + ".txt";
            string filepath1   = ".\\Bar\\" + coinSymbol + "_1.txt";
            string filepathtmp = ".\\Bar\\" + coinSymbol + "_tmp.txt";

            Console.WriteLine("1、生成K线, 2、插入K线");
            string vopi = Console.ReadLine();
            if (vopi == "2")
            {
                #region 插入

                if (!File.Exists(filepath1))
                {
                    Console.WriteLine("不存在文件:" + filepath);
                    return;
                }

                Console.WriteLine("获取上次操作最后一个导入的K线时间.");
                long lastTime = Fashioning.getLastInsertTime(filepathtmp);
                if (lastTime == -1)
                    return;
                Console.WriteLine("获取成功，开始导入数据");

                FileStream fs = new FileStream(filepath1, FileMode.Open, FileAccess.Read);
                StreamReader sReader = new StreamReader(fs);

                string json = "";
                while ((json = sReader.ReadLine()) != null)
                {
                    if (json == "")
                        continue;
                    SrcMinuteLine sml = JsonConvert.DeserializeObject<SrcMinuteLine>(json);
                    if (sml != null)
                    {
                        if (sml.symbol != symbol)
                        {
                            Console.WriteLine("品种不匹配。");
                            break;
                        }
                        DesMinuteLine dml = Fashioning.Transfrom(sml);
                        if (dml == null)
                            break;

                        Console.WriteLine("准备导入==>" + json);
                        long curTime = long.Parse(dml.time);
                        if (lastTime != 0 && curTime < lastTime)
                        {
                            Console.WriteLine("本次导入取消, 原因:已存在。");
                            continue;
                        }
                        if (Import.InsertMinuteLine(dml))
                        {
                            Console.WriteLine("插入成功。");
                            File.WriteAllText(filepathtmp, json);
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                sReader.Close();
                fs.Close();
                Console.WriteLine("执行完毕");
                #endregion
            }
            else if (vopi == "1")
            {
                #region 构建
                Create cr = new Create();

                double rg = 10000.0;
                int floatLen = 4;
                double endPrice = 400.0;
                double minPrice = 0.0001;

                Console.WriteLine("正在计算月线. . .");
                cr.CreateMonth(2019, 02, 17, 2, 0.03, endPrice * rg, minPrice * rg);
                Console.WriteLine("计算完成。");

                Thread.Sleep(1000);

                Console.WriteLine("正在月线转日线. . .");
                cr.toDay();
                Console.WriteLine("转换完成。");

                Thread.Sleep(1000);
                try
                {
                    Console.WriteLine("正在日线转分钟线. . .");
                    cr.toMinute(symbol, rg, floatLen);
                    Console.WriteLine("转换完成。");

                    Console.WriteLine("是否保存到文件(y/n)");
                    string vl = Console.ReadLine();
                    if (vl == "y" || vl == "Y")
                    {
                        cr.toFile(filepath);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                Console.Read();
                #endregion
            }
        }
    }
}
