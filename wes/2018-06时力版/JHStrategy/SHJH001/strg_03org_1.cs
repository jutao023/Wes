using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JiaoHui.JHCore;
using JiaoHui.JHData;
using JiaoHui.STAG;

namespace JiaoHui.Date_08_21
{

    public class strg_03org_1 : Strategy
    {

        #region 获取交易流水号
        string BIG_ORDER_F = "BIG_ORDER_F";
        string MUST_TRADE_ON = "MUST_TRADE_ON";
        string CANCEL_ORDER_OPEN = "CANCEL_ORDER_OPEN";
        string CANCEL_ORDER_CLOSE = "CANCEL_ORDER_CLOSE";

        int tradeRef = 0;

        /// <summary>
        /// 获取一个交易流水号【偶数开仓】
        /// </summary>
        /// <returns></returns>
        string GetTradeNoEven()
        {
            tradeRef++;
            if (tradeRef % 2 == 0)
                return tradeRef + "";

            tradeRef++;
            return tradeRef + "";
        }
        /// <summary>
        /// 获取一个交易流水号【奇数平仓】
        /// </summary>
        /// <returns></returns>
        string GetTradeNoUneven()
        {
            tradeRef++;
            if (tradeRef % 2 == 1)
                return tradeRef + "";

            tradeRef++;
            return tradeRef + "";
        }
        /// <summary>
        /// 获取一个交易流水号【查询】
        /// </summary>
        /// <returns></returns>
        string GetTradeNoQurey()
        {
            tradeRef++;
            return tradeRef + "_Q";
        }

        #endregion

        #region 合同信息
        //获取最小变动单位
        int m_minPrice = 0;
        string contract_id = "";

        int GetMinPrice()
        {
            return m_minPrice;
        }

        string GetContract_ID()
        {
            return contract_id;
        }
        #endregion

        #region 随机定时器时间
        void timer_AroundTimer()
        {
            int timer_time = 2;

            Random rd  = new Random();
            int hour   = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;

            oc_scopeA = scopeA;
            oc_scopeB = scopeB;

            oc_bigOpenVol = bigOpenVol;

            double rangeB = 1.0;

            switch (hour)
            {

                case 0:
                case 1:
                case 2:
                case 3:
                    timer_time = rd.Next(24, 30);
                    rangeB = 0.07;
                    break;

                case 4:
                    timer_time = rd.Next(22, 28);
                    rangeB = 0.08;
                    break;

                case 5:
                    timer_time = rd.Next(20, 26);
                    rangeB = 0.1;
                    break;

                case 6:
                    timer_time = rd.Next(15, 22);
                    rangeB = 0.13;
                    break;

                case 7:
                    if (minute >= 0 && minute <= 15)
                    {
                        timer_time = rd.Next(13, 18);
                        rangeB = 0.17;
                    }
                    else if (minute > 15 && minute <= 30)
                    {
                        timer_time = rd.Next(10, 15);
                        rangeB = 0.25;
                    }
                    else if(minute >= 30 && minute < 45)
                    {
                        timer_time = rd.Next(8, 12);
                        rangeB = 0.35;
                    }else
                    {
                        timer_time = rd.Next(6, 10);
                        rangeB = 0.46;
                    }
                    break;

                case 8:
                    if(minute < 30)
                    {
                        timer_time = rd.Next(4, 8);
                        rangeB = 0.58;
                    }
                    else
                    {
                        timer_time = rd.Next(2, 6);
                        rangeB = 0.79;
                    }
                    break;
                case 9:
                case 10:
                case 11:
                case 12:
                    timer_time = rd.Next(1, 4);
                    rangeB = 1.0;
                    break;

                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    timer_time = rd.Next(2, 6);
                    rangeB = 0.80;
                    break;

                case 19:
                case 20:
                    timer_time = rd.Next(3, 7);
                    rangeB = 0.66;
                    break;

                case 21:
                    if(minute <= 30)
                    {
                        timer_time = rd.Next(3, 7);
                        rangeB = 0.66;
                    }
                    else
                    {
                        timer_time = rd.Next(2, 6);
                        rangeB = 0.80;
                    }

                    break;

                case 22:
                case 23:
                    timer_time = rd.Next(1, 4);
                    rangeB = 1.0;
                    break;
                default:
                    timer_time = rd.Next(2, 6);
                    rangeB = 0.80;
                    break;
            }

            // 普通开平区间
            oc_scopeB = (int)(oc_scopeB * rangeB);
            // 大单开平区间
            oc_bigOpenVol = (int)(bigOpenVol * rangeB);

            timer_time *= tradeGrade;   //交易等级
            SetTimer(timer_time);
        }
        #endregion

