using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarImport
{
    class Import
    {
        static string RequestIP = "http://47.100.102.50";

        public static IRestResponse HttpRestQurey(RestRequest request)
        {
            try
            {
                // 构建restfull 请求链接
                RestClient client = new RestSharp.RestClient(RequestIP);
                // 返回请求结果
                return client.Execute(request);
            }
            catch
            {
                return null;
            }
        }

        public static bool InsertMinuteLine(DesMinuteLine dml)
        {
            string url = "exchange/market/save_kline";

            if (dml == null)
                return false;
            try
            {
                var reqJson = JsonConvert.SerializeObject(dml);
                RestRequest r = new RestRequest(url, Method.POST);
                r.AddParameter("application/json", reqJson, ParameterType.RequestBody);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null)
                    return false;

                string rp = restResponse.Content;
                response_Import res = JsonConvert.DeserializeObject<response_Import>(rp);
                if(res != null && res.code == 0)
                {
                    return true;
                }
                return false;
            }catch
            {
                return false;
            }
        }

        public static DesMinuteLine getLastLine(string coinSymbol)
        {
            string url = "exchange/market/query_kline/{prodSymbol}";
            try
            {
                var r = new RestRequest(url, Method.GET);
                r.AddUrlSegment("prodSymbol", coinSymbol);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null)
                    return null;

                string rp = restResponse.Content;
                response_LastLine rsll = JsonConvert.DeserializeObject<response_LastLine>(rp);
                if(rsll != null && rsll.code == 0)
                {
                    if(rsll.data != null && rsll.data.Count >0)
                        return rsll.data[0];
                    return null;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        
    }
}
