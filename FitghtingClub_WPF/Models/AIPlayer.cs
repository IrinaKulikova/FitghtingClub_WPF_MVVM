using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class AIPlayer : BasePlayer
    {
        public AIPlayer(string name) : base(name) { }

        public override void MakeBlock(Object sender, EventArgsBlock e)
        {
            Thread.Sleep(3000);
            Blocked = ((BodyPart)new Random().Next((int)BodyPart.Head, (int)BodyPart.Legs + 1));
            Block(this, new EventArgsBlock(Blocked));
        }

        public override void MakeHit(Object sender, EventArgsHit e)
        {
            Thread.Sleep(3000);
            BodyPart part = ((BodyPart)new Random().Next((int)BodyPart.Head, (int)BodyPart.Legs + 1));
            int power = (new Random().Next((int)HitPower.Min, (int)HitPower.Max));
            Hit(this, new EventArgsHit(part, power));
        }
    }
}