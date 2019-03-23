#pragma once

using namespace System;

namespace JiaoHui {

	namespace JHData
	{

		//报单
		public ref struct Orderf
		{
			String^ order_local_id;//前端报单号，由API调用ForOderfRequest()后生成， 20位(时间+6位顺序号 yyyyMMddHHmmss######)
			String^ contract_id;//（*下单必填）合同ID
			String^ buyorsell;//（*下单必填）买卖方向(1 - 买入，2 - 卖出)
			String^ offset_flag;//（*下单必填）开平仓标记:1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；
			String^ trade_type;//（*下单必填）申报类型 1、限价；2、市价；3、止损限价；4、止损市价；5、均价
			String^ is_deposit;//（*下单必填）担保方式 1定金；6仓单
			String^ stop_price;//止损价格
			String^ order_price;//（*下单必填）申报价格
			String^ order_qtt;//（*下单必填）申报数量
			String^ order_ip;//（*下单必填）申报IP地址
			String^ detail_seq;//指定仓平仓仓位明细号
			String^ remark;//点差 备注

			String^ order_no;//下单编号
			String^ order_id;//报单ID
			String^ order_time;//下单时间
			String^ client_no;//客户编码
			String^ contract_no;//合同编码
			String^ left_qtt;//余数量
			String^ cancel_qtt;//撤单数量
			String^ operator_no;//交易员代码
			String^ status;//报单状态 1、未成交，2、部分成交，3、成交，4、撤单，5、收市撤单
			String^ cancel_time;//撤单时间
			String^ ret_order_status;//下单状态
			String^ ret_order_status_desc;//下单状态说明
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
			String^ frz_ord_fund;//冻结保证金
			String^ frz_poundary;//冻结手续费
			String^ roe;//汇率
			String^ taxrate;//税率

			String^ order_type;//1,普通交易
							  // 2, 对开仓
							  // 3, 强制转让
							  // 4, 强制减仓
							  // 5, 协议转让
							  // 6, 协议清仓
							  // 7, 协议移仓
							  // 8, 风险度强平
							  // 9, 交割价试算强平
							  // 10, 发售摇号开仓
		};

		//撤单
		public ref struct Cancel_Order
		{
			String^ trade_mode;//（*撤单必填）交易模式 F－远期做市商 FG - 交收撤单
			String^ order_no;//下单编号
			String^ order_id;//（*撤单必填）报单号
			String^ cancel_time;//下单时间
			String^ ret_cancel_status;//撤单状态：  0 成功， 其它失败
			String^ ret_desc;//撤单状态描述
			String^ contract_id;//（*撤单必填）合同编码
			String^ cancel_oper;//（*撤单必填）撤单人（登录帐号）
			String^ cancel_ip;//（*撤单必填）撤单IP地址 
		};

		//数据包头
		public ref struct Trade_Head
		{
			String^ TradeNo;//交易流水号
			String^ ModuleName;//请求模块名称
			String^ RequestType;//请求类型
			String^ ReturnCode;//返回码（返回码及描述参见MktRetDefine.java）
			String^ ReturnDesc;//返回描述
			Int32 ListNum;// 包体记录条数
			Int32 Children;//总子包数
			Int32 ChildIndex;//当前子包顺序号
			String^ EmpAcct;//交易员代码
			String^ SessionId;//会话Session
			String^ OperTime;//操作时间
		};

		//会员信息包体
		public ref struct Asso_Info
		{
			String^ cust_id;//交易商ID
			String^ associator_no;//会员编码
			String^ associator_fullname;//会员全称
			String^ compare_type;//0－不银行监管，否则为center_settle_bank结构体中的bank_sett_id
			String^ contacter;//联系人
			String^ telephone;//联系电话
			String^ acct_name;//资金往来帐户名称(不使用)
			String^ bank_name;//资金往来帐户开户行(不使用)
			String^ bank_account;//资金往来帐户帐号(不使用)
			String^ acct_contract;//资金往来帐户联系方式(不使用)
			String^ sales_name;//市场人员名称
			String^ sales_telphone;//市场人员联系电话
			String^ is_mailing_invoices;//是否邮寄发票 0——否;1——是
			String^ contacter_addr;//收件人地址（联系人地址）
			String^ postcode;//邮政编码（会员邮政编码）
			String^ password_type;//资金密码类型：0没有原密码的强制修改 1有原密码的强制修改 2不需修改
			String^ trade_role;//交易商类型,订货角色：
							  //201：一般交易商
							  //202：中间商
							  //203：生产商
							  //204：融货商
							  //205：预售商
							  //206：供货商
							  //207：综合交易商
							  //208：特别交易商
							  //多个以逗号分隔
			String^ Sign_status;//签约状态 1 - 已签约; 0 - 未签约
		};

