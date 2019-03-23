#ifndef __FOR_DATA_TYPE__
#define __FOR_DATA_TYPE__

#include<string>
using namespace std;

//���ݰ�ͷ
typedef struct
{
	string TradeNo;//������ˮ��
	string ModuleName;//����ģ������
	string RequestType;//��������
	string ReturnCode;//�����루�����뼰�����μ�MktRetDefine.java��
	string ReturnDesc;//��������
	int ListNum;// �����¼����
	int Children;//���Ӱ���
	int ChildIndex;//��ǰ�Ӱ�˳���
	string EmpAcct;//����Ա����
	string SessionId;//�ỰSession
	string OperTime;//����ʱ��
}trade_head;

//�г�״̬
typedef struct
{
	string cur_status;//�г�״̬:1: ��ʼ��
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
	string cur_trade_day;//��ǰ������
}market_status;

//���ֻ���
typedef struct
{
	string curr_id;//���ұ��
	string curr_name;//��������
	string curr_unit;//���ҵ�λ
	string curr_ab;//������д
	string roe;//����
	string settle_day;//������
	string operator_no;//����Ա
	string operate_time;//����ʱ��
}curr_rate;

//��Ա��Ϣ����
typedef struct
{
	string cust_id;//������ID
	string associator_no;//��Ա����
	string associator_fullname;//��Աȫ��
	string compare_type;//0�������м�ܣ�����Ϊcenter_settle_bank�ṹ���е�bank_sett_id
	string contacter;//��ϵ��
	string telephone;//��ϵ�绰
	string acct_name;//�ʽ������ʻ�����(��ʹ��)
	string bank_name;//�ʽ������ʻ�������(��ʹ��)
	string bank_account;//�ʽ������ʻ��ʺ�(��ʹ��)
	string acct_contract;//�ʽ������ʻ���ϵ��ʽ(��ʹ��)
	string sales_name;//�г���Ա����
	string sales_telphone;//�г���Ա��ϵ�绰
	string is_mailing_invoices;//�Ƿ��ʼķ�Ʊ 0������;1������
	string contacter_addr;//�ռ��˵�ַ����ϵ�˵�ַ��
	string postcode;//�������루��Ա�������룩
	string password_type;//�ʽ��������ͣ�0û��ԭ�����ǿ���޸� 1��ԭ�����ǿ���޸� 2�����޸�
	string trade_role;//����������,������ɫ��
		//201��һ�㽻����
		//202���м���
		//203��������
		//204���ڻ���
		//205��Ԥ����
		//206��������
		//207���ۺϽ�����
		//208���ر�����
		//����Զ��ŷָ�
	string Sign_status;//ǩԼ״̬ 1 - ��ǩԼ; 0 - δǩԼ
}asso_info;