        //查看卖盘1-5是否有空,如果存在空返回补仓价
        List<int> SellOfSupple(int _afterPrice)
        {
            List<int> arr = new List<int>();

            int upperPrice = GetUpperLimitPrice();
            if (upperPrice > 0 && _afterPrice == upperPrice)
                return arr;

            int min = GetMinPrice();
            int buyprice = _afterPrice;
            if(buyPrice1_5[0] != 0)
            {
                buyprice = buyPrice1_5[0];
            }

            int mid = -1;
            int size = 0;
            int[] pic = new int[5 + 1];
            int lstp = _afterPrice;
            for(int i = 0; i < 5; i ++)
            {
                int sell = sellVolume1_5[i];
                if(sell == 0)
                {
                    mid = i;
                    if(i > 0)
                    {
                        lstp = sellPrice1_5[i - 1];
                    }
                    break;
                }else
                {
                    if(i == 0)
                    {
                        for(int g = buyprice + min; g < sellPrice1_5[i]; g += min)
                        {
                            pic[size] = g;
                            size++;
                            if (size >= pic.Length)
                                break;
                        }
                    }else
                    {
                        for (int g = sellPrice1_5[i-1] + min; g < sellPrice1_5[i]; g += min)
                        {
                            if (size >= pic.Length)
                                break;
                            pic[size] = g;
                            size++;
                        }
                    }
                }
            }
            if (mid < 0)
                return arr;

            size = 0;
            int m = 1;
            arr.Clear();
            for(int x = mid; x < 5; x++)
            {
                if(pic[size] != 0)
                {
                    arr.Add(pic[size]);
                    size++;
                }else
                {
                    arr.Add(lstp + m * min);
                    m++;
                }
            }
            return arr;
        }
        //查看买盘1-5是否有空,如果存在空返回补仓价
        List<int> BuyOfSupple(int _afterPrice )
        {
            List<int> arr = new List<int>();

            int lowp = GetLowerLimitPrice();
            if (lowp > 0 && lowp == _afterPrice)
                return arr;

            int min = GetMinPrice();
            int sellprice = _afterPrice;
            if(sellPrice1_5[0] != 0)
            {
                sellprice = sellPrice1_5[0];
            }

            int mid = -1;
            int size = 0;
            int[] pic = new int[5 + 1];
            int lstp = _afterPrice;
            for (int i = 0; i < 5; i++)
            {
                int buy = buyVolume1_5[i];
                if (buy == 0)
                {
                    mid = i;
                    if(i > 0)
                    {
                        lstp = buyPrice1_5[i - 1];
                    }
                    break;
                }else
                {
                    if (i == 0)
                    {
                        for (int g = sellprice - min; g > buyPrice1_5[i]; g -= min)
                        {
                            pic[size] = g;
                            size++;
                            if (size >= pic.Length)
                                break;
                        }
                    }
                    else
                    {
                        for (int g = buyPrice1_5[i - 1] - min; g > buyPrice1_5[i]; g -= min)
                        {
                            if (size >= pic.Length)
                                break;
                            pic[size] = g;
                            size++;
                        }
                    }
                }
            }
            if (mid < 0)
                return arr;

            size = 0;
            int m = 1;
            for (int x = mid; x < 5; x++)
            {
                if (pic[size] != 0)
                {
                    arr.Add(pic[size]);
                    size++;
                }
                else
                {
                    arr.Add(lstp - m * min);
                    m++;
                }
            }

            return arr;
        }

