using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class Player : BasePlayer
    {
        public Player(string name) : base(name) { }

        public override void MakeBlock(Object sender, EventArgsBlock e)
        {
            Block(this, new EventArgsBlock(Blocked));
        }

        public override void MakeHit(Object sender, EventArgsHit e)
        {
            Hit(this, new EventArgsHit(e.Part, new Random().Next((int)HitPower.Min, (int)HitPower.Max)));
        }
    }
}