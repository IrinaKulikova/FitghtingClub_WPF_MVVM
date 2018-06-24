using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class ViewModelGetName : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Game _game;
        private String _playerName;
        public String PlayerName
        {
            get => _playerName;
            set
            {
                _playerName = value;
                _game.Players[0].Name = value;
                OnPropertyChanged("PlayerName");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModelGetName()
        {
            _game = Game.GetInstance();
        }
    }
}
