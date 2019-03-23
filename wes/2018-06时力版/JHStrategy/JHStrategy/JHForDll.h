#pragma once

#ifndef __CALL_JHFOR_DLL__
#define __CALL_JHFOR_DLL__

#include "ForDLL.h"
#include "JHDataType.h"
#include "JHStrategy.h"
#include <msclr\auto_gcroot.h>
#include <iostream>
#include <string>

using namespace std;

namespace JiaoHui {

	namespace JHCore {

		class JHForDll : public CForClient
		{
		public:
			//错误消息
			//@param strErro 错误描述,见ForDataType.h中CForDict类
			virtual void OnForErro(string strErro);

			//初始化连接
			//@param strVer 网络协议版本号
			virtual void OnForConnectinit(string strVer);

			//登录（需要delete掉msgHead）
			//@param strDesc 返回描述
			//@param msgHead 包头
			virtual void OnForLogin(trade_head * msgHead);

			//登出(需要delete掉msgHead,登出无回报信息，该函数目前不会被调用)
			//@param msgHead 包头
			virtual void OnLogout(trade_head * msgHead);


			//特征码校验(需要delete掉msgHead,)
			//@param msgHead 包头
			virtual void OnForValSign(trade_head * msgHead);

			//SESSION失效(需要delete掉msgHead)
			//@param msgHead 包头
			// msgHead->return_code:	8172	由于长时间没有操作，自动中断连接，请重新登录
			//							8173	连接超时，请重新登录
			//							8174	该帐号重复登录被踢出
			//							8175	后台管理强制踢出
			//							8176	客户端帐户出现异常
			virtual void OnSessionFail(trade_head * msgHead);

			//会员信息(需要delete掉msgHead、pAssoInfo)
			//@param msgHead 包头
			//@param pAssoInfo 会员信息结构体
			virtual void OnForAssoInfo(trade_head * msgHead, asso_info* pAssoInfo);

			//合同列表(需要delete掉msgHead、pVector)
			//@param msgHead 包头
			//@param pVector 合同信息vector指针
			virtual void OnContractList(trade_head * msgHead, vector<contract_list*>* pVector);
//
			//商品列表(需要delete掉msgHead、pVector)
			//@param msgHead 包头
			//@param pVector 商品列表vector指针
			virtual void OnGoodsList(trade_head * msgHead, vector<goods_list*>* pVector);
//
			//心跳包(需要delete掉msgHead)
			//@param msgHead 包头
			//@param strClientTime 请求心跳时客户端时间
			virtual void OnHeartMsg(trade_head * msgHead, string strClientTime);

			//市场状态(需要delete掉msgHead、pMarketStatus)
			//@param msgHead 包头
			//@param pMarketStatus 市场状态结构体
			virtual void OnMarketStatus(trade_head * msgHead, market_status* pMarketStatus);
//
			//币种汇率(需要delete掉msgHead、pVector)
			//@param msgHead 包头
			//@param pVector 汇率vector指针
			virtual void OnCurrRate(trade_head * msgHead, vector<curr_rate*>* pVector);
//
			//交易回报(需要delete掉msgHead、pTradeReturn)
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnTradeReturn(trade_head * msgHead, vector<trade_return*>* pVector);
//
			//公告(需要delete掉msgHead、pBulletin)
			//@param msgHead 包头
			//@param pBulletin 结构体指针
			virtual void OnBulletin(trade_head * msgHead, bulletin* pBulletin);
//
			//密码修改(需要delete掉msgHead)
			//@param msgHead 包头
			virtual void OnModifyPassword(trade_head * msgHead);

			//资金查询(需要delete掉msgHead和pFund)
			//@param msgHead 包头
			//@param pFund 资金结构体指针
			virtual void OnFund(trade_head * msgHead, fund* pFund);
//
			//下单应答(需要delete掉msgHead和pOrder)
			//@param msgHead 包头
			//@param pOrder 结构体指针
			virtual void OnOrder(trade_head * msgHead, orderf* pOrder);
//
			//仓单查询(需要delete掉msgHead和pVector)
			//@param msgHead 包头
			//@param pVector 仓单vector指针
			virtual void OnReceiptsList(trade_head * msgHead, vector<receipts_list*>* pVector);
//
			//撤单应答(需要delete掉msgHead和pCancel)
			//@param msgHead 包头
			//@param pCancel 结构体指针
			virtual void OnCancelOrder(trade_head * msgHead, cancel_order* pCancel);
//
			//成交查询(需要delete掉msgHead和pVector)
			//@param msgHead 包头
			//@param pFund vector指针
			virtual void OnDealfList(trade_head * msgHead, vector<dealf_list*>* pVector);
//
			//委托查询(需要delete掉msgHead和pVector)
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnOrderfList(trade_head * msgHead, vector <orderf*>* pVector);
//
			//持仓汇总(需要delete掉msgHead和pVector)
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnSubsfList(trade_head * msgHead, vector <subsf_list*>* pVector);
//
			//出入金查询(需要delete掉msgHead和pVector)
			//@param msgHead 包头
			//@param pVector vector指针
			virtual void OnFundInOutList(trade_head * msgHead, vector <fund_inout*>* pVector);
//
			//出入金申请(需要delete掉msgHead和pStruct)
			//@param msgHead 包头
			//@param pStruct 结构体指针
			virtual void OnFundInOutApply(trade_head * msgHead, fund_inout* pStruct);


		public:

			//@param gc_s 回掉的托管类对象
			JHForDll(gcroot<JHStrategy^> gc_s);

			//@ 无参构造
			JHForDll();

			//@ 析构
			~JHForDll();
		public:
			gcroot<JHStrategy^> m_Strategy;//托管类的指针

			//@param strategy 回掉的托管类对象
			//设置回调函数类对象
			void setM_Strategy(gcroot<JHStrategy^> strategy);

		};
	}
}


#endif