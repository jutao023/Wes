using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wes
{
    interface MessageNotice
    {
        void MessageNotify(object sender,string msgType, string msg);
    }

    public interface State
    {
       void RunStatus(object sender, EnumRunStatus status, string _msg);
    }
}
