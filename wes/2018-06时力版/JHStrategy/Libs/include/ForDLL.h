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
	//������Ϣ
	//@param strErro ��������,��ForDataType.h��CForDict��
	virtual void OnForErro(string strErro) = 0;

	//��ʼ������
	//@param strVer ����Э��汾��
	virtual void OnForConnectinit(string strVer) = 0;

	//��¼����Ҫdelete��msgHead��
	//@param strDesc ��������
	//@param msgHead ��ͷ
	virtual void OnForLogin(trade_head * msgHead) = 0;

	//�ǳ�(��Ҫdelete��msgHead,�ǳ��޻ر���Ϣ���ú���Ŀǰ���ᱻ����)
	//@param msgHead ��ͷ
	virtual void OnLogout(trade_head * msgHead) = 0;


	//������У��(��Ҫdelete��msgHead,)
	//@param msgHead ��ͷ
	virtual void OnForValSign(trade_head * msgHead) = 0;

	//SESSIONʧЧ(��Ҫdelete��msgHead)
	//@param msgHead ��ͷ
	// msgHead->return_code:	8172	���ڳ�ʱ��û�в������Զ��ж����ӣ������µ�¼
	//							8173	���ӳ�ʱ�������µ�¼
	//							8174	���ʺ��ظ���¼���߳�
	//							8175	��̨����ǿ���߳�
	//							8176	�ͻ����ʻ������쳣
	virtual void OnSessionFail(trade_head * msgHead) = 0;

	//��Ա��Ϣ(��Ҫdelete��msgHead��pAssoInfo)
	//@param msgHead ��ͷ
	//@param pAssoInfo ��Ա��Ϣ�ṹ��
	virtual void OnForAssoInfo(trade_head * msgHead, asso_info* pAssoInfo) = 0;

	//��ͬ�б�(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector ��ͬ��Ϣvectorָ��
	virtual void OnContractList(trade_head * msgHead, vector<contract_list*>* pVector) = 0;

	//��Ʒ�б�(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector ��Ʒ�б�vectorָ��
	virtual void OnGoodsList(trade_head * msgHead, vector<goods_list*>* pVector) = 0;

	//������(��Ҫdelete��msgHead)
	//@param msgHead ��ͷ
	//@param strClientTime ��������ʱ�ͻ���ʱ��
	virtual void OnHeartMsg(trade_head * msgHead, string strClientTime) = 0;

	//�г�״̬(��Ҫdelete��msgHead��pMarketStatus)
	//@param msgHead ��ͷ
	//@param pMarketStatus �г�״̬�ṹ��
	virtual void OnMarketStatus(trade_head * msgHead, market_status* pMarketStatus) = 0;

	//���ֻ���(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector ����vectorָ��
	virtual void OnCurrRate(trade_head * msgHead, vector<curr_rate*>* pVector) = 0;

	//���׻ر�(��Ҫdelete��msgHead��pTradeReturn)
	//@param msgHead ��ͷ
	//@param pVector vectorָ��
	virtual void OnTradeReturn(trade_head * msgHead, vector<trade_return*>* pVector) = 0;
	
	//����(��Ҫdelete��msgHead��pBulletin)
	//@param msgHead ��ͷ
	//@param pBulletin �ṹ��ָ��
	virtual void OnBulletin(trade_head * msgHead, bulletin* pBulletin) = 0;

	//�����޸�(��Ҫdelete��msgHead)
	//@param msgHead ��ͷ
	virtual void OnModifyPassword(trade_head * msgHead) = 0;
	
	//�ʽ��ѯ(��Ҫdelete��msgHead��pFund)
	//@param msgHead ��ͷ
	//@param pFund �ʽ�ṹ��ָ��
	virtual void OnFund(trade_head * msgHead, fund* pFund) = 0;

	//�µ�Ӧ��(��Ҫdelete��msgHead��pOrder)
	//@param msgHead ��ͷ
	//@param pOrder �ṹ��ָ��
	virtual void OnOrder(trade_head * msgHead, orderf* pOrder) = 0;

	//�ֵ���ѯ(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector �ֵ�vectorָ��
	virtual void OnReceiptsList(trade_head * msgHead, vector<receipts_list*>* pVector) = 0;

	//����Ӧ��(��Ҫdelete��msgHead��pCancel)
	//@param msgHead ��ͷ
	//@param pCancel �ṹ��ָ��
	virtual void OnCancelOrder(trade_head * msgHead, cancel_order* pCancel) = 0;

	//�ɽ���ѯ(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pFund vectorָ��
	virtual void OnDealfList(trade_head * msgHead, vector<dealf_list*>* pVector) = 0;
	
	//ί�в�ѯ(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector vectorָ��
	virtual void OnOrderfList(trade_head * msgHead, vector <orderf*>* pVector) = 0;
	
	//�ֲֻ���(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector vectorָ��
	virtual void OnSubsfList(trade_head * msgHead, vector <subsf_list*>* pVector) = 0;

	//������ѯ(��Ҫdelete��msgHead��pVector)
	//@param msgHead ��ͷ
	//@param pVector vectorָ��
	virtual void OnFundInOutList(trade_head * msgHead, vector <fund_inout*>* pVector) = 0;

	//���������(��Ҫdelete��msgHead��pStruct)
	//@param msgHead ��ͷ
	//@param pStruct �ṹ��ָ��
	virtual void OnFundInOutApply(trade_head * msgHead, fund_inout* pStruct) = 0;
	

