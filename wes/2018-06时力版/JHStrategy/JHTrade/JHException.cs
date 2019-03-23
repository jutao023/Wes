using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaoHui.JHCore
{
    public class JHException : Exception
    {
        public JHException(string _exp) : base(_exp) { }
    }

    public class JHTradeException : JHException
    {
        public JHTradeException(string _exp) : base(_exp) { }
    }

    public class JHMarketException : JHException
    {
        public JHMarketException(string _exp) : base(_exp) { }
    }
}
