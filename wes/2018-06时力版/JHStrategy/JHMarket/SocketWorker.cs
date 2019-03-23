using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace JiaoHui
{
    namespace JHCore
    {
        class SocketWorker
        {
            /// <summary>
            /// 需要接收行情的对象
            /// </summary>
            private JHMarket jhMarket = null;

            /// <summary>
            /// @构造函数 设置接收行情的对象
            /// </summary>
            /// <param name="_jh"></param>
            public SocketWorker(JHMarket _jh)
            {
                jhMarket = _jh;
            }

            /// <summary>
            /// 线程对象
            /// </summary>
            Thread thread = null;

            public void FreeConnect()
            {
                Socket sock = getSocket();
                if(sock != null && sock.Connected)
                {
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                    sock = null;
                }
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }
            }

            /// <summary>
            /// 获取用来接收行情的对象。
            /// </summary>
            /// <returns></returns>
            public JHMarket GetJHMarket()
            {
                return jhMarket;
            }

            /// <summary>
            /// 判断当前连接是否任然有效
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private bool IsConnectedField(Socket s)
            {
                return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
            }

            /// <summary>
            /// Socket对象
            /// </summary>
            private Socket sock = null;

            /// <summary>
            /// 获取当前Socket对象
            /// </summary>
            /// <returns></returns>
            private Socket getSocket()
            {
                return sock;
            }

            private string IP;
            private int PORT;

            /// <summary>
            /// 连接服务器
            /// </summary>
            /// <param name="_ip">IP地址</param>
            /// <param name="_port">端口号</param>
            /// <returns>成功返回true, 否则返回false</returns>
            public bool ConnectServer(string _IP, int _port)
            {
                IP = _IP;
                PORT = _port;

                IPAddress ip = IPAddress.Parse(_IP);
                IPEndPoint ipe = new IPEndPoint(ip, _port);
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                if (sock == null)
                    return false;
                try
                {
                    sock.Connect(ipe);
                }
                catch (Exception se)
                {
                    JHLog.forMarketLog("连接行情服务器失败！异常code:" + se.Message);
                    return false;
                }
                jhMarket.OnConnectMarket();
                return true;
            }

            private string UserName;
            private string Password;
            private string CallbackIP;

            /// <summary>
            /// 登陆行情服务器
            /// </summary>
            /// <param name="_username">用户名称</param>
            /// <param name="_password">密码</param>
            /// <param name="_callbackIP">回掉的IP地址</param>
            /// <returns></returns>
            public bool Login(string _username, string _password, string _callbackIP)
            {
                UserName = _username;
                Password = _password;
                CallbackIP = _callbackIP;

                PDUHead pdh = new PDUHead();
                pdh.setCommandId(PDUHead.JH_LOGIN);
                pdh.setStatus(0);
                pdh.setSvrTime(0);
                pdh.setTotalLength(PDUHead.PDU_HEAD_LEN + PDUHead.JH_LOGIN_LEN);

                byte[] head = pdh.ToByteArray();
                byte[] body = pdh.LoginBody(_username, _password, _callbackIP);
                byte[] login = pdh.HeadAndBody(head, body);

                try
                {
                    sock.Send(login);
                    byte[] rspl = new byte[14];
                    int len = sock.Receive(rspl, PDUHead.PDU_HEAD_LEN, SocketFlags.None);
                    if (len != PDUHead.PDU_HEAD_LEN)
                    {
                        JHLog.forMarketLog("登陆行情服务器失败！");
                        return false;
                    }
                    PDUHead pDU = new PDUHead();
                    pDU.fromString(rspl);
                    if (pDU.status != 0)
                    {
                        JHLog.forMarketLog("登陆行情服务器失败！");
                        return false;
                    }

                    //登陆成功后消息推送给客户端
                    jhMarket.OnLogin(pDU.svrTime+"");
                    //启动行情接收线程
                    thread = new Thread(new ParameterizedThreadStart(ReceiveThread));
                    thread.Start(this);
                    return true;

                }catch(Exception ex)
                {
                    JHLog.forMarketLog("登陆行情服务器失败！" + ex.Message);
                    return false;
                }
            }

            /// <summary>
            /// 线程处理函数 如果登陆成功后用来接收行情
            /// </summary>
            /// <param name="obj"></param>
            public static void ReceiveThread(object obj)
            {
                SocketWorker sw = ((SocketWorker)obj);
                Socket sock = sw.getSocket();
                byte[] bufferArr = new byte[2 * 1024];//包体
                byte[] PDUHeadArr = new byte[PDUHead.PDU_HEAD_LEN];//数据长度
                int totalLen = 0;   //实际数据长度，初始为0
                int readLen = 0;    //读取的长度

                try
                {
                    for (; sock.Connected;)
                    {
                        //初始化缓存
                        Array.Clear(PDUHeadArr, 0, PDUHeadArr.Length);
                        Array.Clear(bufferArr, 0, bufferArr.Length);

                        //接收包头数据
                        int headBuf = PDUHead.PDU_HEAD_LEN;
                        int headLeft = PDUHead.PDU_HEAD_LEN;
                        int headOffset = 0;

                        while (sock.Connected && headLeft > 0)
                        {
                            readLen = sock.Receive(PDUHeadArr, headOffset, headLeft, SocketFlags.None);
                            if (readLen < 0)
                            {
                                throw new MarketException("接收行情包头数据异常！");
                            }
                            if (readLen == 0)
                            {
                                break;
                            }
                            headOffset += readLen;
                            headLeft -= readLen;
                        }
                        //判断接收的数据长度是否有误
                        readLen = headBuf - headLeft;           //抛出异常
                        if (readLen != PDUHead.PDU_HEAD_LEN)
                        {
                            throw new MarketException("接收行情包头数据异常！");
                        }
                        //解析头信息
                        PDUHead phed = PDUHead.byteToPDUHead(PDUHeadArr);
                        //查看缓存区大小是否够用。
                        totalLen = phed.totalLength;
                        if (totalLen > bufferArr.Length)
                        {
                            bufferArr = new byte[totalLen];
                        }

                        //接收包体数据
                        int bodyBuf = totalLen - PDUHead.PDU_HEAD_LEN;
                        int bodyLeft = totalLen - PDUHead.PDU_HEAD_LEN;
                        int bodyOffset = 0;

                        while (sock.Connected && bodyLeft > 0)
                        {
                            readLen = sock.Receive(bufferArr, bodyOffset, bodyLeft, SocketFlags.None);//读取socket数据

                            if (readLen < 0)
                            {
                                throw new MarketException("接收行情包体数据异常！");
                            }
                            if (readLen == 0)
                            {
                                break;
                            }
                            bodyLeft -= readLen;
                            bodyOffset += readLen;
                        }

                        readLen = bodyBuf - bodyLeft;           //抛出异常
                        if (readLen != totalLen - PDUHead.PDU_HEAD_LEN)
                        {
                            throw new MarketException("接收行情包体数据异常！");
                        }

                        //查看接收数据是否是行情数据
                        if (phed.commandId == PDUHead.JH_REALTRADEINFO)
                        {
                            Tick tck = Tick.byteToTick(bufferArr);
                            if(tck == null)
                            {
                                throw new MarketException("解析行情数据包异常！");
                            }
                            sw.GetJHMarket().ReturnTick(tck);
                            sw.GetJHMarket().OnHeartTest(phed.svrTime);
                            continue;
                        }
                        //查看数据是否是心跳数据
                        if (phed.commandId == PDUHead.JH_ACTIVETEST)
                        {
                            sw.GetJHMarket().OnHeartTest(phed.svrTime);
                            continue;
                        }
                    }
                    //异常
                }catch(MarketException me)
                {
                    sw.GetJHMarket().OnError("error@" + "Socket Worker Thread," +  me.Message);
                    JHLog.forMarketLog("Socket Worker Thread," + me.ToString());
                    return;
                }
                catch (Exception ex)
                {
                    JHLog.forMarketLog("Socket Worker Thread," + ex.ToString());
                    return;
                }

            }
        }
    }
}
