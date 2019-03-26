using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    class Log
    {
        public static void LogFor(string _uid, string _coinSymbol, string msg)
        {
            Object oc = new object();
            try
            {
                lock (oc)
                {

                    string date = DateTime.Now.ToString("yyyyMMdd");
                    string dirPath = ".\\log\\uid=" + _uid;
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string filePath = dirPath + "\\" + date + "_" + _coinSymbol + ".txt";
                    File.AppendAllText(filePath, msg+"\r\n");
                }
            }catch
            {

            }
        }
    }
}
