#pragma once

#ifndef _JH_UTILS_
#define _JH_UTILS_

#include "JHDataType.h"
#include <iostream>
#include "ForDataType.h"
using namespace JiaoHui::JHData;

namespace JiaoHui {

	namespace JHUtils {

		public ref class JHUtil
		{
		public:

			static System::String^ stdString_To_clrString(std::string val);

			static std::string clrString_To_stdString(System::String^ val);

			static Trade_Head^ to_cs_Trade_Head(trade_head* ptrade_head);

			static Asso_Info^ to_cs_Asso_Info(asso_info* pAssoInfo);

			static Contract_List^ to_cs_Contract_List(contract_list* pCL);

			static Goods_List^ to_cs_Goods_List(goods_list* pGL);

			static Market_Status^ to_cs_Market_Status(market_status* pms);

			static Curr_Rate^ to_cs_Curr_Rate(curr_rate* pcr);

			static Trade_Return^ to_cs_Trade_Return(trade_return* ptr);

			static Bulletin^ to_cs_Bulletin(bulletin* pb);

			static Fund^ to_cs_Fund(fund* pf);

			static Orderf^ to_cs_Orderf(orderf* po);

			static Receipts_List^ to_cs_Receipts_List(receipts_list* prl);

			static Cancel_Order^ to_cs_Cancel_Order(cancel_order* pco);

			static Dealf_List^ to_cs_Dealf_List(dealf_list* pdl);

			static Subsf_List^ to_cs_Subsf_List(subsf_list* psl);

			static Fund_Inout^ to_cs_Fund_Inout(fund_inout* pfi);

		public:
			//@ 需要delete 返回值
			//@ Orderf^ pof :托管的类型
			static orderf* to_cpp_orderf(Orderf^ pof);

			//@ 需要delete 返回值
			static cancel_order* to_cpp_cancel_order(Cancel_Order^ pco);

		};
	}
}

#endif