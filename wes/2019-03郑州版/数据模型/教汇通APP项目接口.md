## 系统中返回的编码值

| 编码值 | 说明               | 备注                      |
| ------ | ------------------ | ------------------------- |
| 200    | 操作成功           | 返回消息：Success         |
| 500    | 服务器异常         | 返回消息：Data Error      |
| 20000  | 操作失败           | 返回消息：Fail            |
| 20001  | 当前请求为非法请求 | 消息：非法请求,请联系客户 |
| 20002  | 数据加载失败       | 消息：加载失败,请刷新重试 |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
| 21001  | 登录失败           | 返回消息：账号/密码错误   |
| 21002  | 注册失败           | 返回消息：手机号已注册    |
| 21003  | 注册失败           | 返回消息：验证码无效      |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |
|        |                    |                           |







## 登录/注册

### 1、登录

说明：用户登录教汇通APP

**接口请求：**

```http
http://www.wes365.com/app/user/login?phone=13800110011&pwd=123123
```

**接口参数说明：**

| 参数  | 是否必须 | 说明   |
| ----- | -------- | ------ |
| phone | 是       | 手机号 |
| pwd   | 是       | 密码   |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",         //返回值消息
    "returnCode": "200",                //返回值编码（200表示成功）
    "object": [                       //返回的数据信息
        {
        "userId": 10001,              //用户id
        "userAccount": "13800110011", //手机号
        "userLabel": 0,               //用户标签(经济人or普通会员)
        "userAuthentication": true    //实名认证(true表示已认证)
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "21001",                  //返回值编码      
    "returnMessage": "账号/密码错误"	       //错误消息			
}
```





### 2、注册

说明：注册为教汇通会员

**接口请求：**

```http
http://www.wes365.com/app/user/register?phone=13800110011&pwd=abc123&sms_code=78423&recommend_code=9087&mode=1
```

**接口参数说明：**

| 参数           | 是否必须 | 说明                                             |
| -------------- | -------- | ------------------------------------------------ |
| phone          | 是       | 手机号码                                         |
| pwd            | 是       | 密码                                             |
| sms_code       | 是       | 验证码                                           |
| recommend_code | 否       | 推荐码（经济人的邀请码）                         |
| mode           | 是       | 注册方式：1为app注册、2为h5注册、3为系统后台注册 |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",           //返回值消息
    "returnCode": "200",                 //返回值编码（200表示成功）
    "object": [                       //返回的数据信息
        {
        "userId": 10001,              //用户id
        "userAccount": "13800110011", //手机号
        "userLabel": 0,               //用户标签(经济人or普通会员)
        "userAuthentication": true    //实名认证
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "21002",                  //返回值编码
    "returnMessage": "手机号已注册"				
}
```

```json
{
    "returnCode": "21003",                  //返回值编码
    "returnMessage": "验证码无效"				
}
```





### 3、忘记密码

说明：用户忘记密码，修改密码

**接口请求：**

```http
http://www.wes365.com/app/user/forget?phone=13800110011&newpwd=123123&sms_code=7908
```

**接口参数说明：**

| 参数     | 是否必须 | 说明   |
| -------- | -------- | ------ |
| phone    | 是       | 手机号 |
| newpwd   | 是       | 新密码 |
| sms_code | 是       | 验证码 |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",           //返回值消息
    "returnCode": "200",                  //返回值编码（200表示成功）
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "21003",                  //返回值编码      
    "returnMessage": "验证码无效"	         //错误消息			
}
```



### 4、发送验证码

说明：注册、忘记密码时，获取验证码

**接口请求：**

```http
http://www.wes365.com/app/user/sms_code?phone=13800110011&stype=register
```

**接口参数说明：**

| 参数  | 是否必须 | 说明                       |
| ----- | -------- | -------------------------- |
| phone | 是       | 手机号                     |
| stype | 是       | 短信类型：register、change |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                  //返回值编码（200表示成功）
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "21003",                  //返回值编码      
    "returnMessage": "验证码无效"	              //错误消息			
}
```





