#pragma once

using namespace System;

namespace JiaoHui {

	namespace JHData
	{

		//����
		public ref struct Orderf
		{
			String^ order_local_id;//ǰ�˱����ţ���API����ForOderfRequest()�����ɣ� 20λ(ʱ��+6λ˳��� yyyyMMddHHmmss######)
			String^ contract_id;//��*�µ������ͬID
			String^ buyorsell;//��*�µ������������(1 - ���룬2 - ����)
			String^ offset_flag;//��*�µ������ƽ�ֱ��:1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�
			String^ trade_type;//��*�µ�����걨���� 1���޼ۣ�2���мۣ�3��ֹ���޼ۣ�4��ֹ���мۣ�5������
			String^ is_deposit;//��*�µ����������ʽ 1����6�ֵ�
			String^ stop_price;//ֹ��۸�
			String^ order_price;//��*�µ�����걨�۸�
			String^ order_qtt;//��*�µ�����걨����
			String^ order_ip;//��*�µ�����걨IP��ַ
			String^ detail_seq;//ָ����ƽ�ֲ�λ��ϸ��
			String^ remark;//��� ��ע

			String^ order_no;//�µ����
			String^ order_id;//����ID
			String^ order_time;//�µ�ʱ��
			String^ client_no;//�ͻ�����
			String^ contract_no;//��ͬ����
			String^ left_qtt;//������
			String^ cancel_qtt;//��������
			String^ operator_no;//����Ա����
			String^ status;//����״̬ 1��δ�ɽ���2�����ֳɽ���3���ɽ���4��������5�����г���
			String^ cancel_time;//����ʱ��
			String^ ret_order_status;//�µ�״̬
			String^ ret_order_status_desc;//�µ�״̬˵��
										 //�µ�״̬	�µ�״̬˵��
										 //- 1	ϵͳ�쳣
										 //0		�����ɹ�
										 //1		����ʧ��
										 //9		����Ȩ������
										 //10	�ֵ��������붩��
										 //11	�ֵ���������ת��
										 //12	���ķǽ���״̬
										 //13	�г�״̬����
										 //14	��Լ�ǽ���״̬
										 //16	��Լ״̬����
										 //20	��С�䶯��λ����
										 //26	���òֵ�����
										 //27	�޳ֲ�
										 //28	�ֵ��ֲֲ���
										 //29	����ֲֲ���
										 //37	��Լ���Ϊ��
										 //39	��ȡָ����Լ����������ʧ��
										 //80	��Լ�������
										 //502	�µ���������
										 //505	����ֵ�ʧ��
										 //512	�������ݴ���
										 //514	�걨���ʹ���
										 //519	δ��ʼ����Լ��Ϣ
										 //6016	�����۸����
										 //6032	�ֲֶ���ʧ��
										 //8036	�޽����̽���Ȩ��
										 //8050	�����������
										 //8051	��ƽ�ֱ�Ǵ���
										 //8053	�걨���ͻ�ƽ�ִ���
										 //8054	������ʽ����
										 //8055	���𵣱���ʽȨ������
										 //8056	�ֵ�������ʽȨ������
										 //8057	����ֵ�������ʽȨ������
										 //8058	����Ȩ������
										 //8059	ƽ��Ȩ������
										 //8060	��ƽ��Ȩ������
										 //8061	���𿪲�Ȩ������
										 //8063	�ֵ�����Ȩ������
										 //8297	������Լ�������
										 //8312	���������Ƕ���ת��ϵ����������
										 //8313	���ں�Լ��󱨵���
										 //8314	С�ں�Լ��С������
										 //8316	���Ǻ�Լ��С�䶯�۵�������
										 //8317	��ѯ�г��ֲ�������
										 //8318	��ѯ�����ֲ̳�������
										 //8319	�г��ֲ������ƣ���ǰ�ɱ�����
										 //8320	�����ֲ̳������ƣ���ǰ�ɱ�����
										 //8321	��������ֲ������ƣ���ǰ�ɱ�����
										 //8324	�������������󱨵�������
										 //8326	�������������С����������
										 //8327	�����������������С������
										 //8340	��ѯ��Ա������ʧ��
										 //8341	�����ڻ�ʧ��
										 //8367	���Ƿ���߼�
										 //8368	��������ͼ�
										 //8369	���۶���߼�
										 //8370	���۶���ͼ�
										 //8373	����ֲ���ϸʧ��
										 //8385	�г����м��̽���״̬
										 //8386	��Լ���м��̽���״̬
										 //8617	IP��ַ����ȷ
			String^ frz_ord_fund;//���ᱣ֤��
			String^ frz_poundary;//����������
			String^ roe;//����
			String^ taxrate;//˰��

			String^ order_type;//1,��ͨ����
							  // 2, �Կ���
							  // 3, ǿ��ת��
							  // 4, ǿ�Ƽ���
							  // 5, Э��ת��
							  // 6, Э�����
							  // 7, Э���Ʋ�
							  // 8, ���ն�ǿƽ
							  // 9, ���������ǿƽ
							  // 10, ����ҡ�ſ���
		};

