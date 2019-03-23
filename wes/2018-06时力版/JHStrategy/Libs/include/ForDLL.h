#pragma once
#ifndef __FOR_DLL__
#define __FOR_DLL__

#include "ForDataType.h"
#include <vector>
using namespace std;

class CForAgent;
class __declspec(dllexport) CForClient
{
public:
	//错误消息
	//@param strErro 错误描述,见ForDataType.h中CForDict类
	virtual void OnForErro(string strErro) = 0;

	//初始化连接
	//@param strVer 网络协议版本号
	virtual void OnForConnectinit(string strVer) = 0;

	//登录（需要delete掉msgHead）
	//@param strDesc 返回描述
	//@param msgHead 包头
	virtual void OnForLogin(trade_head * msgHead) = 0;

	//登出(需要delete掉msgHead,登出无回报信息，该函数目前不会被调用)
	//@param msgHead 包头
	virtual void OnLogout(trade_head * msgHead) = 0;


	//特征码校验(需要delete掉msgHead,)
	//@param msgHead 包头
	virtual void OnForValSign(trade_head * msgHead) = 0;

	//SESSION失效(需要delete掉msgHead)
	//@param msgHead 包头
	// msgHead->return_code:	8172	由于长时间没有操作，自动中断连接，请重新登录
	//							8173	连接超时，请重新登录
	//							8174	该帐号重复登录被踢出
	//							8175	后台管理强制踢出
	//							8176	客户端帐户出现异常
	virtual void OnSessionFail(trade_head * msgHead) = 0;

	//会员信息(需要delete掉msgHead、pAssoInfo)
	//@param msgHead 包头
	//@param pAssoInfo 会员信息结构体
	virtual void OnForAssoInfo(trade_head * msgHead, asso_info* pAssoInfo) = 0;

	//合同列表(需要delete掉msgHead、pVector)
	//@param msgHead 包头
	//@param pVector 合同信息vector指针
	virtual void OnContractList(trade_head * msgHead, vector<contract_list*>* pVector) = 0;

	//商品列表(需要delete掉msgHead、pVector)
	//@param msgHead 包头
	//@param pVector 商品列表vector指针
	virtual void OnGoodsList(trade_head * msgHead, vector<goods_list*>* pVector) = 0;

	//心跳包(需要delete掉msgHead)
	//@param msgHead 包头
	//@param strClientTime 请求心跳时客户端时间
	virtual void OnHeartMsg(trade_head * msgHead, string strClientTime) = 0;

	//市场状态(需要delete掉msgHead、pMarketStatus)
	//@param msgHead 包头
	//@param pMarketStatus 市场状态结构体
	virtual void OnMarketStatus(trade_head * msgHead, market_status* pMarketStatus) = 0;

	//币种汇率(需要delete掉msgHead、pVector)
	//@param msgHead 包头
	//@param pVector 汇率vector指针
	virtual void OnCurrRate(trade_head * msgHead, vector<curr_rate*>* pVector) = 0;

	//交易回报(需要delete掉msgHead、pTradeReturn)
	//@param msgHead 包头
	//@param pVector vector指针
	virtual void OnTradeReturn(trade_head * msgHead, vector<trade_return*>* pVector) = 0;
	
	//公告(需要delete掉msgHead、pBulletin)
	//@param msgHead 包头
	//@param pBulletin 结构体指针
	virtual void OnBulletin(trade_head * msgHead, bulletin* pBulletin) = 0;

	//密码修改(需要delete掉msgHead)
	//@param msgHead 包头
	virtual void OnModifyPassword(trade_head * msgHead) = 0;
	
	//资金查询(需要delete掉msgHead和pFund)
	//@param msgHead 包头
	//@param pFund 资金结构体指针
	virtual void OnFund(trade_head * msgHead, fund* pFund) = 0;

	//下单应答(需要delete掉msgHead和pOrder)
	//@param msgHead 包头
	//@param pOrder 结构体指针
	virtual void OnOrder(trade_head * msgHead, orderf* pOrder) = 0;

	//仓单查询(需要delete掉msgHead和pVector)
	//@param msgHead 包头
	//@param pVector 仓单vector指针
	virtual void OnReceiptsList(trade_head * msgHead, vector<receipts_list*>* pVector) = 0;

	//撤单应答(需要delete掉msgHead和pCancel)
	//@param msgHead 包头
	//@param pCancel 结构体指针
	virtual void OnCancelOrder(trade_head * msgHead, cancel_order* pCancel) = 0;

