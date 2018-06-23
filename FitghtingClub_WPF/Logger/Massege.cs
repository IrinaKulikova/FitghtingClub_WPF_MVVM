using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class Message
    {
        public DateTime Time { get; set; }
        public String Text { get; set; }

        public Message(String text)
        {
            Time = DateTime.Now;
            Text = text;
        }
    }
}
