using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.Commands.Reload;
using InventorySystem.Items.Firearms;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 回合开始
    {
        public static void 开局()
        {
            黑卡();
            保安逻辑();
        }
        public static void 黑卡()
        {
            foreach (Player p in Player.List)
            {            
                int O5 = 0;
                while(O5 < 1)
                {
                    if (p.Role.Type == RoleTypeId.ClassD && p.CountItem(ItemType.KeycardO5) > 0)
                    {
                        O5 += 1;
                        p.AddItem(ItemType.KeycardO5);
                        p.ShowHint("恭喜你幸运的获得了O5钥匙卡", 5);             
                    }
                }
            }
            foreach (Player p in Player.List)
            {
                int O5 = 0;
                while (O5 < 1)
                {
                    if (p.Role.Type == RoleTypeId.Scientist && p.CountItem(ItemType.KeycardO5) > 0)
                    {
                        O5 += 1;
                        p.AddItem(ItemType.KeycardO5);
                        p.ShowHint("恭喜你幸运的获得了O5钥匙卡", 5);
                    }
                }
            }
        }
        public static void 保安逻辑()
        {
            int guard = 0;
            foreach(Player p in Player.List)
            {
                if(p.Role.Type == RoleTypeId.FacilityGuard)
                {
                    guard++;
                    保安属性(p);
                }
            }
            int ci = guard / 2;
            if(guard > 5)
            { 
                for(int i = 0;ci > 0;i++) 
                { 
                    foreach(Player p in Player.List)
                    {
                        if(p.Role == RoleTypeId.FacilityGuard)
                        {
                            拯救者.生成拯救者(p);
                            ci --;
                        }
                    }
                }
            }
        }
        public static void 保安属性(Player p)
        {
            p.MaxHealth = 120;
            p.ClearAmmo();
            p.ClearItems();
            p.AddItem(ItemType.GunE11SR);
            p.AddItem(ItemType.ParticleDisruptor);
            p.AddItem(ItemType.GrenadeFlash);            
            p.AddItem(ItemType.Medkit);            
            p.AddItem(ItemType.KeycardGuard);
            p.AddItem(ItemType.ArmorCombat);
        }

    }
}
