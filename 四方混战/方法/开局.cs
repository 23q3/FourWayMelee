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
        public static bool 双狗局 = false;
        public static int 最大血量 = 120;
        public static void 开局()
        {
            双狗判定();
            黑卡();
            保安逻辑();
        }
        public static void 双狗判定()
        {
            if(Player.List.Count > 29)
            {
                双狗局 = true;
                最大血量 = 150;
            }
        }
        public static void 黑卡()
        {
            int O5 = 1;
            foreach (Player p in Player.List)
            {
                if (O5 < 1) { return; }
                if (p.Role.Type == RoleTypeId.ClassD && p.CountItem(ItemType.KeycardO5) < 1)
                {
                    p.AddItem(ItemType.KeycardO5);
                    p.ShowHint("恭喜你幸运的获得了O5钥匙卡", 5);
                    O5--;
                }
            }
            O5 = 1;
            foreach (Player p in Player.List)
            {
                if (O5 < 1) { return; }
                if (p.Role.Type == RoleTypeId.Scientist && p.CountItem(ItemType.KeycardO5) < 1)
                { 
                    if (O5 < 1) { return; }
                    p.AddItem(ItemType.KeycardO5);
                    p.ShowHint("恭喜你幸运的获得了O5钥匙卡", 5);
                    O5--;
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
                    保安.保安属性(p);
                }
            }
            int HID = 2;
            foreach(Player p in Player.List)
            {
                if(HID < 1) { return; }
                if(p.Role.Type == RoleTypeId.FacilityGuard)
                {
                    HID--;
                    p.AddItem(ItemType.MicroHID);
                    p.ShowHint("你已获得电磁炮！好好利用！");
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
                            先遣队.生成先遣队(p);
                            ci --;
                        }
                    }
                }
            }
        }
    }
}