		//合同列表包体
		public ref struct Contract_List
		{
			String^ trade_mode;//交易模式 1撮合成交 2做市商
			String^ contract_id;//合同ID
			String^ contract_no;//合同编号
			String^ contract_name;//合同名称
			String^ goods_id;//商品编码
			String^ goods_name;//商品名称
			String^ begin_day;//开始交易日
			String^ trade_end_day;//最后交易日
			String^ csg_begin_day;//开始交收日
			String^ csg_end_day;//最后交收日
			String^ buy_open_poundary;//买开手续费
			String^ buy_open_poundary_flag;//买方开仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ buy_today_poundary;//买方平今手续费
			String^ buy_today_poundary_flag;//买方平今手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ buy_yesterday_poundary;//买方平昨手续费
			String^ buy_yesterday_poundary_flag;//买方平昨手续费的标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ buy_level_poundary;//买方平仓手续费
			String^ buy_level_poundary_flag;//买方平仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ sell_open_poundary;//卖开手续费
			String^ sell_open_poundary_flag;//卖方开仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ sell_today_poundary;//卖方平今手续费
			String^ sell_today_poundary_flag;//卖方平今手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ sell_yesterday_discount;//卖方平昨手续费折扣率
			String^ sell_yesterday_poundary;//卖方平昨手续费
			String^ sell_yesterday_poundary_flag;//卖方平昨手续费的标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ sell_level_poundary;//卖方平仓手续费
			String^ sell_level_poundary_flag;//卖方平仓手续费标志 1 - 比例,使用时除以100000; 2 - 固定,使用时除以10，单位为分
			String^ buy_deposite;//买方向定金
			String^ buy_deposite_flag;//买方向定金标识，比率，使用时除以100000
			String^ sell_deposite;//卖方向定金
			String^ sell_deposite_flag;//卖方向定金标识比率，使用时除以100000
			String^ min_diff_price;//最小变动价
			String^ max_qtt;//单笔最大报单量
			String^ min_qtt;//单笔最小报单量
			String^ today_high_limit;//今最高限价
			String^ today_low_limit;//今最低限价
			String^ last_settle_price;//昨结价
			String^ trans_cft;//转换系数, 吨批转换系数
			String^ curr_id;//货币编号
			String^ curr_name;//货币名称
			String^ curr_unit;//货币单位
			String^ contract_type;//合同类型: 1普通；2-延期（连续现货）；4发售合同
			String^ min_apply_qtt;//最小交收申报量
			String^ permission_flag;//开平仓权限: 0 - 不限制; 1 - 只开; 2 - 只平
			String^ roe;//合同汇率 *100000
			String^ taxrate;//合同税率 *100000
			String^ is_binding;//远期延期是否绑定举荐机构、上市主体、预售商: 0 - 未完全绑定; 1 - 完全绑定
							  //发售合约：0未摇号; > 0已摇号
			String^ field48;//若是做市商合同,报单点差
			String^ field49;//若是做市商合同,报价点差
		};

		//商品信息包体
		public ref struct Goods_List
		{
			String^ goods_id;//商品编号
			String^ g_prop_id;//商品属性编号
			String^ g_prop_name;//商品属性名称
			String^ g_prop_default;//商品属性默认值
		};

		//市场状态
		public ref struct Market_Status
		{
			String^ cur_status;//市场状态:1: 初始化
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
			String^ cur_trade_day;//当前交易日
		};

		//币种汇率
		public ref struct Curr_Rate
		{
			String^ curr_id;//货币编号
			String^ curr_name;//货币名称
			String^ curr_unit;//货币单位
			String^ curr_ab;//货币缩写
			String^ roe;//汇率
			String^ settle_day;//结算日
			String^ operator_no;//操作员
			String^ operate_time;//操作时间
		};

