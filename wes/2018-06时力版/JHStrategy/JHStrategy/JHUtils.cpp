
#include "stdafx.h"

#include <msclr\marshal_cppstd.h> 
#include "JHUtils.h"

using namespace std;
using namespace msclr::interop;
using namespace System;
//
#define clr_To_std marshal_as<std::string>
//
#define std_To_clr marshal_as<System::String^>

//CPP 转 CLR
System::String^ JiaoHui::JHUtils::JHUtil::stdString_To_clrString(std::string val)
{
	return std_To_clr(val);
}

//
std::string JiaoHui::JHUtils::JHUtil::clrString_To_stdString(System::String^ val)
{
	return clr_To_std(val);
}

//
Trade_Head ^ JiaoHui::JHUtils::JHUtil::to_cs_Trade_Head(trade_head * ptrade_head)
{
	Trade_Head^ th = gcnew Trade_Head();

	th->ListNum = ptrade_head->ListNum;
	th->Children = ptrade_head->Children;
	th->ChildIndex = ptrade_head->ChildIndex;

	th->TradeNo = std_To_clr(ptrade_head->TradeNo);
	th->ModuleName = std_To_clr(ptrade_head->ModuleName);
	th->RequestType = std_To_clr(ptrade_head->RequestType);
	th->ReturnCode = std_To_clr(ptrade_head->ReturnCode);
	th->ReturnDesc = std_To_clr(ptrade_head->ReturnDesc);
	th->EmpAcct = std_To_clr(ptrade_head->EmpAcct);
	th->SessionId = std_To_clr(ptrade_head->SessionId);
	th->OperTime = std_To_clr(ptrade_head->OperTime);

	return th;
}

//
Asso_Info ^ JiaoHui::JHUtils::JHUtil::to_cs_Asso_Info(asso_info * pAssoInfo)
{
	Asso_Info^ ai = gcnew Asso_Info();

	ai->cust_id = JHUtil::stdString_To_clrString(pAssoInfo->cust_id);
	ai->associator_no = JHUtil::stdString_To_clrString(pAssoInfo->associator_no);
	ai->associator_fullname = JHUtil::stdString_To_clrString(pAssoInfo->associator_fullname);
	ai->compare_type = JHUtil::stdString_To_clrString(pAssoInfo->compare_type);
	ai->contacter = JHUtil::stdString_To_clrString(pAssoInfo->contacter);

	ai->telephone = JHUtil::stdString_To_clrString(pAssoInfo->telephone);
	ai->acct_name = JHUtil::stdString_To_clrString(pAssoInfo->acct_name);
	ai->bank_name = JHUtil::stdString_To_clrString(pAssoInfo->bank_name);
	ai->bank_account = JHUtil::stdString_To_clrString(pAssoInfo->bank_account);
	ai->acct_contract = JHUtil::stdString_To_clrString(pAssoInfo->acct_contract);

	ai->sales_name = JHUtil::stdString_To_clrString(pAssoInfo->sales_name);
	ai->sales_telphone = JHUtil::stdString_To_clrString(pAssoInfo->sales_telphone);
	ai->is_mailing_invoices = JHUtil::stdString_To_clrString(pAssoInfo->is_mailing_invoices);
	ai->contacter_addr = JHUtil::stdString_To_clrString(pAssoInfo->contacter_addr);
	ai->postcode = JHUtil::stdString_To_clrString(pAssoInfo->postcode);

	ai->password_type = JHUtil::stdString_To_clrString(pAssoInfo->password_type);
	ai->trade_role = JHUtil::stdString_To_clrString(pAssoInfo->trade_role);
	ai->Sign_status = JHUtil::stdString_To_clrString(pAssoInfo->Sign_status);

	return ai;
}

