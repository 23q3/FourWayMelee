using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 保安
    {
        public static void 保安属性(Player p)
        {
            List<ItemType> items = new List<ItemType>
            {
                ItemType.GunE11SR,
                ItemType.ParticleDisruptor,
                ItemType.GrenadeFlash,
                ItemType.Medkit,
                ItemType.KeycardGuard,
                ItemType.ArmorCombat
            };
            方法.生成角色(p,RoleTypeId.FacilityGuard,SpawnReason.RoundStart,RoleSpawnFlags.AssignInventory,物品: items,是否清空物品:true);
        }
    }
}
