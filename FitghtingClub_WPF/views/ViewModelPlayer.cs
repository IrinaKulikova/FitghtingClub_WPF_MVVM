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

        public int HealthPoints
        {
            get => _player.HealthPoints;
            set
            {
                _player.HealthPoints = value;
                OnPropertyChanged("HealthPoints");
            }
        }

        public string Name
        {
            get => _player.Name;
            set
            {
                _player.Name = value;
                OnPropertyChanged("Name");
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