//
Contract_List ^ JiaoHui::JHUtils::JHUtil::to_cs_Contract_List(contract_list * pcl)
{
	Contract_List^ cl = gcnew Contract_List();

	cl->trade_mode = std_To_clr(pcl->trade_mode);
	cl->contract_id = std_To_clr(pcl->contract_id);
	cl->contract_no = std_To_clr(pcl->contract_no);
	cl->contract_name = std_To_clr(pcl->contract_name);

	cl->goods_id = std_To_clr(pcl->goods_id);
	cl->goods_name = std_To_clr(pcl->goods_name);
	cl->begin_day = std_To_clr(pcl->begin_day);
	cl->trade_end_day = std_To_clr(pcl->trade_end_day);
	cl->csg_begin_day = std_To_clr(pcl->csg_begin_day);

	cl->csg_end_day = std_To_clr(pcl->csg_end_day);
	cl->buy_open_poundary = std_To_clr(pcl->buy_open_poundary);
	cl->buy_open_poundary_flag = std_To_clr(pcl->buy_open_poundary_flag);
	cl->buy_today_poundary = std_To_clr(pcl->buy_today_poundary);
	cl->buy_today_poundary_flag = std_To_clr(pcl->buy_today_poundary_flag);

	cl->buy_yesterday_poundary = std_To_clr(pcl->buy_yesterday_poundary);
	cl->buy_yesterday_poundary_flag = std_To_clr(pcl->buy_yesterday_poundary_flag);
	cl->buy_level_poundary = std_To_clr(pcl->buy_level_poundary);
	cl->buy_level_poundary_flag = std_To_clr(pcl->buy_level_poundary_flag);
	cl->sell_open_poundary = std_To_clr(pcl->sell_open_poundary);

	cl->sell_open_poundary_flag = std_To_clr(pcl->sell_open_poundary_flag);
	cl->sell_today_poundary = std_To_clr(pcl->sell_today_poundary);
	cl->sell_today_poundary_flag = std_To_clr(pcl->sell_today_poundary_flag);
	cl->sell_yesterday_discount = std_To_clr(pcl->sell_yesterday_discount);
	cl->sell_yesterday_poundary = std_To_clr(pcl->sell_yesterday_poundary);

	cl->sell_yesterday_poundary_flag = std_To_clr(pcl->sell_yesterday_poundary_flag);
	cl->sell_level_poundary = std_To_clr(pcl->sell_level_poundary);
	cl->sell_level_poundary_flag = std_To_clr(pcl->sell_level_poundary_flag);
	cl->buy_deposite = std_To_clr(pcl->buy_deposite);
	cl->buy_deposite_flag = std_To_clr(pcl->buy_deposite_flag);

	cl->sell_deposite = std_To_clr(pcl->sell_deposite);
	cl->sell_deposite_flag = std_To_clr(pcl->sell_deposite_flag);
	cl->min_diff_price = std_To_clr(pcl->min_diff_price);
	cl->max_qtt = std_To_clr(pcl->max_qtt);
	cl->min_qtt = std_To_clr(pcl->min_qtt);

	cl->today_high_limit = std_To_clr(pcl->today_high_limit);
	cl->today_low_limit = std_To_clr(pcl->today_low_limit);
	cl->last_settle_price = std_To_clr(pcl->last_settle_price);
	cl->trans_cft = std_To_clr(pcl->trans_cft);
	cl->curr_id = std_To_clr(pcl->curr_id);

	cl->curr_name = std_To_clr(pcl->curr_name);
	cl->curr_unit = std_To_clr(pcl->curr_unit);
	cl->contract_type = std_To_clr(pcl->contract_type);
	cl->min_apply_qtt = std_To_clr(pcl->min_apply_qtt);
	cl->permission_flag = std_To_clr(pcl->permission_flag);

	cl->roe = std_To_clr(pcl->roe);
	cl->taxrate = std_To_clr(pcl->taxrate);
	cl->is_binding = std_To_clr(pcl->is_binding);
	cl->field48 = std_To_clr(pcl->field48);
	cl->field49 = std_To_clr(pcl->field49);
	
	return cl;
}

