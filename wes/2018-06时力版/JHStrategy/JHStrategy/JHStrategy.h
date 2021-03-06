#pragma once
#ifndef _JHSTRATEGY_DLL
#define _JHSTRATEGY_DLL

#include "ForDLL.h"
#include "JHDataType.h"
#pragma comment(lib,"ForDLL.lib")

#include <iostream> 
#include <string>
#include <cliext/adapter>  
#include <cliext/vector>
#include "JHUtils.h"


using namespace std;
using namespace System;
using namespace System::Collections::Generic;
using namespace JiaoHui::JHData;

namespace JiaoHui {

	namespace JHCore {

		public ref class JHStrategy
		{
		public:
			//建立连接
			//@param strServerIP 服务器IP
			//@param strServerPort 服务器端口
			bool ForConnect(String^ strServerIP, String^ strServerPort);

			//释放连接
			void ForFreeClient();

			//验证特征码
			//@param strVal 特征码
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForValidateSign(String^ strVal, String^ strTradeNo);

			//登录
			//@param strEmpAcct 帐号
			//@param strPwd 密码
			//@param strLocalMac 本地mac
			//@param strLocalIP 本地IP
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForLogin(String^ strEmpAcct, String^ strPwd, String^ strLocalMac, String^ strLocalIP, String^ strTradeNo);

			//退出登录
			//@param strPwd 密码
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForLogout(String^ strPwd, String^ strTradeNo);

			//前后台心跳包
			//@param strClientTime 客户端时间（会原样返回）
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForHeartMsg(String^ strClientTime, String^ strTradeNo);

			//修改密码
			//@param strOldPwd 旧密码
			//@param strNewPwd 新密码
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForModifyPwd(String^ strOldPwd, String^ strNewPwd, String^ strTradeNo);

			//资金查询请求
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForFundRequest(String^ strTradeNo);

			//下单请求
			//@param pOrder 报单结构体指针
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForOderfRequest(Orderf^ pOrder, String^ strTradeNo);

			//仓单查询请求
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForReceiptsListRequest(String^ strTradeNo);

			//撤单请求
			//@param pCancel 撤单结构体指针
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForCancelOrder(Cancel_Order^ pCancel, String^ strTradeNo);

			//成交查询请求
			//@param strContractId 合同编码（可以为空，表示查全部合同）
			//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
			//@param strGtDealId 查询超过deal_id的成交新消息(可以为空)
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForDealfListRequest(String^ strContractId, String^ strBuyOrSell, String^ strGtDealId, String^ strTradeNo);

			//委托查询请求
			//@param strContractId 合同编码（可以为空，表示查全部合同）
			//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
			//@param strOrderStatus 报单状态（0: 全部或空查询 1: 查可撤）
			//@param strGtOrderId 查询超过order_id的委托(可以为空)
			//@param strOffsetFlag 开平仓标记 0或空 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）
			//@param strTradeType 申报类型 0或空 不限 1市价 2限价
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForOrderfListRequest(String^ strContractId, String^ strBuyOrSell, String^ strOrderStatus, String^ strGtOrderId, String^ strOffsetFlag, String^ strTradeType, String^ strTradeNo);

			//持仓查询请求
			//@param strContractId 合同编码（可以为空，表示查全部合同）
			//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForSubsfListRequest(String^ strContractId, String^ strBuyOrSell, String^ strTradeNo);

			//出入金查询请求
			//@param strInorout 入/出金标志（1：入金，2：出金）
			//@param strBegin 申请开始时间(yyyymmdd)
			//@param strEnd 申请结束时间(yyyymmdd)
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForFundInOutListRequest(String^ strInorout, String^ strBegin, String^ strEnd, String^ strTradeNo);

			//出入金请求
			//@param strInorout 入/出金标志（1：入金，2：出金）
			//@param strAmount 金额
			//@param strFundPwd 出入金密码
			//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
			bool ForFundInOutApply(String^ strInorout, String^ strAmount, String^ strFundPwd, String^ strTradeNo);


		public:

			//错误消息
			//@param strErro 错误描述,见ForDataType.h中CForDict类
			virtual void OnForErro(String^ strErro) {};

			//初始化连接
			//@param strVer 网络协议版本号
			virtual void OnForConnectinit(String^ strVer) {};

			//@param strDesc 返回描述
			//@param msgHead 包头
			virtual void OnForLogin(Trade_Head^ msgHead) {};

			//@param msgHead 包头
			virtual void OnLogout(Trade_Head^ msgHead) {};


			//@param msgHead 包头
			virtual void OnForValSign(Trade_Head^ msgHead) {};

			//@param msgHead 包头
			// msgHead->return_code:	8172	由于长时间没有操作，自动中断连接，请重新登录
			//							8173	连接超时，请重新登录
			//							8174	该帐号重复登录被踢出
			//							8175	后台管理强制踢出
			//							8176	客户端帐户出现异常
			virtual void OnSessionFail(Trade_Head^ msgHead) {};

			//@param msgHead 包头
			//@param pAssoInfo 会员信息结构体
			virtual void OnForAssoInfo(Trade_Head^ msgHead, Asso_Info^ pAssoInfo) {};
//
			//@param msgHead 包头
			//@param pVector 合同信息vector指针
			virtual void OnContractList(Trade_Head^ msgHead, List<Contract_List^> ^pContract_List) {};
///
			//@param msgHead 包头
			//@param pVector 商品列表vector指针
			virtual void OnGoodsList(Trade_Head^ msgHead, List<Goods_List^> ^pGoods_List) {};
///
			//@param msgHead 包头
			//@param strClientTime 请求心跳时客户端时间
			virtual void OnHeartMsg(Trade_Head^ msgHead, String^ strClientTime) {};

			//@param msgHead 包头
			//@param pMarketStatus 市场状态结构体
			virtual void OnMarketStatus(Trade_Head^ msgHead, Market_Status^ pMarketStatus) {};
//
			//@param msgHead 包头
			//@param pVector 汇率vector指针
			virtual void OnCurrRate(Trade_Head^ msgHead, List<Curr_Rate^> ^pCurr_Rate_List) {};
///
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnTradeReturn(Trade_Head^ msgHead, List<Trade_Return^ > ^pTrade_Return_List) {};
///
			//@param msgHead 包头
			//@param pBulletin 结构体指针
			virtual void OnBulletin(Trade_Head^ msgHead, Bulletin^ pBulletin) {};
//
			//@param msgHead 包头
			virtual void OnModifyPassword(Trade_Head^ msgHead) {};

			//@param msgHead 包头
			//@param pFund 资金结构体指针
			virtual void OnFund(Trade_Head^ msgHead, Fund^ pFund) {};
//
			//@param msgHead 包头
			//@param pOrder 结构体指针
			virtual void OnOrder(Trade_Head^ msgHead, Orderf^ pOrder) {};
//
			//@param msgHead 包头
			//@param pVector 仓单vector指针
			virtual void OnReceiptsList(Trade_Head^ msgHead, List<Receipts_List^> ^pReceipts_List) {};
///
			//@param msgHead 包头
			//@param pCancel 结构体指针
			virtual void OnCancelOrder(Trade_Head^ msgHead, Cancel_Order^ pCancel) {};
//
			//@param msgHead 包头
			//@param pFund vector指针
			virtual void OnDealfList(Trade_Head^ msgHead, List<Dealf_List^> ^pDealf_List) {};
///
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnOrderfList(Trade_Head^ msgHead, List<Orderf^> ^pOrderf_List) {};
///
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnSubsfList(Trade_Head^ msgHead, List<Subsf_List^> ^pSubsf_List) {};
///
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnFundInOutList(Trade_Head^ msgHead, List<Fund_Inout^> ^pFund_Inout_List) {};
//
			//@param msgHead 包头
			//@param pStruct 结构体指针
			virtual void OnFundInOutApply(Trade_Head^ msgHead, Fund_Inout^ pStruct) {};

		public:

			JHStrategy();

			~JHStrategy();

		private:

			CForClient* m_ForClient;
		};
	}
}


#endif
