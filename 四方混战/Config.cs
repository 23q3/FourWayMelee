using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 四方混战
{
    public class Config : IConfig
    {
        [Description("插件开关")]
        public bool IsEnabled { get; set; } = true;
        [Description("调试信息输出")]
        public bool Debug { get; set; } = true;
    }
    public class Plugin : Plugin<Config>
    {
        private Event ev;
        public override void OnEnabled()
        {
            base.OnEnabled();
            ev = new Event();
            Exiled.Events.Handlers.Server.RoundStarted += Event.回合开始后;
        }
        public override void OnDisabled()
        {
            base.OnDisabled();
            Exiled.Events.Handlers.Server.RoundStarted -= Event.回合开始后;
            ev = null;
        }
    }
}
