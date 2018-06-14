using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsWoundRouted : EventArgs
    {
        public int Wound { get; set; }
        public BodyPart Part { get; set; }
        public BasePlayer Player { get; set; }
        public EventArgsWoundRouted(BasePlayer player, BodyPart part, int wound)
        {
            Player = player;
            Wound = wound;
            Part = part;
        }
    }
}