		//����
		public ref struct Cancel_Order
		{
			String^ trade_mode;//��*�����������ģʽ F��Զ�������� FG - ���ճ���
			String^ order_no;//�µ����
			String^ order_id;//��*�������������
			String^ cancel_time;//�µ�ʱ��
			String^ ret_cancel_status;//����״̬��  0 �ɹ��� ����ʧ��
			String^ ret_desc;//����״̬����
			String^ contract_id;//��*���������ͬ����
			String^ cancel_oper;//��*������������ˣ���¼�ʺţ�
			String^ cancel_ip;//��*�����������IP��ַ 
		};

		//���ݰ�ͷ
		public ref struct Trade_Head
		{
			String^ TradeNo;//������ˮ��
			String^ ModuleName;//����ģ������
			String^ RequestType;//��������
			String^ ReturnCode;//�����루�����뼰�����μ�MktRetDefine.java��
			String^ ReturnDesc;//��������
			Int32 ListNum;// �����¼����
			Int32 Children;//���Ӱ���
			Int32 ChildIndex;//��ǰ�Ӱ�˳���
			String^ EmpAcct;//����Ա����
			String^ SessionId;//�ỰSession
			String^ OperTime;//����ʱ��
		};

		//��Ա��Ϣ����
		public ref struct Asso_Info
		{
			String^ cust_id;//������ID
			String^ associator_no;//��Ա����
			String^ associator_fullname;//��Աȫ��
			String^ compare_type;//0�������м�ܣ�����Ϊcenter_settle_bank�ṹ���е�bank_sett_id
			String^ contacter;//��ϵ��
			String^ telephone;//��ϵ�绰
			String^ acct_name;//�ʽ������ʻ�����(��ʹ��)
			String^ bank_name;//�ʽ������ʻ�������(��ʹ��)
			String^ bank_account;//�ʽ������ʻ��ʺ�(��ʹ��)
			String^ acct_contract;//�ʽ������ʻ���ϵ��ʽ(��ʹ��)
			String^ sales_name;//�г���Ա����
			String^ sales_telphone;//�г���Ա��ϵ�绰
			String^ is_mailing_invoices;//�Ƿ��ʼķ�Ʊ 0������;1������
			String^ contacter_addr;//�ռ��˵�ַ����ϵ�˵�ַ��
			String^ postcode;//�������루��Ա�������룩
			String^ password_type;//�ʽ��������ͣ�0û��ԭ�����ǿ���޸� 1��ԭ�����ǿ���޸� 2�����޸�
			String^ trade_role;//����������,������ɫ��
							  //201��һ�㽻����
							  //202���м���
							  //203��������
							  //204���ڻ���
							  //205��Ԥ����
							  //206��������
							  //207���ۺϽ�����
							  //208���ر�����
							  //����Զ��ŷָ�
			String^ Sign_status;//ǩԼ״̬ 1 - ��ǩԼ; 0 - δǩԼ
		};

