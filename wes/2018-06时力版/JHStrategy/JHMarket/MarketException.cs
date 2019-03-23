using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiaoHui.JHCore
{
    public class MarketException : Exception
    {
        public MarketException(string _msg) : base(_msg) { }
    }
}