public:
	
	//��������
	//@param strServerIP ������IP
	//@param strServerPort �������˿�
	bool ForConnect(string strServerIP, string strServerPort);

	//�ͷ�����
	void ForFreeClient();

	//��֤������
	//@param strVal ������
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForValidateSign(string strVal, string strTradeNo = "");

	//��¼
	//@param strEmpAcct �ʺ�
	//@param strPwd ����
	//@param strLocalMac ����mac
	//@param strLocalIP ����IP
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForLogin(string strEmpAcct, string strPwd, string strLocalMac, string strLocalIP, string strTradeNo = "");

	//�˳���¼
	//@param strPwd ����
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForLogout(string strPwd, string strTradeNo = "");

	//ǰ��̨������
	//@param strClientTime �ͻ���ʱ�䣨��ԭ�����أ�
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForHeartMsg(string strClientTime, string strTradeNo = "");

	//�޸�����
	//@param strOldPwd ������
	//@param strNewPwd ������
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForModifyPwd(string strOldPwd, string strNewPwd, string strTradeNo = "");

	//�ʽ��ѯ����
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForFundRequest(string strTradeNo = "");

	//�µ�����
	//@param pOrder �����ṹ��ָ��
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForOderfRequest(orderf* pOrder, string strTradeNo = "");

	//�ֵ���ѯ����
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForReceiptsListRequest(string strTradeNo = "");

	//��������
	//@param pCancel �����ṹ��ָ��
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForCancelOrder(cancel_order* pCancel,string strTradeNo = "");

	//�ɽ���ѯ����
	//@param strContractId ��ͬ���루����Ϊ�գ���ʾ��ȫ����ͬ��
	//@param strBuyOrSell �������򣨿���Ϊ�գ���ʾ��ȫ������
	//@param strGtDealId ��ѯ����deal_id�ĳɽ�����Ϣ(����Ϊ��)
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForDealfListRequest(string strContractId = "", string strBuyOrSell = "", string strGtDealId = "", string strTradeNo = "");

	//ί�в�ѯ����
	//@param strContractId ��ͬ���루����Ϊ�գ���ʾ��ȫ����ͬ��
	//@param strBuyOrSell �������򣨿���Ϊ�գ���ʾ��ȫ������
	//@param strOrderStatus ����״̬��0: ȫ����ղ�ѯ 1: ��ɳ���
	//@param strGtOrderId ��ѯ����order_id��ί��(����Ϊ��)
	//@param strOffsetFlag ��ƽ�ֱ�� 0��� 1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת��
	//@param strTradeType �걨���� 0��� ���� 1�м� 2�޼�
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForOrderfListRequest(string strContractId = "", string strBuyOrSell = "", string strOrderStatus = "", string strGtOrderId = "", string strOffsetFlag = "", string strTradeType = "", string strTradeNo = "");

	//�ֲֲ�ѯ����
	//@param strContractId ��ͬ���루����Ϊ�գ���ʾ��ȫ����ͬ��
	//@param strBuyOrSell �������򣨿���Ϊ�գ���ʾ��ȫ������
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForSubsfListRequest(string strContractId = "", string strBuyOrSell = "", string strTradeNo = "");

	//������ѯ����
	//@param strInorout ��/�����־��1�����2������
	//@param strBegin ���뿪ʼʱ��(yyyymmdd)
	//@param strEnd �������ʱ��(yyyymmdd)
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForFundInOutListRequest(string strInorout = "", string strBegin = "", string strEnd = "", string strTradeNo = "");

	//���������
	//@param strInorout ��/�����־��1�����2������
	//@param strAmount ���
	//@param strFundPwd ���������
	//@param strTradeNo ������ˮ�ţ���ԭ�����ص�Ӧ�����ͷ��TradeNo�ֶ�
	bool ForFundInOutApply(string strInorout, string strAmount, string strFundPwd, string strTradeNo = "");
public:
	CForClient();
	~CForClient();
private:

	CForAgent* _pForAgent;
};


#endif
