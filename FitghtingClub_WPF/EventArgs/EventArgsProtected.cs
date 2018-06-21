using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class EventArgsProtected : EventArgs
    {
        public BodyPart Part { get; set; }

        public EventArgsProtected(BodyPart part)
        {
            Part = part;
        }
    }
}
