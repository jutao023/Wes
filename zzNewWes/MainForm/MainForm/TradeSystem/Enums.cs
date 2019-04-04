
namespace wes
{
    enum EnumOrderType
    {
        抢购,
        购买,
        转让,
        兑换,
        增发
    }

    enum EnumBuySellType
    {
        购买,
        转让
    }

    enum EnumExceptionCode
    {
        行情异常,
        交易异常,
        行情线程被迫终止,
        交易线程被迫终止,
        其他异常
    }

    public enum EnumRunStatus
    {
        未启动,
        运行中,
        已停止,
        交易异常停止,
        行情接收异常,
        行情连接异常
    }
}
