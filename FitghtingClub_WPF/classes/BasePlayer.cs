using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public abstract class BasePlayer : INotifyPropertyChanged
    {
        //события установки, получения урона и смерти
        public event EventHandler<EventArgsWound> WoundEvent;
        public event EventHandler<EventArgsBlock> BlockgEvent;
        public event EventHandler<EventArgsDeath> DeathEvent;

        private bool _alive;
        private string _name;
        private int _healthPoints;
        private BodyPart _blockPart;
        public const int MAX_POINTS = 100;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool Alive
        {
            get => _alive;
            private set
            {
                _alive = value;
                OnPropertyChanged("Alive");
            }
        }


        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private bool ToStep { get; set; } = false;

        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                _healthPoints = value;
                OnPropertyChanged("HealthPoints");
            }
        }

        public BodyPart Blocked
        {
            get => _blockPart;
            set
            {
                _blockPart = value;
                OnPropertyChanged("Blocked");
            }
        }


        public BasePlayer(string name)
        {
            Name = name;
            HealthPoints = MAX_POINTS;
            _alive = true;
        }

        public void GetHit(BodyPart part, int power)
        {
            if (part != Blocked)
            {
                HealthPoints -= power;

                if (HealthPoints <= 0)
                {
                    _alive = false;
                }
            }
        }

        internal void NewGame()
        {
            HealthPoints = MAX_POINTS;
        }

        public void Step()
        {
            ToStep = false;
            MakeStep();
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void Block()
        {
            MakeBlock(Blocked);
        }

        public abstract void MakeBlock(BodyPart part);
        public abstract void MakeStep();
    }
}