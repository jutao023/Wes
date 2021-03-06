#include "stdafx.h"
#include "JHStrategy.h"
#include "JHForDll.h"

using namespace JiaoHui::JHUtils;

bool JiaoHui::JHCore::JHStrategy::ForConnect(String ^ strServerIP, String ^ strServerPort)
{
	std::string ip = JHUtil::clrString_To_stdString(strServerIP);
	std::string port = JHUtil::clrString_To_stdString(strServerPort);
	return m_ForClient->ForConnect(ip, port);
}

void JiaoHui::JHCore::JHStrategy::ForFreeClient()
{
	m_ForClient->ForFreeClient();
}

bool JiaoHui::JHCore::JHStrategy::ForValidateSign(String ^ strVal, String ^ strTradeNo)
{
	std::string val = JHUtil::clrString_To_stdString(strVal);
	std::string tradeNo = JHUtil::clrString_To_stdString(strTradeNo);
	return m_ForClient->ForValidateSign(val, tradeNo);
}

bool JiaoHui::JHCore::JHStrategy::ForLogin(String ^ strEmpAcct, String ^ strPwd, 
			     String ^ strLocalMac, String ^ strLocalIP, String ^ strTradeNo)
{
	std::string acct = JHUtil::clrString_To_stdString(strEmpAcct);
	std::string pwd = JHUtil::clrString_To_stdString(strPwd);
	std::string mac = JHUtil::clrString_To_stdString(strLocalMac);
	std::string ip = JHUtil::clrString_To_stdString(strLocalIP);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForLogin(acct, pwd, mac, ip, no);
}

bool JiaoHui::JHCore::JHStrategy::ForLogout(String ^ strPwd, String ^ strTradeNo)
{
	std::string pwd = JHUtil::clrString_To_stdString(strPwd);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForLogout(pwd, no);
}

bool JiaoHui::JHCore::JHStrategy::ForHeartMsg(String ^ strClientTime, String ^ strTradeNo)
{
	std::string time = JHUtil::clrString_To_stdString(strClientTime);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForHeartMsg(time, no);
}

bool JiaoHui::JHCore::JHStrategy::ForModifyPwd(String ^ strOldPwd, String ^ strNewPwd, String ^ strTradeNo)
{
	std::string oldpwd = JHUtil::clrString_To_stdString(strOldPwd);
	std::string newpwd = JHUtil::clrString_To_stdString(strNewPwd);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForModifyPwd(oldpwd, newpwd, no);
}

bool JiaoHui::JHCore::JHStrategy::ForFundRequest(String ^ strTradeNo)
{
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForFundRequest(no);
}

bool JiaoHui::JHCore::JHStrategy::ForOderfRequest(Orderf ^ pOrder, String ^ strTradeNo)
{
	
	orderf* of = JHUtil::to_cpp_orderf(pOrder);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);
	bool b = m_ForClient->ForOderfRequest(of, no);
	delete of;

	return b;
}

bool JiaoHui::JHCore::JHStrategy::ForReceiptsListRequest(String ^ strTradeNo)
{
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForReceiptsListRequest(no);
}

bool JiaoHui::JHCore::JHStrategy::ForCancelOrder(Cancel_Order ^ pCancel, String ^ strTradeNo)
{

	cancel_order* co = JHUtil::to_cpp_cancel_order(pCancel);
	std::string no = JHUtil::clrString_To_stdString(strTradeNo);
	bool b = m_ForClient->ForCancelOrder(co, no);
	delete co;

	return b;
}

bool JiaoHui::JHCore::JHStrategy::ForDealfListRequest(String ^ strContractId, String ^ strBuyOrSell,
													  String ^ strGtDealId, String ^ strTradeNo)
{

	std::string ContractId = JHUtil::clrString_To_stdString(strContractId);
	std::string buysell = JHUtil::clrString_To_stdString(strBuyOrSell);
	std::string GtDealId = JHUtil::clrString_To_stdString(strGtDealId);
	std::string No = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForDealfListRequest(ContractId, buysell, GtDealId, No);
}

bool JiaoHui::JHCore::JHStrategy::ForOrderfListRequest(String ^ strContractId, String ^ strBuyOrSell, 
													   String ^ strOrderStatus, String ^ strGtOrderId, 
													   String ^ strOffsetFlag, String ^ strTradeType,
													   String ^ strTradeNo)
{

	std::string ContractId = JHUtil::clrString_To_stdString(strContractId);
	std::string BuyOrSell = JHUtil::clrString_To_stdString(strBuyOrSell);
	std::string OrderStatus = JHUtil::clrString_To_stdString(strOrderStatus);
	std::string GtOrderId = JHUtil::clrString_To_stdString(strGtOrderId);
	std::string OffsetFlag = JHUtil::clrString_To_stdString(strOffsetFlag);
	std::string TradeType = JHUtil::clrString_To_stdString(strTradeType);
	std::string No = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForOrderfListRequest(ContractId, BuyOrSell, OrderStatus, GtOrderId, OffsetFlag, TradeType, No);
}

bool JiaoHui::JHCore::JHStrategy::ForSubsfListRequest(String ^ strContractId, String ^ strBuyOrSell,
													  String ^ strTradeNo)
{
	std::string ContractId = JHUtil::clrString_To_stdString(strContractId);
	std::string BuyOrSell = JHUtil::clrString_To_stdString(strBuyOrSell);
	std::string No = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForSubsfListRequest(ContractId, BuyOrSell, No);
}

bool JiaoHui::JHCore::JHStrategy::ForFundInOutListRequest(String ^ strInorout, String ^ strBegin,
														  String ^ strEnd, String ^ strTradeNo)
{
	std::string Inorout = JHUtil::clrString_To_stdString(strInorout);
	std::string Begin = JHUtil::clrString_To_stdString(strBegin);
	std::string End = JHUtil::clrString_To_stdString(strEnd);
	std::string No = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForFundInOutListRequest(Inorout, Begin, End, No);
}

bool JiaoHui::JHCore::JHStrategy::ForFundInOutApply(String ^ strInorout, String ^ strAmount,
													String ^ strFundPwd, String ^ strTradeNo)
{

	std::string Inorout = JHUtil::clrString_To_stdString(strInorout);
	std::string Amount = JHUtil::clrString_To_stdString(strAmount);
	std::string FundPwd = JHUtil::clrString_To_stdString(strFundPwd);
	std::string No = JHUtil::clrString_To_stdString(strTradeNo);

	return m_ForClient->ForFundInOutApply(Inorout, Amount, FundPwd, No);
}

JiaoHui::JHCore::JHStrategy::JHStrategy()
{
	m_ForClient = new JHForDll(this);
}

JiaoHui::JHCore::JHStrategy::~JHStrategy()
{
	if (m_ForClient)
	{
		delete m_ForClient;
	}
}

///////

