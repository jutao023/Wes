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
			//������Ϣ
			//@param strErro ��������,��ForDataType.h��CForDict��
			virtual void OnForErro(string strErro);

			//��ʼ������
			//@param strVer ����Э��汾��
			virtual void OnForConnectinit(string strVer);

			//��¼����Ҫdelete��msgHead��
			//@param strDesc ��������
			//@param msgHead ��ͷ
			virtual void OnForLogin(trade_head * msgHead);

			//�ǳ�(��Ҫdelete��msgHead,�ǳ��޻ر���Ϣ���ú���Ŀǰ���ᱻ����)
			//@param msgHead ��ͷ
			virtual void OnLogout(trade_head * msgHead);


			//������У��(��Ҫdelete��msgHead,)
			//@param msgHead ��ͷ
			virtual void OnForValSign(trade_head * msgHead);

			//SESSIONʧЧ(��Ҫdelete��msgHead)
			//@param msgHead ��ͷ
			// msgHead->return_code:	8172	���ڳ�ʱ��û�в������Զ��ж����ӣ������µ�¼
			//							8173	���ӳ�ʱ�������µ�¼
			//							8174	���ʺ��ظ���¼���߳�
			//							8175	��̨����ǿ���߳�
			//							8176	�ͻ����ʻ������쳣
			virtual void OnSessionFail(trade_head * msgHead);

			//��Ա��Ϣ(��Ҫdelete��msgHead��pAssoInfo)
			//@param msgHead ��ͷ
			//@param pAssoInfo ��Ա��Ϣ�ṹ��
			virtual void OnForAssoInfo(trade_head * msgHead, asso_info* pAssoInfo);

			//��ͬ�б�(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector ��ͬ��Ϣvectorָ��
			virtual void OnContractList(trade_head * msgHead, vector<contract_list*>* pVector);
//
			//��Ʒ�б�(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector ��Ʒ�б�vectorָ��
			virtual void OnGoodsList(trade_head * msgHead, vector<goods_list*>* pVector);
//
			//������(��Ҫdelete��msgHead)
			//@param msgHead ��ͷ
			//@param strClientTime ��������ʱ�ͻ���ʱ��
			virtual void OnHeartMsg(trade_head * msgHead, string strClientTime);

			//�г�״̬(��Ҫdelete��msgHead��pMarketStatus)
			//@param msgHead ��ͷ
			//@param pMarketStatus �г�״̬�ṹ��
			virtual void OnMarketStatus(trade_head * msgHead, market_status* pMarketStatus);
//
			//���ֻ���(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector ����vectorָ��
			virtual void OnCurrRate(trade_head * msgHead, vector<curr_rate*>* pVector);
//
			//���׻ر�(��Ҫdelete��msgHead��pTradeReturn)
			//@param msgHead ��ͷ
			//@param pVector vectorָ��
			virtual void OnTradeReturn(trade_head * msgHead, vector<trade_return*>* pVector);
//
			//����(��Ҫdelete��msgHead��pBulletin)
			//@param msgHead ��ͷ
			//@param pBulletin �ṹ��ָ��
			virtual void OnBulletin(trade_head * msgHead, bulletin* pBulletin);
//
			//�����޸�(��Ҫdelete��msgHead)
			//@param msgHead ��ͷ
			virtual void OnModifyPassword(trade_head * msgHead);

			//�ʽ��ѯ(��Ҫdelete��msgHead��pFund)
			//@param msgHead ��ͷ
			//@param pFund �ʽ�ṹ��ָ��
			virtual void OnFund(trade_head * msgHead, fund* pFund);
//
			//�µ�Ӧ��(��Ҫdelete��msgHead��pOrder)
			//@param msgHead ��ͷ
			//@param pOrder �ṹ��ָ��
			virtual void OnOrder(trade_head * msgHead, orderf* pOrder);
//
			//�ֵ���ѯ(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector �ֵ�vectorָ��
			virtual void OnReceiptsList(trade_head * msgHead, vector<receipts_list*>* pVector);
//
			//����Ӧ��(��Ҫdelete��msgHead��pCancel)
			//@param msgHead ��ͷ
			//@param pCancel �ṹ��ָ��
			virtual void OnCancelOrder(trade_head * msgHead, cancel_order* pCancel);
//
			//�ɽ���ѯ(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pFund vectorָ��
			virtual void OnDealfList(trade_head * msgHead, vector<dealf_list*>* pVector);
//
			//ί�в�ѯ(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector vectorָ��
			virtual void OnOrderfList(trade_head * msgHead, vector <orderf*>* pVector);
//
			//�ֲֻ���(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector vectorָ��
			virtual void OnSubsfList(trade_head * msgHead, vector <subsf_list*>* pVector);
//
			//������ѯ(��Ҫdelete��msgHead��pVector)
			//@param msgHead ��ͷ
			//@param pVector vectorָ��
			virtual void OnFundInOutList(trade_head * msgHead, vector <fund_inout*>* pVector);
//
			//���������(��Ҫdelete��msgHead��pStruct)
			//@param msgHead ��ͷ
			//@param pStruct �ṹ��ָ��
			virtual void OnFundInOutApply(trade_head * msgHead, fund_inout* pStruct);


		public:

			//@param gc_s �ص����й������
			JHForDll(gcroot<JHStrategy^> gc_s);

			//@ �޲ι���
			JHForDll();

			//@ ����
			~JHForDll();
		public:
			gcroot<JHStrategy^> m_Strategy;//�й����ָ��

			//@param strategy �ص����й������
			//���ûص����������
			void setM_Strategy(gcroot<JHStrategy^> strategy);

		};
	}
}


#endif