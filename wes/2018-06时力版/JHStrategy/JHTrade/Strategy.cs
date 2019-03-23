using System;
using System.Collections.Generic;
using System.Threading;
using JiaoHui.JHData;

namespace JiaoHui.JHCore
{
    public enum EnumBuySell
    {
        买入,
        卖出,
        查询全部
    }

    public enum EnumOpenClose
    {
        开仓_新订,
        平今,
        平昨,
        平仓_先订先转,
        平仓_转今优先,
        平仓_指定平仓
    }

    public class Strategy
    {

        // 构造函数
        public Strategy()
        {
            lastTradeHeartTime = GetTimestamp();
            lastMarketHeartTime = lastTradeHeartTime;
            httpMarket = new HttpMarket();

            thread = new Thread(new ParameterizedThreadStart(StrategyThread));
            thread.Start(this);
        }

        // 析构函数
        ~Strategy()
        {
            if (thread != null)
            {
                //对象结束 关闭线程
                thread.Abort();
            }
        }

        #region Strategy成员属性

        Int32 m_timer = 9999999;

        //交易端是否出错
        bool trade_Is_Error = false;
        //行情端是否出错
        bool market_Is_Error = false;
        //交易会话是否出错
        bool session_Is_Error = false;
        //交易是否登陆成功
        bool trade_login_ok = false;

        //保存交易端最后一次心跳时间
        Int32 lastTradeHeartTime = 0;
        //保持行情端最后一次心跳时间
        Int32 lastMarketHeartTime = 0;
        //行情服务器与本地时间差
        Int32 time_market_dif = 0;
        //交易服务器以本地时间差
        Int32 time_trade_dif = 0;

        // 交易状态: false 不可交易状态
        bool IsTradeNo = false;

        // 行情对象
        ManageMarket manageMarket = null;
        // 交易对象
        ManageTrade manageTrade = null;
        //历史行情
        HttpMarket httpMarket = null;

        //输出设备
        PrintMessage printMsg = null;
        //状态通知
        StateNotify stateNotify = null;

        //交易监管线程
        Thread thread = null;
        #endregion

        #region 线程监控模块
        public static void StrategyThread(Object _obj)
        {
            Strategy stag = (Strategy)_obj;

            if (stag.printMsg != null)
            {
                stag.printMsg.Print("启动监控线程 成功！");
            }

            Thread.Sleep(3000);

            for (; ; )
            {
                try
                {
                    lock (stag)
                    {
                        stag.OnTimer();
                    }
                    Thread.Sleep(2);
                }
                catch (JHTradeException ex)
                {
                    JHLog.forTradeLog(ex.ToString());
                    if (stag.printMsg != null)
                    {
                        stag.printMsg.Print("监控线程执行异常！message:" + ex.Message);
                        stag.printMsg.Print("重新启动监控线程 . . .");
                    }
                    stag.thread = new Thread(new ParameterizedThreadStart(StrategyThread));
                    stag.thread.Start(stag);
                    break;
                }catch(JHMarketException JM)
                {
                    JHLog.forTradeLog(JM.ToString());
                    if (stag.printMsg != null)
                    {
                        stag.printMsg.Print("监控线程执行异常！message:" + JM.Message);
                        stag.printMsg.Print("重新启动监控线程 . . .");
                    }
                    stag.thread = new Thread(new ParameterizedThreadStart(StrategyThread));
                    stag.thread.Start(stag);
                    break;
                }
                catch (Exception ex)
                {
                    JHLog.forTradeLog(ex.ToString());
                    stag.PrintLine("异常停止！" + ex.Message);
                    break;
                }
            }
        }

        #endregion

        #region 信息设置和获取
        string market_addr;
        string market_port;

        string trade_addr;
        string trade_port;

        string http_addr;
        string http_prot;

        string username;
        string password;

        /// <summary>
        /// 特征码
        /// </summary>
        string valsign;
        /// <summary>
        /// 合同ID
        /// </summary>
        string contractID;

        public string GetContractID()
        {
            return contractID;
        }

        public void SetContractID(string _contractId)
        {
            contractID = _contractId;
        }

        public void SetValSign(string _sign)
        {
            valsign = _sign;
        }

