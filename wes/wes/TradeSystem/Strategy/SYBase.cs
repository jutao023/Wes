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

        /// <summary>
        /// 线程
        /// </summary>
        Thread thread = null;

        /// <summary>
        /// 消息通知
        /// </summary>
        MessageNotice messageNotice = null;

        /// <summary>
        /// 定时器间隔默认1000毫秒
        /// </summary>
        uint timer = 1000;
       
        static void ThreadFun(Object obj)
        {
            SYBase sY = obj as SYBase;
            sY.OnInit();

            while(true)
            {
                Thread.Sleep(1000);
            }
        }

        public SYBase()
        {
            thread = new Thread(new ParameterizedThreadStart(ThreadFun));
            thread.Start(this);
        }

        /// <summary>
        /// 设置定时器，单位毫秒 必须 > 0;
        /// </summary>
        /// <param name="_timer"></param>
        public void SetTimer(uint _timer)
        {
            if (_timer <= 0)
                _timer = 1000;

            this.timer = _timer;
        }

        /// <summary>
        /// 打印一条消息
        /// </summary>
        /// <param name="_msg"></param>
        public void Print(string _msg)
        {
            if(messageNotice != null)
            {
                messageNotice.MessageNotify(this, "200", _msg);
            }
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        public virtual void Load()
        {

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




        public static void Test()
        {

            SocketWorker sw = new SocketWorker();
      //      sw.Connect();
           
         //    SYRequest.QureyCoinSymbolMarket("XDFYX");

  //           SYRequest.QureyBuy(100, "XDFYX", "12", "0.12");

 //            SYRequest.QureySell(100, "XDFYX", "20", "99.9999");

 //            SYRequest.QureyPosition(101, 1, 10);

  //           SYRequest.QureyCancelOrder(101, "");

  //           SYRequest.QureyReturnTrade("", EnumOrderType.购买);

        //     SYRequest.OureyAllOrder(100, "XDFYX");

 //            SYRequest.QureyOrder("11201903151252423176");

            // SocketWorker s = new SocketWorker();

            //SYBase bs = new SYStrategy();
            //bs.Load();
        }
    }
}