//��ͬ�б����
typedef struct
{
	string trade_mode;//����ģʽ 1��ϳɽ� 2������
	string contract_id;//��ͬID
	string contract_no;//��ͬ���
	string contract_name;//��ͬ����
	string goods_id;//��Ʒ����
	string goods_name;//��Ʒ����
	string begin_day;//��ʼ������
	string trade_end_day;//�������
	string csg_begin_day;//��ʼ������
	string csg_end_day;//�������
	string buy_open_poundary;//��������
	string buy_open_poundary_flag;//�򷽿��������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string buy_today_poundary;//��ƽ��������
	string buy_today_poundary_flag;//��ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string buy_yesterday_poundary;//��ƽ��������
	string buy_yesterday_poundary_flag;//��ƽ�������ѵı�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string buy_level_poundary;//��ƽ��������
	string buy_level_poundary_flag;//��ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string sell_open_poundary;//����������
	string sell_open_poundary_flag;//�������������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string sell_today_poundary;//����ƽ��������
	string sell_today_poundary_flag;//����ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string sell_yesterday_discount;//����ƽ���������ۿ���
	string sell_yesterday_poundary;//����ƽ��������
	string sell_yesterday_poundary_flag;//����ƽ�������ѵı�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string sell_level_poundary;//����ƽ��������
	string sell_level_poundary_flag;//����ƽ�������ѱ�־ 1 - ����,ʹ��ʱ����100000; 2 - �̶�,ʹ��ʱ����10����λΪ��
	string buy_deposite;//���򶨽�
	string buy_deposite_flag;//���򶨽��ʶ�����ʣ�ʹ��ʱ����100000
	string sell_deposite;//�����򶨽�
	string sell_deposite_flag;//�����򶨽��ʶ���ʣ�ʹ��ʱ����100000
	string min_diff_price;//��С�䶯��
	string max_qtt;//������󱨵���
	string min_qtt;//������С������
	string today_high_limit;//������޼�
	string today_low_limit;//������޼�
	string last_settle_price;//����
	string trans_cft;//ת��ϵ��, ����ת��ϵ��
	string curr_id;//���ұ��
	string curr_name;//��������
	string curr_unit;//���ҵ�λ
	string contract_type;//��ͬ����: 1��ͨ��2-���ڣ������ֻ�����4���ۺ�ͬ
	string min_apply_qtt;//��С�����걨��
	string permission_flag;//��ƽ��Ȩ��: 0 - ������; 1 - ֻ��; 2 - ֻƽ
	string roe;//��ͬ���� *100000
	string taxrate;//��ͬ˰�� *100000
	string is_binding;//Զ�������Ƿ�󶨾ټ��������������塢Ԥ����: 0 - δ��ȫ��; 1 - ��ȫ��
					  //���ۺ�Լ��0δҡ��; > 0��ҡ��
	string field48;//���������̺�ͬ,�������
	string field49;//���������̺�ͬ,���۵��
}contract_list;

//��Ʒ��Ϣ����
typedef struct
{
	string goods_id;//��Ʒ���
	string g_prop_id;//��Ʒ���Ա��
	string g_prop_name;//��Ʒ��������
	string g_prop_default;//��Ʒ����Ĭ��ֵ
}goods_list;

//���׻ر�
typedef struct
{
	string return_seq;//�ر�˳���
	string return_type;//�ر�����:
						// 	1 - ���ױ����ɽ��ر���
						// 	2 - ���ױ�������֪ͨ��
						// 	3 - �����걨����֪ͨ��
						// 	4 - �����걨����ر���
						// 	5 - ���ǿ�Ƴ���֪ͨ
						// 	6 - OTC��Լ������Ϣ
	string return_title;//�ر�����
	string return_cnt;//�ر�����
					  //�ر����ͣ���1���ױ����ɽ��ر��������ݸ�ʽ��1��ʶ | �ɽ���ID | �ɽ����� | ί�е�ID | ί�е��� | ��ͬID | ��ͬ��� | �ɽ��۸� | �ɽ����� | ת�ü۲� | ��ƽ�ֱ��(1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�) | ��������(1 - ��ͨ���ף�2 - �Կ��֣�3 - ǿ��ת�ã�4 - ǿ�Ƽ��֣�5 - Э��ת�ã�6 - Э����֣�7 - Э���Ʋ֣�8 - ���ն�ǿƽ��9 - ���������ǿƽ��10 - ����ҡ�ſ���) | �ر�����
					  //�ر����ͣ���2���ױ�������֪ͨ������5���ǿ�Ƴ���֪ͨ�������ݸ�ʽ��2��ʶ | ί�е�ID | ί�е��� | �������� | �ر�����
	string deal_id;//�ɽ���ID
	string deal_no;// �ɽ�����
	string status;//�ر�״̬
	string create_time;//�ر�����ʱ��
	string Send_Times;//���ʹ���
	string trade_day;//��ǰ������
}trade_return;