//
Goods_List ^ JiaoHui::JHUtils::JHUtil::to_cs_Goods_List(goods_list * pGL)
{
	Goods_List^ gl = gcnew Goods_List();

	gl->g_prop_default = std_To_clr(pGL->g_prop_default);
	gl->g_prop_name = std_To_clr(pGL->g_prop_name);
	gl->g_prop_id = std_To_clr(pGL->g_prop_id);
	gl->goods_id = std_To_clr(pGL->goods_id);

	return gl;
}

//
Market_Status ^ JiaoHui::JHUtils::JHUtil::to_cs_Market_Status(market_status * pms)
{
	Market_Status^ ms = gcnew Market_Status();

	ms->cur_status = std_To_clr(pms->cur_status);
	ms->cur_trade_day = std_To_clr(pms->cur_trade_day);

	return ms;
}

//
Curr_Rate ^ JiaoHui::JHUtils::JHUtil::to_cs_Curr_Rate(curr_rate * pcr)
{
	Curr_Rate^ cr = gcnew Curr_Rate();

	cr->curr_id = std_To_clr(pcr->curr_id);
	cr->curr_name = std_To_clr(pcr->curr_name);
	cr->curr_unit = std_To_clr(pcr->curr_unit);
	cr->curr_ab = std_To_clr(pcr->curr_ab);
	cr->roe = std_To_clr(pcr->roe);

	cr->settle_day = std_To_clr(pcr->settle_day);
	cr->operator_no = std_To_clr(pcr->operator_no);
	cr->operate_time = std_To_clr(pcr->operate_time);

	return cr;
}

//
Trade_Return^ JiaoHui::JHUtils::JHUtil::to_cs_Trade_Return(trade_return * ptr)
{
	
	Trade_Return^ tr = gcnew Trade_Return();

	tr->return_seq = std_To_clr(ptr->return_seq);
	tr->return_type = std_To_clr(ptr->return_type);
	tr->return_title = std_To_clr(ptr->return_title);
	tr->return_cnt = std_To_clr(ptr->return_cnt);
	tr->deal_id = std_To_clr(ptr->deal_id);

	tr->deal_no = std_To_clr(ptr->deal_no);
	tr->status = std_To_clr(ptr->status);
	tr->create_time = std_To_clr(ptr->create_time);
	tr->Send_Times = std_To_clr(ptr->Send_Times);
	tr->trade_day = std_To_clr(ptr->trade_day);

	return tr;
}

//
Bulletin ^ JiaoHui::JHUtils::JHUtil::to_cs_Bulletin(bulletin * pb)
{
	Bulletin^ b = gcnew Bulletin();
	
	b->bulletin_seq = std_To_clr(pb->bulletin_seq);
	b->type = std_To_clr(pb->type);
	b->title = std_To_clr(pb->title);
	b->content = std_To_clr(pb->content);
	b->content_type = std_To_clr(pb->content_type);

	b->create_time = std_To_clr(pb->create_time);
	b->trans_string = std_To_clr(pb->trans_string);
	b->trade_day = std_To_clr(pb->trade_day);

	return b;
}

//
Fund ^ JiaoHui::JHUtils::JHUtil::to_cs_Fund(fund * pf)
{
	Fund^ f = gcnew Fund();

	f->avl_fund = std_To_clr(pf->avl_fund);

	f->occp_deposit = std_To_clr(pf->occp_deposit);
	f->frz_ord_fund = std_To_clr(pf->frz_ord_fund);
	f->frz_risk_fund = std_To_clr(pf->frz_risk_fund);
	f->frz_csg_fund = std_To_clr(pf->frz_csg_fund);
	f->acct_balance = std_To_clr(pf->acct_balance);

	f->avl_rcpt = std_To_clr(pf->avl_rcpt);
	f->today_poundary = std_To_clr(pf->today_poundary);
	f->today_inout_fund = std_To_clr(pf->today_inout_fund);
	f->today_in_fund = std_To_clr(pf->today_in_fund);
	f->today_out_fund = std_To_clr(pf->today_out_fund);
	
	f->total_right = std_To_clr(pf->total_right);
	f->today_cny_balance = std_To_clr(pf->today_cny_balance);
	f->risk_degree = std_To_clr(pf->risk_degree);
	f->rate_acct_balance = std_To_clr(pf->rate_acct_balance);
	f->max_can_out = std_To_clr(pf->max_can_out);

	f->position_profit = std_To_clr(pf->position_profit);
	f->floating_proft = std_To_clr(pf->floating_proft);
	f->system_date = std_To_clr(pf->system_date);
	f->frz_others = std_To_clr(pf->frz_others);
	f->last_avl_fund = std_To_clr(pf->last_avl_fund);

	return f;
}

