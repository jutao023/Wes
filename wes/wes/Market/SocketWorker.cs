using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Fleck;
using System.Net.WebSockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace wes
{
    class SocketWorker 
    {
        string URI = "ws://47.100.102.50:28901/topic/market/trade/XDFYX/CNY";
        //80    28901

        /// <summary>
        /// 线程
        /// </summary>
        Thread thread;


        OutPut op = new OutPut();

        /// <summary>
        /// 接收数据的对象
        /// </summary>
        Body body;

        readonly ClientWebSocket webSocket = new ClientWebSocket();
        readonly CancellationToken cancellation = new CancellationToken();

        Socket sock;

        public bool Connect()
        {

            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (sock == null)
                return false;
            try
            {
                op.Show();
                sock.Connect("47.100.102.50", 28901);//39.104.106.202
                thread = new Thread(new ParameterizedThreadStart(ThreadFun));
                thread.Start(this);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void ThreadFun(object obj)
        {
            SocketWorker socketWorker = (SocketWorker)obj;
           

            Socket socket = socketWorker.sock;

            byte[] coin = Encoding.UTF8.GetBytes("{\"symbol\":\"XDFYX / CNY\"}");
            Head hed = new Head();

            hed.length = 26 + coin.Length;
            hed.sequencedId = 0L;
            hed.code = 20021;
            hed.version = 1;
            hed.terminal = "1001";
            hed.requestId = 0;

            byte[] sedh = hed.headToByteArray();

            int hdlength = sedh.Length + coin.Length;
            byte[] senddata = new byte[hdlength];

            Buffer.BlockCopy(sedh, 0, senddata, 0, sedh.Length);  //这种方法仅适用于字节数组
            Buffer.BlockCopy(coin, 0, senddata, sedh.Length, coin.Length);

            int sendlen =  socket.Send(senddata, senddata.Length, SocketFlags.None);
            try
            {
                for (; socket.Connected;)
                {
                    int headBuf = Head.LENGTH;
                    int headLeft = Head.LENGTH;
                    int headOffset = 0;

                    int readLen = 0;
                    byte[] HeadBuffer = new byte[Head.LENGTH];//数据长度
                    while (socket.Connected && headLeft > 0)
                    {
                        readLen = socket.Receive(HeadBuffer, headOffset, headLeft, SocketFlags.None);
                        if (readLen <= 0)
                        {
                            break;
                        }
                        headOffset += readLen;
                        headLeft -= readLen;
                    }

                    Head head = Head.ByteToHead(HeadBuffer);
                    if (head == null)
                    {
                        throw new Exception("解析包头信息异常");
                    }
                    //接收包体数据
                    int bodyBuf = head.length - Head.LENGTH;
                    int bodyLeft = bodyBuf;
                    int bodyOffset = 0;

                    byte[] bodyBuffer = new byte[head.length - Head.LENGTH];

                    while (socket.Connected && bodyLeft > 0)
                    {
                        readLen = socket.Receive(bodyBuffer, bodyOffset, bodyLeft, SocketFlags.None);//读取socket数据
                        if (readLen <= 0)
                        {
                            break;
                        }
                        bodyLeft -= readLen;
                        bodyOffset += readLen;
                    }
                    //读取信息后 解析
                    string message = Encoding.UTF8.GetString(bodyBuffer);
                    socketWorker.op.printmsg(message);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}



/*
             SocketWorker socketWorker = (SocketWorker)obj;
            Socket socket = socketWorker.sock;
            try
            {
                for (; socket.Connected ;)
                {
                    int headBuf = Head.LENGTH;
                    int headLeft = Head.LENGTH;
                    int headOffset = 0;

                    int readLen = 0;
                    byte[] HeadBuffer = new byte[Head.LENGTH];//数据长度
                    while (socket.Connected && headLeft > 0)
                    {
                        readLen = socket.Receive(HeadBuffer, headOffset, headLeft, SocketFlags.None);

                        if (readLen <= 0)
                        {
                            break;
                        }
                        headOffset += readLen;
                        headLeft -= readLen;
                    }
                    Head head = Head.ByteToHead(HeadBuffer);
                    if(head == null)
                    {
                        throw new Exception("解析包头信息异常");
                    }
                    //接收包体数据
                    int bodyBuf =  head.length - Head.LENGTH;
                    int bodyLeft = bodyBuf;
                    int bodyOffset = 0;

                    byte[] bodyBuffer = new byte[head.length - Head.LENGTH];

                    while (socket.Connected && bodyLeft > 0)
                    {
                        readLen = socket.Receive(bodyBuffer, bodyOffset, bodyLeft, SocketFlags.None);//读取socket数据
                        if (readLen <= 0)
                        {
                            break;
                        }
                        bodyLeft -= readLen;
                        bodyOffset += readLen;
                    }
                    //读取信息后 解析
                    if(head.responceCode == 200)
                    {
                        //TODO
                    }
                }

            }catch (Exception ex)
            {
                ex.ToString();
            }






    OutPut outt = new OutPut();
            outt.Show();
            outt.printmsg(stream.ToString());
            byte[] ars = stream.ToArray();
            Array.Reverse(ars);
            int size = socket.Send(ars, 26, SocketFlags.None);




    
            MemoryStream stream = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(stream);

            Int32 len = 26;
            Int64 rsoe = 0L;
            Int16  code = 20021;
            Int32 version = 1;
            Int32 requestID = 0;

            bw.Write(len);
            bw.Write(rsoe);
            bw.Write(code);
            bw.Write(version);
            byte[] ture = Encoding.UTF8.GetBytes("1001");
            bw.Write(ture);
            bw.Write(requestID);
            bw.Flush();
            
            /*
            Head head = new Head();
            head.length = 26;
            head.sequencedId = 0L;
            head.code = 20021;
            head.version = 1;
            head.terminal = "1001";
            head.requestId = 0;

            byte headArray;
            */
     
