using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 拯救者
    {
        public static void 生成拯救者(Player p)
        {
            p.Role.Set(RoleTypeId.ChaosMarauder, Exiled.API.Enums.SpawnReason.RoundStart, RoleSpawnFlags.All);
            p.MaxHealth = 200;
            p.AddItem(ItemType.GrenadeFlash);
            p.RankName = "混沌拯救者";
            p.RankColor = "green";
            p.ShowHint(
                "你是混沌拯救者！担起作为先锋部队的职责" +
                "努力救出尽可能多的D级人员" +
                "干掉碍事的警卫和SCP" +
                "争取到下一波大部队的支援"
                , 5);
        }
        public static void 删除拯救者(Player p)
        {
            方法.删除称号(p);
        }
    }
}
