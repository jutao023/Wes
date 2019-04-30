using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    class Fashioning
    {
       
        public static DesMinuteLine Transfrom(SrcMinuteLine srcLine)
        {
            double avgPrice = srcLine.open;
            avgPrice = (srcLine.open + srcLine.close + srcLine.high + srcLine.low) / 4.0;

            //成交笔数
            int count =  getCount();
            //成交量
            int volume = getVol() * count;
            //成交额
            double turnover = Math.Round(volume * avgPrice, 2);
            //K线起始时间戳
            string time = getTimeStamp(srcLine.year, srcLine.month, srcLine.day, srcLine.hour, srcLine.minute);
            DesMinuteLine dml = new DesMinuteLine();

            dml.count    = count + "";
            dml.volume   = volume + "";
            dml.turnover = turnover + "";
            dml.time     = time;

            dml.openPrice   = srcLine.open + "";
            dml.closePrice  = srcLine.close + "";
            dml.lowestPrice = srcLine.low + "";
            dml.highestPrice = srcLine.high + "";

            dml.symbol = srcLine.symbol;
            dml.period = "1min";

            return dml;
        }

        static string getTimeStamp(int Y,int M,int D,int h,int m)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            DateTime nowTime = new DateTime(Y, M, D, h, m, 0, 0);
            long unixTime = (long)System.Math.Round((nowTime - startTime).TotalMilliseconds, MidpointRounding.AwayFromZero);
            return unixTime.ToString();
        }

        const int minVol = 1;
        const int maxVol = 13;
        static int getVol()
        {
            return getRandom(minVol, maxVol);
        }

        const int minCount = 4;
        const int maxCount = 60;
        static int getCount()
        {
            return getRandom(minCount, maxCount);
        }

        public static int getRandom(int min, int max)
        {
            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int rand = BitConverter.ToInt32(bytes, 0);
            if (rand < 0)
                rand *= -1;
            int rtn = rand % max;
            if (rtn >= min)
            {
                return rtn;
            }
            return getRandom(min, max);
        }

        public static long getLastInsertTime(string filePath)
        {

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sReader = new StreamReader(fs);

            try
            {
                long time = 0;
                if (!File.Exists(filePath))
                {
                    sReader.Close();
                    fs.Close();
                    return 0;
                }
                string json = "";
                while ((json = sReader.ReadLine()) != null)
                {
                    if (json == "")
                        continue;
                    SrcMinuteLine sml = JsonConvert.DeserializeObject<SrcMinuteLine>(json);
                    if(sml != null)
                    {
                        string strtime = getTimeStamp(sml.year,sml.month,sml.day,sml.hour,sml.minute);
                        time = long.Parse(strtime);
                    }
                }
                sReader.Close();
                fs.Close();
                return time;
            }
            catch
            {
                sReader.Close();
                fs.Close();
                return -1;
            }
        }
    }
}