		//��ͬ�б����
		public ref struct Contract_List
		{
			String^ trade_mode;//����ģʽ 1��ϳɽ� 2������
			String^ contract_id;//��ͬID
			String^ contract_no;//��ͬ���
			String^ contract_name;//��ͬ����
			String^ goods_id;//��Ʒ����
			String^ goods_name;//��Ʒ����
			String^ begin_day;//��ʼ������
			String^ trade_end_day;//�������
			String^ csg_begin_day;//��ʼ������
			String^ csg_end_day;//�������
			String^ buy_open_poundary;//��������
			String^ buy_open_poundary_flag;//�򷽿��������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ buy_today_poundary;//��ƽ��������
			String^ buy_today_poundary_flag;//��ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ buy_yesterday_poundary;//��ƽ��������
			String^ buy_yesterday_poundary_flag;//��ƽ�������ѵı�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ buy_level_poundary;//��ƽ��������
			String^ buy_level_poundary_flag;//��ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ sell_open_poundary;//����������
			String^ sell_open_poundary_flag;//�������������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ sell_today_poundary;//����ƽ��������
			String^ sell_today_poundary_flag;//����ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ sell_yesterday_discount;//����ƽ���������ۿ���
			String^ sell_yesterday_poundary;//����ƽ��������
			String^ sell_yesterday_poundary_flag;//����ƽ�������ѵı�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ sell_level_poundary;//����ƽ��������
			String^ sell_level_poundary_flag;//����ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
			String^ buy_deposite;//���򶨽�
			String^ buy_deposite_flag;//���򶨽��ʶ�����ʣ�ʹ��ʱ����100000
			String^ sell_deposite;//�����򶨽�
			String^ sell_deposite_flag;//�����򶨽��ʶ���ʣ�ʹ��ʱ����100000
			String^ min_diff_price;//��С�䶯��
			String^ max_qtt;//������󱨵���
			String^ min_qtt;//������С������
			String^ today_high_limit;//������޼�
			String^ today_low_limit;//������޼�
			String^ last_settle_price;//����
			String^ trans_cft;//ת��ϵ��, ����ת��ϵ��
			String^ curr_id;//���ұ��
			String^ curr_name;//��������
			String^ curr_unit;//���ҵ�λ
			String^ contract_type;//��ͬ����: 1��ͨ��2-���ڣ������ֻ�����4���ۺ�ͬ
			String^ min_apply_qtt;//��С�����걨��
			String^ permission_flag;//��ƽ��Ȩ��: 0 - ������; 1 - ֻ��; 2 - ֻƽ
			String^ roe;//��ͬ���� *100000
			String^ taxrate;//��ͬ˰�� *100000
			String^ is_binding;//Զ�������Ƿ�󶨾ټ��������������塢Ԥ����: 0 - δ��ȫ��; 1 - ��ȫ��
							  //���ۺ�Լ��0δҡ��; > 0��ҡ��
			String^ field48;//���������̺�ͬ,�������
			String^ field49;//���������̺�ͬ,���۵��
		};

		//��Ʒ��Ϣ����
		public ref struct Goods_List
		{
			String^ goods_id;//��Ʒ���
			String^ g_prop_id;//��Ʒ���Ա��
			String^ g_prop_name;//��Ʒ��������
			String^ g_prop_default;//��Ʒ����Ĭ��ֵ
		};

		//�г�״̬
		public ref struct Market_Status
		{
			String^ cur_status;//�г�״̬:1: ��ʼ��
							  // 5 : ����
							  // 10 : ���Ͼ���
							  // 15 : ����
							  // 20 : ��ͣ
							  // 25 : ���д���
							  // 30 : �м����걨
							  // 35 : ΥԼ�϶�
							  // 40 : ���մ��
							  // 45 : ����
							  // 50 : ����׼��
							  // 55 : ���㿪ʼ
							  // 60 : �������
							  // 65 : �ȴ�����ȷ��
							  // 70 : ����ȷ��
							  // 0 : ����
			String^ cur_trade_day;//��ǰ������
		};

		//���ֻ���
		public ref struct Curr_Rate
		{
			String^ curr_id;//���ұ��
			String^ curr_name;//��������
			String^ curr_unit;//���ҵ�λ
			String^ curr_ab;//������д
			String^ roe;//����
			String^ settle_day;//������
			String^ operator_no;//����Ա
			String^ operate_time;//����ʱ��
		};

