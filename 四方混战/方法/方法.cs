using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Permissions.Commands.Permissions;
using LiteNetLib;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace 四方混战.方法
{
    
    internal class 方法
    {
        public static Dictionary<Player,string> 插件角色 = new Dictionary<Player,string>();
        public static void 删除角色(
            Player p)
        {
            插件角色.Remove(p);    
            p.RankColor = null;
            p.RankName = null;    
            p.MaxHealth = 回合开始.最大血量;
        }
        public static void 生成角色(
            Player p,
            RoleTypeId 角色 = RoleTypeId.None,
            SpawnReason? 生成原因 = null,
            RoleSpawnFlags? 生成参数 = null,
            bool 是否清空物品 = false,
            int 最大血量 = 120,
            List<ItemType> 物品 = null,
            string 称号 = null,
            string 称号颜色 = null,
            string 说明 = null,
            float 说明显示时长 = 3,
            string 角色名 = null
            )
        {
            if (角色名 != null)
            {
                插件角色.Add(p,角色名);
            }
            if (角色 != RoleTypeId.None)
            {
                p.Role.Set(角色, 生成原因 ?? SpawnReason.None, 生成参数 ?? RoleSpawnFlags.None);
            }         
            if(最大血量 == 120 && 回合开始.双狗局)
            {
                p.Health = 回合开始.最大血量;
            }
            else 
            {
                p.Health = 最大血量;
            }
            p.RankName = 称号;
            p.RankColor = 称号颜色;
            p.ShowHint(说明,说明显示时长);           
            if(是否清空物品)
            {
                p.ClearItems();
            }
            p.AddItem(物品);
        }
        
        public static void 普通血量(Player p)
        {
            if (p.IsHuman && !插件角色.TryGetValue(p, out _))
            {
                p.Health = 回合开始.最大血量;
            }
        }
        public static void 逃出装备(SpawnedEventArgs ev,Player p )
        {
            if(ev.Reason == SpawnReason.Escaped && !插件角色.TryGetValue(p, out _))
            {
                p.Health = 200;
                p.AddItem(ItemType.MicroHID);
                p.EnableEffect(EffectType.Scp207, 1, 0,true);
                p.EnableEffect(EffectType.Vitality, 1, 0,true);
                p.ShowHint("\n获得电磁炮和可乐效果！\n如果背包满了请丢弃一件物品！",6);
            }
        }
        public static void SCP设置(SpawnedEventArgs ev,Player p)
        {
            if (p.Role == RoleTypeId.Scp049)
            {
                p.Health = 4500;
                p.EnableEffect(EffectType.BodyshotReduction, 40, 0);
                p.ShowHint("\n\n\n\n你拥有20％的枪械抗性！\n你在使用R技能时 可以为周围的队友回血！");                
            }
            if (p.Role == RoleTypeId.Scp173)
            {
                p.Health = 6000;
                p.EnableEffect(EffectType.BodyshotReduction, 100, 0, true);
                p.ShowHint("\n\n\n\n枪械对你难以造成伤害！你拥有50％的枪械抗性！");
            }
            if (p.Role == RoleTypeId.Scp939)
            {
                p.Health = 4500;
                p.ShowHint("\n");
            }
        }
    }
}