        #region 随机报单开仓
        void LimitOrderIn()
        {
            //最终价
            int afterPrice = 1;
            #region 最终价 计算
            if (lastTick != null)
            {
                afterPrice = lastTick.newPrice;
            }else
            {
                return;
            }
            #endregion

            Random rd = new Random();

            #region 补充空白 盘口
            List<int> listsups = BuyOfSupple(afterPrice);
            if (listsups.Count > 0)
            {
                foreach (int pricein in listsups)
                {
                    int suppleVol = rd.Next( oc_scopeA, oc_scopeB);
                    if (ForLimitOrder(EnumBuySell.买入, EnumOpenClose.开仓_新订, pricein, suppleVol, contract_id, GetTradeNoUneven()))
                    {
                        PrintLine("995@【补仓】开仓成功，价格:" + pricein + ",手数:" + suppleVol + " 。");
                    }
                }
            }
            else
            {
                int randPrice = 0;
                int randVol = rd.Next(oc_scopeA, oc_scopeB);
                int level = rd.Next(0, 5);
                int buy1  = buyPrice1_5[0];
                int sell1 = sellPrice1_5[0];

                if(buy1 != 0 && sell1 == 0)
                {
                    randPrice = buy1 - level * GetMinPrice();
                }else if(buy1 != 0 && sell1 != 0)
                {
                    if(sell1 - buy1 > 2)
                    {
                        randPrice = buy1 + GetMinPrice();
                    }else
                    {
                        randPrice = buy1 - level * GetMinPrice();
                    }
                }else if(buy1 ==0 && sell1 != 0)
                {
                    randPrice = sell1 - GetMinPrice();
                }
                else
                {
                    randPrice = afterPrice - level * GetMinPrice();
                }
                if (ForLimitOrder(EnumBuySell.买入, EnumOpenClose.开仓_新订, randPrice, randVol, contract_id, GetTradeNoUneven()))
                {
                    PrintLine("995@【开仓】开仓成功，价格:" + randPrice + ",手数:" + randVol + " 。");
                }
            }
            #endregion


            #region 每次必须成交一笔开仓
            int firstVol = rd.Next(1, MustScope);
            int firstPrice = (sellPrice1_5[0] > 0 ? sellPrice1_5[0] : 0);
            if (firstPrice == 0)
            {
                firstPrice = afterPrice + GetMinPrice();
            }
            if (ForLimitOrder(EnumBuySell.买入, EnumOpenClose.开仓_新订, firstPrice, firstVol, contract_id, MUST_TRADE_ON))
            {
                PrintLine("995@【开仓】开仓成功，价格:" + firstPrice + ",手数:" + firstVol + " 。");
            }
            #endregion

        }
        #endregion

