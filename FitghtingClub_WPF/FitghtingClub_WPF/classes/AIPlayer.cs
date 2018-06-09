using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    /// <summary>
    /// игрок- компьютер
    /// </summary>
    public class AIPlayer : BasePlayer
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="name">имя игрока</param>
        public AIPlayer(string name) : base(name) { }

        /// <summary>
        /// поставить блок
        /// </summary>
        public override void MakeBlock(BodyPart part)
        {
            MakeBlock((BodyPart)new Random().Next((int)BodyPart.Head, (int)BodyPart.Legs + 1));
        }

        /// <summary>
        /// переопределяем метод базового класса сделать ход
        /// </summary>
        public override void MakeStep()
        {
            //генерируем событие игрок походил
        }
    }
}