		//���׻ر�
		public ref struct Trade_Return
		{
			String^ return_seq;//�ر�˳���
			String^ return_type;//�ر�����:
							   // 	1 - ���ױ����ɽ��ر���
							   // 	2 - ���ױ�������֪ͨ��
							   // 	3 - �����걨����֪ͨ��
							   // 	4 - �����걨����ر���
							   // 	5 - ���ǿ�Ƴ���֪ͨ
							   // 	6 - OTC��Լ������Ϣ
			String^ return_title;//�ر�����
			String^ return_cnt;//�ر�����
							  //�ر����ͣ���1���ױ����ɽ��ر��������ݸ�ʽ��1��ʶ | �ɽ���ID | �ɽ����� | ί�е�ID | ί�е��� | ��ͬID | ��ͬ��� | �ɽ��۸� | �ɽ����� | ת�ü۲� | ��ƽ�ֱ��(1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�) | ��������(1 - ��ͨ���ף�2 - �Կ��֣�3 - ǿ��ת�ã�4 - ǿ�Ƽ��֣�5 - Э��ת�ã�6 - Э����֣�7 - Э���Ʋ֣�8 - ���ն�ǿƽ��9 - ���������ǿƽ��10 - ����ҡ�ſ���) | �ر�����
							  //�ر����ͣ���2���ױ�������֪ͨ������5���ǿ�Ƴ���֪ͨ�������ݸ�ʽ��2��ʶ | ί�е�ID | ί�е��� | �������� | �ر�����
			String^ deal_id;//�ɽ���ID
			String^ deal_no;// �ɽ�����
			String^ status;//�ر�״̬
			String^ create_time;//�ر�����ʱ��
			String^ Send_Times;//���ʹ���
			String^ trade_day;//��ǰ������
		};

		//����
		public ref struct Bulletin
		{
			String^ bulletin_seq;//����˳���
			String^ type;//��������1 ���� 2˽��
			String^ title;//�������
			String^ content;//��������
			String^ content_type;//������������
								// 	1, ��ͨ����(�����)
								// 	2, ��ͨ����(������)
								// 	3, ǿ��ƽ���µ�����
								// 	4, ��������������,
								// 	5, ӯ������������,
								// 	6, �Զ�ӯ������������,
								// 	7, ǿ�ƽ��չ���,
								// 	8, ǿ�ƻع�����
			String^ create_time;//���淢��ʱ��
			String^ trans_string;//3ǿ��ƽ����Ϣ��:order_id|order_no|contract_id|contract_no|buyorsell|offset_flag|is_deposit|order_price|order_qtt|left_qtt|status|order_time|order_type
								//4��5��������ӯ����������Ϣ��order_id | order_no | contract_id | contract_no | buyorsell | offset_flag | is_deposit | order_price | order_qtt | left_qtt | status | order_time | co_id | ret_code(0�����ɹ�) | trade_type
								//6�Զ�ֹӯֹ�𴥷���Ϣ����plo_no | plo_id | ORDER_LOCAL_ID | contract_id | contract_no | buyorsell | offset_flag | is_deposit | profit_price | loss_price | order_qtt | order_ip | valid_date | status | add_time | activity_time | pl_id | ret_code(0�����ɹ�)
			String^ trade_day;//��ǰ������
		};

		//�ʽ���Ϣ
		public ref struct Fund
		{
			String^ avl_fund;//�����ʽ�
			String^ occp_deposit;//����ռ��
			String^ frz_ord_fund;//��������
			String^ frz_risk_fund;//��ض���
			String^ frz_csg_fund;//��ض���
			String^ acct_balance;//����۲����ӯ����
			String^ avl_rcpt;//�����òֵ�
			String^ today_poundary;//����������
			String^ today_inout_fund;//���ճ����
			String^ today_in_fund;//�������
			String^ today_out_fund;//���ճ���
			String^ total_right;//Ȩ�棨Ȩ�棽�����ʽ𣫱�֤��ռ�ã���������+��ض���+���ն���+ABS��-����۲��
			String^ today_cny_balance;//����ƽ��ӯ������ƽ�ּۣ����ּۣ�������/˰��
			String^ risk_degree;//���ն�
			String^ rate_acct_balance;//����ӯ������˰����˰�Ķ���
			String^ max_can_out;//���ɳ����
			String^ position_profit;//�ֲ�ӯ��
			String^ floating_proft;//����ӯ��=�ֲ�ӯ��+����ӯ��
			String^ system_date;//�ʽ��ѯʱ���
			String^ frz_others;//��������(�ֻ�����)
			String^ last_avl_fund;//���տ���
		};

		//�ֵ��б�
		public ref struct Receipts_List
		{
			String^ rcpt_no;//�ֵ�����(��)
			String^ goods_id;//��Ʒ����
			String^ goods_name;//��Ʒ����
			String^ contract_id;//��ͬID
			String^ contract_no;//��ͬ����
			String^ trans_cft;//����ת��
			String^ rcpt_qtt;//����
			String^ avlb_qtt;//��������
			String^ frz_qtt;//��������
			String^ csg_qtt;//�ѽ�������
			String^ frz_csg_qtt;//���ն�������
			String^ frz_risk_qtt;//��������ֵ�����
			String^ loan_qtt;//��Ѻ��������
			String^ cancel_qtt;//ע������
			String^ in_storage_date;//�������(��)
		};

