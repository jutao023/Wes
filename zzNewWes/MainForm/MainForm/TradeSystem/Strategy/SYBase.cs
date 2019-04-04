using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wes
{
    class SYBase
    {
        public SYBase()
        {
            
        }

        /// <summary>
        /// 线程
        /// </summary>
        Thread thread = null;
        /// <summary>
        /// 定时器间隔默认1000毫秒
        /// </summary>
        int timer = 1000;
        /// <summary>
        /// 交易是否停止
        /// </summary>
        bool tradeStop = false;
        /// <summary>
        ///  线程处理函数
        /// </summary>
        /// <param name="obj"></param>
        static void ThreadFun(Object obj)
        {
            SYBase sY = obj as SYBase;
            try
            {
                // 加载必要信息
                if (!sY.Load())
                {
                    return;
                }
                // 初始化
                sY.OnInit();

                // 连接行情
                bool con = sY.MarketConnect();
                if (con)
                {
                    sY.isConnect = true;
                    while (!sY.tradeStop)
                    {
                        if (sY.isConnect)
                        {
                            sY.OnTimer();
                            Thread.Sleep(sY.timer);
                        }else
                        {
                            if(sY.MarketConnect())
                            {
                                sY.isConnect = true;
                                sY.Print("与行情服务器重新建立连接成功!");
                                Thread.Sleep(1000);
                            }else
                            {
                                sY.Print("一分钟后重新建立与行情端的socket连接!");
                                Thread.Sleep(6000);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                sY.OnError(EnumExceptionCode.交易线程被迫终止, "交易引发严重异常,交易线程被迫退出！ 异常信息:" + ex.ToString());
                return;
            }
        }


        //输出对象
        OutPut pOut;


        public EnumRunStatus runStatus { get; set; }        //运行状态
        public long userId { get; set; }                    //用户主键ID
        protected string coinSymbol { get; set; }           //产品编号
        protected string userName { get; set; }             //账户
        protected string password { get; set; }             //密码
        protected SocketWorker socketWorker { get; set; }   // 行情工作线程
        private bool isConnect { get; set; }            //行情是否连接中

        //启动交易
        public void Start(string _uid, string _coinSymbol)
        {
            //用户名
            userName = "";
            //密码
            password = "";
            coinSymbol = _coinSymbol;
            userId = long.Parse(_uid);

            if (pOut != null)
            {
                pOut.Text = "UID:" + userId + ", 产品编号:" + coinSymbol;
            }

            //状态更新
            runStatus = EnumRunStatus.运行中;
            
            //显示信息
            Show();

            thread = new Thread(new ParameterizedThreadStart(ThreadFun));
            thread.Start(this);

        }
        //连接行情端
        private bool MarketConnect()
        {
            socketWorker = new SocketWorker();
            if (!socketWorker.Connect())
            {
                Print("建立行情 socket 连接失败！");
                return false;
            }
            socketWorker.Init(this, coinSymbol);
            Print("建立行情 socket 连接成功！");
            return true;
        }



        /// <summary>
        /// 关闭交易
        /// </summary>
        public void closeTrade()
        {
            if (socketWorker != null)
            {
                socketWorker.closeTrade();
            }

            runStatus = EnumRunStatus.已停止;
            pOut.RealClose();
            pOut = null;
            thread.Abort();
            tradeStop = true;
        }
        /// <summary>
        /// 设置定时器等级，单位秒 必须 > 0,1是最高级;
        /// </summary>
        /// <param name="_timer"></param>
        public void SetTimer(int _timer)
        {
            if (_timer <= 0)
                _timer = 1;

            this.timer = _timer * 1000;
        }
        /// <summary>
        /// 运行错误
        /// </summary>
        /// <param name="eec"></param>
        /// <param name="_ErrMsg"></param>
        public void OnError(EnumExceptionCode eec, string _ErrMsg)
        {
            runStatus = EnumRunStatus.异常停止;
            Log.LogFor(userId + "", coinSymbol,"时间:" +DateTime.Now.ToString() + _ErrMsg);
            if(eec == EnumExceptionCode.行情异常)
            {
                runStatus = EnumRunStatus.行情接收异常;
                isConnect = false;
                Print("行情接收异常,被迫断开连接,与行情服务器断开连接!");
            }
        }


        /// <summary>
        /// 加载数据
        /// </summary>
        public virtual bool Load()
        {
            return false;
        }
        /// <summary>
        /// 对象创建成功，后调用一次
        /// </summary>
        public virtual void OnInit()
        {

        }
        /// <summary>
        /// 定时器，每次到点调用
        /// </summary>
        public virtual void OnTimer()
        {

        }
        /// <summary>
        /// 行情通知
        /// </summary>
        /// <param name="_verCode"></param>
        /// <param name="json"></param>
        public virtual void OnMarket(int _verCode, string json)
        {

        }



        public void Print(string _msg)
        {
            if(pOut != null && _msg != null)
                pOut.printmsg(_msg);
        }
        public void setPrintDlg(OutPut _op)
        {
            pOut = _op;
        }
        public void Show()
        {
            pOut.Show();
        }
    }
}
