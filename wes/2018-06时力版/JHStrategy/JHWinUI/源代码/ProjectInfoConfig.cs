using JiaoHui.JHCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JHWinUI
{

    public enum EnumRunState
    {
        运行中 = 0,
        未运行 = 1,
        异常 = 2,
        停止 = 3,
        错误 = 4,
        超时 = 5,
    }

    public class ProjectStrategy
    {
        public string username;
        public string projectName;
        public EnumRunState runFlag = EnumRunState.未运行;
        public string fileName;
        public string strategyName;

        public string market_addr;
        public string market_port;
        public string trade_addr;
        public string trade_port;
        public string http_addr;
        public string http_port;
        public string valsign;
        public string contractID;

        public string password;
        public string runState = "";
        public Strategy runStrategy = null;
        public OutPut showMessage = null;

        public bool BeforeInit(Strategy _stag, StateNotify _sn = null, OutPut _outp =null)
        {
            if (_stag == null)
                return false;
            runStrategy = _stag;
            runStrategy.SetContractID(this.contractID);
            runStrategy.SetUserInfo(this.username, this.password);
            runStrategy.SetValSign(this.valsign);
            runStrategy.SetTradeAddr(this.trade_addr, this.trade_port);
            runStrategy.SetMarketAddr(this.market_addr, this.market_port);
            runStrategy.SetHttpAddr(this.http_addr, this.http_port);

            showMessage = _outp;
            runStrategy.SetPrintMessage(_outp);

            runStrategy.SetStateNotify(_sn);
            return true;
        }

        public void CutOff()
        {
            if (runStrategy == null)
                return;
            lock(runStrategy)
            {
                runStrategy.SetPrintMessage(null);
                runStrategy.SetStateNotify(null);
            }
        }

        public void Init()
        {
            //初始化
            if (runStrategy != null)
                runStrategy.OnInit();
            //启动程序
            if (runStrategy != null)
                runStrategy.InitInstance();
        }

        public void Free()
        {
            //释放链接
            if(runStrategy != null)
                runStrategy.FreeObject();
        }

        public void Exit()
        {
            //退出
            if (runStrategy != null)
            {
                runStrategy.OnExit();
                runStrategy = null;
            }
        }
    }

    public class AssemblyClassInfo
    {
        public string FileFullName;
        public string ClassFullName;
    }
}