        #region 随机报单平仓
        //剩余总持仓
        int Position = 0;
        int qureyCnt = 0;
        void CloseOrderIn()
        {
            //如果持仓等于0 查询持仓
            if(Position <= 0 && qureyCnt % 4 == 0)
            {
                ForJHTradeSubsfListRequest(GetContractID(), EnumBuySell.买入, GetTradeNoQurey());
                return;
            }else if(Position <= 0)
            {
                qureyCnt++;
                return;
            }

            //最终价
            int afterPrice = 1;
            #region 最终价 计算
            if (lastTick != null)
            {
                afterPrice = lastTick.newPrice;
            }
            else
            {
                return;
            }
            #endregion

            Random rd = new Random();

            #region 补充空白 盘口
            List<int> listsups = SellOfSupple(afterPrice);
            if (listsups.Count > 0)
            {
                foreach (int pricein in listsups)
                {
                    int suppleVol = rd.Next(oc_scopeA, oc_scopeB);
                    if (ForLimitOrder(EnumBuySell.卖出, EnumOpenClose.平仓_先订先转, pricein, suppleVol, contract_id, GetTradeNoEven()))
                    {
                        PrintLine("995@【平仓补仓】平仓成功，价格:" + pricein + ",手数:" + suppleVol + " 。");
                        Position -= suppleVol;
                        if (Position <= 0)
                            return;
                    }
                }
            }
            else
            {
                int randPrice = 0;
                int randVol = rd.Next(oc_scopeA, oc_scopeB);
                int level = rd.Next(0, 5);
                int buy1 = buyPrice1_5[0];
                int sell1 = sellPrice1_5[0];

                if (sell1 != 0 && buy1 == 0)
                {
                    randPrice = buy1 + level * GetMinPrice();
                }
                else if (buy1 != 0 && sell1 != 0)
                {
                    if (sell1 - buy1 > 2)
                    {
                        randPrice = sell1 - GetMinPrice();
                    }
                    else
                    {
                        randPrice = sell1 + level * GetMinPrice();
                    }
                }
                else if (sell1 == 0 && buy1 != 0)
                {
                    randPrice = buy1 + GetMinPrice();
                }
                else
                {
                    randPrice = afterPrice + level * GetMinPrice();
                }
                if (ForLimitOrder(EnumBuySell.卖出, EnumOpenClose.平仓_先订先转, randPrice, randVol, contract_id, GetTradeNoEven()))
                {
                    PrintLine("995@【平仓】平仓成功，价格:" + randPrice + ",手数:" + randVol + " 。");
                    Position -= randVol;
                    if (Position <= 0)
                        return;
                }
            }
            #endregion

            #region 必须成交一次
            int firstVol = rd.Next(1, MustScope);
            int firstPrice = (buyPrice1_5[0] > 0 ? buyPrice1_5[0] : 0);
            if (firstPrice == 0)
            {
                firstPrice = afterPrice - GetMinPrice();
            }
            if (ForLimitOrder(EnumBuySell.卖出, EnumOpenClose.平仓_先订先转, firstPrice, firstVol, contract_id, MUST_TRADE_ON))
            {
                PrintLine("995@【开仓】开仓成功，价格:" + firstPrice + ",手数:" + firstVol + " 。");
                Position -= firstVol;
                return;
            }

            #endregion
        }
        #endregion

        #region 随机撤单
        void CancelOrderf()
        {
            int hour = DateTime.Now.Hour;
            int cal = 5;
            if (hour <= 7)
            {
                cal = 3;
            }
            else if (hour > 12 && hour < 21)
            {
                cal = 4;
            }

            #region 撤除开仓单
            for (int i = 0; i < listOpens.Count; i++)
            {
                if (i % cal == 0)
                {
                    Orderf of = listOpens[i];
                    Cancel_Order co = new Cancel_Order();
                    co.trade_mode = "F";
                    co.order_no = of.order_no;
                    co.order_id = of.order_id;
                    co.contract_id = of.contract_no;

                    if (ForJHTradeCancelOrder(co, CANCEL_ORDER_OPEN))
                    {
                        PrintLine("995@请求撤除开仓单！合同ID：" + co.contract_id + "，流水号：" + CANCEL_ORDER_OPEN);
                    }
                    listOpens.RemoveAt(i);
                }
            }
            #endregion

            #region 撤除平仓单
            for (int i = 0; i < listCloses.Count; i++)
            {
                if (i % cal == 0)
                {
                    Orderf of = listCloses[i];

                    Cancel_Order co = new Cancel_Order();
                    co.trade_mode = "F";
                    co.order_no = of.order_no;
                    co.order_id = of.order_id;
                    co.contract_id = of.contract_no;

                    if (ForJHTradeCancelOrder(co, CANCEL_ORDER_CLOSE))
                    {
                        PrintLine("995@请求撤除开仓单！合同ID：" + co.contract_id + "，流水号：" + CANCEL_ORDER_CLOSE);
                    }
                    listCloses.RemoveAt(i);
                }
            }
            #endregion
        }
        #endregion

        #region 约每小时执行一次
        int timeScopeA = 45;
        int timeScopeB = 76;

        double burops = 0.2;
        double burops_v = 0;
        double sumops_v = 0;