//����
typedef struct
{
	string bulletin_seq;//����˳���
	string type;//��������1 ���� 2˽��
	string title;//�������
	string content;//��������
	string content_type;//������������
						// 	1, ��ͨ����(�����)
						// 	2, ��ͨ����(������)
						// 	3, ǿ��ƽ���µ�����
						// 	4, ��������������,
						// 	5, ӯ������������,
						// 	6, �Զ�ӯ������������,
						// 	7, ǿ�ƽ��չ���,
						// 	8, ǿ�ƻع�����
	string create_time;//���淢��ʱ��
	string trans_string;//3ǿ��ƽ����Ϣ��:order_id|order_no|contract_id|contract_no|buyorsell|offset_flag|is_deposit|order_price|order_qtt|left_qtt|status|order_time|order_type
						//4��5��������ӯ����������Ϣ��order_id | order_no | contract_id | contract_no | buyorsell | offset_flag | is_deposit | order_price | order_qtt | left_qtt | status | order_time | co_id | ret_code(0�����ɹ�) | trade_type
						//6�Զ�ֹӯֹ�𴥷���Ϣ����plo_no | plo_id | ORDER_LOCAL_ID | contract_id | contract_no | buyorsell | offset_flag | is_deposit | profit_price | loss_price | order_qtt | order_ip | valid_date | status | add_time | activity_time | pl_id | ret_code(0�����ɹ�)
	string trade_day;//��ǰ������
}bulletin;

//�ʽ���Ϣ
typedef struct
{
	string avl_fund;//�����ʽ�
	string occp_deposit;//����ռ��
	string frz_ord_fund;//��������
	string frz_risk_fund;//��ض���
	string frz_csg_fund;//��ض���
	string acct_balance;//����۲����ӯ����
	string avl_rcpt;//�����òֵ�
	string today_poundary;//����������
	string today_inout_fund;//���ճ����
	string today_in_fund;//�������
	string today_out_fund;//���ճ���
	string total_right;//Ȩ�棨Ȩ�棽�����ʽ𣫱�֤��ռ�ã���������+��ض���+���ն���+ABS��-����۲��
	string today_cny_balance;//����ƽ��ӯ������ƽ�ּۣ����ּۣ�������/˰��
	string risk_degree;//���ն�
	string rate_acct_balance;//����ӯ������˰����˰�Ķ���
	string max_can_out;//���ɳ����
	string position_profit;//�ֲ�ӯ��
	string floating_proft;//����ӯ��=�ֲ�ӯ��+����ӯ��
	string system_date;//�ʽ��ѯʱ���
	string frz_others;//��������(�ֻ�����)
	string last_avl_fund;//���տ���
}fund;

//����
typedef struct  
{
	string order_local_id;//ǰ�˱����ţ���API����ForOderfRequest()�����ɣ� 20λ(ʱ��+6λ˳��� yyyyMMddHHmmss######)
	string contract_id;//��*�µ������ͬID
	string buyorsell;//��*�µ������������(1 - ���룬2 - ����)
	string offset_flag;//��*�µ������ƽ�ֱ��:1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�
	string trade_type;//��*�µ�����걨���� 1���޼ۣ�2���мۣ�3��ֹ���޼ۣ�4��ֹ���мۣ�5������
	string is_deposit;//��*�µ����������ʽ 1����6�ֵ�
	string stop_price;//ֹ��۸�
	string order_price;//��*�µ�����걨�۸�
	string order_qtt;//��*�µ�����걨����
	string order_ip;//��*�µ�����걨IP��ַ
	string detail_seq;//ָ����ƽ�ֲ�λ��ϸ��
	string remark;//��� ��ע

	string order_no;//�µ����
	string order_id;//����ID
	string order_time;//�µ�ʱ��
	string client_no;//�ͻ�����
	string contract_no;//��ͬ����
	string left_qtt;//������
	string cancel_qtt;//��������
	string operator_no;//����Ա����
	string status;//����״̬ 1��δ�ɽ���2�����ֳɽ���3���ɽ���4��������5�����г���
	string cancel_time;//����ʱ��
	string ret_order_status;//�µ�״̬
	string ret_order_status_desc;//�µ�״̬˵��
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
	string frz_ord_fund;//���ᱣ֤��
	string frz_poundary;//����������
	string roe;//����
	string taxrate;//˰��

	string order_type;//1,��ͨ����
						// 2, �Կ���
						// 3, ǿ��ת��
						// 4, ǿ�Ƽ���
						// 5, Э��ת��
						// 6, Э�����
						// 7, Э���Ʋ�
						// 8, ���ն�ǿƽ
						// 9, ���������ǿƽ
						// 10, ����ҡ�ſ���
}orderf;

