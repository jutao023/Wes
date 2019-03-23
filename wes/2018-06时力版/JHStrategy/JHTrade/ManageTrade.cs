
using System;
using System.Collections.Generic;
using JiaoHui.JHData;


namespace JiaoHui.JHCore
{
    class ManageTrade : JHStrategy
    {
        Strategy strategy = null;

        #region 设置用户信息

        string trade_addr;
        string trade_port;

        string username;
        string password;

        string valsign;

        public void SetValSign(string _sign)
        {
            valsign = _sign;
        }

        public void SetUserInfo(string _user, string _pwd)
        {
            username = _user;
            password = _pwd;
        }

        public void SetTradeAddr(string _addr, string _port)
        {
            trade_addr = _addr;
            trade_port = _port;
        }
        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strag"></param>
        public ManageTrade(Strategy strag)
        {
            strategy = strag;
        }

        #region 请求信息
        /// <summary>
        /// 释放连接
        /// </summary>
        public void ForJHTradeFreeClient()
        {
            try
            {
                ForFreeClient();
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
            }
        }
        /// <summary>
        /// 验证特征码
        /// </summary>
        /// <param name="strVal">特征码</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeValidateSign(string strVal, string strTradeNo)
        {
            try
            {
                return ForValidateSign(strVal, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        public bool ForJHTradeLogin(string strEmpAcct, string strPwd, string strLocalMac, string strLocalIP, string strTradeNo)
        {
            try
            {

                return ForLogin(strEmpAcct, strPwd, strLocalMac, strLocalIP, strTradeNo);
            }
            catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="strOldPwd">旧密码</param>
        /// <param name="strNewPwd">新密码</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeModifyPwd(string strOldPwd, string strNewPwd, string strTradeNo)
        {
            try
            {
                return ForModifyPwd(strOldPwd, strNewPwd, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 资金查询请求
        /// </summary>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeFundRequest(string strTradeNo)
        {
            try
            {
                return ForFundRequest(strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
        /// <param name="_order_ip">（*下单必填）申报IP地址</param>
        /// <param name="_strTradeNo">交易流水号</param>
        /// <returns></returns>
        public bool ForJHTradeOrderfRequest(string _contract_id, string _buyorsell, string _offset_flag, string _trade_type,
                                     string _is_deposit, string _order_price, string _order_qtt, string _strTradeNo)
        {
            Orderf orf = new Orderf();
            orf.contract_id = _contract_id;
            orf.buyorsell = _buyorsell;
            orf.offset_flag = _offset_flag;
            orf.trade_type = _trade_type;
            orf.is_deposit = _is_deposit;
            orf.order_price = _order_price;
            orf.order_qtt = _order_qtt;
            orf.order_ip = JHUtil.GetNaviteIP();
            try
            {
                return ForOderfRequest(orf, _strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForOderfRequest(pOrder, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
            Cancel_Order cord = new Cancel_Order();

            cord.trade_mode = _trade_node;
            cord.order_id = _order_id;
            cord.contract_id = _contract_id;
            cord.cancel_oper = _cancel_oper;
            cord.cancel_ip = JHUtil.GetNaviteIP();
            try
            {
                return ForCancelOrder(cord, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForCancelOrder(pCancel, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForReceiptsListRequest(strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForDealfListRequest(strContractId, strBuyOrSell, strGtDealId, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 委托查询请求
        /// </summary>
        /// <param name="strContractId">合同编码（可以为空，表示查全部合同）</param>
        /// <param name="strBuyOrSell">买卖方向（可以为空，表示查全部方向）</param>
        /// <param name="strOrderStatus">报单状态（0: 全部或空查询 1: 查可撤）</param>
        /// <param name="strGtOrderId">查询超过order_id的委托(可以为空)</param>
        /// <param name="strOffsetFlag">开平仓标记 0或空 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）</param>
        /// <param name="strTradeType">申报类型 0或空 不限 1市价 2限价</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeOrderfListRequest(string strContractId, string strBuyOrSell,
                                         string strOrderStatus, string strGtOrderId, string strOffsetFlag,
                                         string strTradeType, string strTradeNo)
        {
            try
            {
                return ForOrderfListRequest(strContractId, strBuyOrSell, strOrderStatus, strGtOrderId, strOffsetFlag, strTradeType, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
        public bool ForJHTradeSubsfListRequest(string strContractId, string strBuyOrSell, string strTradeNo)
        {
            try
            {
                return ForSubsfListRequest(strContractId, strBuyOrSell, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForJHTradeFundInOutListRequest(strInorout, strBegin, strEnd, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
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
                return ForFundInOutApply(strInorout, strAmount, strFundPwd, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 前后台心跳包
        /// </summary>
        /// <param name="strClientTime">客户端时间（会原样返回）</param>
        /// <param name="strTradeNo">交易流水号，会原样反回到应答包包头的TradeNo字段</param>
        /// <returns></returns>
        public bool ForJHTradeHeartMsg(string strClientTime, string strTradeNo)
        {
            try
            {
                return ForHeartMsg(strClientTime, strTradeNo);
            }
            catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易请求, ex.ToString());
                return false;
            }
        }
        #endregion

        #region 回报信息

        public override void OnForConnectinit(string strVer)
        {
            try
            {
                strategy.OnJHTradeForConnectinit(strVer);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnForValSign(Trade_Head msgHead)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeForValSign(msgHead);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnForLogin(Trade_Head msgHead)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeForLogin(msgHead);
            }catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnLogout(Trade_Head msgHead)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnModifyPassword(Trade_Head msgHead)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
            }
            catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnHeartMsg(Trade_Head msgHead, string strClientTime)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeHeartMsg(msgHead, strClientTime);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnSessionFail(Trade_Head msgHead)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeSessionFail(msgHead);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnForErro(string strErro)
        {
            try
            {
                strategy.OnJHTradeError(strErro);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        /*******************错误信息应答*****************/

        public override void OnForAssoInfo(Trade_Head msgHead, Asso_Info pAssoInfo)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeForAssoInfo(msgHead, pAssoInfo);
            }catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnGoodsList(Trade_Head msgHead, List<Goods_List> pGoods_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeGoodsList(msgHead, pGoods_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnContractList(Trade_Head msgHead, List<Contract_List> pContract_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeContractList(msgHead, pContract_List);
            }catch (Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnMarketStatus(Trade_Head msgHead, Market_Status pMarketStatus)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeMarketStatus(msgHead, pMarketStatus);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        public override void OnCurrRate(Trade_Head msgHead, List<Curr_Rate> pCurr_Rate_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeCurrRate(msgHead, pCurr_Rate_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnTradeReturn(Trade_Head msgHead, List<Trade_Return> pTrade_Return_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeTradeReturn(msgHead, pTrade_Return_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }
        /****************以上登陆成功后会自动推送*************/

        public override void OnBulletin(Trade_Head msgHead, Bulletin pBulletin)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeBulletin(msgHead, pBulletin);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnFund(Trade_Head msgHead, Fund pFund)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeFund(msgHead, pFund);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnFundInOutApply(Trade_Head msgHead, Fund_Inout pStruct)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeFundInOutApply(msgHead, pStruct);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnFundInOutList(Trade_Head msgHead, List<Fund_Inout> pFund_Inout_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeFundInOutList(msgHead, pFund_Inout_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnDealfList(Trade_Head msgHead, List<Dealf_List> pDealf_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeDealfList(msgHead, pDealf_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnCancelOrder(Trade_Head msgHead, Cancel_Order pCancel)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeCancelOrder(msgHead, pCancel);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnOrder(Trade_Head msgHead, Orderf pOrder)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeOrder(msgHead, pOrder);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnOrderfList(Trade_Head msgHead, List<Orderf> pOrderf_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeOrderfList(msgHead, pOrderf_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnReceiptsList(Trade_Head msgHead, List<Receipts_List> pReceipts_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeReceiptsList(msgHead, pReceipts_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        public override void OnSubsfList(Trade_Head msgHead, List<Subsf_List> pSubsf_List)
        {
            if (strategy == null)
                return;
            try
            {
                strategy.OnJHTradeHead(msgHead);
                strategy.OnJHTradeSubsfList(msgHead, pSubsf_List);
            }catch(Exception ex)
            {
                strategy.OnExceptionMessage(EnumStateFlag.交易回报, ex.ToString());
            }
        }

        #endregion
    }
}
