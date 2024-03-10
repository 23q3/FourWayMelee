using Exiled.API.Features;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 四方混战.方法;

namespace 四方混战
{
    public class Event
    {
        public static void 回合开始后()
        {
            回合开始.开局();
        }
    }
}