	//成交查询(需要delete掉msgHead和pVector)
	//@param msgHead 包头
	//@param pFund vector指针
	virtual void OnDealfList(trade_head * msgHead, vector<dealf_list*>* pVector) = 0;
	
	//委托查询(需要delete掉msgHead和pVector)
	//@param msgHead 包头
	//@param pVector vector指针
	virtual void OnOrderfList(trade_head * msgHead, vector <orderf*>* pVector) = 0;
	
	//持仓汇总(需要delete掉msgHead和pVector)
	//@param msgHead 包头
	//@param pVector vector指针
	virtual void OnSubsfList(trade_head * msgHead, vector <subsf_list*>* pVector) = 0;

	//出入金查询(需要delete掉msgHead和pVector)
	//@param msgHead 包头
	//@param pVector vector指针
	virtual void OnFundInOutList(trade_head * msgHead, vector <fund_inout*>* pVector) = 0;

	//出入金申请(需要delete掉msgHead和pStruct)
	//@param msgHead 包头
	//@param pStruct 结构体指针
	virtual void OnFundInOutApply(trade_head * msgHead, fund_inout* pStruct) = 0;
	

public:
	
	//建立连接
	//@param strServerIP 服务器IP
	//@param strServerPort 服务器端口
	bool ForConnect(string strServerIP, string strServerPort);

	//释放连接
	void ForFreeClient();

	//验证特征码
	//@param strVal 特征码
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForValidateSign(string strVal, string strTradeNo = "");

	//登录
	//@param strEmpAcct 帐号
	//@param strPwd 密码
	//@param strLocalMac 本地mac
	//@param strLocalIP 本地IP
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForLogin(string strEmpAcct, string strPwd, string strLocalMac, string strLocalIP, string strTradeNo = "");

	//退出登录
	//@param strPwd 密码
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForLogout(string strPwd, string strTradeNo = "");

	//前后台心跳包
	//@param strClientTime 客户端时间（会原样返回）
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForHeartMsg(string strClientTime, string strTradeNo = "");

	//修改密码
	//@param strOldPwd 旧密码
	//@param strNewPwd 新密码
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForModifyPwd(string strOldPwd, string strNewPwd, string strTradeNo = "");

	//资金查询请求
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForFundRequest(string strTradeNo = "");

	//下单请求
	//@param pOrder 报单结构体指针
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForOderfRequest(orderf* pOrder, string strTradeNo = "");

	//仓单查询请求
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForReceiptsListRequest(string strTradeNo = "");

	//撤单请求
	//@param pCancel 撤单结构体指针
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForCancelOrder(cancel_order* pCancel,string strTradeNo = "");

	//成交查询请求
	//@param strContractId 合同编码（可以为空，表示查全部合同）
	//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
	//@param strGtDealId 查询超过deal_id的成交新消息(可以为空)
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForDealfListRequest(string strContractId = "", string strBuyOrSell = "", string strGtDealId = "", string strTradeNo = "");

	//委托查询请求
	//@param strContractId 合同编码（可以为空，表示查全部合同）
	//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
	//@param strOrderStatus 报单状态（0: 全部或空查询 1: 查可撤）
	//@param strGtOrderId 查询超过order_id的委托(可以为空)
	//@param strOffsetFlag 开平仓标记 0或空 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）
	//@param strTradeType 申报类型 0或空 不限 1市价 2限价
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForOrderfListRequest(string strContractId = "", string strBuyOrSell = "", string strOrderStatus = "", string strGtOrderId = "", string strOffsetFlag = "", string strTradeType = "", string strTradeNo = "");

	//持仓查询请求
	//@param strContractId 合同编码（可以为空，表示查全部合同）
	//@param strBuyOrSell 买卖方向（可以为空，表示查全部方向）
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForSubsfListRequest(string strContractId = "", string strBuyOrSell = "", string strTradeNo = "");

	//出入金查询请求
	//@param strInorout 入/出金标志（1：入金，2：出金）
	//@param strBegin 申请开始时间(yyyymmdd)
	//@param strEnd 申请结束时间(yyyymmdd)
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForFundInOutListRequest(string strInorout = "", string strBegin = "", string strEnd = "", string strTradeNo = "");

	//出入金请求
	//@param strInorout 入/出金标志（1：入金，2：出金）
	//@param strAmount 金额
	//@param strFundPwd 出入金密码
	//@param strTradeNo 交易流水号，会原样反回到应答包包头的TradeNo字段
	bool ForFundInOutApply(string strInorout, string strAmount, string strFundPwd, string strTradeNo = "");
public:
	CForClient();
	~CForClient();
private:

	CForAgent* _pForAgent;
};


#endif