		//交易回报
		public ref struct Trade_Return
		{
			String^ return_seq;//回报顺序号
			String^ return_type;//回报类型:
							   // 	1 - 交易报单成交回报；
							   // 	2 - 交易报单撤单通知；
							   // 	3 - 交收申报撤单通知；
							   // 	4 - 交收申报结果回报；
							   // 	5 - 风控强制撤单通知
							   // 	6 - OTC合约报价消息
			String^ return_title;//回报标题
			String^ return_cnt;//回报内容
							  //回报类型：“1交易报单成交回报”，内容格式：1标识 | 成交单ID | 成交单号 | 委托单ID | 委托单号 | 合同ID | 合同编号 | 成交价格 | 成交数量 | 转让价差 | 开平仓标记(1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；) | 报单类型(1 - 普通交易；2 - 对开仓；3 - 强制转让；4 - 强制减仓；5 - 协议转让；6 - 协议清仓；7 - 协议移仓；8 - 风险度强平；9 - 交割价试算强平；10 - 发售摇号开仓) | 回报内容
							  //回报类型：“2交易报单撤单通知”，“5风控强制撤单通知”，内容格式：2标识 | 委托单ID | 委托单号 | 撤单数量 | 回报内容
			String^ deal_id;//成交单ID
			String^ deal_no;// 成交单号
			String^ status;//回报状态
			String^ create_time;//回报发布时间
			String^ Send_Times;//发送次数
			String^ trade_day;//当前交易日
		};

		//公告
		public ref struct Bulletin
		{
			String^ bulletin_seq;//公告顺序号
			String^ type;//公告类型1 公共 2私有
			String^ title;//公告标题
			String^ content;//公告内容
			String^ content_type;//公告内容类型
								// 	1, 普通公告(跑马灯)
								// 	2, 普通公告(弹出框)
								// 	3, 强制平仓下单公告
								// 	4, 条件单触发公告,
								// 	5, 盈亏单触发公告,
								// 	6, 自动盈亏单触发公告,
								// 	7, 强制交收公告,
								// 	8, 强制回购公告
			String^ create_time;//公告发布时间
			String^ trans_string;//3强制平仓消息串:order_id|order_no|contract_id|contract_no|buyorsell|offset_flag|is_deposit|order_price|order_qtt|left_qtt|status|order_time|order_type
								//4、5条件单、盈亏单触发消息串order_id | order_no | contract_id | contract_no | buyorsell | offset_flag | is_deposit | order_price | order_qtt | left_qtt | status | order_time | co_id | ret_code(0报单成功) | trade_type
								//6自动止盈止损触发消息串：plo_no | plo_id | ORDER_LOCAL_ID | contract_id | contract_no | buyorsell | offset_flag | is_deposit | profit_price | loss_price | order_qtt | order_ip | valid_date | status | add_time | activity_time | pl_id | ret_code(0报单成功)
			String^ trade_day;//当前交易日
		};

		//资金信息
		public ref struct Fund
		{
			String^ avl_fund;//可用资金
			String^ occp_deposit;//定金占用
			String^ frz_ord_fund;//报单冻结
			String^ frz_risk_fund;//风控冻结
			String^ frz_csg_fund;//风控冻结
			String^ acct_balance;//帐面价差（盯市盈亏）
			String^ avl_rcpt;//最大可用仓单
			String^ today_poundary;//当日手续费
			String^ today_inout_fund;//当日出入金
			String^ today_in_fund;//当日入金
			String^ today_out_fund;//当日出金
			String^ total_right;//权益（权益＝可用资金＋保证金占用＋报单冻结+风控冻结+交收冻结+ABS（-账面价差））
			String^ today_cny_balance;//当日平仓盈亏＝（平仓价－开仓价）＊手数/税率
			String^ risk_degree;//风险度
			String^ rate_acct_balance;//帐面盈亏（计税）计税的盯市
			String^ max_can_out;//最大可出金额
			String^ position_profit;//持仓盈亏
			String^ floating_proft;//浮动盈亏=持仓盈亏+盯市盈亏
			String^ system_date;//资金查询时间戳
			String^ frz_others;//其他冻结(现货冻结)
			String^ last_avl_fund;//上日可用
		};