		//�ɽ��б�
		public ref struct Dealf_List
		{
			String^ deal_no;//�ɽ���
			String^ deal_id;//�ɽ�ID
			String^ order_no;//ί�е���
			String^ order_id;//ί�е�ID
			String^ opp_order_no;//���ֱ�����
			String^ deal_time;//�ɽ�ʱ��
			String^ client_no;//�ͻ�����
			String^ contract_id;//��ͬID
			String^ contract_no;//��ͬ����
			String^ buyorsell;//��������
			String^ offset_flag;//��ƽ������ 1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�
			String^ order_type;//�걨���� 1, ��ͨ���� 2, �Կ��� 3, ǿ��ת�� 4, ǿ�Ƽ��� 5, Э��ת�� 6, Э����� 7, Э���Ʋ� 8, ���ն�ǿƽ 9, ���������ǿƽ 10, ����ҡ�ſ���
			String^ is_deposit;//������ʽ  1����6�ֵ�
			String^ deal_price;//�ɽ��۸�
			String^ deal_qtt;// �ɽ�����
			String^ profit_loss;// ת�ü۲�
			String^ detail_seq;// ���˳���
		};

		//�ֲֲ�ѯ
		public ref struct Subsf_List
		{
			String^	contract_id;//��ͬID
			String^	contract_no;//��ͬ����
			String^	client_no;//�ͻ�����
			String^	buyorsell;//��������
			String^	dpst_total_qtt;//����ֲ�
			String^	dpst_amt;//ռ�ñ�֤���
			String^	rcpt_total_subs;//�ֵ��ֲ�
			String^	dpst_avg_price;//���𿪲־���
			String^	rcpt_avg_price;//�ֵ����־���
			String^	cnyable_qtt;//�ܿ�ת������
			String^	cnyable_qtt_today;//��ֿ�ת������
			String^	rcpt_cnyable_qtt;//�ֵ���ת������
			String^	rcpt_cnyable_qtt_today;//�ֵ���ֿ�ת������
			String^	initial_cost;//���ֳɱ�(������ֵ�ӯ������Ϊ���� + �ֵ��Ŀ��ֳɱ�)
			String^	position_cost;//�ֲֳɱ�(������ֵ�ӯ������Ϊ���� + �ֵ��ĳֲֳɱ�)
			String^	dpst_position_avg_price;//����ֲ־���
			String^	rctp_position_avg_price;//�ֵ��ֲ־���
			String^	position_profit;//�ֲ�ӯ��
			String^	mark_market_profit;//����ӯ��
			String^	floating_profit;//����ӯ��
			String^	roe;//����(ʹ��ʱ����100000)
			String^	rcpt_qtt_r;//���вֵ�������
			String^	lender_qtt_w;//�ڲֵ���
			String^	other_qtt;//���ʳֲ�����
			String^	frz_csg_qtt_d;//�����ն���
			String^	frz_csg_qtt_r;//�ֵ����ն���
		};

		//������ѯ
		public ref struct Fund_Inout
		{
			String^ inout_seq;//�����˳���
			String^ cust_no;//��Ա����
			String^ inorout;//������־: 1�����2������
			String^ amount;//���
			String^ pay_way;//֧����ʽ��5 �ֽ�; 6 ֧Ʊ; 7 ת��֧Ʊ; 8 ���; 9 ����; 10 ���; 100 ֧����; - 9 �ͻ��˴�WEB��ַΪ�ֶ�payment_no
			String^ bank_id;//������Ӧ���ĵĽ������б��
			String^ bank_name;//��������
			String^ bank_account;//Ʊ�ݶ�Ӧ�����ʺ�
			String^ payment_no;//����Ʊ�ݱ��;��pay_way = -9, ���ֶ�Ϊ������ַ
			String^ oper;//������
			String^ oper_time;//����ʱ��
			String^ auth;//����Ա
			String^ auth_date;//����ʱ��
			String^ status;//״̬: 1 �����; 2 ����; 10 ���д�����; 11 ���в���; 99 �����;	- 1 ȡ��; - 2��ɾ��;
		};




	}
}




