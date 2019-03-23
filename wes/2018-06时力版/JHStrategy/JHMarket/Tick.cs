using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace JiaoHui
{
    namespace JHCore
    {
        public class Tick
        {
            public static int BIT_8 = 8;
            public static int BIT_4 = 4;
            public static int BIT_2 = 2;
            public static int BIT_1 = 1;
            public static int PRICE_DEPTH = 5; //行情深度 （买卖1价  到 买卖5价）
            public static int VOLUME_DEPTH = 5;//成交量深度 （买卖1量  到 买卖5量）

            //复制对象
            public static Tick TickCopyTo(Tick tick)
            {
                if (tick == null)
                    return null;
                Tick cpt = new Tick();
                cpt.quotationSeq = tick.quotationSeq;   //1
                cpt.timestamp = tick.timestamp;//2
                cpt.datetime = new DateTime(tick.timestamp);//3
                cpt.contractID = new string(tick.contractID.ToCharArray());
                cpt.marketID = new string(tick.marketID.ToCharArray());
                cpt.openPrice = tick.openPrice;
                cpt.highPrice = tick.highPrice;
                cpt.lowPrice = tick.lowPrice;
                cpt.newPrice = tick.newPrice;
                cpt.lastClosePrice = tick.lastClosePrice;
                cpt.averagePrice = tick.averagePrice;

                cpt.totalVolume = tick.totalVolume;
                cpt.totalAmount = tick.totalAmount;
                cpt.subsVolume = tick.subsVolume;
                cpt.curVolume = tick.curVolume;
                cpt.actionType = tick.actionType;

                cpt.quotationType = tick.quotationType;

                cpt.buyPrice1_5 = new Int32[Tick.PRICE_DEPTH];
                Array.ConstrainedCopy(tick.buyPrice1_5, 0, cpt.buyPrice1_5, 0, Tick.PRICE_DEPTH);

                cpt.buyVolume1_5 = new Int32[Tick.VOLUME_DEPTH];
                Array.ConstrainedCopy(tick.buyVolume1_5, 0, cpt.buyVolume1_5, 0, Tick.VOLUME_DEPTH);

                cpt.sellPrice1_5 = new Int32[Tick.PRICE_DEPTH];
                Array.ConstrainedCopy(tick.sellPrice1_5, 0, cpt.sellPrice1_5, 0, Tick.PRICE_DEPTH);

                cpt.sellVolume1_5 = new Int32[Tick.VOLUME_DEPTH];
                Array.ConstrainedCopy(tick.sellVolume1_5, 0, cpt.sellVolume1_5, 0, Tick.VOLUME_DEPTH);

                return cpt;
            }

            //byte 转 Tick
            public static Tick byteToTick(byte[] srcDate)
            {
                int Len = 0;
                Tick tick = new Tick();

                //1     服务器端生产，，依次增长，便于过滤重复的行情。可否改为8位流水号一直增长
                byte[] quotationSeq_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, quotationSeq_t, 0, Tick.BIT_8);
                Array.Reverse(quotationSeq_t);
                tick.quotationSeq = BitConverter.ToInt64(quotationSeq_t, 0);
                Len += Tick.BIT_8;

                //2     当前行情时间(DateTime)
                byte[] datetime_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, datetime_t, 0, Tick.BIT_4);
                Array.Reverse(datetime_t);
                Int32 tim = BitConverter.ToInt32(datetime_t, 0);
                tick.timestamp = tim;   //时间戳类型
                DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0)); // 当地时区
                DateTime dt = startTime.AddSeconds(tim);
                tick.datetime = dt;     //DateTime类型
                Len += Tick.BIT_4;

                //3     合同代码
                byte[] contractID_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, contractID_t, 0, Tick.BIT_8);
                string constr = System.Text.Encoding.Default.GetString(contractID_t);
                tick.contractID = constr.Replace("\0", "");
                Len += Tick.BIT_8;

                //4     市场代码
                byte[] marketID_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, marketID_t, 0, Tick.BIT_8);
                string mark = System.Text.Encoding.Default.GetString(marketID_t);
                tick.marketID = mark.Replace("\0", "");
                Len += Tick.BIT_8;

                //5     今开(分)
                byte[] openPrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, openPrice_t, 0, Tick.BIT_4);
                Array.Reverse(openPrice_t);
                tick.openPrice = BitConverter.ToInt32(openPrice_t, 0);
                Len += Tick.BIT_4;

                //6     最高价
                byte[] highPrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, highPrice_t, 0, Tick.BIT_4);
                Array.Reverse(highPrice_t);
                tick.highPrice = BitConverter.ToInt32(highPrice_t, 0);
                Len += Tick.BIT_4;

                //7     最低价
                byte[] lowPrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, lowPrice_t, 0, Tick.BIT_4);
                Array.Reverse(lowPrice_t);
                tick.lowPrice = BitConverter.ToInt32(lowPrice_t, 0);
                Len += Tick.BIT_4;

                //8     最新价
                byte[] newPrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, newPrice_t, 0, Tick.BIT_4);
                Array.Reverse(newPrice_t);
                tick.newPrice = BitConverter.ToInt32(newPrice_t, 0);
                Len += Tick.BIT_4;

                //9     前收(当前项目中取前结-前均的值)
                byte[] lastClosePrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, lastClosePrice_t, 0, Tick.BIT_4);
                Array.Reverse(lastClosePrice_t);
                tick.lastClosePrice = BitConverter.ToInt32(lastClosePrice_t, 0);
                Len += Tick.BIT_4;

                //10    均价
                byte[] averagePrice_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, averagePrice_t, 0, Tick.BIT_4);
                Array.Reverse(averagePrice_t);
                tick.averagePrice = BitConverter.ToInt32(averagePrice_t, 0);
                Len += Tick.BIT_4;

                //11    成交量（总）
                byte[] totalVolume_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, totalVolume_t, 0, Tick.BIT_8);
                Array.Reverse(totalVolume_t);
                tick.totalVolume = BitConverter.ToInt64(totalVolume_t, 0);
                Len += Tick.BIT_8;

                //12    成交额（总）
                byte[] totalAmount_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, totalAmount_t, 0, Tick.BIT_8);
                Array.Reverse(totalAmount_t);
                tick.totalAmount = BitConverter.ToInt64(totalAmount_t, 0);
                Len += Tick.BIT_8;

                //13    订货量
                byte[] subsVolume_t = new byte[Tick.BIT_8];
                Array.ConstrainedCopy(srcDate, Len, subsVolume_t, 0, Tick.BIT_8);
                Array.Reverse(subsVolume_t);
                tick.subsVolume = BitConverter.ToInt64(subsVolume_t, 0);
                Len += Tick.BIT_8;

                //14    本笔成交量
                byte[] curVolume_t = new byte[Tick.BIT_4];
                Array.ConstrainedCopy(srcDate, Len, curVolume_t, 0, Tick.BIT_4);
                Array.Reverse(curVolume_t);
                tick.curVolume = BitConverter.ToInt32(curVolume_t, 0);
                Len += Tick.BIT_4;

                //15    买卖属性: 
                byte[] actionType_t = new byte[Tick.BIT_2];
                Array.ConstrainedCopy(srcDate, Len, actionType_t, 0, Tick.BIT_2);
                Array.Reverse(actionType_t);
                tick.actionType = BitConverter.ToInt16(actionType_t, 0);
                Len += Tick.BIT_2;

                //16    行情类型
                byte quotationType_t = srcDate[Len];
                tick.quotationType = quotationType_t;
                Len += Tick.BIT_1;


                int i = 0;
                //17    买一价 到 买五价
                Int32[] buyP15 = new Int32[Tick.PRICE_DEPTH];
                for (i = 0; i < Tick.PRICE_DEPTH; i++)
                {
                    byte[] buy_p = new byte[Tick.BIT_4];
                    Array.ConstrainedCopy(srcDate, Len, buy_p, 0, Tick.BIT_4);
                    Array.Reverse(buy_p);
                    buyP15[i] = BitConverter.ToInt32(buy_p, 0);
                    Len += Tick.BIT_4;
                }
                tick.buyPrice1_5 = buyP15;

                //18    买一量 到 买五量
                Int32[] buyV15 = new Int32[Tick.VOLUME_DEPTH];
                for (i = 0; i < Tick.VOLUME_DEPTH; i++)
                {
                    byte[] buy_v = new byte[Tick.BIT_4];
                    Array.ConstrainedCopy(srcDate, Len, buy_v, 0, Tick.BIT_4);
                    Array.Reverse(buy_v);
                    buyV15[i] = BitConverter.ToInt32(buy_v, 0);
                    Len += Tick.BIT_4;
                }
                tick.buyVolume1_5 = buyV15;

                //19    卖一价 到 卖五价
                Int32[] sellP15 = new Int32[Tick.PRICE_DEPTH];
                for (i = 0; i < Tick.PRICE_DEPTH; i++)
                {
                    byte[] sell_p = new byte[Tick.BIT_4];
                    Array.ConstrainedCopy(srcDate, Len, sell_p, 0, Tick.BIT_4);
                    Array.Reverse(sell_p);
                    sellP15[i] = BitConverter.ToInt32(sell_p, 0);
                    Len += Tick.BIT_4;
                }
                tick.sellPrice1_5 = sellP15;

                //20    卖一量 到 卖五量
                Int32[] sellV15 = new Int32[Tick.VOLUME_DEPTH];
                for (i = 0; i < Tick.VOLUME_DEPTH; i++)
                {
                    byte[] sell_v = new byte[Tick.BIT_4];
                    Array.ConstrainedCopy(srcDate, Len, sell_v, 0, Tick.BIT_4);
                    Array.Reverse(sell_v);
                    sellV15[i] = BitConverter.ToInt32(sell_v, 0);
                    Len += Tick.BIT_4;
                }
                tick.sellVolume1_5 = sellV15;

                return tick;
            }

            public Int64 quotationSeq; //服务器端生产，，依次增长，便于过滤重复的行情。可否改为8位流水号一直增长
            public Int64 timestamp; //时间戳
            public DateTime datetime; //当前行情时间(YYYYMMDDHH24MiSS)
            public string contractID; //合同代码
            public string marketID; //市场代码
            public Int32 openPrice; //今开（分）
            public Int32 highPrice; //最高价
            public Int32 lowPrice; //最低价
            public Int32 newPrice; //最新价
            public Int32 lastClosePrice; //前收(当前项目中取前结-前均的值)
            public Int32 averagePrice; //均价

            public Int64 totalVolume; //成交量（总）
            public Int64 totalAmount; //成交额（总）
            public Int64 subsVolume; //订货量
            public Int32 curVolume; //本笔成交量
            public Int16 actionType; // 买卖属性: 
                                     // 平盘1 NICE_ACTION, 
                                     // 外盘2 BUY_ACTION，
                                     // 内盘4 SELL_ACTION， 
                                     // 0无意义；
                                     // 双开8，
                                     // 双平16，
                                     // 换手24
                                     //byte
            public Int16 quotationType; // 行情类型
                                        // 1：成交行情，
                                        // 2：报单行情，
                                        // 3：集合竞价成交，
                                        // 4:当日初始申报，之前没有成交。

            public Int32[] buyPrice1_5;  //买一价 到 买五价
            public Int32[] buyVolume1_5; //买一量 到 买五量
            public Int32[] sellPrice1_5; //卖一价 到 卖五价
            public Int32[] sellVolume1_5;//卖一量 到 卖五量

        }
    }
}
