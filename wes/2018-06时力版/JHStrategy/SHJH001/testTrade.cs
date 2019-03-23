using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JiaoHui.JHCore;
using JiaoHui.JHData;
using JiaoHui.STAG;

namespace SHJH001
{
    class testTrade : Strategy
    {
        int tradeRef = 0;
        string GetTradeNo()
        {
            tradeRef++;
            return tradeRef + "";
        }

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
        Contract_List Cont_L = null;
        //获取涨停板价
        int GetUpperLimitPrice()
        {
            if (Cont_L != null)
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

        int tradeCount = 0;
        List<string> listQureys = new List<string>();
        List<string> listSponce = new List<string>();

        public Tick lastTick = null;        // 最新tick

        public Int32[] buyPrice1_5;     // 买一价 到 买五价
        public Int32[] buyVolume1_5;    // 买一量 到 买五量
        public Int32[] sellPrice1_5;    // 卖一价 到 卖五价
        public Int32[] sellVolume1_5;   // 卖一量 到 卖五量 

        public override void OnInit()
        {
            listSponce.Clear();
            listQureys.Clear();
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


        int count = 0;
        //定时器
        public override void OnTimer()
        {
            try
            {
                string tradeno = GetTradeNo();
                Random rd = new Random();
                int vol = rd.Next(1, 5);
                string strt = DateTime.Now.ToString();
                if (count % 2 == 0 && count < 5000)
                {

                    if (ForLimitOrder(EnumBuySell.买入, EnumOpenClose.开仓_新订, lastTick.newPrice + m_minPrice * 100, vol, contract_id, tradeno))
                    {
                        listQureys.Add("请求时间:" + strt + " 流水号: " + tradeno + "  ,【开仓】，价格:" + (lastTick.newPrice + m_minPrice * 100) + ",手数:" + vol + " 。");
                    }
                }
                else if( count < 5001)
                {
                    if (ForLimitOrder(EnumBuySell.卖出, EnumOpenClose.平仓_先订先转, lastTick.newPrice - m_minPrice * 100, vol, contract_id, tradeno))
                    {
                        listQureys.Add("请求时间:" + strt + " 流水号: " + tradeno + "  ,【平仓】，价格:" + (lastTick.newPrice - m_minPrice * 100) + ",手数:" + vol + " 。");
                    }
                }
                count++;
            }
            catch (Exception ex)
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
                string strt = DateTime.Now.ToString();
                string tradeno = msgHead.TradeNo;
                listSponce.Add("回报时间:"+ strt +" 流水号:" + tradeno +"  ,价格:" + pOrder.order_price + " ,数量:" + pOrder.order_qtt);
            }
        }

        //报单查询应答
        public override void OnJHTradeOrderfList(Trade_Head msgHead, List<Orderf> pOrderf_List)
        {

        }

        //撤单应答
        public override void OnJHTradeCancelOrder(Trade_Head msgHead, Cancel_Order pCancel)
        {

        }

        //退出
        public override void OnExit()
        {
            base.OnExit();

            foreach(string str in listQureys)
            {
                forRequest(str);
            }

            foreach(string str in listSponce)
            {
                forResponse(str);
            }
        }


        public void forRequest(string _info)
        {
            string filePath = ".\\Log";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
                directory.Create();

            FileStream file = new FileStream(filePath + "\\forRequest.txt", FileMode.Append);
            StreamWriter swrite = new StreamWriter(file, Encoding.Default);

            swrite.WriteLine(_info);
            swrite.Close();
            file.Close();
        }


        public void forResponse(string _info)
        {
            string filePath = ".\\Log";
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
                directory.Create();

            FileStream file = new FileStream(filePath + "\\forResponse.txt", FileMode.Append);
            StreamWriter swrite = new StreamWriter(file, Encoding.Default);

            swrite.WriteLine(_info);
            swrite.Close();
            file.Close();
        }

    }
}
