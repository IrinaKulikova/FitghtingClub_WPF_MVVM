using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    class ViewModelGame : INotifyPropertyChanged
    {
        private Game _game;

        ObservableCollection<ViewModelPlayer> _players = new ObservableCollection<ViewModelPlayer>();

        public ObservableCollection<ViewModelPlayer> Players {
            get =>_players;
            set
            {
                _players = value;
                OnPropertyChanged("Players");
            }
        }

        public ViewModelGame()
        {
            _game = new Game();
            foreach (BasePlayer player in _game.Players)
            {
                Players.Add(new ViewModelPlayer(player));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
