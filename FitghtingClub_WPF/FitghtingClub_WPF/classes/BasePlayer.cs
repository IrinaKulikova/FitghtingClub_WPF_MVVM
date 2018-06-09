using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    /// <summary>
    /// базовый класс игрок
    /// </summary>
    public abstract class BasePlayer : INotifyPropertyChanged
    {
        /// <summary>
        /// состояние игрок жив
        /// </summary>
        private bool _alive;

        /// <summary>
        /// имя игрока
        /// </summary>
        private string _name;

        /// <summary>
        /// очки здоровья игрока
        /// </summary>
        private int _healthPoints;

        /// <summary>
        /// 
        /// </summary>
        private BodyPart _blockPart;

        public bool Alive
        {
            get => _alive;
            private set
            {
                _alive = value;
                OnPropertyChanged("Alive");
            }
        }

        /// <summary>
        /// имя
        /// </summary>
        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// очередь игрока
        /// </summary>
        private bool ToStep { get; set; } = false;

        /// <summary>
        /// очки здоровья игрока
        /// </summary>
        public int HealthPoints
        {
            get => _healthPoints;
            private set
            {
                _healthPoints = value;
                OnPropertyChanged("HealthPoints");
            }
        }

        /// <summary>
        /// заблокированная часть тела
        /// </summary>
        public BodyPart Blocked
        {
            get => _blockPart;
            set
            {
                _blockPart = value;
                OnPropertyChanged("Blocked");
            }
        }

        /// <summary>
        /// максимальные очки здоровья
        /// </summary>
        public int MaxPoints { get; } = 100;

        /// <summary>
        /// событие изминения какого либо свойства у объекта
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="name">имя игрока</param>
        public BasePlayer(string name)
        {
            Name = name;
            HealthPoints = MaxPoints;
            _alive = true;
        }

        /// <summary>
        /// метод принимающий часть тела для удара
        /// </summary>
        public void GetHit(BodyPart part, int power)
        {
            if (part != Blocked)
            {
                //уменьшаем здоровье
                HealthPoints -= power;

                if (HealthPoints <= 0)
                {
                    _alive = false;
                }
            }
        }

        /// <summary>
        /// обработка события новая игра
        /// </summary>
        internal void NewGame()
        {
            HealthPoints = MaxPoints;
        }

        /// <summary>
        /// метод инкапсулирующий вызов события ход
        /// </summary>
        /// <param name="e"></param>
        public void Step()
        {
            ToStep = false;
            MakeStep();
        }

        /// <summary>
        /// метод, который генерирует событие изминения данных у игрока
        /// </summary>
        /// <param name="prop"></param>
        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        /// <summary>
        /// метод установить блок
        /// </summary>
        public void Block()
        {
            MakeBlock(Blocked);
        }

        /// <summary>
        /// абстрактный метод для перегрузки - поставить блок
        /// </summary>
        public abstract void MakeBlock(BodyPart part);

        /// <summary>
        /// абстрактный метод сделать ход для перегрузки у производнях классов
        /// </summary>
        public abstract void MakeStep();
    }
}