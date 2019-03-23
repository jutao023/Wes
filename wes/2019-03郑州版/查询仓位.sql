http://47.100.102.50/exchange/order/query_position
POST  JSON传参

{
  "memberId":10 ,//必传
  "productSymbol":"XDFYX" //非必传 产品编码
}

返参
{
    "data": [
        {
            "id": 1,
            "memberId": 100,
            "prodSymbol": "XDFYX",
            "balance": 985344,
            "frozenBalance": 9940,
            "address": null,
            "isLock": 0,
            "prodName": "新东方英语",
            "sellPrice": 134.3638,
            "averagePrice": 129.9972,
            "transferRate": null
        },
        {
            "id": 635,
            "memberId": 100,
            "prodSymbol": "ASD23",
            "balance": 100,
            "frozenBalance": 0,
            "address": null,
            "isLock": 0,
            "prodName": "ASD",
            "sellPrice": null,
            "averagePrice": null,
            "transferRate": null
        }
    ],
    "code": 0,
    "message": "SUCCESS",
    "totalPage": null,
    "totalElement": null
}