## 首页

### 1、Banner轮播图

说明：查询banner轮播图片

**接口请求：**

```http
http://www.wes365.com/app/index/banner?terminal=user-app
```

**接口参数说明：**

| 参数     | 是否必须 | 说明                                           |
| -------- | -------- | ---------------------------------------------- |
| terminal | 是       | 终端标识：user-app(用户端)、market-app(行情端) |

**接口请求返回：**获取到当前要加载的广告信息

成功例子：

```json
{
    "returnMessage": "Success",          //返回值消息
    "returnCode": "200",                 //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
            {
                "bannerId": 1,              //bannerID
                "bannerImage": "string",    //图片地址
                "bannerHttpUrl": "string", //点击图片的链接地址
                "isClick": true,            //是否可点击标记
                "sortId": 1                 //排序编号(展示顺序的序列号)
            },
             {
                "bannerId": 2,     
                "bannerImage": "string", 
                "bannerHttpUrl": "string", 
                "isClick": true,   
                "sortId": 2      
            },
             {
                "bannerId": 3,    
                "bannerImage": "string", 
                "bannerHttpUrl": "string",
                "isClick": true,  
                "sortId": 3     
            }
        ]    
    }
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "20002",                  //返回值编码      
    "returnMessage": "加载失败,请刷新重试"	       //错误消息			
}
```





### 2、版本更新

说明：查询当前app的版本信息



**接口请求：**

```http
http://www.wes365.com/app/update/version?app_key=com.zh.wes
```

**接口参数说明：**

