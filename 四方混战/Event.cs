using CommandSystem.Commands.Console;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
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
        public static void 玩家生成后(SpawnedEventArgs ev)
        {
            Player p = ev.Player;
            方法.方法.普通血量(p);
        }
        public static void 支援刷新前(RespawningTeamEventArgs ev)
        {
            
        }
        public static void 玩家受伤前(HurtingEventArgs ev)
        {
            亮亮博士.亮亮检测(ev);
        }
        public static void 玩家死亡后(DiedEventArgs ev)
        {
            Player p = ev.Player;
            方法.方法.删除角色(p);
        }
    }
}