//
Orderf ^ JiaoHui::JHUtils::JHUtil::to_cs_Orderf(orderf * po)
{
	Orderf^ o = gcnew Orderf();

	o->order_local_id = std_To_clr(po->order_local_id);
	o->contract_id = std_To_clr(po->contract_id);
	o->buyorsell = std_To_clr(po->buyorsell);

	o->offset_flag = std_To_clr(po->offset_flag);
	o->trade_type = std_To_clr(po->trade_type);
	o->is_deposit = std_To_clr(po->is_deposit);
	o->stop_price = std_To_clr(po->stop_price);
	o->order_price = std_To_clr(po->order_price);

	o->order_qtt = std_To_clr(po->order_qtt);
	o->order_ip = std_To_clr(po->order_ip);
	o->detail_seq = std_To_clr(po->detail_seq);
	o->remark = std_To_clr(po->remark);
	o->order_no = std_To_clr(po->order_no);

	o->order_id = std_To_clr(po->order_id);
	o->order_time = std_To_clr(po->order_time);
	o->client_no = std_To_clr(po->client_no);
	o->contract_no = std_To_clr(po->contract_no);
	o->left_qtt = std_To_clr(po->left_qtt);

	o->cancel_qtt = std_To_clr(po->cancel_qtt);
	o->operator_no = std_To_clr(po->operator_no);
	o->status = std_To_clr(po->status);
	o->cancel_time = std_To_clr(po->cancel_time);
	o->ret_order_status = std_To_clr(po->ret_order_status);
	
	o->ret_order_status_desc = std_To_clr(po->ret_order_status_desc);
	o->frz_ord_fund = std_To_clr(po->frz_ord_fund);
	o->frz_poundary = std_To_clr(po->frz_poundary);
	o->roe = std_To_clr(po->roe);
	o->taxrate = std_To_clr(po->taxrate);

	o->order_type = std_To_clr(po->order_type);

	return o;
}

//
Receipts_List^ JiaoHui::JHUtils::JHUtil::to_cs_Receipts_List(receipts_list * prl)
{
	Receipts_List^ rl = gcnew Receipts_List();

	rl->rcpt_no = std_To_clr(prl->rcpt_no);
	rl->goods_id = std_To_clr(prl->goods_id);
	rl->goods_name = std_To_clr(prl->goods_name);
	rl->contract_id = std_To_clr(prl->contract_id);
	rl->contract_no = std_To_clr(prl->contract_no);

	rl->trans_cft = std_To_clr(prl->trans_cft);
	rl->rcpt_qtt = std_To_clr(prl->rcpt_qtt);
	rl->avlb_qtt = std_To_clr(prl->avlb_qtt);
	rl->frz_qtt = std_To_clr(prl->frz_qtt);
	rl->csg_qtt = std_To_clr(prl->csg_qtt);

	rl->frz_csg_qtt = std_To_clr(prl->frz_csg_qtt);
	rl->frz_risk_qtt = std_To_clr(prl->frz_risk_qtt);
	rl->loan_qtt = std_To_clr(prl->loan_qtt);
	rl->cancel_qtt = std_To_clr(prl->cancel_qtt);
	rl->in_storage_date = std_To_clr(prl->in_storage_date);

	return rl;
}

