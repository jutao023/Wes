#include "stdafx.h"
#include "JHForDll.h"
#include "JHUtils.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace JiaoHui::JHUtils;
//空构造
JiaoHui::JHCore::JHForDll::JHForDll()
{
	m_Strategy = gcnew JHStrategy();
}

JiaoHui::JHCore::JHForDll::JHForDll(gcroot<JHStrategy^> gc_s)
{
	this->m_Strategy = gc_s;
}

JiaoHui::JHCore::JHForDll::~JHForDll()
{

}

//set方法
void JiaoHui::JHCore::JHForDll::setM_Strategy(gcroot<JHStrategy^> strategy)
{
	this->m_Strategy = strategy;
}

//回掉函数
void JiaoHui::JHCore::JHForDll::OnForErro(string strErro)
{
	m_Strategy->OnForErro(JHUtil::stdString_To_clrString(strErro));
}

//
void JiaoHui::JHCore::JHForDll::OnForConnectinit(string strVer)
{
	m_Strategy->OnForConnectinit(JHUtil::stdString_To_clrString(strVer));
}

//
void JiaoHui::JHCore::JHForDll::OnForLogin(trade_head * msgHead)
{
	Trade_Head ^ th = JHUtil::to_cs_Trade_Head(msgHead);
	m_Strategy->OnForLogin(th);

	delete th;
	delete msgHead;
}

//
void JiaoHui::JHCore::JHForDll::OnLogout(trade_head * msgHead)
{

	Trade_Head ^ th = JHUtil::to_cs_Trade_Head(msgHead);
	m_Strategy->OnLogout(th);

	delete th;
	delete msgHead;
}

//
void JiaoHui::JHCore::JHForDll::OnForValSign(trade_head * msgHead)
{
	Trade_Head ^ th = JHUtil::to_cs_Trade_Head(msgHead);
	m_Strategy->OnForValSign(th);

	delete th;
	delete msgHead;
}

//
void JiaoHui::JHCore::JHForDll::OnSessionFail(trade_head * msgHead)
{
	Trade_Head ^ th = JHUtil::to_cs_Trade_Head(msgHead);

	m_Strategy->OnSessionFail(th);

	delete th;
	delete msgHead;
}

//
void JiaoHui::JHCore::JHForDll::OnForAssoInfo(trade_head * msgHead, asso_info * pAssoInfo)
{

	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Asso_Info^ ai = JHUtil::to_cs_Asso_Info(pAssoInfo);

	m_Strategy->OnForAssoInfo(th, ai);

	delete th;
	delete ai;

	delete msgHead;
	delete pAssoInfo;
}

//
void JiaoHui::JHCore::JHForDll::OnContractList(trade_head * msgHead, vector<contract_list*>* pVector)
{
	
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Contract_List^>^ lcl = gcnew List<Contract_List^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Contract_List^ CL = JHUtil::to_cs_Contract_List(pVector->at(i));
		lcl->Add(CL);
		delete pVector->at(i);
	}

	m_Strategy->OnContractList(th, lcl);

	for(int i = 0 ; i < lcl->Count ; i++)
	{
		delete lcl[i];
	}
	delete th;
	delete lcl;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnGoodsList(trade_head * msgHead, vector<goods_list*>* pVector)
{
	
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Goods_List^>^ lgl = gcnew List<Goods_List^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Goods_List^ gl = JHUtil::to_cs_Goods_List(pVector->at(i));
		lgl->Add(gl);
		delete pVector->at(i);
	}
	
	m_Strategy->OnGoodsList(th, lgl);

	for (int i = 0; i < lgl->Count; i++)
	{
		delete lgl[i];
	}

	delete lgl;
	delete th;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnHeartMsg(trade_head * msgHead, string strClientTime)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	String^ cTime = JHUtil::stdString_To_clrString(strClientTime);

	m_Strategy->OnHeartMsg(th, cTime);

	delete th;

	delete msgHead;
}

void JiaoHui::JHCore::JHForDll::OnMarketStatus(trade_head * msgHead, market_status * pMarketStatus)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Market_Status^ ms = JHUtil::to_cs_Market_Status(pMarketStatus);

	m_Strategy->OnMarketStatus(th, ms);

	delete th;
	delete ms;

	delete msgHead;
	delete pMarketStatus;
}

void JiaoHui::JHCore::JHForDll::OnCurrRate(trade_head * msgHead, vector<curr_rate*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Curr_Rate^>^ lcr = gcnew List<Curr_Rate^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Curr_Rate^ cr = JHUtil::to_cs_Curr_Rate(pVector->at(i));
		lcr->Add(cr);
		delete pVector->at(i);
	}

	m_Strategy->OnCurrRate(th, lcr);

	for (int i = 0; i < lcr->Count; i++)
	{
		delete lcr[i];
	}

	delete lcr;
	delete th;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnTradeReturn(trade_head * msgHead, vector<trade_return*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Trade_Return^>^ ltr = gcnew List<Trade_Return^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Trade_Return^ tr = JHUtil::to_cs_Trade_Return(pVector->at(i));
		ltr->Add(tr);
		delete pVector->at(i);
	}
	m_Strategy->OnTradeReturn(th, ltr);

	for (int i = 0; i < ltr->Count; i++)
	{
		delete ltr[i];
	}
	delete th;
	delete ltr;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnBulletin(trade_head * msgHead, bulletin * pBulletin)
{
	
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Bulletin^ b = JHUtil::to_cs_Bulletin(pBulletin);

	m_Strategy->OnBulletin(th, b);

	delete th;
	delete b;

	delete msgHead;
	delete pBulletin;
}

