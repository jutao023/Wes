#ifndef __FOR_DATA_TYPE__
#define __FOR_DATA_TYPE__

#include<string>
using namespace std;

//数据包头
typedef struct
{
	string TradeNo;//交易流水号
	string ModuleName;//请求模块名称
	string RequestType;//请求类型
	string ReturnCode;//返回码（返回码及描述参见MktRetDefine.java）
	string ReturnDesc;//返回描述
	int ListNum;// 包体记录条数
	int Children;//总子包数
	int ChildIndex;//当前子包顺序号
	string EmpAcct;//交易员代码
	string SessionId;//会话Session
	string OperTime;//操作时间
}trade_head;

//市场状态
typedef struct
{
	string cur_status;//市场状态:1: 初始化
							// 5 : 开市
							// 10 : 集合竞价
							// 15 : 交易
							// 20 : 暂停
							// 25 : 收市处理
							// 30 : 中间商申报
							// 35 : 违约认定
							// 40 : 交收撮合
							// 45 : 结束
							// 50 : 结算准备
							// 55 : 结算开始
							// 60 : 结算完成
							// 65 : 等待结算确认
							// 70 : 结算确认
							// 0 : 闭市
	string cur_trade_day;//当前交易日
}market_status;

//币种汇率
typedef struct
{
	string curr_id;//货币编号
	string curr_name;//货币名称
	string curr_unit;//货币单位
	string curr_ab;//货币缩写
	string roe;//汇率
	string settle_day;//结算日
	string operator_no;//操作员
	string operate_time;//操作时间
}curr_rate;

//会员信息包体
typedef struct
{
	string cust_id;//交易商ID
	string associator_no;//会员编码
	string associator_fullname;//会员全称
	string compare_type;//0－不银行监管，否则为center_settle_bank结构体中的bank_sett_id
	string contacter;//联系人
	string telephone;//联系电话
	string acct_name;//资金往来帐户名称(不使用)
	string bank_name;//资金往来帐户开户行(不使用)
	string bank_account;//资金往来帐户帐号(不使用)
	string acct_contract;//资金往来帐户联系方式(不使用)
	string sales_name;//市场人员名称
	string sales_telphone;//市场人员联系电话
	string is_mailing_invoices;//是否邮寄发票 0——否;1——是
	string contacter_addr;//收件人地址（联系人地址）
	string postcode;//邮政编码（会员邮政编码）
	string password_type;//资金密码类型：0没有原密码的强制修改 1有原密码的强制修改 2不需修改
	string trade_role;//交易商类型,订货角色：
		//201：一般交易商
		//202：中间商
		//203：生产商
		//204：融货商
		//205：预售商
		//206：供货商
		//207：综合交易商
		//208：特别交易商
		//多个以逗号分隔
	string Sign_status;//签约状态 1 - 已签约; 0 - 未签约
}asso_info;

