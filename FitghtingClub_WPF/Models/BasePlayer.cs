using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitghtingClub_WPF
{
    public abstract class BasePlayer : DependencyObject
    {
        public event EventHandler<EventArgsHit> HitEvent;
        public event EventHandler<EventArgsBlock> BlockEvent;
        public event EventHandler<EventArgsWound> WoundEvent;
        public event EventHandler<EventArgsProtected> ProtectedEvent;
        public event EventHandler<EventArgsDeath> DeathEvent;

        private BodyPart _blockPart;
        private bool _haveToSetBlock;
        private bool _haveToSetHit;
        public const int MAX_POINTS = 100;
        public event PropertyChangedEventHandler PropertyChanged;


        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(BasePlayer), new PropertyMetadata("no name"));


        public int HealthPoints
        {
            get { return (int)GetValue(HealthPointsProperty); }
            set { SetValue(HealthPointsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HealthPoints.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HealthPointsProperty =
            DependencyProperty.Register("HealthPoints", typeof(int), typeof(BasePlayer), new PropertyMetadata(default(int)));


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

        public void GetHit(Object sender, EventArgsWound e)
        {
            if (sender != this)
            {
                if (e.Part != Blocked)
                {
                    HealthPoints -= e.Power;
                    WoundEvent?.Invoke(this, new EventArgsWound(e.Part, e.Power));

                    if (HealthPoints <= 0)
                    {
                        DeathEvent?.Invoke(this, new EventArgsDeath());
                    }
                }
                else
                {
                    ProtectedEvent?.Invoke(this, new EventArgsProtected(Blocked));
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