using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{


    enum EnumAttributeType
    {
        月,
        日,
        分
    }

    class Create
    {

        public int startYear { get; set; }

        public int startMonth { get; set; }

        public int startDay { get; set; }

        public int monthLenth { get; set; }

        public double minPrice { get; set; }

        public double endPrice { get; set; }

        //所有的月线
        private List<MonthKLine> monthKLines = new List<MonthKLine>();

        // 所有的日线
        private List<DayLine> dayLines = new List<DayLine>();

        // 所有的分钟线
        private List<MinuteLine> minuteLines = new List<MinuteLine>();

        public void CreateMonth(int st_Y, int st_M, int st_D, int lenth, double upRange, double endPrice,double minPrice)
        {
            this.startYear = st_Y;
            this.startMonth = st_M;
            this.startDay = st_D;
            this.monthLenth = lenth;
            this.endPrice = endPrice;
            this.minPrice = minPrice;

            int m = startMonth;
            int y = startYear;
         
            // 剩余总量
            double curVal = endPrice * upRange;
            // 开盘价
            double openPrice = endPrice - curVal;
            //判断是否是一个月
            if (startDay == 1 && monthLenth ==1)
            {
                MonthKLine vk = new MonthKLine();
                vk.open = openPrice;
                vk.low = openPrice;
                vk.high = endPrice;
                vk.close = endPrice;

                vk.year = st_Y;
                vk.month = st_M;

                vk.beginDay = st_D;
                vk.endDay = YearType.getDayCount(st_Y, st_M);

                vk.type = "default";

                monthKLines.Add(vk);

                return;
            }

            // 当前个数
            int curCount = monthLenth + 1;
            int realLent = 0;
            if(st_D == 1)
            {
                // 当前个数
                curCount = monthLenth;
                realLent = -1;
            }
            int maxCount = curCount;
            double maxVal = curVal;
            for (int i = startMonth; i <= monthLenth + startMonth + realLent; i++)
            {
                m = i;
                MonthKLine vk = new MonthKLine();
                if (m > 12)
                {
                    m = i - 12;
                    y = startYear + 1;
                }
                vk.beginDay = 1;
                vk.endDay = YearType.getDayCount(y, m);
                if (i == startMonth)
                {
                    vk.beginDay = startDay;
                    vk.endDay = YearType.getDayCount(y, m);
                }
                if (i == startMonth + monthLenth + realLent)
                {
                    vk.beginDay = 1;
                    vk.endDay = startDay;
                }
                if (!YearType.isYear(y) && m == 2 && vk.endDay >= 29)
                {
                    vk.endDay = 28;
                }
                vk.year = y;
                vk.month = m;
                vk.open = openPrice;

                double val = getUpMonth(curCount, curVal, maxCount, maxVal);
                curVal -= val;
                curCount--;

                vk.close = vk.open + val;
                vk.low = vk.open;
                vk.high = vk.close;
                vk.type = "default";

                monthKLines.Add(vk);
                openPrice = vk.close;
            }
        }

        public bool toDay()
        {
            if(monthKLines.Count ==0)
            {
                Console.WriteLine("没有月线，无法转换");
                return false;
            }

            foreach (MonthKLine yml in monthKLines)
            {
                double openPrice = yml.open;

                int curCount = yml.endDay + 1 - yml.beginDay;
                int maxCount = curCount;

                double curVal = yml.close - yml.open;
                double maxVal = curVal;

                for (int i = yml.beginDay; i <= yml.endDay; i++)
                {
                    DayLine vk = new DayLine();

                    vk.year  = yml.year;
                    vk.month = yml.month;
                    vk.day   = i;

                    double val = getUpDay(curCount, curVal, maxCount, maxVal);
                    curVal -= val;
                    curCount--;

                    vk.open  = openPrice;
                    vk.close = vk.open + val;
                    vk.low   = vk.open;
                    vk.high  = vk.close;
                    vk.type  = "default";

                    dayLines.Add(vk);

                    openPrice =  vk.close;
                }
            }
            return true;
        }

        public bool toMinute(string _symbol,double _range, int _len)
        {
            if(dayLines.Count == 0)
            {
                Console.WriteLine("没有日线，无法转换");
                return false;
            }

            foreach(DayLine yml in dayLines)
            {

                double openPrice = yml.open;

                int curCount = 1440;
                int maxCount = curCount;

                double curVal = yml.close - yml.open;
                double maxVal = curVal;

                for (int i = 0; i <= 1439; i++)
                {
                    MinuteLine vk = new MinuteLine();

                    vk.symbol = _symbol;
                    vk.year = yml.year;
                    vk.month = yml.month;
                    vk.day = yml.day;
                    vk.hour = i / 60;
                    vk.minute = i % 60;

                    double val = getUpMinute(curCount, curVal, maxCount, maxVal);
                    curVal -= val;
                    curCount--;

                    vk.open = openPrice;
                    vk.type = "default";

                    // 填充K线
                    fillMinuteBar(val, ref vk);

                    //记录下一次开盘价
                    openPrice = vk.close + minPrice;

                    // 完善K线
                    repair(ref vk, _range, _len);
                    // 添加到队列
                    minuteLines.Add(vk);

                    Console.WriteLine("开:" + vk.open + ", 收:" + vk.close + ", 高:" + vk.high + ", 低:" + vk.low);
                }
            }
            return true;
        }

        public bool toFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
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

            return true;
        }

        private void repair(ref MinuteLine ml, double _range, int _len)
        {
            ml.open = Math.Round((ml.open / _range), _len);
            ml.close = Math.Round((ml.close / _range), _len);
            ml.low = Math.Round((ml.low / _range), _len);
            ml.high = Math.Round((ml.high / _range), _len);
        }

        private void fillMinuteBar(double val,ref MinuteLine ml)
        {

            double lowRng   = MyRandom.getRandom(0, 32) / 100.0;
            double higthRng = MyRandom.getRandom(0, 46) / 100.0;

            double lowVal   = val * lowRng;
            double higthVal = val * higthRng;

            ml.close = ml.open + val;
            ml.low   = ml.open - lowVal;
            ml.high  = ml.close + higthVal;
        }

        private double getUpMonth(int _curCount,double _curVal, int maxCount, double maxVal)
        {
            double rtVal = 0.0;
            if (_curVal <= 0 || maxCount <= 0)
                return rtVal;

            if (maxCount == 1)
                return maxVal;

            if (_curCount == 1)
                return _curVal;

            double rang = MyRandom.getRandom(80, 121) / 100.0;
            rtVal = (maxVal / maxCount) * rang;

            if(rtVal >= _curVal)
            {
                return _curVal / _curCount;
            }

            return rtVal;
        }

        private double getUpDay(int _curCount, double _curVal, int maxCount, double maxVal)
        {
            double rtVal = 0.0;
            if (_curVal <= 0 || maxCount <= 0)
                return rtVal;

            if (maxCount == 1)
                return maxVal;

            if (_curCount == 1)
                return _curVal;

            double rang = MyRandom.getRandom(90, 111) / 100.0;
            rtVal = (maxVal / maxCount) * rang;

            if (rtVal >= _curVal)
            {
                return _curVal / _curCount;
            }

            return rtVal;
        }

        private double getUpMinute(int _curCount, double _curVal, int maxCount, double maxVal)
        {
            double rtVal = 0.0;
            if (_curVal <= 0 || maxCount <= 0)
                return rtVal;

            if (maxCount == 1)
                return maxVal;

            if (_curCount == 1)
                return _curVal;

            double rang = MyRandom.getRandom(93, 108) / 100.0;
            rtVal = (maxVal / maxCount) * rang;

            if (rtVal >= _curVal)
            {
                return _curVal / _curCount;
            }

            return rtVal;
        }
    }
}