//合同列表包体
typedef struct
{
	string trade_mode;//交易模式 1撮合成交 2做市商
	string contract_id;//合同ID
	string contract_no;//合同编号
	string contract_name;//合同名称
	string goods_id;//商品编码
	string goods_name;//商品名称
	string begin_day;//开始交易日
	string trade_end_day;//最后交易日
	string csg_begin_day;//开始交收日
	string csg_end_day;//最后交收日
	string buy_open_poundary;//买开手续费
	string buy_open_poundary_flag;//买方开仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string buy_today_poundary;//买方平今手续费
	string buy_today_poundary_flag;//买方平今手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string buy_yesterday_poundary;//买方平昨手续费
	string buy_yesterday_poundary_flag;//买方平昨手续费的标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string buy_level_poundary;//买方平仓手续费
	string buy_level_poundary_flag;//买方平仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string sell_open_poundary;//卖开手续费
	string sell_open_poundary_flag;//卖方开仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string sell_today_poundary;//卖方平今手续费
	string sell_today_poundary_flag;//卖方平今手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string sell_yesterday_discount;//卖方平昨手续费折扣率
	string sell_yesterday_poundary;//卖方平昨手续费
	string sell_yesterday_poundary_flag;//卖方平昨手续费的标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string sell_level_poundary;//卖方平仓手续费
	string sell_level_poundary_flag;//卖方平仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
	string buy_deposite;//买方向定金
	string buy_deposite_flag;//买方向定金标识，比率，使用时除以100000
	string sell_deposite;//卖方向定金
	string sell_deposite_flag;//卖方向定金标识比率，使用时除以100000
	string min_diff_price;//最小变动价
	string max_qtt;//单笔最大报单量
	string min_qtt;//单笔最小报单量
	string today_high_limit;//今最高限价
	string today_low_limit;//今最低限价
	string last_settle_price;//昨结价
	string trans_cft;//转换系数, 吨批转换系数
	string curr_id;//货币编号
	string curr_name;//货币名称
	string curr_unit;//货币单位
	string contract_type;//合同类型: 1普通；2-延期（连续现货）；4发售合同
	string min_apply_qtt;//最小交收申报量
	string permission_flag;//开平仓权限: 0 - 不限制; 1 - 只开; 2 - 只平
	string roe;//合同汇率 *100000
	string taxrate;//合同税率 *100000
	string is_binding;//远期延期是否绑定举荐机构、上市主体、预售商: 0 - 未完全绑定; 1 - 完全绑定
					  //发售合约：0未摇号; > 0已摇号
	string field48;//若是做市商合同,报单点差
	string field49;//若是做市商合同,报价点差
}contract_list;

//商品信息包体
typedef struct
{
	string goods_id;//商品编号
	string g_prop_id;//商品属性编号
	string g_prop_name;//商品属性名称
	string g_prop_default;//商品属性默认值
}goods_list;

//交易回报
typedef struct
{
	string return_seq;//回报顺序号
	string return_type;//回报类型:
						// 	1 - 交易报单成交回报；
						// 	2 - 交易报单撤单通知；
						// 	3 - 交收申报撤单通知；
						// 	4 - 交收申报结果回报；
						// 	5 - 风控强制撤单通知
						// 	6 - OTC合约报价消息
	string return_title;//回报标题
	string return_cnt;//回报内容
					  //回报类型：“1交易报单成交回报”，内容格式：1标识 | 成交单ID | 成交单号 | 委托单ID | 委托单号 | 合同ID | 合同编号 | 成交价格 | 成交数量 | 转让价差 | 开平仓标记(1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；) | 报单类型(1 - 普通交易；2 - 对开仓；3 - 强制转让；4 - 强制减仓；5 - 协议转让；6 - 协议清仓；7 - 协议移仓；8 - 风险度强平；9 - 交割价试算强平；10 - 发售摇号开仓) | 回报内容
					  //回报类型：“2交易报单撤单通知”，“5风控强制撤单通知”，内容格式：2标识 | 委托单ID | 委托单号 | 撤单数量 | 回报内容
	string deal_id;//成交单ID
	string deal_no;// 成交单号
	string status;//回报状态
	string create_time;//回报发布时间
	string Send_Times;//发送次数
	string trade_day;//当前交易日
}trade_return;

//公告
typedef struct
{
	string bulletin_seq;//公告顺序号
	string type;//公告类型1 公共 2私有
	string title;//公告标题
	string content;//公告内容
	string content_type;//公告内容类型
						// 	1, 普通公告(跑马灯)
						// 	2, 普通公告(弹出框)
						// 	3, 强制平仓下单公告
						// 	4, 条件单触发公告,
						// 	5, 盈亏单触发公告,
						// 	6, 自动盈亏单触发公告,
						// 	7, 强制交收公告,
						// 	8, 强制回购公告
	string create_time;//公告发布时间
	string trans_string;//3强制平仓消息串:order_id|order_no|contract_id|contract_no|buyorsell|offset_flag|is_deposit|order_price|order_qtt|left_qtt|status|order_time|order_type
						//4、5条件单、盈亏单触发消息串order_id | order_no | contract_id | contract_no | buyorsell | offset_flag | is_deposit | order_price | order_qtt | left_qtt | status | order_time | co_id | ret_code(0报单成功) | trade_type
						//6自动止盈止损触发消息串：plo_no | plo_id | ORDER_LOCAL_ID | contract_id | contract_no | buyorsell | offset_flag | is_deposit | profit_price | loss_price | order_qtt | order_ip | valid_date | status | add_time | activity_time | pl_id | ret_code(0报单成功)
	string trade_day;//当前交易日
}bulletin;

