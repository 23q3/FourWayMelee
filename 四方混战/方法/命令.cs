using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RemoteAdmin;
using System.Runtime.CompilerServices;

namespace 四方混战.方法
{
    internal class 命令
    {
        [CommandHandler(typeof(RemoteAdminCommandHandler))]
        public class 面板 : ICommand
        {
            private Player player = null;

            public string Command { get; } = "spawn";
            public string[] Aliases { get; } = { "s" };
            public string Description { get; } = "spawn/s + 插件角色名 + 玩家id";

            public string[] Usage { get; } = new string[1] { "list" };
            public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
            {
                if (arguments.Count != 1 && arguments.Count !=2)
                {
                    response = "错误的格式！用法 spawn/s + 插件角色名 + 玩家id";
                    return false;
                }
                if (arguments.Count == 2)
                {
                    bool s = int.TryParse(arguments.At(1), out int n);
                    if (s)
                    {

                    }
                    else
                    {
                        response = "不合法的数字ID 请输入整数！";
                        return false;
                    }               
                    foreach (Player p in Player.List) 
                    {
                        
                        if (p.Id == n)
                        {
                            player = p;
                        }                                            
                    }
                    if (player == null)
                    {
                        response = $"未找到id为: {n} 的玩家,请输入正确的id";
                        return false;
                    }
                }
                else
                {
                    if(arguments.At(0) == "list") 
                    {
                        response =
                        "角色列表：\n" +
                        "c/clear 清除身份\n" +
                        "hdxqd 混沌先遣队\n" +
                        "bc 四方装备保安\n" +
                        "ll 亮亮博士";
                        return true;
                    }
                    else
                    {
                        response = "错误的格式！用法 spawn/s + 插件角色名 + 玩家id";
                        return false;
                    }
                }
                if (arguments.At(0) == "hdxqd")
                {
                    先遣队.生成先遣队(player);
                    response = "生成成功！";
                    player = null;
                    return true;
                }
                else if (arguments.At(0) == "ba")
                {
                    保安.保安属性(player);
                    response = "生成成功！";
                    player = null;
                    return true;
                }
                else if (arguments.At(0) == "c"|| arguments.At(0) == "clear")
                {
                    方法.删除角色(player);
                    response = "已清除";
                    player = null;
                    return true;
                }
                else if (arguments.At(0) == "ll")
                {
                    亮亮博士.生成亮亮(player);
                    response = "生成成功！";
                    return true;
                }
                else
                {
                    response = $"未知的角色: {arguments.At(0)} 输入list查看所有角色";
                    return false;
                }
            }
        }
    }
}