        int NextTime()
        {
            Random rd = new Random();
            if (sumops_v < 15)
            {
                burops_v = rd.Next(1, 4);
                if (burops_v + sumops_v <= 15)
                {
                    sumops_v += burops_v;
                    burops = burops_v / 15.0;
                }
                else
                {
                    burops_v = 15 - sumops_v;
                    sumops_v = 15;
                    burops = burops_v / 15.0;
                }
            }

            if (sumops_v >= 15)
            {
                sumops_v = 0;
                burops_v = 0;
                return rd.Next(timeScopeA, timeScopeB);
            }else
            {
                return 1;
            }
        }

        void NextOpen()
        {
            int limitP = 0;
            if (lastTick != null)
            {
                limitP = lastTick.openPrice;
            }
            else
            {
                return;
            }
            int hour = DateTime.Now.Hour;
            int ttP = ((int)(limitP * uprange * hour)) / GetMinPrice();
            limitP = limitP + ttP * GetMinPrice();

            int vol = (int)(oc_bigOpenVol * burops);

            if (ForLimitOrder(EnumBuySell.买入, EnumOpenClose.开仓_新订, limitP, vol, contract_id, BIG_ORDER_F))
            {
                PrintLine("3003@【大单买入】开仓成功，价格:" + limitP + ",手数:" + vol + " 。");
            }
        }

        bool IsBigOrderf(string order_no)
        {
            foreach (BigOrder bo in listOrderNos)
            {
                if (order_no == bo.order_no)
                    return true;
            }
            return false;
        }

        #endregion

        #region 成员属性

        DateTime nextOpenTime = DateTime.Now;               // 下次大单开仓时间
        List<BigOrder> listOrderNos = new List<BigOrder>(); // 大单的交易流水好集合
        List<Orderf> listOpens = new List<Orderf>();        // 报单集合(开仓)；
        List<Orderf> listCloses = new List<Orderf>();       // 报单集合(平仓)；

        int tradeGrade = 1;                 //交易等级

        int bigOpenVol = 50000;             // 大单报单量
        int oc_bigOpenVol = 50000;

        double uprange = 0.00001;           // 十万分之一
        int speed = 1;                      // 基础倍数

        int scopeA = 1;                     // 平仓量 范围大小  起始
        int scopeB = 223;                   // 平仓量 范围大小  结束

        int oc_scopeA = 1;
        int oc_scopeB = 223;

        int MustScope = 47;                 // 每次必须成交手数

        public Tick lastTick = null;        // 最新tick

        public Int32[] buyPrice1_5;     // 买一价 到 买五价
        public Int32[] buyVolume1_5;    // 买一量 到 买五量
        public Int32[] sellPrice1_5;    // 卖一价 到 卖五价
        public Int32[] sellVolume1_5;   // 卖一量 到 卖五量 

        //本合同信息
        #endregion
        
        #region 合同信息
        Contract_List Cont_L = null;
        //获取涨停板价
        int GetUpperLimitPrice()
        {
            if(Cont_L != null)
            {
                return int.Parse(Cont_L.today_high_limit);
            }
            return -1;
        }
        //获取跌停板价
        int GetLowerLimitPrice()
        {
            if (Cont_L != null)
            {
                return int.Parse(Cont_L.today_low_limit);
            }
            return -1;
        }

        #endregion

        void ReadFile()
        {
            string filePath = @".\Config\StrategyCof.txt";
            if (!File.Exists(filePath))
            {
                return;
            }

            FileStream file = null;
            StreamReader sr = null;
            try
            {
                file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                sr = new StreamReader(file, Encoding.Default);
                string strline = "";
                while ((strline = sr.ReadLine()) != null)
                {
                    if (strline == "" || strline == "\n")
                        continue;
                    if (strline[0] == '#')
                        continue;
                    strline = strline.Replace("\t", "");
                    strline = strline.Replace(" ", "");
                    string[] stagCof = strline.Split(new char[] { ',' });
                    if (stagCof.Length < 5)
                        continue;

                    string username     = stagCof[0];
                    string contract_no  = stagCof[1];
                    string maxVol       = stagCof[2];
                    string tmpUpRange   = stagCof[3];
                    string tmpSpeed     = stagCof[4];

                    if (GetContractID() == contract_no)
                    {
                        speed       = int.Parse(tmpSpeed);
                        bigOpenVol  = int.Parse(maxVol);
                        uprange     = Convert.ToDouble(tmpUpRange);

                        PrintLine("3004@《导入仓位权重信息成功！权重大小:" + speed + ", 最大单量:" + bigOpenVol + "单笔最大涨幅"+ uprange + "》");
                        sr.Close();
                        file.Close();
                        return;
                    }
                }
                sr.Close();
                file.Close();
            }
            catch (Exception ex)
            {
                if(sr != null)
                {
                    sr.Close();
                }
                if(file != null)
                {
                    file.Close();
                }
                PrintLine(ex.Message);
            }
        }