		//仓单列表
		public ref struct Receipts_List
		{
			String^ rcpt_no;//仓单编码(空)
			String^ goods_id;//商品编码
			String^ goods_name;//商品名称
			String^ contract_id;//合同ID
			String^ contract_no;//合同编码
			String^ trans_cft;//吨批转换
			String^ rcpt_qtt;//数量
			String^ avlb_qtt;//可用数量
			String^ frz_qtt;//冻结数量
			String^ csg_qtt;//已交收数量
			String^ frz_csg_qtt;//交收冻结数量
			String^ frz_risk_qtt;//风控锁定仓单数量
			String^ loan_qtt;//质押锁定数量
			String^ cancel_qtt;//注销数量
			String^ in_storage_date;//入库日期(空)
		};

		//成交列表
		public ref struct Dealf_List
		{
			String^ deal_no;//成交号
			String^ deal_id;//成交ID
			String^ order_no;//委托单号
			String^ order_id;//委托单ID
			String^ opp_order_no;//对手报单号
			String^ deal_time;//成交时间
			String^ client_no;//客户编码
			String^ contract_id;//合同ID
			String^ contract_no;//合同编码
			String^ buyorsell;//买卖方向
			String^ offset_flag;//开平仓类型 1、开仓（新订）；2、平今；3、平昨；4、平仓（先订先转）；5、平仓（转今优先）；6、指定仓平仓；
			String^ order_type;//申报类型 1, 普通交易 2, 对开仓 3, 强制转让 4, 强制减仓 5, 协议转让 6, 协议清仓 7, 协议移仓 8, 风险度强平 9, 交割价试算强平 10, 发售摇号开仓
			String^ is_deposit;//担保方式  1定金；6仓单
			String^ deal_price;//成交价格
			String^ deal_qtt;// 成交数量
			String^ profit_loss;// 转让价差
			String^ detail_seq;// 逐笔顺序号
		};

		//持仓查询
		public ref struct Subsf_List
		{
			String^	contract_id;//合同ID
			String^	contract_no;//合同编码
			String^	client_no;//客户编码
			String^	buyorsell;//买卖方向
			String^	dpst_total_qtt;//定金持仓
			String^	dpst_amt;//占用保证金金
			String^	rcpt_total_subs;//仓单持仓
			String^	dpst_avg_price;//定金开仓均价
			String^	rcpt_avg_price;//仓单开仓均价
			String^	cnyable_qtt;//总可转让数量
			String^	cnyable_qtt_today;//今仓可转让数量
			String^	rcpt_cnyable_qtt;//仓单可转让数量
			String^	rcpt_cnyable_qtt_today;//仓单今仓可转让数量
			String^	initial_cost;//开仓成本(若允许仓单盈亏，则为定金 + 仓单的开仓成本)
			String^	position_cost;//持仓成本(若允许仓单盈亏，则为定金 + 仓单的持仓成本)
			String^	dpst_position_avg_price;//定金持仓均价
			String^	rctp_position_avg_price;//仓单持仓均价
			String^	position_profit;//持仓盈亏
			String^	mark_market_profit;//盯市盈亏
			String^	floating_profit;//浮动盈亏
			String^	roe;//汇率(使用时除以100000)
			String^	rcpt_qtt_r;//自有仓单可用量
			String^	lender_qtt_w;//融仓单量
			String^	other_qtt;//融资持仓数量
			String^	frz_csg_qtt_d;//定金交收冻结
			String^	frz_csg_qtt_r;//仓单交收冻结
		};

		//出入金查询
		public ref struct Fund_Inout
		{
			String^ inout_seq;//出入金顺序号
			String^ cust_no;//会员编码
			String^ inorout;//出入金标志: 1：入金，2：出金
			String^ amount;//金额
			String^ pay_way;//支付方式；5 现金; 6 支票; 7 转账支票; 8 电汇; 9 网银; 10 汇款; 100 支付宝; - 9 客户端打开WEB地址为字段payment_no
			String^ bank_id;//出入金对应中心的结算银行编号
			String^ bank_name;//银行名称
			String^ bank_account;//票据对应银行帐号
			String^ payment_no;//银行票据编号;若pay_way = -9, 该字段为网银地址
			String^ oper;//申请人
			String^ oper_time;//申请时间
			String^ auth;//记账员
			String^ auth_date;//记账时间
			String^ status;//状态: 1 待审核; 2 驳回; 10 银行处理中; 11 银行驳回; 99 已完成;	- 1 取消; - 2已删除;
		};




	}
}




