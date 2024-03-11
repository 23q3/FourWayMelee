using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 亮亮博士
    {
        public static List<Player> LL = new List<Player>();
        public static void 生成亮亮(Player p)
        {
            List<ItemType> items = new List<ItemType>
            {
                ItemType.ArmorHeavy,
                ItemType.KeycardO5,
                ItemType.Adrenaline,
                ItemType.GunLogicer,
                ItemType.GunFRMG0,
                ItemType.ParticleDisruptor,
                ItemType.Jailbird,
                ItemType.MicroHID
            };
            方法.生成角色(p,RoleTypeId.Scientist,SpawnReason.Respawn,RoleSpawnFlags.None,true,500,items,"亮亮博士","yellow","你是亮亮博士！你天生自带强力武器！\n" +
                "SCP-173一次只能对你造成75HP伤害！",15,"ll");
        }
        public static void 亮亮检测(HurtingEventArgs ev)
        {
            Player k = ev.Attacker;
            Player p = ev.Player;
            if (方法.插件角色.TryGetValue(p,out string v) && v == "ll" && k.Role == RoleTypeId.Scp173)
            {
                ev.Amount = 75;
            }
        }
    }
}
