using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaoHui.JHCore
{

    public class NotifyCode
    {
        public static string TRADE_LOGIN_OK = "1001@Trade Login OK";
        public static string TRADE_RETURN_ERROR = "1002@Trade Return Error";
        public static string TRADE_HEART_WARNING = "1003@Trade Heart Warning";
        public static string TRADE_SESSION_EXCEPTION = "1004@Trade Session Exception";
        public static string TRADE_TIME_ERROR = "1013@交易服务器返回时间格式有误？请重新开启工程！";


        public static string MARKET_LOGIN_OK = "2001@Market Login OK";
        public static string MARKET_RETURN_ERROR = "2002@Market Return Error";
        public static string MARKET_HEART_WARNING = "2003@Market Heart Warning";
        public static string MARKET_TIME_ERROR = "2013@行情服务器返回时间格式有误？请重新开启工程！";

        public static string SRATEGY_INIT_SUCCESS = "3001@Strategy Initialize Success";
    }

    public interface StateNotify
    {
        void OnNotify(object _obj, string Info);
    }
}