//资金信息
typedef struct
{
	string avl_fund;//可用资金
	string occp_deposit;//定金占用
	string frz_ord_fund;//报单冻结
	string frz_risk_fund;//风控冻结
	string frz_csg_fund;//风控冻结
	string acct_balance;//帐面价差（盯市盈亏）
	string avl_rcpt;//最大可用仓单
	string today_poundary;//当日手续费
	string today_inout_fund;//当日出入金
	string today_in_fund;//当日入金
	string today_out_fund;//当日出金
	string total_right;//权益（权益＝可用资金＋保证金占用＋报单冻结+风控冻结+交收冻结+ABS（-账面价差））
	string today_cny_balance;//当日平仓盈亏＝（平仓价－开仓价）＊手数/税率
	string risk_degree;//风险度
	string rate_acct_balance;//帐面盈亏（计税）计税的盯市
	string max_can_out;//最大可出金额
	string position_profit;//持仓盈亏
	string floating_proft;//浮动盈亏=持仓盈亏+盯市盈亏
	string system_date;//资金查询时间戳
	string frz_others;//其他冻结(现货冻结)
	string last_avl_fund;//上日可用
}fund;

//报单
typedef struct  
{
	string order_local_id;//前端报单号，由API调用ForOderfRequest()后生成， 20位(时间+6位顺序号 yyyyMMddHHmmss######)
	string contract_id;//（*下单必填）合同ID
	string buyorsell;//（*下单必填）买卖方向(1 - 买入，2 - 卖出)
	string offset_flag;//（*下单必填）开平仓标记:1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；
	string trade_type;//（*下单必填）申报类型 1、限价；2、市价；3、止损限价；4、止损市价；5、均价
	string is_deposit;//（*下单必填）担保方式 1定金；6仓单
	string stop_price;//止损价格
	string order_price;//（*下单必填）申报价格
	string order_qtt;//（*下单必填）申报数量
	string order_ip;//（*下单必填）申报IP地址
	string detail_seq;//指定仓平仓仓位明细号
	string remark;//点差 备注

	string order_no;//下单编号
	string order_id;//报单ID
	string order_time;//下单时间
	string client_no;//客户编码
	string contract_no;//合同编码
	string left_qtt;//余数量
	string cancel_qtt;//撤单数量
	string operator_no;//交易员代码
	string status;//报单状态 1、未成交，2、部分成交，3、成交，4、撤单，5、收市撤单
	string cancel_time;//撤单时间
	string ret_order_status;//下单状态
	string ret_order_status_desc;//下单状态说明
								//下单状态	下单状态说明
								//- 1	系统异常
								//0		操作成功
								//1		操作失败
								//9		交易权限限制
								//10	仓单不能买入订货
								//11	仓单不能卖出转让
								//12	中心非交易状态
								//13	市场状态错误
								//14	合约非交易状态
								//16	合约状态错误
								//20	最小变动价位限制
								//26	可用仓单不足
								//27	无持仓
								//28	仓单持仓不足
								//29	定金持仓不足
								//37	合约编号为空
								//39	获取指定合约交易手续费失败
								//80	合约编码错误
								//502	下单数量错误
								//505	冻结仓单失败
								//512	报单数据错误
								//514	申报类型错误
								//519	未初始化合约信息
								//6016	报单价格错误
								//6032	持仓冻结失败
								//8036	无交易商交易权限
								//8050	买卖方向错误
								//8051	开平仓标记错误
								//8053	申报类型或开平仓错误
								//8054	担保方式错误
								//8055	定金担保方式权限限制
								//8056	仓单担保方式权限限制
								//8057	定金仓单担保方式权限限制
								//8058	开仓权限限制
								//8059	平仓权限限制
								//8060	开平仓权限限制
								//8061	定金开仓权限限制
								//8063	仓单开仓权限限制
								//8297	超过合约最后交易日
								//8312	报单量不是吨批转换系数的整数倍
								//8313	大于合约最大报单量
								//8314	小于合约最小报单量
								//8316	不是合约最小变动价的整数倍
								//8317	查询市场持仓量错误
								//8318	查询交易商持仓量错误
								//8319	市场持仓量限制，当前可报单量
								//8320	交易商持仓量限制，当前可报单量
								//8321	特殊待遇持仓量限制，当前可报单量
								//8324	特殊待遇单笔最大报单量限制
								//8326	特殊待遇单笔最小报单量限制
								//8327	不是特殊待遇单笔最小报单量
								//8340	查询会员手续费失败
								//8341	冻结融货失败
								//8367	超涨幅最高价
								//8368	超跌幅最低价
								//8369	超熔断最高价
								//8370	超熔断最低价
								//8373	冻结持仓明细失败
								//8385	市场非中间商交收状态
								//8386	合约非中间商交收状态
								//8617	IP地址不正确
	string frz_ord_fund;//冻结保证金
	string frz_poundary;//冻结手续费
	string roe;//汇率
	string taxrate;//税率

	string order_type;//1,普通交易
						// 2, 对开仓
						// 3, 强制转让
						// 4, 强制减仓
						// 5, 协议转让
						// 6, 协议清仓
						// 7, 协议移仓
						// 8, 风险度强平
						// 9, 交割价试算强平
						// 10, 发售摇号开仓
}orderf;

