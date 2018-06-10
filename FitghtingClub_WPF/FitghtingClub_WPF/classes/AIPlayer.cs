using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class AIPlayer : BasePlayer
    {
        public AIPlayer(string name) : base(name) { }
        
        public override void MakeBlock(BodyPart part)
        {
            MakeBlock((BodyPart)new Random().Next((int)BodyPart.Head, (int)BodyPart.Legs + 1));
        }
        
        public override void MakeStep()
        {
            //генерируем событие игрок походил
        }
    }
}