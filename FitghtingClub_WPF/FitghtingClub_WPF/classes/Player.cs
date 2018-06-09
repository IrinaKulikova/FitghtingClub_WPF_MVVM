using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    /// <summary>
    /// класс игрок
    /// </summary>
    public class Player : BasePlayer
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="name">имя игрока</param>
        public Player(string name) : base(name) { }

        /// <summary>
        /// поставить блок
        /// </summary>
        public override void MakeBlock(BodyPart part)
        {
            Blocked = part;
        }

        /// <summary>
        /// переопределяем метод базового класса сделать ход
        /// </summary>
        public override void MakeStep()
        {
            //fixe me
        }
    }
}
