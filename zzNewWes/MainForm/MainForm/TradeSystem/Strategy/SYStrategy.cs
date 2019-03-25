using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{


    class VolumePrice
    {
        public double price { get; set; }
        public int volume { get; set; }
    }

    class SYStrategy : SYAttrbute
    {

        VolumePrice getSellPrice()
        {
            try
            {
                Random rd = new Random();
                VolumePrice vp = new VolumePrice();
                vp.volume = rd.Next(1, otherToSell * OtherMore + 1);

                int len = quoteSell.Length;
                if (len > realQuoteSell.Length)
                    len = realQuoteSell.Length;

                for (int i = 0; i < len; i++)
                {
                    double q = quoteSell[i].price;
                    double rq = realQuoteSell[i].price;
                    if (q - rq > 0.0001 || q - rq < -0.0001)
                    {
                        vp.price = quoteSell[i].price;
                        return vp;
                    }
                }

                if (realQuoteSell.Length < maxRealQuoteLen)
                {
                    vp.price = quoteSell[realQuoteSell.Length - 1].price + minPrice;
                    return vp;
                }
                int index = rd.Next(0, lev_sell.Length);
                vp.price = quoteSell[lev_sell[index]].price;
                return vp;
            }
            catch
            {
                return null;
            }
        }

        VolumePrice getBuyPrice()
        {
            try
            {
                Random rd = new Random();
                VolumePrice vp = new VolumePrice();
                vp.volume = rd.Next(1, otherToBuy * OtherMore + 1);

                int len = quoteBuy.Length;
                if (len > realQuoteBuy.Length)
                    len = realQuoteBuy.Length;

                for (int i = 0; i < len; i++)
                {
                    double q = quoteBuy[i].price;
                    double rq = realQuoteBuy[i].price;
                    if (q - rq > 0.0001 || q - rq < -0.0001)
                    {
                        vp.price = q;
                        return vp;
                    }
                }

                if (realQuoteBuy.Length < maxRealQuoteLen)
                {
                    vp.price = quoteBuy[realQuoteBuy.Length - 1].price - minPrice;
                    return vp;
                }
                int index = rd.Next(0, lev_buy.Length);
                vp.price = quoteBuy[lev_buy[index]].price;
                return vp;
            }
            catch
            {
                return null;
            }
        }

        VolumePrice getMustBuyPrice()
        {
            try
            {
                Random rd = new Random();
                VolumePrice mvp = new VolumePrice();
                mvp.volume = rd.Next(1, mustToBuy * mustMore);
                if (realQuoteSell.Length == 0)
                    return null;

                mvp.price = realQuoteSell[0].price;
                return mvp;
            }
            catch
            {
                return null;
            }
        }

        VolumePrice getMustSellPrice()
        {
            try
            {
                Random rd = new Random();
                VolumePrice mvp = new VolumePrice();
                mvp.volume = rd.Next(1, mustToSell * mustMore);
                if (realQuoteBuy.Length == 0)
                    return null;

                mvp.price = realQuoteBuy[0].price;
                return mvp;
            }
            catch
            {
                return null;
            }
        }

        void OrderSplit(List<Order> orderList)
        {
            // 清空记录
            orderLimitBuys.Clear();
            orderLimitSells.Clear();
            
            // 清空历史
            buyOrders.Clear();
            sellOrders.Clear();
            foreach (var ord in orderList)
            {
                if (ord.direction == Order.direction_BUY)
                {
                    buyOrders.Add(ord);
                }
                else
                {
                    sellOrders.Add(ord);
                }
            }
        }

        void cancelSurpOrder()
        {
            int Count = maxOrderCount / 2;
            Random rd = new Random();
            if(buyOrders.Count > Count)
            {
                int cancelCount = buyOrders.Count - Count;
                for(int i = 0; i < cancelCount; i++)
                {
                    int index = rd.Next(0, buyOrders.Count);
                    Order ord = buyOrders[index];
                    CancelOrder(ord.orderId);
                    buyOrders.RemoveAt(index);
                }
            }

            if(sellOrders.Count > Count)
            {
                int cancelCount = sellOrders.Count - Count;
                for (int i = 0; i < cancelCount; i++)
                {
                    int index = rd.Next(0, sellOrders.Count);
                    Order ord = sellOrders[index];
                    CancelOrder(ord.orderId);
                    sellOrders.RemoveAt(index);
                }
            }
        }

        void cancelSurpOrder(int _cancelCount)
        {
            int cel = _cancelCount;
            int bcnt = buyOrders.Count;
            int scnt = sellOrders.Count;
            if (bcnt >= scnt)
            {
                if(cel > buyOrders.Count )
                {
                    cel = buyOrders.Count;   
                }
                Random rd = new Random();
                for (int i = 0; i < cel; i++)
                {
                    Order ord = buyOrders[0];
                    CancelOrder(ord.orderId);
                    buyOrders.RemoveAt(0);
                }
            }
            else if(bcnt < scnt)
            {
                if (cel > sellOrders.Count)
                {
                    cel = sellOrders.Count;
                }
                Random rd = new Random();
                for (int i = 0; i < cel; i++)
                {
                    Order ord = sellOrders[0];
                    CancelOrder(ord.orderId);
                    sellOrders.RemoveAt(0);
                }
            }
            if(bcnt == 0 && scnt == 0)
            {
                CancelLimit();
            }
        }


        public override void OnInit()
        {
            //查询所有未成交的报单
            List<Order> orders = getAllOrder(coinSymbol);
            if (orders != null && orders.Count > 0)
            {
                Print("获取到所有未成交报单信息!");

                //拆分报单
                OrderSplit(orders);
                //撤除沉余单
                cancelSurpOrder();

            }
            Print("策略启动成功！");
        }

        public override void OnTimer()
        {
            try
            {
                timerCount++;

                #region 委托单
                //开仓  空
                if (timerCount % 5 == 0)
                {
                    limitCount++;
                    VolumePrice vp = getSellPrice();
                    // 盘口单
                    if (vp != null)
                    {
                        Sell(vp.volume, vp.price);
                    }
                    // 成交单
                    vp = getMustBuyPrice();
                    if (vp != null)
                    {
                        Buy(vp.volume, vp.price, true);
                    }
                }

                //开仓  多
                if ((timerCount - 2) % 5 == 0)
                {
                    limitCount++;
                    VolumePrice vp = getBuyPrice();
                    if (vp != null)
                    {
                        Buy( vp.volume, vp.price);
                    }
                    //成交单
                    vp = getMustSellPrice();
                    if(vp != null)
                    {
                        Sell(vp.volume, vp.price, true);
                    }

                }

                #endregion

                if(limitCount % 3 == 0)
                {
                    cancelSurpOrder(1);
                }

                #region 撤除沉余单
                // 查询所有未成交订单
                if (timerCount % maxOrderCount == 0)
                {
                    List<Order> orders = getAllOrder(coinSymbol);
                    if (orders != null && orders.Count > 0)
                    {
                        //拆分报单
                        OrderSplit(orders);
                        //撤除沉余单
                        cancelSurpOrder();
                    }
                }
                #endregion
            }
            catch
            {

            }
        }

        int timerCount = 3;
        int limitCount = 0;

        //所有买单委托的列表
        List<Order> buyOrders = new List<Order>();
        //所有卖单委托的列表
        List<Order> sellOrders = new List<Order>();
    }
}