        public override void OnInit()
        {
            speed = 1;

            ReadFile();

            scopeA = 1;
            scopeB *= speed;

            oc_scopeA = scopeA;
            oc_scopeB = scopeB;

            oc_bigOpenVol = bigOpenVol;

            MustScope *= speed;
        }

        public override void OnRunStateSuccess()
        {
            #region 数据下载

            PrintLine("正在获取最新的报价牌行情. . .");
            Tick tic = HttpGetRealTimeQuote();
            if (tic != null)
            {
                lastTick = tic;
                PrintLine("获取报价牌行情成功！");

                buyPrice1_5 = tic.buyPrice1_5;
                buyVolume1_5 = tic.buyVolume1_5;
                sellPrice1_5 = tic.sellPrice1_5;
                sellVolume1_5 = tic.sellVolume1_5;
            }
            else
            {
                PrintLine("获取报价牌行情失败？");
            }
            #endregion

            #region 报单查询
            ForJHTradeOrderfListRequest(GetContractID(), "", "1", "", "", "", GetTradeNoQurey());
            #endregion

            timer_AroundTimer();

            nextOpenTime = DateTime.Now;
            nextOpenTime = nextOpenTime.AddMinutes(NextTime());
        }

        public override void OnTick(Tick tick)
        {
            if (tick != null)
            {
                buyPrice1_5 = tick.buyPrice1_5;
                buyVolume1_5 = tick.buyVolume1_5;
                sellPrice1_5 = tick.sellPrice1_5;
                sellVolume1_5 = tick.sellVolume1_5;

                lastTick = tick;
            }
        }

        int timerCount = -1;
        //定时器
        public override void OnTimer()
        {
            try
            {
                timerCount++;
                //开仓报单
                if (timerCount % 2 == 0)
                {
                    LimitOrderIn();
                }
                else   //平仓报单
                {
                    CloseOrderIn();
                }
                //每过180次 报单 查询可撤报单
                if (timerCount % 180 == 0)
                {
                    ForJHTradeOrderfListRequest(GetContractID(), "", "1", "", "", "", GetTradeNoQurey());
                }else if(timerCount % 9 == 0)//没过9次报单后进行撤单处理。
                {
                    CancelOrderf();
                }
                //每次时间到了一笔大买单
                if (DateTime.Now > nextOpenTime)
                {
                    int min = NextTime();
                    nextOpenTime = nextOpenTime.AddMinutes(min);
                    NextOpen();
                }

                //随机定时器
                timer_AroundTimer();

            }catch(Exception ex)
            {
                throw new JHTradeException(ex.ToString());
            }
        }

        //合同
        public override void OnJHTradeContractList(Trade_Head msgHead, List<Contract_List> pContract_List)
        {
            if (pContract_List != null && msgHead.ListNum != 0)
            {
                foreach (Contract_List pcl in pContract_List)
                {
                    if (pcl.contract_no == GetContractID())
                    {
                        Cont_L = pcl;
                        m_minPrice = int.Parse(pcl.min_diff_price);
                        contract_id = pcl.contract_id;
                    }
                }
            }
        }

