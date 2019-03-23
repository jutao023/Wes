using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaoHui.JHCore
{
    public class JHMarket
    {

        /// <summary>
        /// 行情工作Socket
        /// </summary>
        private SocketWorker socketWorker = null;

        /// <summary>
        /// 构造函数
        /// </summary>
        public JHMarket()
        {
            socketWorker = new SocketWorker( this );
        }

        /// <summary>
        /// 请求连接行情服务器
        /// </summary>
        /// <param name="_addr">IP地址</param>
        /// <param name="_port">端口号</param>
        /// <returns>调用成功返回 true ,否则返回 false</returns>
        public bool ForConnectMarket(string _addr, int _port)
        {
            return socketWorker.ConnectServer(_addr, _port);
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        public void ForFreeConnectMarket()
        {
            socketWorker.FreeConnect();
        }
        
        /// <summary>
        /// 当前连接行情服务器成功后被调用
        /// </summary>
        virtual public void OnConnectMarket() { }

        /// <summary>
        /// 请求登陆行情服务器
        /// </summary>
        /// <param name="_user">用户名</param>
        /// <param name="_pwd">密码</param>
        /// <param name="_callbackIP">设置回调IP</param>
        /// <returns></returns>
        public bool ForLogin(string _user, string _pwd, string _callbackIP)
        {
            return socketWorker.Login(_user, _pwd, _callbackIP);
        }

        /// <summary>
        /// 登陆成功后被调用
        /// </summary>
        virtual public void OnLogin(string serverTime) { }

        /// <summary>
        /// 当收到行情后此函数会被调用
        /// </summary>
        /// <param name="tick"></param>
        virtual public void ReturnTick(Tick tick) { }

        /// <summary>
        /// 客户端通信发送错误
        /// </summary>
        /// <param name="errorMsg"></param>
        virtual public void OnError(string errorMsg) { }

        /// <summary>
        /// 接收心跳包
        /// </summary>
        /// <param name="serverTime"></param>
        virtual public void OnHeartTest(Int32 serverTime) { }
    }
}
