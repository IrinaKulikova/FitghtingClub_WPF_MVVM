using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsHitRouted : EventArgs
    {
        public int Power { get; set; }
        public BodyPart Part { get; set; }
        public BasePlayer Player { get; set; }
        public EventArgsHitRouted(BasePlayer player, BodyPart part, int power)
        {
            Player = player;
            Power = power;
            Part = part;
        }
    }
}