//仓单列表
typedef struct  
{
	string rcpt_no;//仓单编码(空)
	string goods_id;//商品编码
	string goods_name;//商品名称
	string contract_id;//合同ID
	string contract_no;//合同编码
	string trans_cft;//吨批转换
	string rcpt_qtt;//数量
	string avlb_qtt;//可用数量
	string frz_qtt;//冻结数量
	string csg_qtt;//已交收数量
	string frz_csg_qtt;//交收冻结数量
	string frz_risk_qtt;//风控锁定仓单数量
	string loan_qtt;//质押锁定数量
	string cancel_qtt;//注销数量
	string in_storage_date;//入库日期(空)
}receipts_list;

//撤单
typedef struct  
{
	string trade_mode;//（*撤单必填）交易模式 F－远期做市商 FG - 交收撤单
	string order_no;//下单编号
	string order_id;//（*撤单必填）报单号
	string cancel_time;//下单时间
	string ret_cancel_status;//撤单状态：  0 成功， 其它失败
 	string ret_desc;//撤单状态描述
	string contract_id;//（*撤单必填）合同编码
	string cancel_oper;//（*撤单必填）撤单人（登录帐号）
	string cancel_ip;//（*撤单必填）撤单IP地址 
}cancel_order;

//成交列表
typedef struct 
{
	string deal_no;//成交号
	string deal_id;//成交ID
	string order_no;//委托单号
	string order_id;//委托单ID
	string opp_order_no;//对手报单号
	string deal_time;//成交时间
	string client_no;//客户编码
	string contract_id;//合同ID
	string contract_no;//合同编码
	string buyorsell;//买卖方向
	string offset_flag;//开平仓类型 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；
	string order_type;//申报类型 1, 普通交易 2, 对开仓 3, 强制转让 4, 强制减仓 5, 协议转让 6, 协议清仓 7, 协议移仓 8, 风险度强平 9, 交割价试算强平 10, 发售摇号开仓
	string is_deposit;//担保方式  1定金；6仓单
	string deal_price;//成交价格
	string deal_qtt;// 成交数量
	string profit_loss;// 转让价差
	string detail_seq;// 逐笔顺序号
}dealf_list;