void JiaoHui::JHCore::JHForDll::OnModifyPassword(trade_head * msgHead)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);

	m_Strategy->OnModifyPassword(th);

	delete th;

	delete msgHead;
}

void JiaoHui::JHCore::JHForDll::OnFund(trade_head * msgHead, fund * pFund)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Fund^ f = JHUtil::to_cs_Fund(pFund);

	m_Strategy->OnFund(th, f);

	delete th;
	delete f;

	delete msgHead;
	delete pFund;
}

void JiaoHui::JHCore::JHForDll::OnOrder(trade_head * msgHead, orderf * pOrder)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Orderf^ o = JHUtil::to_cs_Orderf(pOrder);
	
	m_Strategy->OnOrder(th, o);

	delete th;
	delete o;

	delete msgHead;
	delete pOrder;
}

void JiaoHui::JHCore::JHForDll::OnReceiptsList(trade_head * msgHead, vector<receipts_list*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Receipts_List^>^ lrl = gcnew List<Receipts_List^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Receipts_List^ rl = JHUtil::to_cs_Receipts_List(pVector->at(i));
		lrl->Add(rl);
		delete pVector->at(i);
	}
	m_Strategy->OnReceiptsList(th, lrl);

	for (int i = 0; i < lrl->Count; i++)
	{
		delete lrl[i];
	}
	delete th;
	delete lrl;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnCancelOrder(trade_head * msgHead, cancel_order * pCancel)
{

	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Cancel_Order^ co = JHUtil::to_cs_Cancel_Order(pCancel);

	m_Strategy->OnCancelOrder(th, co);

	delete th;
	delete co;

	delete msgHead;
	delete pCancel;
}

void JiaoHui::JHCore::JHForDll::OnDealfList(trade_head * msgHead, vector<dealf_list*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Dealf_List^>^ ldl = gcnew List<Dealf_List^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Dealf_List^dl = JHUtil::to_cs_Dealf_List(pVector->at(i));
		ldl->Add(dl);
		delete pVector->at(i);
	}

	m_Strategy->OnDealfList(th, ldl);
	
	for (int i = 0; i < ldl->Count; i++)
	{
		delete ldl[i];
	}
	delete th;
	delete ldl;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnOrderfList(trade_head * msgHead, vector<orderf*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Orderf^>^ lo = gcnew List<Orderf^>();
	for (size_t i = 0; i <pVector->size(); i++)
	{
		Orderf^ o = JHUtil::to_cs_Orderf(pVector->at(i));
		lo->Add(o);
		delete pVector->at(i);
	}

	m_Strategy->OnOrderfList(th, lo);

	for (int i = 0; i < lo->Count; i++)
	{
		delete lo[i];
	}
	delete th;
	delete lo;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnSubsfList(trade_head * msgHead, vector<subsf_list*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Subsf_List^>^ lsl = gcnew List<Subsf_List^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Subsf_List^ sl = JHUtil::to_cs_Subsf_List(pVector->at(i));
		lsl->Add(sl);
		delete pVector->at(i);
	}

	m_Strategy->OnSubsfList(th, lsl);

	for (int i = 0; i < lsl->Count; i++)
	{
		delete lsl[i];
	}
	delete th;
	delete lsl;


	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnFundInOutList(trade_head * msgHead, vector<fund_inout*>* pVector)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	List<Fund_Inout^>^ lfi = gcnew List<Fund_Inout^>();
	for (size_t i = 0; i < pVector->size(); i++)
	{
		Fund_Inout^ fi = JHUtil::to_cs_Fund_Inout(pVector->at(i));
		lfi->Add(fi);
		delete pVector->at(i);
	}

	m_Strategy->OnFundInOutList(th, lfi);

	for (int i = 0; i < lfi->Count; i++)
	{
		delete lfi[i];
	}
	delete th;
	delete lfi;

	delete msgHead;
	delete pVector;
}

void JiaoHui::JHCore::JHForDll::OnFundInOutApply(trade_head * msgHead, fund_inout * pStruct)
{
	Trade_Head^ th = JHUtil::to_cs_Trade_Head(msgHead);
	Fund_Inout^ fi = JHUtil::to_cs_Fund_Inout(pStruct);

	m_Strategy->OnFundInOutApply(th, fi);

	delete th;
	delete fi;

	delete msgHead;
	delete pStruct;
}
