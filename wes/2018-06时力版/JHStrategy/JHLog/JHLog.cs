using System;
using System.IO;
using System.Text;

namespace JiaoHui
{
    namespace JHCore
    {
        public class JHLog
        {
            static void WriteMarketFile(string _msg)
            {
                string filePath = ".\\Log";
                DirectoryInfo directory = new DirectoryInfo(filePath);
                if (!directory.Exists)//不存在
                    directory.Create();

                FileStream file = new FileStream(filePath + "\\Market.txt", FileMode.Append);

                StreamWriter swrite = new StreamWriter(file,Encoding.Default);
                DateTime time = DateTime.Now;
                string strTime = time.ToString();
                string strEnd = "\n";
                string wr_msg = strTime + "  " + _msg + strEnd;

                swrite.WriteLine(wr_msg);
                swrite.Close();
                file.Close();
            }

            static JHLog jhlog = new JHLog();
            public static void forMarketLog(string _msg)
            {
                lock (jhlog)
                {
                    WriteMarketFile(_msg);
                }
            }


            static void WriteTradeFile(string _msg)
            {
                string filePath = ".\\Log";
                DirectoryInfo directory = new DirectoryInfo(filePath);
                if (!directory.Exists)//不存在
                    directory.Create();

                FileStream file = new FileStream(filePath + "\\Trade.txt", FileMode.Append);

                StreamWriter swrite = new StreamWriter(file, Encoding.Default);
                DateTime time = DateTime.Now;
                string strTime = time.ToString();
                string strEnd = "\n";
                string wr_msg = strTime + "  " + _msg + strEnd;

                swrite.WriteLine(wr_msg);
                swrite.Close();
                file.Close();
            }
            static JHLog jhtrade = new JHLog();
            public static void forTradeLog(string _msg)
            {
                lock (jhtrade)
                {
                    WriteTradeFile(_msg);
                }
            }


            public static void forRequest(string _info)
            {
                string filePath = ".\\Log";
                DirectoryInfo directory = new DirectoryInfo(filePath);
                if (!directory.Exists)//不存在
                    directory.Create();

                FileStream file = new FileStream(filePath + "\\forRequest.txt", FileMode.Append);

                StreamWriter swrite = new StreamWriter(file, Encoding.Default);
                DateTime time = DateTime.Now;
                string strTime = time.ToString();
                string strEnd = "\n";
                string wr_msg = strTime + "  " + _info + strEnd;

                swrite.WriteLine(wr_msg);
                swrite.Close();
                file.Close();
            }


            public static void forResponse(string _info)
            {
                string filePath = ".\\Log";
                DirectoryInfo directory = new DirectoryInfo(filePath);
                if (!directory.Exists)//不存在
                    directory.Create();

                FileStream file = new FileStream(filePath + "\\forResponse.txt", FileMode.Append);

                StreamWriter swrite = new StreamWriter(file, Encoding.Default);
                DateTime time = DateTime.Now;
                string strTime = time.ToString();
                string strEnd = "\n";
                string wr_msg = strTime + "  " + _info + strEnd;

                swrite.WriteLine(wr_msg);
                swrite.Close();
                file.Close();
            }

        }
    }
}
