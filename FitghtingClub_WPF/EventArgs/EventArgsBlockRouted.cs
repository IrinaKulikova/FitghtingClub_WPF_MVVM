using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsBlockRouted : EventArgs
    {
        public BodyPart Part { get; set; }
        public BasePlayer Player { get; set; }
        public EventArgsBlockRouted(BasePlayer player, BodyPart part)
        {
            Player = player;
            Part = part;
        }
    }
}
