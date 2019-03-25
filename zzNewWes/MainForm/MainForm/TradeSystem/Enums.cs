
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
        线程被终止,
        socket异常,
        其他异常
    }

    enum EnumRunStatus
    {
        未启动,
        已启动,
        运行中,
        已停止,
        异常停止
    }
}
