using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    class ViewModelPlayer : INotifyPropertyChanged
    {
        private BasePlayer _player;

        public ViewModelPlayer(BasePlayer player)
        {
            _player = player;
        }

        public int Health {
            get => _player.HealthPoints;
            set
            {
                _player.HealthPoints = value;
                OnPropertyChanged("Health");
            }
        }

        public BodyPart SetBlock
        {
            get => _player.Blocked;
            set
            {
                _player.Blocked = value;
                OnPropertyChanged("SetBlock");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