| 参数    | 是否必须 | 说明                          |
| ------- | -------- | ----------------------------- |
| app_key | 是       | app密钥（默认为：com.zh.wes） |
|         |          |                               |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",         //返回值消息
    "returnCode": "200",                //返回值编码（200表示成功）
    "object": [                         //返回的数据信息
        {
        "appSecret": "com.zh.wes",     //app密钥
        "newVersion": "v1.0.0", 	    //最新版本号
        "versionNum": 100,			    //版本标识符
        "getUrl": "string",			//app下载地址
        "newFeatures": "string",   	//更新内容
        "forceFlag": true		        //强制更新标记(true表示强制更新)
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 3、搜索[分页]（第三方提供）

说明：app中输入要搜索的商品信息。（模糊匹配）

商品信息包含：商品名称、商品编号、商品种类



**接口请求：**

```http
http://www.wes365.com/app/search/?content=........
```

**接口参数说明：**

| 参数    | 是否必须 | 说明       |
| ------- | -------- | ---------- |
| content | 是       | 搜索的内容 |
|         |          |            |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                  //返回值编码（200表示成功）
    "totalCount": 0,
    "object": [                       //返回的数据信息
        {  
           //商品列表信息
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 4、站内消息[分页]

说明：app中的站内消息



**接口请求：**

```http
http://www.wes365.com/app/msg?userid=10001
```

**接口参数说明：**

| 参数   | 是否必须 | 说明   |
| ------ | -------- | ------ |
| userid | 是       | 用户id |
|        |          |        |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                  //返回值编码（200表示成功）
    "totalCount": 12,
    "object": [                       //返回的数据信息
        {
        "messageTitle": "String",      //标题
        "messageContent": "String",    //内容
        "messageDate":"String"         //时间
        },
        {
        "messageTitle": "String",     
        "messageContent": "String",
        "messageDate": "String" 
        },
        {
        "messageTitle": "String",     
        "messageContent": "String",    
        "messageDate":"String"
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 5、公告[分页]

说明：显示官方的公告信息



**接口请求：**

```http
http://www.wes365.com/app/index/notice?terminal=user-app
```

**接口参数说明：**

| 参数     | 是否必须 | 说明                                           |
| -------- | -------- | ---------------------------------------------- |
| terminal | 是       | 终端标识：user-app(用户端)、market-app(行情端) |
|          |          |                                                |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",            //返回值消息
    "returnCode": "200",                   //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
        "noticTitle": "String",     //标题
        "noticContent": "String"    //内容
        "noticContent": "String"    //时间    
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 6、热门商品列表[分页]（第三方提供）

说明：查询热门商品信息，返回列表



**接口请求：**

```http
http://www.wes365.com/...........................
```

**接口参数说明：**

| 参数 | 是否必须 | 说明 |
| ---- | -------- | ---- |
|      | 是       |      |
|      |          |      |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
           //商品信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```











## 选课

### 1、所有商品信息[分页]（第三方提供）

说明：查询所有商品信息，返回列表

**接口请求：**

```http
http://www.wes365.com/..................
```

**接口参数说明：**

| 参数 | 是否必须 | 说明 |
| ---- | -------- | ---- |
|      | 是       |      |
|      | 是       |      |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
           //商品信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```

```json
{
    "returnCode": "20002",                       //返回值编码      
    "returnMessage": "加载失败,请刷新重试"	       //错误消息			
}
```





### 2、所有商品种类（第三方提供）

说明：查询所有商品的种类（用于在对商品进行条件过滤时，从后台获取所有的商品分类，从而可以选择不同的分类来过滤商品）



**接口请求：**

```http
http://www.wes365.com/...................
```

**接口参数说明：**

| 参数 | 是否必须 | 说明 |
| ---- | -------- | ---- |
|      |          |      |
|      |          |      |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
           //商品种类信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```



### 3、关注商品/取消关注商品

说明：对某个商品进行关注或取消关注



**接口请求：**

```http
http://www.wes365.com/app/goods/follow?userid=10001&goodsid=T9011&flag=1
```

**接口参数说明：**

| 参数    | 是否必须 | 说明                           |
| ------- | -------- | ------------------------------ |
| goodsid | 是       | 商品编号                       |
| flag    | 是       | 标记：1表示关注、0表示取消关注 |
| userid  | 是       | 用户id                         |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```







### 4、查看所有已关注商品[分页]

说明：查询所有已关注的商品信息列表



**接口请求：**

```http
http://www.wes365.com/app/goods/following?userid=100001
```

**接口参数说明：**

| 参数   | 是否必须 | 说明   |
| ------ | -------- | ------ |
| userid | 是       | 用户id |
|        |          |        |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
        "goodsId": "T9011",          //商品编号
        "goodsName": "String",       //商品名称
        "goodsImage": "String",      //商品图片路径
        "goodsType": "String",       //商品分类名称
        "goodsPrice": 48.9,          //商品单价(当日高价/抢购价格)
        "rushEndTime": "2019-03-06 24:00:00",    //抢购结束时间
        "buyType": 0,               //购买类型：1表示订购、0表示抢购       
        "goodsStatus": 1            //商品状态：0表示售罄、1表示可购买     
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```







### 5、对商品进行条件过滤[分页]（第三方提供）

说明：根据选择的条件，对商品进行过滤



**接口请求：**

```http
http://www.wes365.com/...............................
```

**接口参数说明：**

| 参数 | 是否必须 | 说明 |
| ---- | -------- | ---- |
|      | 是       |      |
|      |          |      |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 0,
    "object": [                       //返回的数据信息
        {
           //信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 6、获取某个商品的单价（第三方提供）

说明：查询某个商品的市场单价(高价/抢购价/低价)



**接口请求：**

```http
http://www.wes365.com/app/goods/max?goodsid=J9011&mode=1
```

**接口参数说明：**

| 参数    | 是否必须 | 说明                                      |
| ------- | -------- | ----------------------------------------- |
| goodsid | 是       | 商品编号                                  |
| mode    | 是       | 购买方式：1表示订购、2表示抢购、3表示转让 |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "object": [                       //返回的数据信息
        {
        "goodsId": "J9022",     // 商品种类信息   
        "maxPrice": 11.2109     // 高价/抢购价    
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```



### 7、提交订单

说明：app向服务器提交订单相关信息。

服务器存储订单的相关信息。订单总价=商品单价*购买数量



**接口请求：**

```http
http://www.wes365.com/app/order/submit?userid=10001&goodsid=T9011&goodsname=韦博英语&amount=11&mode=1&price=20.12
```

**接口参数说明：**

| 参数      | 是否必须 | 说明                           |
| --------- | -------- | ------------------------------ |
| userid    | 是       | 用户id                         |
| goodsid   | 是       | 商品编号                       |
| goodsname | 是       | 商品名称                       |
| mode      | 是       | 购买方式：1表示订购、2表示抢购 |
| amount    | 是       | 购买数量                       |
| price     | 是       | 商品单价(订购价/抢购价)        |
|           |          |                                |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
        "orderId": "String",              //订单id
        "orderTradeNum": "String"        //订单交易流水号（订单编号）   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 8、订单支付

说明：根据用户选择的支付方式，对已提交订单进行付款。



**接口请求：**

```http
http://www.wes365.com/app/order/pay?orderid=101&money=340.1&ptype=1
```

**接口参数说明：**

| 参数    | 是否必须 | 说明                                          |
| ------- | -------- | --------------------------------------------- |
| orderid | 是       | 订单id                                        |
| money   | 是       | 订单支付总金额                                |
| ptype   | 是       | 支付方式：1表示支付宝、2表示微信、3表示银行卡 |
|         |          |                                               |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 9、获取推荐商品信息（第三方提供）

说明：在进入到支付成功页面时，会获取一个推荐商品给用户



**接口请求：**

```http
http://www.wes365.com/app/goods/recommend?goodsid=T9011
```

**接口参数说明：**

| 参数    | 是否必须 | 说明     |
| ------- | -------- | -------- |
| goodsid | 是       | 商品编号 |
|         |          |          |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "object": [                       //返回的数据信息
        {
           //商品信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 10、查看商品详情（第三方提供）

说明：查询某个商品的详情信息



**接口请求：**

```http
http://www.wes365.com/app/goods/detail?goodsid=J9011
```

**接口参数说明：**

| 参数    | 是否必须 | 说明     |
| ------- | -------- | -------- |
| goodsid | 是       | 商品编号 |
|         |          |          |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
             //banner图片地址
             //商品编号
             //商品名称
             //商品的高价
             //商品的低价
             //商品的抢购价
             //商品描述（url地址）
             //用户持有当前商品的数量
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 11、商品转让

说明：针对当前持有的商品数量进行转卖



**接口请求：**

```http
http://www.wes365.com/app/order/resell?userid=1001&goodsis=J9011&goodsname=韦博英语&amount=8&price=12.11
```

**接口参数说明：**

| 参数      | 是否必须 | 说明             |
| --------- | -------- | ---------------- |
| userid    | 是       | 用户id           |
| goodsid   | 是       | 商品编号         |
| amount    | 是       | 转让数量         |
| price     | 是       | 商品市场价(低价) |
| goodsname | 是       | 商品名称         |
|           |          |                  |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
           //信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```





### 12、商品兑换

说明：针对当前持有的商品进行兑换。



**接口请求：**

```http
http://www.wes365.com/...................
```

**接口参数说明：**

| 参数 | 是否必须 | 说明 |
| ---- | -------- | ---- |
|      |          |      |
|      |          |      |

**接口请求返回：**

成功例子：

```json
{
    "returnMessage": "Success",               //返回值消息
    "returnCode": "200",                      //返回值编码（200表示成功）
    "totalCount": 3,
    "object": [                       //返回的数据信息
        {
           //信息   
        }
    ]
}
```

失败例子：

```json
{
    "returnCode": "500",                  //返回值编码      500表示失败
    "returnMessage": "Data Error"				
}
```









