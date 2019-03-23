using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace JiaoHui.JHCore
{
   
    public class HttpMarket
    {
        string http_ip;
        string http_port;

        public void SetHttp_Info(string _ip,string _port)
        {
            http_ip   = _ip;
            http_port = _port;
        }

        /// <summary>
        /// 下载今日所有有效合同的实时行情
        /// </summary>
        /// <returns></returns>
        public bool HttpDownLoadQuote(string _contractid, string _username)
        {
            //请求url
            string url = "http://" + http_ip + ":" + http_port + "/00000001/baseInfo/PriceBoard";
            string filePath = @".\Tmp\";
            //是否存在此文件夹
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
                directory.Create();

            try
            {
                filePath += "Today_"+_contractid+ "_" + _username +".tick";
                //判断是否存在相同的文件
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);    //存在则删除
                }

                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 获取报价牌(当日) ，调用此函数前必须先调用 bool HttpDownLoadToday()；函数下载数据。
        /// </summary>
        /// <param name="_contractID">合同ID：为空则获取所有行情，非空则获取指定行情</param>
        /// <returns></returns>
        public Tick GetTodayQuote(string _contractID , string _username)
        {

            Tick listTicks = null;

            string filePath = @".\Tmp\Today_" + _contractID + "_" + _username + ".tick";
            if (!System.IO.File.Exists(filePath))
                return null;

            FileStream fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                byte[] buf = new byte[163];
                int len = 0;
                while ((len = fstream.Read(buf, 0, buf.Length)) > 0)
                {
                    if (len != buf.Length)
                        break;
                    Tick tick = Tick.byteToTick(buf);
                    if (tick != null)
                    {
                        if (tick.contractID == _contractID)
                        {
                            listTicks = tick;
                            return listTicks;
                        }
                    }
                }
                fstream.Close();
                return listTicks;
            }
            catch
            {
                fstream.Close();
                return null;
            }

        }


        /// <summary>
        /// 下载指定行情数据
        /// </summary>
        /// <param name="_contractID">有效的合同ID</param>
        /// <param name="_datetime">下载行情的日期</param>
        /// <returns></returns>
        public bool HttpDownLoadTick(string _contractID, string _username,DateTime _datetime)
        {

            if (_contractID == null || _datetime == null)
                return false;

            string time = string.Format("{0:yyyyMMdd}", _datetime);
            string endurl = time + "_" + _contractID + "_detail";
            //拼接URL
            string url = "http://" + http_ip + ":" + http_port + "/00000001/"+_contractID+"/detail/" + endurl;
            //拼接文件
            string filePath = @".\Tmp\";

            //判断是否存在文件夹
            DirectoryInfo directory = new DirectoryInfo(filePath);
            if (!directory.Exists)//不存在
                directory.Create();
            filePath += time + "_" + _contractID +"_" + _username + ".tick";

            if (DateTime.Now < _datetime)
            {
                return false;
            }
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Year;
            int day = DateTime.Now.Year;
            //检查文件是否下载过
            if (_datetime.Year == year && _datetime.Month == month && _datetime.Day == day)
            {
                //判断是否存在相同的文件
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);    //存在则删除
                }
            }else
            {
                //判断是否存在相同的文件
                if (System.IO.File.Exists(filePath))
                {
                    return true;
                }
            }
            try
            {

                FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();
                responseStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 回去指定时间和合理的历史行情，必须先调用 bool HttpDownLoadWas(string _contractID, DateTime _datetime)；下载数据。
        /// </summary>
        /// <returns></returns>
        public List<Tick> GetHostoryTick(string _contractID, string _username, DateTime _date)
        {
            if (_date == null || _contractID == null || _contractID == "")
                return null;
            string time = string.Format("{0:yyyyMMdd}", _date);
            string filePath = @".\Tmp\";
            filePath += time + "_" + _contractID + "_" + _username + ".tick";

            if (!System.IO.File.Exists(filePath))
                return null;

            FileStream fstream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            List<Tick> listTicks = new List<Tick>();
            try
            {
                byte[] buf = new byte[163];
                int len = 0;
                while ((len = fstream.Read(buf, 0, buf.Length)) > 0)
                {
                    if (len != buf.Length)
                        break;
                    Tick tick = Tick.byteToTick(buf);
                    if (tick != null)
                    {
                        if (_contractID == "")
                        {
                            listTicks.Add(tick);
                        }
                        else if (tick.contractID == _contractID)
                        {
                            listTicks.Add(tick);
                        }
                    }
                }
                fstream.Close();
                return listTicks;
            }
            catch
            {
                fstream.Close();
                return null;
            }
        }


        /// <summary>
        /// 获取实时报价牌行情
        /// </summary>
        /// <param name="_contractid"></param>
        /// <returns></returns>
        public Tick HttpGetRealTimeQuote(string _contractid)
        {
            //请求url
            string url = "http://" + http_ip + ":" + http_port + "/00000001/baseInfo/PriceBoard";
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.KeepAlive = false;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                byte[] bArr = new byte[163];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);

                Tick rtn = null;
                while (size > 0)
                {
                    Tick tic = Tick.byteToTick(bArr);
                    if (tic == null)
                        continue;
                    if(tic.contractID == _contractid)
                    {
                        rtn = tic;
                    }
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                responseStream.Close();
                return rtn;
            }catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取历史行情
        /// </summary>
        /// <param name="_contractID"></param>
        /// <param name="_datetime"></param>
        /// <returns></returns>
        public List<Tick> HttpGetHostoryTick(string _contractID, DateTime _datetime)
        {

            List<Tick> listTicks = new List<Tick>();

            if (_contractID == null || _datetime == null)
                return null;
            string time = string.Format("{0:yyyyMMdd}", _datetime);
            string endurl = time + "_" + _contractID + "_detail";
            //拼接URL
            string url = "http://" + http_ip + ":" + http_port + "/00000001/" + _contractID + "/detail/" + endurl;

            try
            {
                // 设置参数
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.KeepAlive = false;
                //发送请求并获取相应回应数据
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求
                Stream responseStream = response.GetResponseStream();
                //创建本地文件写入流
                byte[] bArr = new byte[163];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);

                while (size > 0)
                {
                    Tick tic = Tick.byteToTick(bArr);
                    if (tic == null)
                        continue;

                    if(tic.contractID == _contractID)
                    {
                        listTicks.Add(tic);
                    }
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                responseStream.Close();
                return listTicks;
            }
            catch
            {

                return null;
            }
        }
    }
}