        //持仓信息应答
        public override void OnJHTradeSubsfList(Trade_Head msgHead, List<Subsf_List> pSubsf_List)
        {
            if (msgHead.ListNum == 0)
                return;

            foreach (Subsf_List sl in pSubsf_List)
            {
                if (sl.contract_no == GetContractID())
                {
                    Position = int.Parse(sl.cnyable_qtt);
                    break;
                }
            }
        }

        //成交回报
        public override void OnJHTradeTradeReturn(Trade_Head msgHead, List<Trade_Return> pTrade_Return_List)
        {

        }

        //报单应答
        public override void OnJHTradeOrder(Trade_Head msgHead, Orderf pOrder)
        {
            if (msgHead != null && pOrder != null && msgHead.ReturnCode == "201")
            {
                //如果是大单报单 添加到大单队列。
                if (BIG_ORDER_F == msgHead.TradeNo)
                {
                    BigOrder big = new BigOrder();

                    big.tradeNo = BIG_ORDER_F;
                    big.limitTime = DateTime.Now;
                    big.order_no = pOrder.order_no;
                    big.order_id = pOrder.order_id;
                    big.bigOrder = pOrder;

                    listOrderNos.Add(big);
                    return;
                }
                
                //如果是必须成交的单子不处理
                if(MUST_TRADE_ON == msgHead.TradeNo)
                {
                    return;
                }
                
                //挂单
                if (int.Parse(msgHead.TradeNo) % 2 == 1)
                {
                    listOpens.Add(pOrder);
                }
                else
                {
                    listCloses.Add(pOrder);
                }
            }
        }

        //报单查询应答
        public override void OnJHTradeOrderfList(Trade_Head msgHead, List<Orderf> pOrderf_List)
        {
            
            // string status;//报单状态 1、未成交，2、部分成交，3、成交，4、撤单，5、收市撤单
            if (msgHead.ChildIndex > 1)
            {
                foreach (Orderf of in pOrderf_List)
                {
                    if (IsBigOrderf(of.order_no))
                    {
                        continue;
                    }
                    if (of.status == "1" || of.status == "2")
                    {
                        Cancel_Order co = new Cancel_Order();

                        co.trade_mode = "F";
                        co.order_no = of.order_no;
                        co.order_id = of.order_id;
                        co.contract_id = of.contract_no;
                        string trade_no = GetTradeNoQurey();
                        if (ForJHTradeCancelOrder(co, trade_no))
                        {
                            PrintLine("995@保护性撤单成功！合同ID：" + co.contract_id + "，流水号：" + trade_no);
                        }
                    }
                }
                return;
            }
            List<Cancel_Order> listCO = new List<Cancel_Order>();
            foreach (Orderf of in pOrderf_List)
            {
                if (of.contract_no != GetContractID())
                    continue;
                if (IsBigOrderf(of.order_no))
                {
                    continue;
                }
                if (of.status == "1" || of.status == "2")
                {
                    Cancel_Order co = new Cancel_Order();

                    co.trade_mode = "F";
                    co.order_no = of.order_no;
                    co.order_id = of.order_id;
                    co.contract_id = of.contract_no;

                    listCO.Add(co);
                }
            }

            if (listCO.Count >= 11)
            {
                int cancelCount = listCO.Count;
                for (int i = 0; i < cancelCount; i = i + 5)
                {
                    Cancel_Order cco = listCO[i];
                    string trade_no = GetTradeNoQurey();
                    if (ForJHTradeCancelOrder(cco, trade_no))
                    {
                        PrintLine("995@撤单请求发送成功！合同ID：" + cco.contract_id + "，流水号：" + trade_no);
                    }
                }
                return;
            }
        }

        //撤单应答
        public override void OnJHTradeCancelOrder(Trade_Head msgHead, Cancel_Order pCancel)
        {
            if (pCancel.ret_cancel_status == "0")
            {
                PrintLine("995@撤单成功！合同ID：" + pCancel.contract_id + "，流水号：" + msgHead.TradeNo);
            }
            else
            {
                PrintLine("995@撤单失败！合同ID：" + pCancel.contract_id + "，流水号：" + msgHead.TradeNo);
            }
        }

        //退出
        public override void OnExit()
        {
            base.OnExit();
        }
    }
}