//
Cancel_Order ^ JiaoHui::JHUtils::JHUtil::to_cs_Cancel_Order(cancel_order * pco)
{
	Cancel_Order^ co = gcnew Cancel_Order();

	co->trade_mode = std_To_clr(pco->trade_mode);
	co->order_no = std_To_clr(pco->order_no);
	co->order_id = std_To_clr(pco->order_id);
	co->cancel_time = std_To_clr(pco->cancel_time);

	co->ret_cancel_status = std_To_clr(pco->ret_cancel_status);
	co->ret_desc = std_To_clr(pco->ret_desc);
	co->contract_id = std_To_clr(pco->contract_id);
	co->cancel_oper = std_To_clr(pco->cancel_oper);
	co->cancel_ip = std_To_clr(pco->cancel_ip);

	return co;
}

//
Dealf_List ^ JiaoHui::JHUtils::JHUtil::to_cs_Dealf_List(dealf_list * pdl)
{

	Dealf_List^ dl = gcnew Dealf_List();

	dl->deal_no = std_To_clr(pdl->deal_no);
	dl->deal_id = std_To_clr(pdl->deal_id);

	dl->order_no = std_To_clr(pdl->order_no);
	dl->order_id = std_To_clr(pdl->order_id);
	dl->opp_order_no = std_To_clr(pdl->opp_order_no);
	dl->deal_time = std_To_clr(pdl->deal_time);
	dl->client_no = std_To_clr(pdl->client_no);

	dl->contract_id = std_To_clr(pdl->contract_id);
	dl->contract_no = std_To_clr(pdl->contract_no);
	dl->buyorsell = std_To_clr(pdl->buyorsell);
	dl->offset_flag = std_To_clr(pdl->offset_flag);
	dl->order_type = std_To_clr(pdl->order_type);

	dl->is_deposit = std_To_clr(pdl->is_deposit);
	dl->deal_price = std_To_clr(pdl->deal_price);
	dl->deal_qtt = std_To_clr(pdl->deal_qtt);
	dl->profit_loss = std_To_clr(pdl->profit_loss);
	dl->detail_seq = std_To_clr(pdl->detail_seq);

	return dl;
}

//
Subsf_List ^ JiaoHui::JHUtils::JHUtil::to_cs_Subsf_List(subsf_list * psl)
{
	
	Subsf_List^ sl = gcnew Subsf_List();

	sl->contract_id = std_To_clr(psl->contract_id);

	sl->contract_no = std_To_clr(psl->contract_no);
	sl->client_no = std_To_clr(psl->client_no);
	sl->buyorsell = std_To_clr(psl->buyorsell);
	sl->dpst_total_qtt = std_To_clr(psl->dpst_total_qtt);
	sl->dpst_amt = std_To_clr(psl->dpst_amt);

	sl->rcpt_total_subs = std_To_clr(psl->rcpt_total_subs);
	sl->dpst_avg_price = std_To_clr(psl->dpst_avg_price);
	sl->rcpt_avg_price = std_To_clr(psl->rcpt_avg_price);
	sl->cnyable_qtt = std_To_clr(psl->cnyable_qtt);
	sl->cnyable_qtt_today = std_To_clr(psl->cnyable_qtt_today);

	sl->rcpt_cnyable_qtt = std_To_clr(psl->rcpt_cnyable_qtt);
	sl->rcpt_cnyable_qtt_today = std_To_clr(psl->rcpt_cnyable_qtt_today);
	sl->initial_cost = std_To_clr(psl->initial_cost);
	sl->position_cost = std_To_clr(psl->position_cost);
	sl->dpst_position_avg_price = std_To_clr(psl->dpst_position_avg_price);

	sl->rctp_position_avg_price = std_To_clr(psl->rctp_position_avg_price);
	sl->position_profit = std_To_clr(psl->position_profit);
	sl->mark_market_profit = std_To_clr(psl->mark_market_profit);
	sl->floating_profit = std_To_clr(psl->floating_profit);
	sl->roe = std_To_clr(psl->roe);

	sl->rcpt_qtt_r = std_To_clr(psl->rcpt_qtt_r);
	sl->lender_qtt_w = std_To_clr(psl->lender_qtt_w);
	sl->other_qtt = std_To_clr(psl->other_qtt);
	sl->frz_csg_qtt_d = std_To_clr(psl->frz_csg_qtt_d);
	sl->frz_csg_qtt_r = std_To_clr(psl->frz_csg_qtt_r);

	return sl;
}