        public void SetUserInfo(string _user,string _pwd)
        {
            username = _user;
            password = _pwd;
        }

        public void SetTradeAddr(string _addr, string _port)
        {
            trade_addr = _addr;
            trade_port = _port;
        }

        public void SetMarketAddr(string _addr, string _port)
        {
            market_addr = _addr;
            market_port = _port;
        }

        public void SetHttpAddr(string _addr, string _port)
        {
            http_addr = _addr;
            http_prot = _port;
            httpMarket.SetHttp_Info(_addr, _port);
        }

        public Int32 GetTimestamp()
        {
            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            Int32 timestamp = Convert.ToInt32((DateTime.Now - dateStart).TotalSeconds);
            return timestamp;
        }
        public Int32 GetTimestamp(DateTime _date)
        {
            if (_date == null)
                return GetTimestamp();

            DateTime dateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            Int32 timestamp = Convert.ToInt32((_date - dateStart).TotalSeconds);
            return timestamp;
        }

        /// <summary>
        /// 设置定时器,设置成公会系统会调用 OnTimer();
        /// </summary>
        /// <param name="_second">设置定时器时间，以秒为单位</param>
        public void SetTimer(Int32 _second)
        {
            m_timer = _second;
        }
        /// <summary>
        /// 销毁定时器
        /// </summary>
        public void KillTimer()
        {
            m_timer = 9999999;
        }
        /// <summary>
        /// 设置一个输出设备
        /// </summary>
        /// <param name="pmsg"></param>
        public void SetPrintMessage(PrintMessage pmsg)
        {
            printMsg = pmsg;
        }
        /// <summary>
        /// 设置一个状态通知
        /// </summary>
        /// <param name="snt"></param>
        public void SetStateNotify(StateNotify snt)
        {
            stateNotify = snt;
        }

        #endregion

        #region OutPut One
        bool testOne = false;
        public void TestTick()
        {
            DateTime dtt = new DateTime(1970, 1, 1, 8, 0, 0);
            DateTime dtm = new DateTime(1970, 1, 1, 8, 0, 0);
            DateTime dtn = new DateTime(1970, 1, 1, 8, 0, 0);
            dtt = dtt.AddSeconds(lastTradeHeartTime);
            dtm = dtm.AddSeconds(lastMarketHeartTime);
            dtn = dtn.AddSeconds(GetTimestamp());

            string time_T = dtt.ToString();
            string time_M = dtm.ToString();
            string time_N = dtn.ToString();

            string json_T = "1099@{\"LastTime【交易】\":\""+time_T+"\",\"时差\":\""+time_trade_dif+"(秒)\",\"本地\"" +time_N+ "\"}";
            string json_M = "2099@{\"LastTime【行情】\":\""+time_M+"\",\"时差\":\""+time_market_dif+"(秒)\",\"本地\"" +time_N+ "\"}";

            PrintLine(json_T);
            PrintLine(json_M);

            testOne = true;
        }

        //打印信息
        public void PrintLine(string _msg)
        {
            if (_msg == null)
                return;
            if(printMsg != null)
            {
                printMsg.Print(_msg);
            }
        }

        public void PrintHead(Trade_Head msgHead, string _msg = "")
        {
            string msg = "code:" + msgHead.ReturnCode + ",desc:" + msgHead.ReturnDesc;
            PrintLine(_msg + ", " + msg);
        }
        #endregion

        /// <summary>
        /// 释放对象
        /// </summary>
        public void FreeObject()
        {
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                    thread = null;
                }

                if (manageMarket != null)
                {
                    manageMarket.ForFreeConnectMarket();
                    manageMarket = null;
                }