//持仓查询
typedef struct 
{
	string	contract_id;//合同ID
	string	contract_no;//合同编码
	string	client_no;//客户编码
	string	buyorsell;//买卖方向
	string	dpst_total_qtt;//定金持仓
	string	dpst_amt;//占用保证金金
	string	rcpt_total_subs;//仓单持仓
	string	dpst_avg_price;//定金开仓均价
	string	rcpt_avg_price;//仓单开仓均价
	string	cnyable_qtt;//总可转让数量
	string	cnyable_qtt_today;//今仓可转让数量
	string	rcpt_cnyable_qtt;//仓单可转让数量
	string	rcpt_cnyable_qtt_today;//仓单今仓可转让数量
	string	initial_cost;//开仓成本(若允许仓单盈亏，则为定金 + 仓单的开仓成本)
	string	position_cost;//持仓成本(若允许仓单盈亏，则为定金 + 仓单的持仓成本)
	string	dpst_position_avg_price;//定金持仓均价
	string	rctp_position_avg_price;//仓单持仓均价
	string	position_profit;//持仓盈亏
	string	mark_market_profit;//盯市盈亏
	string	floating_profit;//浮动盈亏
	string	roe;//汇率(使用时除以100000)
	string	rcpt_qtt_r;//自有仓单可用量
	string	lender_qtt_w;//融仓单量
	string	other_qtt;//融资持仓数量
	string	frz_csg_qtt_d;//定金交收冻结
	string	frz_csg_qtt_r;//仓单交收冻结
}subsf_list;

//出入金查询
typedef struct
{
	string inout_seq;//出入金顺序号
	string cust_no;//会员编码
	string inorout;//出入金标志: 1：入金，2：出金
	string amount;//金额
	string pay_way;//支付方式；5 现金; 6 支票; 7 转账支票; 8 电汇; 9 网银; 10 汇款; 100 支付宝; - 9 客户端打开WEB地址为字段payment_no
	string bank_id;//出入金对应中心的结算银行编号
	string bank_name;//银行名称
	string bank_account;//票据对应银行帐号
	string payment_no;//银行票据编号;若pay_way = -9, 该字段为网银地址
	string oper;//申请人
	string oper_time;//申请时间
	string auth;//记账员
	string auth_date;//记账时间
	string status;//状态: 1 待审核; 2 驳回; 10 银行处理中; 11 银行驳回; 99 已完成;	- 1 取消; - 2已删除;
}fund_inout;

class CForDict
{
public:
	//API错误描述
	static const string FOR_ERRO_SOCKET_SEND;//消息发送出错
	static const string FOR_ERRO_SOCKET_RECV;//消息接收出错
	static const string FOR_ERRO_VAL_SIGN;//解析特征码信息出错
	static const string FOR_ERRO_VERSION;//消息协议版本与本地解析不匹配
	static const string FOR_ERRO_PARSE_LOGIN;//解析登录信息出错
	static const string FOR_ERRO_PARSE_ASSOINFO;//解析会员信息出错
	static const string FOR_ERRO_PARSE_CONTRACTLIST;//解析合同列表信息出错
	static const string FOR_ERRO_PARSE_GOODSLIST;//解析商品信息出错
	static const string FOR_ERRO_PARSE_CTPINFO;//解析行情信息出错
	static const string FOR_ERRO_PARSE_MARKETSTATUS;//解析市场状态出错
	static const string FOR_ERRO_PARSE_CURRRATE;//解析汇率信息出错
	static const string FOR_ERRO_PARSE_TRADERETURN;//解析交易回报信息出错
	static const string FOR_ERRO_PARSE_BULLETIN;//解析公告信息出错
	static const string FOR_ERRO_PARSE_FUND;//解析资金信息出错
	static const string FOR_ERRO_PARSE_ORDERF;//解析下单应答出错
	static const string FOR_ERRO_PARSE_RECEIPTS;//解析仓单列表信息出错
	static const string FOR_ERRO_PARSE_CANCELORDER;//解析撤单应答出错
	static const string FOR_ERRO_PARSE_DEALFLIST;//解析成交列表出错
	static const string FOR_ERRO_PARSE_ORDERFLIST;//解析委托列表出错
	static const string FOR_ERRO_PARSE_SUBSFLIST;//解析持仓信息出错
	static const string FOR_ERRO_PARSE_FUNDINOUTLIST;//解析出入金信息出错
	static const string FOR_ERRO_PARSE_FUNDINOUTAPPLY;//解析出入金申请出错

protected:
	CForDict() {};
	~CForDict() {};
};

#endif
