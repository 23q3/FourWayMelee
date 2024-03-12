using Exiled.API.Features;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 先遣队
    {
        public static void 生成先遣队(Player p)
        {
            List<ItemType> 物品 = new List<ItemType>
            {
                ItemType.GrenadeFlash
            };
            方法.生成角色(p, RoleTypeId.ChaosMarauder, Exiled.API.Enums.SpawnReason.RoundStart, RoleSpawnFlags.AssignInventory, false, 200, 物品, "混沌先遣队", "green",
                "\n你是混沌先遣队！担起作为先锋部队的职责\n" +
                "努力救出尽可能多的D级人员\n" +
                "争取票数以获得支援！\n"
                , 15,角色名:"hdxqd");         
        }
    }
}