                if (manageTrade != null)
                {
                    //manageTrade.ForLogout(password, "");
                    manageTrade.ForFreeClient();
                    manageTrade = null;
                }
            }
            catch(Exception ex)
            {
                PrintLine("释放连接异常:" + ex.Message);
                JHLog.forTradeLog("释放连接异常:" + ex.ToString());
            }
        }

        // 启动交易
        public void InitInstance()
        {
            try
            {
                trade_login_ok = false;
                IsTradeNo = false;
                if (manageMarket != null)
                {
                    manageMarket.ForFreeConnectMarket();
                }
                manageMarket = new ManageMarket(this);
                bool IsConnect = manageMarket.ForConnectMarket(market_addr, int.Parse(market_port));
                if (IsConnect == false)
                {
                    manageMarket.ForMarketFreeConnect();
                    manageMarket = null;
                }
            }catch(Exception ex)
            {
                JHLog.forMarketLog("连接行情服务器异常！" + ex.ToString());
                throw new JHMarketException("连接行情服务器异常！");
            }
        }

        // 当前策略成功启动后会调用此函数
        public void OnInitInstance()
        {
            //设置登陆状态
            trade_login_ok = true;

            //每次重新链接登陆后调用
            OnRunStateSuccess();

            if (printMsg != null)
                printMsg.Print("策略启动成功");
            if (stateNotify != null)
            {
                stateNotify.OnNotify(this, NotifyCode.SRATEGY_INIT_SUCCESS);
            }
            //设置位可以交易状态
            IsTradeNo = true;

            //把当前异常状态设置位正常状态
            trade_Is_Error = false;
            session_Is_Error = false;
            market_Is_Error = false;

        }

        #region 下载行情数据
        /// <summary>
        /// 下载今日所有有效合同最新报价牌文件
        /// </summary>
        /// <returns></returns>
        public bool HttpDownLoadQuote()
        {
            return httpMarket.HttpDownLoadQuote(GetContractID(), username);
        }
        /// <summary>
        /// 回去报价牌信息(当日) ，调用此函数前必须先调用 bool HttpDownLoadToday()；函数下载数据。
        /// </summary>
        /// <param name="_contractID">合同ID：为空则获取所有行情，非空则获取指定行情</param>
        /// <returns></returns>
        public Tick GetTodayQuote()
        {
            return httpMarket.GetTodayQuote(GetContractID() , username);
        }

        /// <summary>
        /// 下载指定日期和合同的行情数据文件
        /// </summary>
        /// <param name="_contractID">有效的合同ID</param>
        /// <param name="_datetime">下载行情的日期</param>
        /// <returns></returns>
        public bool HttpDownLoadTick(DateTime _datetime)
        {
            return httpMarket.HttpDownLoadTick(GetContractID(), username, _datetime);
        }
        /// <summary>
        /// 获取指定时间和合同的历史行情，必须先调用 bool HttpDownLoadWas(string _contractID, DateTime _datetime)；下载数据。
        /// </summary>
        /// <returns></returns>
        public List<Tick> GetHostoryTick(string _contractID, DateTime _date)
        {
            return httpMarket.GetHostoryTick(_contractID, username , _date);
        }

        /// <summary>
        /// 获取实时报价牌行情
        /// </summary>
        /// <param name="_contractid"></param>
        /// <returns></returns>
        public Tick HttpGetRealTimeQuote()
        {
            return httpMarket.HttpGetRealTimeQuote(GetContractID());
        }
        /// <summary>
        /// 获取历史行情
        /// </summary>
        /// <param name="_contractID"></param>
        /// <param name="_datetime"></param>
        /// <returns></returns>
        public List<Tick> HttpGetHostoryTick(string _contractID, DateTime _datetime)
        {
            return httpMarket.HttpGetHostoryTick(_contractID, _datetime);
        }
        #endregion

        #region 自处理应答信息
        //行情接口端
        public void OnJHMarketConnectMarket()
        {
            if (printMsg != null)
            {
                printMsg.Print("链接行情服务器成功！正在进行登陆验证. . .");
            }
            //登陆行情服务器
            if (manageMarket != null)
            {
                bool IsMarketLogin = manageMarket.ForLogin(username, password, JHUtil.GetMacAddress());
                if(IsMarketLogin == false)
                {
                    manageMarket.ForMarketFreeConnect();
                    manageMarket = null;
                }
            }
        }
        public void OnJHMarketLogin(string svrTime)
        {
            if(svrTime == "")
            {
                if (stateNotify != null)
                {
                    stateNotify.OnNotify(this, NotifyCode.MARKET_TIME_ERROR);
                }
                return;
            }
            if(printMsg != null)
                printMsg.Print("登陆行情服务器 成功!");
            if(stateNotify != null)
            {
                stateNotify.OnNotify(this, NotifyCode.MARKET_LOGIN_OK);
            }
            //保存登陆时间
            lastMarketHeartTime = int.Parse(svrTime);
            time_market_dif = lastMarketHeartTime - GetTimestamp();
            if (manageTrade != null)
            {
                manageTrade.ForFreeClient();
                manageTrade = null;
            }

            manageTrade = new ManageTrade(this);
            manageTrade.SetTradeAddr(trade_addr, trade_port);
            manageTrade.SetUserInfo(username, password);
            manageTrade.SetValSign(valsign);
            //连接交易服务器
            bool mant = manageTrade.ForConnect(trade_addr, trade_port);
            if (mant == false)
            {
                manageTrade = null;
            }

        }

        //交易接口端
        public void OnJHTradeForConnectinit(string strVer)
        {
            if(printMsg != null)
            {
                printMsg.Print("链接交易服务器成功！正在进行特征码验证. . .");
            }
            //服务器连接成功后进行特征码验证
            bool validate = manageTrade.ForJHTradeValidateSign(valsign, "valsign");
            if(validate == false)
            {
                manageTrade.ForFreeClient();
                manageTrade = null;
                return;
            }
            OnTradeConnect();
        }
        public void OnJHTradeForValSign(Trade_Head msgHead)
        {
            if (printMsg != null)
            {
                printMsg.Print("验证特征码成功！正在进行登陆验证. . .");
            }
            //特征码验证成功后进行登陆
            bool rlogin = manageTrade.ForJHTradeLogin(username, password, JHUtil.GetMacAddress(), JHUtil.GetNaviteIP(), "login");
            if(rlogin == false)
            {
                manageTrade.ForFreeClient();
                manageTrade = null;
            }
        }
        public void OnJHTradeForLogin(Trade_Head msgHead)
        {
            if(msgHead.OperTime == "")
            {
                if (stateNotify != null)
                {
                    stateNotify.OnNotify(this, NotifyCode.TRADE_TIME_ERROR);
                }
                return;
            }
            string msg = "";
            bool brt = false;
            if (int.Parse(msgHead.ReturnCode) == 0)
            {
                msg = "登陆交易服务器成功! code:" + msgHead.ReturnCode + ",desc:" + msgHead.ReturnDesc;
            }else
            {
                brt = true;
                msg = "登陆交易服务器异常! code:" + msgHead.ReturnCode + ",desc:" + msgHead.ReturnDesc;
                JHLog.forTradeLog(msg);
            }
            PrintLine(msg);
            if (brt)
                return;

            DateTime servTime;
            //计算时间差
            servTime = Convert.ToDateTime(msgHead.OperTime);
            //保存服务器推送时间
            lastTradeHeartTime = GetTimestamp(servTime);
            //保持本地与服务器时间差
            time_trade_dif = lastTradeHeartTime - GetTimestamp();
            //通知准备工作已经完成
            OnInitInstance();
        }
        #endregion

        #region 异常或心跳处理
        public void OnExceptionMessage(EnumStateFlag sf, string _exMsg)
        {
            //写入日志
            if(sf == EnumStateFlag.行情请求 || sf == EnumStateFlag.行情回报)
            {
                JHLog.forMarketLog(_exMsg);
            }
            else if(sf == EnumStateFlag.交易请求 || sf == EnumStateFlag.交易回报)
            {
                JHLog.forTradeLog(_exMsg);
            }
            //打印到控制台
            if(printMsg != null)
            {
                printMsg.Print(_exMsg);
            }
        }

        /// <summary>
        /// 接收行情心跳测试包
        /// </summary>
        /// <param name="srvTime"></param>
        public void OnMarketHeartTest(Int32 srvTime)
        {
            market_Is_Error = false;
            lastMarketHeartTime = srvTime;
        }
        /// <summary>
        /// 交易接口心跳应答
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="strTime"></param>
        public void OnJHTradeHeartMsg(Trade_Head msgHead, string strTime)
        {
            if (strTime == "")
                return;
            trade_Is_Error = false;
            lastTradeHeartTime = int.Parse(strTime);
        }

        /// <summary>
        /// 交易接口发生错误情报后调用
        /// </summary>
        /// <param name="strErr">错误信息</param>
        public void OnJHTradeError(string strErr)
        {
            trade_Is_Error = true;
            IsTradeNo = false;
            if (printMsg != null)
            {
                printMsg.Print("交易接口发生错误! Message：" + strErr);
            }
            if(stateNotify != null)
            {
                stateNotify.OnNotify(this, NotifyCode.TRADE_RETURN_ERROR);
            }
        }
        /// <summary>
        /// 会话异常						
        /// </summary>
        /// <param name="msgHead">msgHead.return_code:
        /// 8172	由于长时间没有操作,自动中断连接，请重新登录。
        /// 8173	连接超时，请重新登录。
        /// 8174	该帐号重复登录被踢出。
        /// 8175	后台管理强制踢出。
        /// 8176	客户端帐户出现异常。
        /// </param>
        public void OnJHTradeSessionFail(Trade_Head msgHead)
        {
            session_Is_Error = true;
            IsTradeNo = false;
            if(printMsg != null)
            {
                printMsg.Print("交易接口会话异常! Code：" + msgHead.ReturnCode + ", Message：" + msgHead.ReturnDesc);
            }
            if(stateNotify != null)
            {
                stateNotify.OnNotify(this, NotifyCode.TRADE_SESSION_EXCEPTION);
            }
        }
        /// <summary>
        /// 行情异常
        /// </summary>
        /// <param name="strErrorMsg"></param>
        public void OnJHMarketError(string strErrorMsg)
        {
            if (strErrorMsg == null)
                return;
            int nd = strErrorMsg.IndexOf('@');
            if (nd > 0)
            {
                string ard = strErrorMsg.Substring(0, nd);
                if (ard == "error")
                {
                    market_Is_Error = true;
                    IsTradeNo = false;
                }
            }
            if (printMsg != null)
            {
                printMsg.Print(strErrorMsg);
            }
            if (stateNotify != null && market_Is_Error)
            {
                stateNotify.OnNotify(this, NotifyCode.MARKET_RETURN_ERROR);
            }
        }

        /// <summary>
        /// 收到任意回报时调用
        /// </summary>
        /// <param name="msgHead"></param>
        public void OnJHTradeHead(Trade_Head msgHead)
        {
            lastTradeHeartTime = GetTimestamp() + time_trade_dif;
            trade_Is_Error = false;
//            DateTime servTime;
//            servTime = Convert.ToDateTime(msgHead.OperTime);
//            lastTradeHeartTime = GetTimestamp(servTime);
        }
        #endregion

        #region 行情回调函数
        /// <summary>
        /// 登陆成功后行情自动实时推送
        /// </summary>
        /// <param name="tick"></param>
        public void OnJHMarketTick(Tick tick)
        {
            if(IsTradeNo && tick.contractID == contractID)
            {
                OnTick(tick);
                if(testOne)
                {
                    DateTime dtd = new DateTime(1970, 1, 1, 8, 0, 0);
                    dtd = dtd.AddSeconds(tick.timestamp);
                    string Info = "2004@";
                    double pri = tick.newPrice;
                    double lastPrice = pri / 10000;
                    Info += "{\"最新价\":\""+lastPrice+"\",\"时间\":\""+dtd.TimeOfDay.ToString()+"\"}";
                    PrintLine(Info);
                    testOne = false;
                }
            }
        }
        #endregion

        #region 交易请求模块
        /// <summary>
        /// 资金查询请求
        /// </summary>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeFundRequest(string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeFundRequest(strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 报单函数
        /// </summary>
        /// <param name="_buysell">（*下单必填）买卖方向(1 - 买入，2 - 卖出)</param>
        /// <param name="_openclose">（*下单必填）开平仓标记:1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；
        ///                                                5、平仓（转今优先）；6、指定仓平仓；</param>
        /// <param name="_price">委托价格</param>
        /// <param name="_volume">委托数量</param>
        /// <param name="_tradeno">交易流水</param>
        /// <returns></returns>
        public bool ForLimitOrder(EnumBuySell _buysell, EnumOpenClose _openclose, int _price, int _volume, string _contractId, string _tradeno)
        {
            Orderf orf = new Orderf();
            orf.contract_no = contractID;
            orf.contract_id = _contractId;
            orf.is_deposit = "1";
            orf.trade_type = "1";
            //买卖方向
            if(_buysell == EnumBuySell.买入)
            {
                orf.buyorsell = "1";
            }else
            {
                orf.buyorsell = "2";
            }
            //开平标志
            if (_openclose == EnumOpenClose.开仓_新订)
            {
                orf.offset_flag = "1";
            }else if(_openclose == EnumOpenClose.平今)
            {
                orf.offset_flag = "2";
            }else if(_openclose == EnumOpenClose.平昨)
            {
                orf.offset_flag = "3";
            }else if(_openclose == EnumOpenClose.平仓_先订先转)
            {
                orf.offset_flag = "4";
            }else if(_openclose == EnumOpenClose.平仓_转今优先)
            {
                orf.offset_flag = "5";
            }else
            {
                orf.offset_flag = "6";
            }

            orf.order_price = _price + "";
            orf.order_qtt = _volume + "";
            try
            {
                if (manageTrade != null)
                    return manageTrade.ForJHTradeOrderfRequest(orf, _tradeno);
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="_contract_id">（*下单必填）合同ID</param>
        /// <param name="_buyorsell">（*下单必填）买卖方向(1 - 买入，2 - 卖出)</param>
        /// <param name="_offset_flag">（*下单必填）开平仓标记:1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；</param>
        /// <param name="_trade_type">（*下单必填）申报类型 1、限价；2、市价；3、止损限价；4、止损市价；5、均价</param>
        /// <param name="_is_deposit">（*下单必填）担保方式 1定金；6仓单</param>
        /// <param name="_order_price">（*下单必填）申报价格</param>
        /// <param name="_order_qtt">（*下单必填）申报数量</param>
        /// <param name="_strTradeNo">交易流水号</param>
        /// <returns></returns>
        public bool ForJHTradeOrderfRequest(string _contract_id, string _buyorsell, string _offset_flag, string _trade_type,
             string _is_deposit, string _order_price, string _order_qtt, string _strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeOrderfRequest(_contract_id, _buyorsell, _offset_flag, _trade_type,
                                               _is_deposit, _order_price, _order_qtt, _strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        // 报单字段说明
        // order_local_id;//前端报单号，由API调用ForOderfRequest()后生成， 20位(时间+6位顺序号 yyyyMMddHHmmss######)
        // contract_id;//
        // buyorsell;//
        // offset_flag;//
        // trade_type;//
        // is_deposit;//
        // stop_price;//止损价格
        // order_price;//
        // order_qtt;//
        // order_ip;//
        // detail_seq;//指定仓平仓仓位明细号
        // remark;//点差 备注   
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="pOrder">报单结构体</param>
        /// <param name="strTradeNo">交易流水号</param>
        /// <returns></returns>
        public bool ForJHTradeOrderfRequest(Orderf pOrder, string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeOrderfRequest(pOrder, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="_trade_node">（*撤单必填）交易模式 F－远期做市商 FG - 交收撤单</param>
        /// <param name="_order_id">（*撤单必填）报单号</param>
        /// <param name="_contract_id">（*撤单必填）合同编码</param>
        /// <param name="_cancel_oper">（*撤单必填）撤单人（登录帐号）</param>
        /// <param name="_cancel_ip">（*撤单必填）撤单IP地址 </param>
        /// <param name="strTradeNo">交易流水号</param>
        /// <returns></returns>
        public bool ForJHTradeCancelOrder(string _trade_node, string _order_id, string _contract_id,
                                   string _cancel_oper, string strTradeNo)
        {
            try
            {


                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeCancelOrder(_trade_node, _order_id, _contract_id,
                                                 _cancel_oper, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        //撤单字段说明
        // trade_mode;//（*撤单必填）交易模式 F－远期做市商 FG - 交收撤单
        // order_no;//下单编号
        // order_id;//（*撤单必填）报单号
        // cancel_time;//下单时间
        // ret_cancel_status;//撤单状态：  0 成功， 其它失败
        // ret_desc;//撤单状态描述
        // contract_id;//（*撤单必填）合同编码
        // cancel_oper;//（*撤单必填）撤单人（登录帐号）
        // cancel_ip;//（*撤单必填）撤单IP地址 
        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="pCancel"></param>
        /// <param name="strTradeNo"></param>
        /// <returns></returns>
        public bool ForJHTradeCancelOrder(Cancel_Order pCancel, string strTradeNo)
        {
            try
            {
                if (pCancel == null)
                    return false;

                Cancel_Order cancel_order = pCancel;
                cancel_order.cancel_ip = JHUtil.GetNaviteIP();
                cancel_order.cancel_oper = username;

                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeCancelOrder(cancel_order, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 仓单查询请求
        /// </summary>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeReceiptsListRequest(string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeReceiptsListRequest(strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 成交查询请求
        /// </summary>
        /// <param name="strContractId">合同编码（可以为空，表示查全部合同）</param>
        /// <param name="strBuyOrSell">买卖方向（可以为空，表示查全部方向）</param>
        /// <param name="strGtDealId">查询超过deal_id的成交新消息(可以为空)</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeDealfListRequest(string strContractId, string strBuyOrSell, string strGtDealId, string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeDealfListRequest(strContractId, strBuyOrSell, strGtDealId, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 委托查询请求
        /// </summary>
        /// <param name="strContractId">合同编码（可以为空，表示查全部合同）</param>
        /// <param name="_buysell">买卖方向（可以为空，表示查全部方向）</param>
        /// <param name="strOrderStatus">报单状态（0: 全部或空查询 1: 查可撤）</param>
        /// <param name="strGtOrderId">查询超过order_id的委托(可以为空)</param>
        /// <param name="_openclose">开平仓标记 0或空 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）</param>
        /// <param name="strTradeType">申报类型 0或空 不限 1市价 2限价</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeOrderfListRequest(string strContractId, string _buysell,
                                         string strOrderStatus, string strGtOrderId, string _openclose,
                                         string strTradeType, string strTradeNo)
        {
            try
            {
                //买卖方向
                string strBuyOrSell = _buysell;

                //开平标志
                string strOffsetFlag = _openclose;

                if (manageTrade != null && trade_login_ok)
                {
                    return manageTrade.ForJHTradeOrderfListRequest(strContractId, strBuyOrSell, strOrderStatus,
                                                     strGtOrderId, strOffsetFlag, strTradeType, strTradeNo);
                }
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 持仓查询请求
        /// </summary>
        /// <param name="strContractId">合同编码（可以为空，表示查全部合同）</param>
        /// <param name="strBuyOrSell">买卖方向（可以为空，表示查全部方向）</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeSubsfListRequest(string strContractId, EnumBuySell _buysell, string strTradeNo)
        {
            try
            {
                string strBuyOrSell = "";
                //买卖方向
                if (_buysell == EnumBuySell.买入)
                {
                    strBuyOrSell = "1";
                }
                else if(_buysell == EnumBuySell.卖出)
                {
                    strBuyOrSell = "2";
                }else
                {
                    strBuyOrSell = "";
                }

                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeSubsfListRequest(strContractId, strBuyOrSell, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 出入金查询请求
        /// </summary>
        /// <param name="strInorout">入/出金标志（1：入金，2：出金）</param>
        /// <param name="strBegin">申请开始时间(yyyymmdd)</param>
        /// <param name="strEnd">申请结束时间(yyyymmdd)</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeFundInOutListRequest(string strInorout, string strBegin, string strEnd, string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeFundInOutListRequest(strInorout, strBegin, strEnd, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 出入金请求
        /// </summary>
        /// <param name="strInorout">入/出金标志（1：入金，2：出金）</param>
        /// <param name="strAmount">金额</param>
        /// <param name="strFundPwd">出入金密码</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeFundInOutApply(string strInorout, string strAmount, string strFundPwd, string strTradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                    return manageTrade.ForJHTradeFundInOutApply(strInorout, strAmount, strFundPwd, strTradeNo);
                return false;
            }catch
            {
                return false;
            }
        }
        /// <summary>
        /// 心跳测试
        /// </summary>
        /// <param name="strClientTime"></param>
        /// <param name="TradeNo"></param>
        /// <returns></returns>
        public bool ForJHTradeHeartMsg(string strClientTime, string TradeNo)
        {
            try
            {
                if (manageTrade != null && trade_login_ok)
                {
                    return manageTrade.ForJHTradeHeartMsg(strClientTime, TradeNo);
                }
                return false;
            }catch(Exception ex)
            {
                throw new JHTradeException(ex.Message);
            }finally
            {
                
            }
        }
        #endregion

        #region 交易回调函数

        /// <summary>
        /// 会员信息
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pAssoInfo"></param>
        virtual public void OnJHTradeForAssoInfo(Trade_Head msgHead, Asso_Info pAssoInfo) { }
        
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pGoods_List"></param>
        virtual public void OnJHTradeGoodsList(Trade_Head msgHead, List<Goods_List> pGoods_List) { }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pContract_List"></param>
        virtual public void OnJHTradeContractList(Trade_Head msgHead, List<Contract_List> pContract_List) { }

        /// <summary>
        /// 市场状态
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pMarketStatus"></param>
        virtual public void OnJHTradeMarketStatus(Trade_Head msgHead, Market_Status pMarketStatus) { }

        /// <summary>
        /// 汇率信息
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pCurr_Rate_List"></param>
        virtual public void OnJHTradeCurrRate(Trade_Head msgHead, List<Curr_Rate> pCurr_Rate_List) { }
        
        /// <summary>
        /// 交易回报
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pTrade_Return_List"></param>
        virtual public void OnJHTradeTradeReturn(Trade_Head msgHead, List<Trade_Return> pTrade_Return_List) { }

        /*************************/
        
        /// <summary>
        /// 资金查询
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pFund"></param>
        virtual public void OnJHTradeFund(Trade_Head msgHead, Fund pFund) { }

        /// <summary>
        /// 交易公告
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pBulletin"></param>
        virtual public void OnJHTradeBulletin(Trade_Head msgHead, Bulletin pBulletin) { }

        /// <summary>
        /// 出入金申请应答
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pStruct"></param>
        virtual public void OnJHTradeFundInOutApply(Trade_Head msgHead, Fund_Inout pStruct) { }

        /// <summary>
        /// 出入金查询应答
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pFund_Inout_List"></param>
        virtual public void OnJHTradeFundInOutList(Trade_Head msgHead, List<Fund_Inout> pFund_Inout_List) { }

        /// <summary>
        /// 撤单应答
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pCancel"></param>
        virtual public void OnJHTradeCancelOrder(Trade_Head msgHead, Cancel_Order pCancel) { }

        /// <summary>
        /// 成交查询
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pDealf_List"></param>
        virtual public void OnJHTradeDealfList(Trade_Head msgHead, List<Dealf_List> pDealf_List) { }

        /// <summary>
        /// 下单应答
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pOrder"></param>
        virtual public void OnJHTradeOrder(Trade_Head msgHead, Orderf pOrder) { }

        /// <summary>
        /// 委托查询
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pOrderf_List"></param>
        virtual public void OnJHTradeOrderfList(Trade_Head msgHead, List<Orderf> pOrderf_List) { }

        /// <summary>
        /// 仓单查询（教汇没有仓单所以此函数无效）
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pReceipts_List"></param>
        virtual public void OnJHTradeReceiptsList(Trade_Head msgHead, List<Receipts_List> pReceipts_List) { }

        /// <summary>
        /// 持仓汇总
        /// </summary>
        /// <param name="msgHead"></param>
        /// <param name="pSubsf_List"></param>
        virtual public void OnJHTradeSubsfList(Trade_Head msgHead, List<Subsf_List> pSubsf_List) { }

        #endregion


        virtual public void OnInit()
        {

        }

        virtual public void OnTradeConnect()
        {

        }

        virtual public void OnRunStateSuccess()
        {

        }

        virtual public void OnTick(Tick tick)
        {

        }

        virtual public void OnExit()
        {

        }

        virtual public void OnTimer()
        {

        }

    }
}