//
Fund_Inout ^ JiaoHui::JHUtils::JHUtil::to_cs_Fund_Inout(fund_inout * pfi)
{
	
	Fund_Inout ^ fi = gcnew Fund_Inout();
	
	fi->inout_seq = std_To_clr(pfi->inout_seq);
	fi->cust_no = std_To_clr(pfi->cust_no);
	fi->inorout = std_To_clr(pfi->inorout);
	fi->amount = std_To_clr(pfi->amount);

	fi->pay_way = std_To_clr(pfi->pay_way);
	fi->bank_id = std_To_clr(pfi->bank_id);
	fi->bank_name = std_To_clr(pfi->bank_name);
	fi->bank_account = std_To_clr(pfi->bank_account);
	fi->payment_no = std_To_clr(pfi->payment_no);

	fi->oper = std_To_clr(pfi->oper);
	fi->oper_time = std_To_clr(pfi->oper_time);
	fi->auth = std_To_clr(pfi->auth);
	fi->auth_date = std_To_clr(pfi->auth_date);
	fi->status = std_To_clr(pfi->status);

	return fi;
}

//CLR  转  C++
orderf* JiaoHui::JHUtils::JHUtil::to_cpp_orderf(Orderf ^ pof)
{
	//
	String^ tmp = nullptr;
	//定义
	orderf* of = new orderf();
	memset(of, 0, sizeof orderf);

	tmp = pof->order_local_id;
	if (tmp != nullptr)
		of->order_local_id = clr_To_std(tmp);
	else
		of->order_local_id = "";

	tmp = pof->contract_id;
	if (tmp != nullptr)
		of->contract_id = clr_To_std(tmp);
	else
		of->contract_id = "";

	tmp = pof->buyorsell;
	if (tmp != nullptr)
		of->buyorsell = clr_To_std(tmp);
	else
		of->buyorsell = "";

	tmp = pof->offset_flag;
	if (tmp != nullptr)
		of->offset_flag = clr_To_std(tmp);
	else
		of->offset_flag = "";

	tmp = pof->trade_type;
	if (tmp != nullptr)
		of->trade_type = clr_To_std(tmp);
	else
		of->trade_type = "";

	tmp = pof->is_deposit;
	if (tmp != nullptr)
		of->is_deposit = clr_To_std(tmp);
	else
		of->is_deposit = "";

	tmp = pof->stop_price;
	if (tmp != nullptr)
		of->stop_price = clr_To_std(tmp);
	else
		of->stop_price = "";

	tmp = pof->order_price;
	if (tmp != nullptr)
		of->order_price = clr_To_std(tmp);
	else
		of->order_price = "";

	tmp = pof->order_qtt;
	if (tmp != nullptr)
		of->order_qtt = clr_To_std(tmp);
	else
		of->order_qtt = "";

	tmp = pof->order_ip;
	if (tmp != nullptr)
		of->order_ip = clr_To_std(tmp);
	else
		of->order_ip = "";

	tmp = pof->detail_seq;
	if (tmp != nullptr)
		of->detail_seq = clr_To_std(tmp);
	else
		of->detail_seq = "";

	tmp = pof->remark;
	if (tmp != nullptr)
		of->remark = clr_To_std(tmp);
	else
		of->remark = "";

	tmp = pof->order_no;
	if (tmp != nullptr)
		of->order_no = clr_To_std(tmp);
	else
		of->order_no = "";

	tmp = pof->order_id;
	if (tmp != nullptr)
		of->order_id = clr_To_std(tmp);
	else
		of->order_id = "";

	tmp = pof->order_time;
	if (tmp != nullptr)
		of->order_time = clr_To_std(tmp);
	else
		of->order_time = "";

	tmp = pof->client_no;
	if (tmp != nullptr)
		of->client_no = clr_To_std(tmp);
	else
		of->client_no = "";

	tmp = pof->contract_no;
	if (tmp != nullptr)
		of->contract_no = clr_To_std(tmp);
	else
		of->contract_no = "";

	tmp = pof->left_qtt;
	if (tmp != nullptr)
		of->left_qtt = clr_To_std(tmp);
	else
		of->left_qtt = "";
//
	tmp = pof->cancel_qtt;
	if (tmp != nullptr)
		of->cancel_qtt = clr_To_std(tmp);
	else
		of->cancel_qtt = "";

	tmp = pof->operator_no;
	if (tmp != nullptr)
		of->operator_no = clr_To_std(tmp);
	else
		of->operator_no = "";

	tmp = pof->status;
	if (tmp != nullptr)
		of->status = clr_To_std(tmp);
	else
		of->status = "";

	tmp = pof->cancel_time;
	if (tmp != nullptr)
		of->cancel_time = clr_To_std(tmp);
	else
		of->cancel_time = "";

	tmp = pof->ret_order_status;
	if (tmp != nullptr)
		of->ret_order_status = clr_To_std(tmp);
	else
		of->ret_order_status = "";

	tmp = pof->ret_order_status_desc;
	if (tmp != nullptr)
		of->ret_order_status_desc = clr_To_std(tmp);
	else
		of->ret_order_status_desc = "";

	tmp = pof->frz_ord_fund;
	if (tmp != nullptr)
		of->frz_ord_fund = clr_To_std(tmp);
	else
		of->frz_ord_fund = "";

	tmp = pof->frz_poundary;
	if (tmp != nullptr)
		of->frz_poundary = clr_To_std(tmp);
	else
		of->frz_poundary = "";

	tmp = pof->roe;
	if (tmp != nullptr)
		of->roe = clr_To_std(tmp);
	else
		of->roe = "";

	tmp = pof->taxrate;
	if (tmp != nullptr)
		of->taxrate = clr_To_std(tmp);
	else
		of->taxrate = "";

	tmp = pof->order_type;
	if (tmp != nullptr)
		of->order_type = clr_To_std(tmp);
	else
		of->order_type = "";

	return of;
}

