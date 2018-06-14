using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsBlock : EventArgs
    {
        public BodyPart Part { get; set; }

        public EventArgsBlock(BodyPart part) { Part = part; }
    }
}
