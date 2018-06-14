using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsDeathRouted : EventArgs
    {
        public BasePlayer Player { get; set; }
        public EventArgsDeathRouted(BasePlayer player)
        {
            Player = player;
        }
    }
}