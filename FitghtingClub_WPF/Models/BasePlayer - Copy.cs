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
        public event EventHandler<EventArgsHit> HitEvent;
        public event EventHandler<EventArgsBlock> BlockEvent;
        public event EventHandler<EventArgsDeath> DeathEvent;

        private string _name;
        private int _healthPoints;
        private BodyPart _blockPart;
        private bool _haveToSetBlock;
        private bool _haveToSetHit;
        public const int MAX_POINTS = 100;
        public event PropertyChangedEventHandler PropertyChanged;

        public bool HaveToSetBlock
        {
            get => _haveToSetBlock;
            set
            {
                _haveToSetBlock = value;
                OnPropertyChanged("HaveToSetBlock");
            }
        }

        public bool HaveToSetHit
        {
            get => _haveToSetHit;
            set
            {
                _haveToSetHit = value;
                OnPropertyChanged("HaveToSetHit");
            }
        }

        public void Hit(Object sender, EventArgsHit e)
        {
            HitEvent?.Invoke(sender, e);
        }

        public void Block(Object sender, EventArgsBlock e)
        {
            BlockEvent?.Invoke(sender, e);
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

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
        }

        public void GetHit(Object sender, EventArgsWoundRouted e)
        {
            if (sender != this)
            {
                if (e.Part != Blocked)
                {
                    HealthPoints -= e.Power;

                    if (HealthPoints <= 0)
                    {
                        DeathEvent?.Invoke(this, new EventArgsDeath());
                    }
                }
            }
        }

        public void NewGame(object sender, EventArgs e)
        {
            HealthPoints = MAX_POINTS;
            HaveToSetBlock = false;
            HaveToSetHit = false;
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public abstract void MakeBlock(BodyPart part);
        public abstract void MakeHit(BodyPart part);
    }
}