//�ֵ��б�
typedef struct  
{
	string rcpt_no;//�ֵ�����(��)
	string goods_id;//��Ʒ����
	string goods_name;//��Ʒ����
	string contract_id;//��ͬID
	string contract_no;//��ͬ����
	string trans_cft;//����ת��
	string rcpt_qtt;//����
	string avlb_qtt;//��������
	string frz_qtt;//��������
	string csg_qtt;//�ѽ�������
	string frz_csg_qtt;//���ն�������
	string frz_risk_qtt;//��������ֵ�����
	string loan_qtt;//��Ѻ��������
	string cancel_qtt;//ע������
	string in_storage_date;//�������(��)
}receipts_list;

//����
typedef struct  
{
	string trade_mode;//��*�����������ģʽ F��Զ�������� FG - ���ճ���
	string order_no;//�µ����
	string order_id;//��*�������������
	string cancel_time;//�µ�ʱ��
	string ret_cancel_status;//����״̬��  0 �ɹ��� ����ʧ��
 	string ret_desc;//����״̬����
	string contract_id;//��*���������ͬ����
	string cancel_oper;//��*������������ˣ���¼�ʺţ�
	string cancel_ip;//��*�����������IP��ַ 
}cancel_order;

//�ɽ��б�
typedef struct 
{
	string deal_no;//�ɽ���
	string deal_id;//�ɽ�ID
	string order_no;//ί�е���
	string order_id;//ί�е�ID
	string opp_order_no;//���ֱ�����
	string deal_time;//�ɽ�ʱ��
	string client_no;//�ͻ�����
	string contract_id;//��ͬID
	string contract_no;//��ͬ����
	string buyorsell;//��������
	string offset_flag;//��ƽ������ 1�����֣��¶�����2��ƽ��3��ƽ��4��ƽ�֣��ȶ���ת����5��ƽ�֣�ת�����ȣ���6��ָ����ƽ�֣�
	string order_type;//�걨���� 1, ��ͨ���� 2, �Կ��� 3, ǿ��ת�� 4, ǿ�Ƽ��� 5, Э��ת�� 6, Э����� 7, Э���Ʋ� 8, ���ն�ǿƽ 9, ���������ǿƽ 10, ����ҡ�ſ���
	string is_deposit;//������ʽ  1����6�ֵ�
	string deal_price;//�ɽ��۸�
	string deal_qtt;// �ɽ�����
	string profit_loss;// ת�ü۲�
	string detail_seq;// ���˳���
}dealf_list;

//�ֲֲ�ѯ
typedef struct 
{
	string	contract_id;//��ͬID
	string	contract_no;//��ͬ����
	string	client_no;//�ͻ�����
	string	buyorsell;//��������
	string	dpst_total_qtt;//����ֲ�
	string	dpst_amt;//ռ�ñ�֤���
	string	rcpt_total_subs;//�ֵ��ֲ�
	string	dpst_avg_price;//���𿪲־���
	string	rcpt_avg_price;//�ֵ����־���
	string	cnyable_qtt;//�ܿ�ת������
	string	cnyable_qtt_today;//��ֿ�ת������
	string	rcpt_cnyable_qtt;//�ֵ���ת������
	string	rcpt_cnyable_qtt_today;//�ֵ���ֿ�ת������
	string	initial_cost;//���ֳɱ�(������ֵ�ӯ������Ϊ���� + �ֵ��Ŀ��ֳɱ�)
	string	position_cost;//�ֲֳɱ�(������ֵ�ӯ������Ϊ���� + �ֵ��ĳֲֳɱ�)
	string	dpst_position_avg_price;//����ֲ־���
	string	rctp_position_avg_price;//�ֵ��ֲ־���
	string	position_profit;//�ֲ�ӯ��
	string	mark_market_profit;//����ӯ��
	string	floating_profit;//����ӯ��
	string	roe;//����(ʹ��ʱ����100000)
	string	rcpt_qtt_r;//���вֵ�������
	string	lender_qtt_w;//�ڲֵ���
	string	other_qtt;//���ʳֲ�����
	string	frz_csg_qtt_d;//�����ն���
	string	frz_csg_qtt_r;//�ֵ����ն���
}subsf_list;

