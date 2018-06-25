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

        public override void MakeBlock(BodyPart part)
        {
            Blocked = part;
            Block(this, new EventArgsBlock(part));
        }

        public override void MakeHit(BodyPart part)
        {
            Hit(this, new EventArgsHit(part, random.Next((int)HitPower.Min, (int)HitPower.Max)));
        }
    }
}