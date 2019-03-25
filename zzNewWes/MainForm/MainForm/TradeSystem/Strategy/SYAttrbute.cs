using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    abstract class SYAttrbute : SYBase
    {
        #region 子类重写
        public override void OnInit()
        {
            base.OnInit();
        }
        public override void OnTimer()
        {
            base.OnTimer();
        }
        #endregion

        #region 用户下单
        /// <summary>
        /// 购买
        /// </summary>
        /// <param name="_vol">数量</param>
        /// <param name="_price">价格</param>
        /// <returns></returns>
        protected bool Buy(int _vol, double _price, bool beIsMust = false)
        {
            try
            {
                double limit = _price;
                if (limit > upLimitPrice)
                {
                    limit = upLimitPrice;
                }
                if(limit < lowLimitPrice)
                {
                    limit = lowLimitPrice;
                }
                   
                string orderId = ProduceOrderID.GetOrderID(EnumBuySellType.购买); //订单ID
                request_OrderLimit ol = SYRequest.QureyBuy(userId, coinSymbol, _vol + "", limit + "", orderId);
                if (ol != null)
                {
                    Print("订单【买入】成功！商品编号:" + coinSymbol + ", 数量:" + _vol + ", 价格:" + limit + ", 订单号:" + orderId);
                    if (beIsMust == false)
                        orderLimitBuys.Add(ol);
                    return true;
                }
                return false;
            } catch
            {
                return false;
            }
        }

        /// <summary>
        /// 转让
        /// </summary>
        /// <param name="_vol">数量</param>
        /// <param name="_price">价格</param>
        /// <returns></returns>
        protected bool Sell(long _vol, double _price, bool beIsMust = false)
        {
            try
            {
                if (position == null)
                {
                    position = SYRequest.QureyPosition(userId, coinSymbol);
                    if (position == null)
                    {
                        Print("转卖仓位不足，无法进行转卖。");
                        return false;
                    }
                }
                if (position.balance <= 0)
                {
                    position = SYRequest.QureyPosition(userId, coinSymbol);
                    if (position.balance == 0)
                    {
                        Print("转卖仓位不足，无法进行转卖。");
                        return false;
                    }
                }
                if (_vol > position.balance)
                {
                    Print("转卖数量大于实际持有量，已按实际拥有数量专卖。");
                    _vol = (long)position.balance;
                }
                double limit = _price;
                if (limit < lowLimitPrice)
                {
                    limit = lowLimitPrice;
                }
                if(limit > upLimitPrice)
                {
                    limit = upLimitPrice;
                }
                string orderId = ProduceOrderID.GetOrderID(EnumBuySellType.转让); //订单ID
                request_OrderLimit ol = SYRequest.QureySell(userId, coinSymbol, _vol + "", limit + "",orderId);
                if (ol != null)
                {
                    position.balance -= _vol;
                    Print("订单【转卖】成功！商品编号:" + coinSymbol + ", 数量:" + _vol + ", 价格:" + limit +", 订单号:" + orderId);
                    if (beIsMust == false)
                        orderLimitSells.Add(ol);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 公有方法

        protected List<Order> getAllOrder(string _coinSymbol)
        {
            return SYRequest.OureyAllOrder(userId, coinSymbol);
        }

        protected bool CancelOrder(string _orderId)
        {

            if (SYRequest.QureyCancelOrder(userId, _orderId))
            {
                Print("撤单成功！订单编号:" + _orderId);
                return true;
            }
            return false;
        }

        protected void CancelLimit()
        {
            bool noCancel = orderLimitBuys.Count + orderLimitSells.Count < maxOrderCount;
            if(noCancel)
            {
                return;
            }
            int cancelCount = 1;
            if (orderLimitBuys.Count > orderLimitSells.Count)
            {
                if (cancelCount > orderLimitBuys.Count)
                {
                    cancelCount = orderLimitBuys.Count;
                }
                Random rd = new Random();
                for (int i = 0; i < cancelCount; i++)
                {
                    int index = rd.Next(0, orderLimitBuys.Count);
                    CancelOrder(orderLimitBuys[index].orderId);
                    orderLimitBuys.RemoveAt(index);
                }
            }
            else if (orderLimitSells.Count > orderLimitBuys.Count)
            {
                if (cancelCount > orderLimitSells.Count)
                {
                    cancelCount = orderLimitSells.Count;
                }
                Random rd = new Random();
                for (int i = 0; i < cancelCount; i++)
                {
                    int index = rd.Next(0, orderLimitSells.Count);
                    CancelOrder(orderLimitSells[index].orderId);
                    orderLimitSells.RemoveAt(index);
                }
            }
        }

        #endregion

        private void LoadConfig()
        {
            SqLiteHelper sqlHelper = new SqLiteHelper();
            sqlHelper.SqliteOpen();
            try
            {
                string sql = "SELECT * FROM attrbute WHERE fk_uid=" + userId;
                //读取整张表
                SQLiteDataReader reader = sqlHelper.Execute(sql);
                if (reader != null)
                {
                    reader.Read();
                    mustMore     = reader.GetInt32(reader.GetOrdinal("mustMore"));
                    OtherMore    = reader.GetInt32(reader.GetOrdinal("OtherMore"));
                    minPrice     = reader.GetDouble(reader.GetOrdinal("minPrice"));
                    timerGrade   = reader.GetInt32(reader.GetOrdinal("timerGrade"));
                    mustToSell   = reader.GetInt32(reader.GetOrdinal("mustToSell"));
                    mustToBuy    = reader.GetInt32(reader.GetOrdinal("mustToBuy"));
                    otherToBuy   = reader.GetInt32(reader.GetOrdinal("otherToBuy"));
                    otherToSell  = reader.GetInt32(reader.GetOrdinal("otherToSell"));
                    maxOrderCount= reader.GetInt32(reader.GetOrdinal("maxOrderCount"));
                }
                else
                {
                    Print("加载配置信息异常即将交易停止！");
                    sqlHelper.SqliteClose();
                    closeTrade();
                    return;
                }
                sqlHelper.SqliteClose();
            }
            catch(Exception ex)
            {
                sqlHelper.SqliteClose();
                OnError(EnumExceptionCode.其他异常, "加载配置信息异常即将交易停止！\r\n" + ex.ToString());
                closeTrade();
                return;
            }
        }

        /// <summary>
        /// 加载交易信息
        /// </summary>
        public sealed override bool Load()
        {
            try
            {
                #region 成员属性赋值
                LoadConfig();

                //真实盘口深度
                maxRealQuoteLen = 10;
                //伪盘口深度
                maxQuoteLen = maxRealQuoteLen + 1;
                //交易对
                symbol = coinSymbol + "/CNY";
                //设置线程的休眠等级
                SetTimer(timerGrade);

                #endregion

                #region 交易价格信息处理
                //查询当日交易的价格区间
                coinSymbolMarket = SYRequest.QureyCoinSymbolMarket(coinSymbol);
                if (coinSymbolMarket == null)
                {
                    Print("获取当日涨跌停信息失败,策略启动失败！");
                    return false;
                }
                if (coinSymbolMarket.beginPrice == null || coinSymbolMarket.maxPrice == null || coinSymbolMarket.minPrice == null)
                {
                    Print("获取当日涨跌停信息有误,策略启动失败！");
                    return false;
                }

                // 开盘价
                openPrice = (double)decimal.Round((decimal)coinSymbolMarket.beginPrice, 2);
                // 最高限价
                upLimitPrice = (double)decimal.Round((decimal)coinSymbolMarket.maxPrice, 2);
                // 最低限价
                lowLimitPrice = (double)decimal.Round((decimal)coinSymbolMarket.minPrice, 2);

                Print("获取当日涨跌停信息成功！");
                #endregion

                #region 更新用户持仓信息
                //查询所有持仓
                position = SYRequest.QureyPosition(userId, coinSymbol);
                if (position == null || position.balance == 0)
                {
                    Print("该账户不存在仓位信息！");
                }
                else
                {
                    Print("获取到所有仓位信息信息！");
                }
                #endregion

                #region 盘口信息更新
                //查询盘口信息
                Quote q = SYRequest.QureyQuote(symbol);
                realQuoteBuy = q.bid.items.ToArray();
                realQuoteSell = q.ask.items.ToArray();
                int len = maxQuoteLen;
                quoteBuy = new QuoteItem[len];
                quoteSell = new QuoteItem[len];
                for (int i = 0; i < len; i++)
                {
                    quoteBuy[i] = new QuoteItem();
                    quoteSell[i] = new QuoteItem();
                }

                productFakeQuote();
                #endregion

                #region 建立行情连接
                socketWorker = new SocketWorker();
                if (!socketWorker.Connect())
                {
                    Print("建立行情 socket 连接失败,策略启动失败！");
                    return false;
                }
                socketWorker.Init(this, symbol);
                Print("建立行情 socket 连接成功！");
                #endregion

                return true;
            } catch (Exception ex)
            {
                OnError(EnumExceptionCode.其他异常,"加载配置信息异常即将交易停止！\r\n" + ex.ToString());
                closeTrade();
                return false;
            }
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        public sealed override void closeTrade()
        {
            try
            {
                if(socketWorker!= null)
                {
                    socketWorker.closeTrade();
                }
                base.closeTrade();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 行情信息通知
        /// </summary>
        /// <param name="_verCode"></param>
        /// <param name="_data"></param>
        public void OnMarket(int _verCode, string json)
        {
            if (json == null)
                return;
            try
            {
                if (_verCode == 20023)
                {
                    LastPrice lp = Action.JsonToLastPrice(json);
                    string loc = "lock";
                    lock (loc)
                    {
                        if (lp != null)
                        {
                            lastPrice = lp;
                            if (lastPrice.price != null)
                            {
                                newPrice = (double)decimal.Round((decimal)lp.price, 2);
                            }
                        }
                    }
                }
                if (_verCode == 20024)
                {
                    string loc = "lock";
                    lock (loc)
                    {
                        QuoteDepth quote = Action.JsonToQuoteDepth(json);
                        if (quote.direction == "BUY")
                        {
                            QuoteItem[] tmp = quote.items.ToArray();
                            realQuoteBuy = tmp;
                        }
                        else
                        {
                            QuoteItem[] tmp = quote.items.ToArray();
                            realQuoteSell = tmp;
                        }
                        productFakeQuote();
                    }
                }
            } catch (Exception ex)
            {
                Print(ex.ToString());
            }
        }

        private void productFakeQuote()
        {
            int len = maxQuoteLen;
            double min = minPrice;
            if (realQuoteBuy != null && realQuoteBuy.Length > 0 && (realQuoteSell == null || realQuoteSell.Length == 0))
            {
                double b = realQuoteBuy[0].price;
                if(b > upLimitPrice || b < openPrice)
                    b = openPrice;

                double s = b + min;
                for (int i = 0; i < len; i++)
                {
                    QuoteItem tmps = quoteSell[i];
                    tmps.price = s;
                    tmps.amount = 0;

                    QuoteItem tmpb = quoteBuy[i];
                    tmpb.price = b;
                    tmpb.amount = 0;

                    s += min;
                    b -= min;
                }
            }
            else if (realQuoteSell != null && realQuoteSell.Length > 0 && (realQuoteBuy == null || realQuoteBuy.Length == 0))
            {
                double s = realQuoteSell[0].price;
                if (s > upLimitPrice || s < openPrice)
                    s = openPrice;

                double b = s - min;
                for (int i = 0; i < len; i++)
                {
                    QuoteItem tmps = quoteSell[i];
                    tmps.price = s;
                    tmps.amount = 0;

                    QuoteItem tmpb = quoteBuy[i];
                    tmpb.price = b;
                    tmpb.amount = 0;

                    s += min;
                    b -= min;
                }
            }
            else if ((realQuoteSell == null || realQuoteSell.Length == 0) && (realQuoteBuy == null || realQuoteBuy.Length == 0))
            {

                double s = openPrice + min;
                double b = openPrice;
                for (int i = 0; i < len; i++)
                {
                    QuoteItem tmps = quoteSell[i];
                    tmps.price = s;
                    tmps.amount = 0;

                    QuoteItem tmpb = quoteBuy[i];
                    tmpb.price = b;
                    tmpb.amount = 0;

                    s += min;
                    b -= min;
                }
            }
            else
            {
                double s = realQuoteSell[0].price;
                double b = realQuoteBuy[0].price;

                if ((s > upLimitPrice || s < openPrice) && (b > upLimitPrice || b < openPrice))
                {
                    s = openPrice + min;
                    b = openPrice;
                }
                else if(s > upLimitPrice || s < openPrice)
                {
                    s = b + min;
                }
                else if(b > upLimitPrice || b < openPrice)
                {
                    b = s - min;
                }
                else
                {
                    if(s - b > 2 * min)
                    {
                        b = s - min;
                    }
                }
                for (int i = 0; i < len; i++)
                {
                    QuoteItem tmps = quoteSell[i];
                    tmps.price = s;
                    tmps.amount = 0;

                    QuoteItem tmpb = quoteBuy[i];
                    tmpb.price = b;
                    tmpb.amount = 0;

                    s += min;
                    b -= min;
                }
            }
        }


        /**********************/
        /*******成员属性*******/
        /*********************/

        protected SocketWorker socketWorker { get; set; }                    // 行情工作线程

        protected CoinSymbolMarket coinSymbolMarket { get; set; }            //当日交易允许的最高、最低价。
        protected LastPrice lastPrice { get; set; }                          //最新价格信息
        protected QuoteItem[] quoteBuy { get; set; }                          //买盘盘口深度
        protected QuoteItem[] quoteSell { get; set; }                         //卖盘盘口深度
        protected QuoteItem[] realQuoteBuy { get; set; }                          //买盘盘口深度
        protected QuoteItem[] realQuoteSell { get; set; }                         //卖盘盘口深度


        //买单请求列表
        protected List<request_OrderLimit> orderLimitBuys  = new List<request_OrderLimit>();
        //卖单请求列表
        protected List<request_OrderLimit> orderLimitSells = new List<request_OrderLimit>();
                 

        protected Position position;                          //所有持仓

        private   int maxQuoteLen { get; set; }
        protected int maxRealQuoteLen { get; set; }
        protected int[] lev_buy = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9 };
        protected int[] lev_sell = { 0, 1, 1, 2, 2, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9 };


        protected double openPrice { get; set; }            //开盘价
        protected double newPrice { get; set; }             //最新价
        protected double upLimitPrice { get; set; }         //当日最高限价
        protected double lowLimitPrice { get; set; }        //当日最低限价

        /*************************/
        /*******MYSQL字段属性******/
        /*************************/

        protected string symbol { get; set; }               //交易对


        protected int mustMore{ get; set; }                 //开仓倍数（必成交）
        protected int OtherMore{ get; set; }                //开仓倍数（非成交）
        protected double minPrice { get; set; }             //最小变动单位


        protected int timerGrade { get; set; }         //交易线程休眠等级 
        protected int mustToSell { get; set; }         //卖单必须成交数量
        protected int mustToBuy { get; set; }          //买单必须成交数量

        protected int otherToBuy { get; set; }         //非必须成交
        protected int otherToSell { get; set; }        //非必须成交

        protected int maxOrderCount { get; set; }      //队列中最大保留未成交报单数量
    }
}