//������ѯ
typedef struct
{
	string inout_seq;//�����˳���
	string cust_no;//��Ա����
	string inorout;//������־: 1�����2������
	string amount;//���
	string pay_way;//֧����ʽ��5 �ֽ�; 6 ֧Ʊ; 7 ת��֧Ʊ; 8 ���; 9 ����; 10 ���; 100 ֧����; - 9 �ͻ��˴�WEB��ַΪ�ֶ�payment_no
	string bank_id;//������Ӧ���ĵĽ������б��
	string bank_name;//��������
	string bank_account;//Ʊ�ݶ�Ӧ�����ʺ�
	string payment_no;//����Ʊ�ݱ��;��pay_way = -9, ���ֶ�Ϊ������ַ
	string oper;//������
	string oper_time;//����ʱ��
	string auth;//����Ա
	string auth_date;//����ʱ��
	string status;//״̬: 1 �����; 2 ����; 10 ���д�����; 11 ���в���; 99 �����;	- 1 ȡ��; - 2��ɾ��;
}fund_inout;

class CForDict
{
public:
	//API��������
	static const string FOR_ERRO_SOCKET_SEND;//��Ϣ���ͳ���
	static const string FOR_ERRO_SOCKET_RECV;//��Ϣ���ճ���
	static const string FOR_ERRO_VAL_SIGN;//������������Ϣ����
	static const string FOR_ERRO_VERSION;//��ϢЭ��汾�뱾�ؽ�����ƥ��
	static const string FOR_ERRO_PARSE_LOGIN;//������¼��Ϣ����
	static const string FOR_ERRO_PARSE_ASSOINFO;//������Ա��Ϣ����
	static const string FOR_ERRO_PARSE_CONTRACTLIST;//������ͬ�б���Ϣ����
	static const string FOR_ERRO_PARSE_GOODSLIST;//������Ʒ��Ϣ����
	static const string FOR_ERRO_PARSE_CTPINFO;//����������Ϣ����
	static const string FOR_ERRO_PARSE_MARKETSTATUS;//�����г�״̬����
	static const string FOR_ERRO_PARSE_CURRRATE;//����������Ϣ����
	static const string FOR_ERRO_PARSE_TRADERETURN;//�������׻ر���Ϣ����
	static const string FOR_ERRO_PARSE_BULLETIN;//����������Ϣ����
	static const string FOR_ERRO_PARSE_FUND;//�����ʽ���Ϣ����
	static const string FOR_ERRO_PARSE_ORDERF;//�����µ�Ӧ�����
	static const string FOR_ERRO_PARSE_RECEIPTS;//�����ֵ��б���Ϣ����
	static const string FOR_ERRO_PARSE_CANCELORDER;//��������Ӧ�����
	static const string FOR_ERRO_PARSE_DEALFLIST;//�����ɽ��б����
	static const string FOR_ERRO_PARSE_ORDERFLIST;//����ί���б����
	static const string FOR_ERRO_PARSE_SUBSFLIST;//�����ֲ���Ϣ����
	static const string FOR_ERRO_PARSE_FUNDINOUTLIST;//�����������Ϣ����
	static const string FOR_ERRO_PARSE_FUNDINOUTAPPLY;//����������������

protected:
	CForDict() {};
	~CForDict() {};
};

#endif
