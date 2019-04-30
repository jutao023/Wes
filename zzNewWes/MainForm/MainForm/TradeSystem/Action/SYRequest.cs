using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wes
{
    class SYRequest
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public const string RequestIP = "http://47.100.102.50";

        public static IRestResponse HttpRestQurey(RestRequest request)
        {
            try
            {
                // 构建restfull 请求链接
                RestClient client = new RestSharp.RestClient(RequestIP);
                // 返回请求结果
                return client.Execute(request);
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据品种编号 查询行情规则信息
        /// </summary>
        /// <param name="_proNum"></param>
        /// <returns></returns>
        public static CoinSymbolMarket QureyCoinSymbolMarket(string coinSymbol)
        {
            string URL = "exchange/market/info/{proNum}";
            try
            {
                var r = new RestRequest(URL, Method.GET);
                r.AddUrlSegment("proNum", coinSymbol);
                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;

                string json = response.Content;
                response_CoinSymbolMarket rcm = JsonConvert.DeserializeObject<response_CoinSymbolMarket>(json);
                if (rcm != null && rcm.code == 0 && rcm.data != null)
                {
                    if(rcm.data.Count >= 1)
                        return rcm.data[0];
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 请求购买
        /// </summary>
        /// <param name="_userId">用户ID</param>
        /// <param name="_symbol">产品编号</param>
        /// <param name="_vol">数量</param>
        /// <param name="_price">价格</param>
        /// <returns>返回报单信息---Json 格式</returns>
        public static request_OrderLimit QureyBuy(long _userId, string _coinSymbol, string _vol,string _price , string orderId = "")
        {
            string URL = "exchange/order/trade";
            try
            {
                request_OrderLimit orderLimit = new request_OrderLimit();
                orderLimit.baseSymbol = "CNY";
                orderLimit.coinSymbol = _coinSymbol;
                orderLimit.symbol = _coinSymbol + "/CNY";
                orderLimit.direction = request_OrderLimit.direction_BUY;  //买入
                orderLimit.type = request_OrderLimit.type_LIMIT;     //限价
                orderLimit.orderCate = request_OrderLimit.orderCate_TRADE; //交易
                orderLimit.orderMemberType = request_OrderLimit.orderMemberType_ROBOT;//机器人
                if (orderId == "")
                {
                    orderLimit.orderId = ProduceOrderID.GetOrderID(EnumBuySellType.购买); //订单ID
                }
                else
                {
                    orderLimit.orderId = orderId;
                }
                orderLimit.memberId = _userId;     //用户ID
                orderLimit.price = _price;      //价格
                orderLimit.amount = _vol;        //数量

                var reqJson = JsonConvert.SerializeObject(orderLimit);
                RestRequest r = new RestRequest(URL, Method.POST);
                r.AddParameter("application/json", reqJson, ParameterType.RequestBody);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null) return null;

                string json = restResponse.Content;
                response_Order rol = JsonConvert.DeserializeObject<response_Order>(json);
                if (rol != null && rol.code == 0)
                {
                    return orderLimit;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 请求卖出
        /// </summary>
        /// <param name="_userId">用户ID</param>
        /// <param name="_symbol">产品编号</param>
        /// <param name="_vol">数量</param>
        /// <param name="_price">价格</param>
        /// <returns>返回报单信息---Json 格式</returns>
        public static request_OrderLimit QureySell(long _userId, string _coinSymbol, string _vol, string _price, string orderId = "")
        {
            string URL = "exchange/order/trade";

            try
            {
                request_OrderLimit orderLimit = new request_OrderLimit();
                orderLimit.baseSymbol = "CNY";
                orderLimit.coinSymbol = _coinSymbol;
                orderLimit.symbol = _coinSymbol + "/CNY";
                orderLimit.direction = request_OrderLimit.direction_SELL;  //卖出
                orderLimit.type = request_OrderLimit.type_LIMIT;      //限价
                orderLimit.orderCate = request_OrderLimit.orderCate_TRADE; //交易
                orderLimit.orderMemberType = request_OrderLimit.orderMemberType_ROBOT;//机器人
                if(orderId == "")
                {
                    orderLimit.orderId = ProduceOrderID.GetOrderID(EnumBuySellType.转让); //订单ID
                }
                else
                {
                    orderLimit.orderId = orderId;
                }
                orderLimit.memberId = _userId;     //用户ID
                orderLimit.price = _price;         //价格
                orderLimit.amount = _vol;          //数量

                var jsonReq = JsonConvert.SerializeObject(orderLimit);
                RestRequest r = new RestRequest(URL, Method.POST);
                r.AddParameter("application/json", jsonReq, ParameterType.RequestBody);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null) return null;

                string json = restResponse.Content;
                response_Order rol = JsonConvert.DeserializeObject<response_Order>(json);

                if (rol != null && rol.code == 0)
                {
                    return orderLimit;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户ID 查询用户的所有持仓
        /// </summary>
        /// <param name="_userId">用户ID</param>
        /// <param name="_page">页码</param>
        /// <param name="_limit">每页大小</param>
        /// <returns>返回查询结果---Json 格式</returns>
        public static List<Position> QureyAllPosition(long _userId, int _page, int _limit)
        {
            string URL = "exchange/order/position/{memberId}/{page}/{limit}";

            try
            {
                RestRequest r = new RestRequest(URL, Method.GET);
                r.AddUrlSegment("memberId", _userId);
                r.AddUrlSegment("page", _page);
                r.AddUrlSegment("limit", _limit);

                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;

                string json = response.Content;
                response_Position rp = JsonConvert.DeserializeObject<response_Position>(json);
                if (rp != null && rp.code == 0 && rp.data != null)
                {
                    return rp.data;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询用户某个品种的持仓
        /// </summary>
        /// <param name="_userId">用户ID</param>
        /// <param name="_symbol">商品编码</param>
        /// <returns></returns>
        public static Position QureyPosition(long _userId,string _coinSymbol)
        {

            string URL = "exchange/order/query_position";
            try
            {
                string json = "{\"memberId\":" + _userId + ",\"productSymbol\":\"" + _coinSymbol + "\"}";
                RestRequest r = new RestRequest(URL, Method.POST);
                r.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null) return null;

                string resJson = restResponse.Content;
                response_Position rp = JsonConvert.DeserializeObject<response_Position>(resJson);
                if(rp != null && rp.data !=null)
                {
                    if(rp.data.Count > 0)
                    {
                        return rp.data[0];
                    }
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据订单编号 请求撤单
        /// </summary>
        /// <param name="_userId">用户ID</param>
        /// <param name="_orderId">订单ID</param>
        /// <returns>返回撤单结果---Json 格式</returns>
        public static bool QureyCancelOrder(long _userId, string _orderId)
        {
            string URL = "exchange/order/cancel/{orderId}/{memberId}";

            try
            {
                RestRequest r = new RestRequest(URL, Method.DELETE);
                r.AddUrlSegment("memberId", _userId);
                r.AddUrlSegment("orderId", _orderId);

                IRestResponse response = HttpRestQurey(r);
                if (response == null) return false;
                string json = response.Content;
                response_CancelOrder rco = JsonConvert.DeserializeObject<response_CancelOrder>(json);
                if (rco != null && rco.code == 0)
                {
                    return true;
                }
                return false;

            }catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根据订单编号查询 某一笔委托单的所有成交记录
        /// </summary>
        /// <param name="_orderId">订单ID</param>
        /// <param name="_type">订单类型</param>
        /// <returns>返回查询结果---Json 格式</returns>
        public static List<Trade> QureyReturnTrade(string _orderId,EnumOrderType _type)
        {
            string URL = "exchange/order/{orderId}/{orderType}";

            try
            {
                string ordt = request_OrderType.orderType_BUY;  //默认查询购买信息
                if (_type == EnumOrderType.抢购)
                    ordt = request_OrderType.orderType_RUSH;
                else if (_type == EnumOrderType.转让)
                    ordt = request_OrderType.orderType_SELL;
                else if (_type == EnumOrderType.兑换)
                    ordt = request_OrderType.orderType_REDEEM;
                else if (_type == EnumOrderType.增发)
                    ordt = request_OrderType.orderType_ADD;

                var r = new RestRequest(URL, Method.GET);
                r.AddUrlSegment("orderId", _orderId);
                r.AddUrlSegment("orderType", ordt);
                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;

                string json = response.Content;
                response_Trade rt = JsonConvert.DeserializeObject<response_Trade>(json);

                if (rt != null && rt.code == 0 && rt.data != null)
                {
                    return rt.data;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户ID 和品种编号，查询当前品种 所有还在队列中的委托单。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="_coinSymbol"></param>
        /// <returns></returns>
        public static List<Order> OureyAllOrder(long userId, string _coinSymbol)
        {
            string URL = "exchange/order/un_deal/{memberId}/{productNum}";
            try
            {
                var r = new RestRequest(URL, Method.GET);
                r.AddUrlSegment("memberId", userId);
                r.AddUrlSegment("productNum", _coinSymbol);
                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;
                string json = response.Content;
                response_Order ro = JsonConvert.DeserializeObject<response_Order>(json);
                if (ro != null && ro.code == 0 && ro.data != null)
                {
                    return ro.data;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据订单编号 查询某笔委托单的最新交易状态，包含具体成交记录。
        /// </summary>
        /// <param name="_orderId"></param>
        /// <returns></returns>
        public static Order QureyOrder(string _orderId)
        {
            string URL = "exchange/order/query/{orderId}";

            try
            {
                var r = new RestRequest(URL, Method.GET);
                r.AddUrlSegment("orderId", _orderId);
                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;
                string json = response.Content;
                response_OneOrder ro = JsonConvert.DeserializeObject<response_OneOrder>(json);

                if (ro != null && ro.code == 0 && ro.data != null)
                {
                    return ro.data;
                }
                return null;
            }catch
            {
                return null;
            }
        }

        public static Quote QureyQuote(string _symbol)
        {
            string URL = "exchange/order/exchange-plate";

            try
            {
                string json = "{\"symbol\":\"" + _symbol + "\"}";
                RestRequest r = new RestRequest(URL, Method.POST);
                r.AddParameter("application/json", json, ParameterType.RequestBody);
                IRestResponse restResponse = HttpRestQurey(r);
                if (restResponse == null)
                {
                    return null;
                }

                string resJson = restResponse.Content;
                Quote quote = JsonConvert.DeserializeObject<Quote>(resJson);

                if(quote != null)
                {
                    if (quote.ask == null || quote.bid == null)
                        return null;
                    return quote;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static Symbol[] QureyAllSymbol()
        {
            string URL = "market/symbol";

            try
            {
                RestRequest r = new RestRequest(URL, Method.GET);
                IRestResponse response = HttpRestQurey(r);
                if (response == null) return null;

                string json = response.Content;
                var rp = JsonConvert.DeserializeObject<Symbol[]>(json);
                if(rp != null && rp.Length > 0)
                {
                    return rp;
                }
                return null;
            }
            catch(Exception ex)
            {
                string v = ex.ToString();
                return null;
            }
        }
    }
}
