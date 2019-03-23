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
        /// 定时器间隔默认1000毫秒
        /// </summary>
        int timer = 1000;

        /// <summary>
        /// 输出
        /// </summary>
        OutPut pOut;

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
            try
            {

                SYBase sY = obj as SYBase;
                // 加载必要信息
                if (!sY.Load())
                {
                    return;
                }
                // 初始化
                sY.OnInit();

                while (!sY.tradeStop)
                {
                    sY.OnTimer();
                    Thread.Sleep(sY.timer);
                }
            }
            catch






            {

            }
        }

        public SYBase()
        {
            thread = new Thread(new ParameterizedThreadStart(ThreadFun));
            thread.Start(this);
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
        /// 关闭交易
        /// </summary>
        public virtual void closeTrade()
        {
            tradeStop = true;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="_msg"></param>
        public void Print(string _msg)
        {
            pOut.printmsg(_msg);
        }
        public void setOutPut(OutPut _op)
        {
            pOut = _op;
            pOut.Show();
        }
    }
}