//
cancel_order * JiaoHui::JHUtils::JHUtil::to_cpp_cancel_order(Cancel_Order ^ pco)
{
	
	String^ tmp = nullptr;
	
	cancel_order* co = new cancel_order();
	memset(co, 0, sizeof cancel_order);
	
	tmp = pco->trade_mode;
	if (tmp != nullptr)
		co->trade_mode = clr_To_std(tmp);
	else
		co->trade_mode = "";

	tmp = pco->order_no;
	if (tmp != nullptr)
		co->order_no = clr_To_std(tmp);
	else
		co->order_no = "";

	tmp = pco->order_id;
	if (tmp != nullptr)
		co->order_id = clr_To_std(tmp);
	else
		co->order_id = "";

	tmp = pco->cancel_time;
	if (tmp != nullptr)
		co->cancel_time = clr_To_std(tmp);
	else
		co->cancel_time = "";

	tmp = pco->ret_cancel_status;
	if (tmp != nullptr)
		co->ret_cancel_status = clr_To_std(tmp);
	else
		co->ret_cancel_status = "";

	tmp = pco->ret_desc;
	if (tmp != nullptr)
		co->ret_desc = clr_To_std(tmp);
	else
		co->ret_desc = "";

	tmp = pco->contract_id;
	if (tmp != nullptr)
		co->contract_id = clr_To_std(tmp);
	else
		co->contract_id = "";

	tmp = pco->cancel_oper;
	if (tmp != nullptr)
		co->cancel_oper = clr_To_std(tmp);
	else
		co->cancel_oper = "";

	tmp = pco->cancel_ip;
	if (tmp != nullptr)
		co->cancel_ip = clr_To_std(tmp);
	else
		co->cancel_ip = "";

	return co;
}


