using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaoHui
{
    namespace JHCore
    {
        public class PDUHead
        {
            //@相应类型，代表请求登陆
            public static Int32 JH_LOGIN = 0x0001;
            public static Int32 JH_LOGIN_RSP = 0x8001;
            public static Int32 JH_ACTIVETEST = 0x0002;
            public static Int32 JH_MESSAGE = 0x0003;
            public static Int32 JH_REALTRADEINFO = 0x0009;
            public static Int32 PDU_HEAD_LEN = 14;
            public static Int32 JH_LOGIN_LEN = 20 + 30 + 20;
            public static Int32 WM_FQ_COMM_MSG = (0x0400 + 100 + 300 + 1);//socket通讯端口消息进入 
                                                                          //将字节数组转换成 PDUHead
            public static PDUHead byteToPDUHead(byte[] head)
            {

                if (head == null)
                {
                    return null;
                }

                PDUHead ph = new PDUHead();
                int i = 0, j = 0;
                byte[] total = new byte[4];
                total[i++] = head[j++];
                total[i++] = head[j++];
                total[i++] = head[j++];
                total[i++] = head[j++];
                Array.Reverse(total);

                i = 0;
                byte[] comm = new byte[4];
                comm[i++] = head[j++];
                comm[i++] = head[j++];
                comm[i++] = head[j++];
                comm[i++] = head[j++];
                Array.Reverse(comm);

                i = 0;
                byte[] svrt = new byte[4];
                svrt[i++] = head[j++];
                svrt[i++] = head[j++];
                svrt[i++] = head[j++];
                svrt[i++] = head[j++];
                Array.Reverse(svrt);

                i = 0;
                byte[] status = new byte[2];
                status[i++] = head[j++];
                status[i++] = head[j++];
                Array.Reverse(status);

                ph.setTotalLength(BitConverter.ToInt32(total, 0));
                ph.setCommandId(BitConverter.ToInt32(comm, 0));
                ph.setSvrTime(BitConverter.ToInt32(svrt, 0));
                ph.setStatus(BitConverter.ToInt16(status, 0));

                return ph;
            }


            //1 总长度包括包体
            public Int32 totalLength = 0;
            //2 命令或响应类型 ,广播行情 : 9
            public Int32 commandId = 0;
            //3 时间
            public Int32 svrTime = 0;
            //4 状态
            public Int16 status = 0;

            public void setTotalLength(Int32 totalLen)
            {
                totalLength = totalLen;
            }

            public void setCommandId(Int32 comId)
            {
                commandId = comId;
            }

            public void setSvrTime(Int32 svrT)
            {
                svrTime = svrT;
            }

            public void setStatus(Int16 stat)
            {
                status = stat;
            }

            //包头信息转换成byte数组
            public byte[] ToByteArray()
            {

                byte[] headByte = new byte[14];

                headByte[0] = (byte)((totalLength & 0xFF000000) >> 24);
                headByte[1] = (byte)((totalLength & 0x00FF0000) >> 16);
                headByte[2] = (byte)((totalLength & 0x0000FF00) >> 8);
                headByte[3] = (byte)((totalLength & 0x000000FF));

                headByte[4] = (byte)((commandId & 0xFF000000) >> 24);
                headByte[5] = (byte)((commandId & 0x00FF0000) >> 16);
                headByte[6] = (byte)((commandId & 0x0000FF00) >> 8);
                headByte[7] = (byte)((commandId & 0x000000FF));

                headByte[8] = (byte)((svrTime & 0xFF000000) >> 24);
                headByte[9] = (byte)((svrTime & 0x00FF0000) >> 16);
                headByte[10] = (byte)((svrTime & 0x0000FF00) >> 8);
                headByte[11] = (byte)((svrTime & 0x000000FF));

                headByte[12] = (byte)((status & 0xFF000000) >> 8);
                headByte[13] = (byte)((status & 0x00FF0000));

                return headByte;
            }

            //头和体合并成一个字节数组
            public byte[] HeadAndBody(byte[] head, byte[] body)
            {

                byte[] andAll = new byte[head.Length + body.Length];
                Array.ConstrainedCopy(head, 0, andAll, 0, head.Length);
                Array.ConstrainedCopy(body, 0, andAll, head.Length, body.Length);

                return andAll;
            }

            //登陆的账户信息转换成数组
            public byte[] LoginBody(string user, string pwd, string ip)
            {
                if (user == null || pwd == null || ip == null)
                    return null;
                byte[] retByte = new byte[70];

                char[] cuser = user.ToCharArray();
                byte[] dUser = Encoding.UTF8.GetBytes(cuser);

                char[] cpwd = pwd.ToCharArray();
                byte[] dPwd = Encoding.UTF8.GetBytes(cpwd);

                char[] cip = pwd.ToCharArray();
                byte[] dIp = Encoding.UTF8.GetBytes(cip);

                Array.ConstrainedCopy(dUser, 0, retByte, 0, (dUser.Length > 20 ? 20 : dUser.Length));
                Array.ConstrainedCopy(dPwd, 0, retByte, 20, (dPwd.Length > 30 ? 30 : dPwd.Length));
                Array.ConstrainedCopy(dIp, 0, retByte, 20 + 30, (dIp.Length > 20 ? 20 : dIp.Length));

                return retByte;
            }

            //解析头信息
            public int fromString(byte[] msgBuf)
            {
                int len = 0;
                try
                {
                    if (msgBuf == null)
                    {
                        return -1;
                    }

                    byte[] bytes = new byte[4];

                    Array.Copy(msgBuf, len, bytes, 0, 4);
                    Array.Reverse(bytes);
                    totalLength = BitConverter.ToInt32(bytes, 0);
                    len += 4;

                    Array.Copy(msgBuf, len, bytes, 0, 4);
                    Array.Reverse(bytes);
                    commandId = BitConverter.ToInt32(bytes, 0);
                    len += 4;

                    Array.Copy(msgBuf, len, bytes, 0, 4);
                    Array.Reverse(bytes);
                    svrTime = BitConverter.ToInt32(bytes, 0);
                    len += 4;

                    bytes = new byte[2];
                    Array.Copy(msgBuf, len, bytes, 0, 2);
                    Array.Reverse(bytes);
                    status = BitConverter.ToInt16(bytes, 0);
                    len += 2;
                }
                catch
                {

                }
                return len;
            }
        }
    }
}
