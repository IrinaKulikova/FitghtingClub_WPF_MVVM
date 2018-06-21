using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsWound : EventArgs
    {
        public int Power { get; set; }
        public BodyPart Part { get; set; }

        public EventArgsWound(BodyPart part, int power)
        {
            Part = part;
            Power = power;
        }
    }
}
