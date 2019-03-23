
using System;

namespace JiaoHui.JHCore
{
    class ManageMarket : JHMarket
    {

        Strategy strategy = null;

        public ManageMarket(Strategy strag)
        {
            strategy = strag;
        }

        public void ForMarketFreeConnect()
        {
            try { 
                ForFreeConnectMarket();
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情请求, ex.ToString());
            }
        }

        public bool ForMarketConnect(string _ip, int _port)
        {
            try
            {
                return ForConnectMarket(_ip, _port);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情请求, ex.ToString());
                return false;
            }
        }

        public bool ForMarketLogin(string _user, string _pwd)
        {
            try
            {
                return ForLogin(_user, _pwd, JHUtil.GetNaviteIP());
            }catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情请求, ex.ToString());
                return false;
            }
        }

        public override void OnConnectMarket()
        {
            try
            {
                strategy.OnJHMarketConnectMarket();
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情回报, ex.ToString());
            }
        }

        public override void OnLogin(string serverTime)
        {
            try
            {
                strategy.OnJHMarketLogin(serverTime);
            }catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情回报, ex.ToString());
            }
        }

        public override void ReturnTick(Tick tick)
        {
            try
            {
                strategy.OnJHMarketTick(tick);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情回报, ex.ToString());
            }
        }

        public override void OnError(string errorMsg)
        {
            try
            {

                strategy.OnJHMarketError(errorMsg);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情回报, ex.ToString());
            }
        }

        public override void OnHeartTest(int serverTime)
        {
            try
            {
                strategy.OnMarketHeartTest(serverTime);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.行情回报, ex.ToString());
            }
        }
    }
}
