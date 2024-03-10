using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战.方法
{
    internal class 方法
    {
        public static void 删除称号(Player p)
        {
            p.RankColor = null;
            p.RankName = null;
        }
    }
}
