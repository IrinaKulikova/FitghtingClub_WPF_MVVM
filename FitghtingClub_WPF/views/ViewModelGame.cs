using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    class ViewModelGame : INotifyPropertyChanged
    {
        private Game _game;

        ObservableCollection<ViewModelPlayer> _players = new ObservableCollection<ViewModelPlayer>();

        public ObservableCollection<ViewModelPlayer> Players
        {
            get => _players;
            set
            {
                _players = value;
                OnPropertyChanged("Players");
            }
        }

        public int CurrentPlayer
        {
            get => _game.CurrentPlayer;
        }

        public int Round
        {
            get => _game.Round;
        }


        private ICommand _commandBlock;
        public ICommand CommandBlock
        {
            get
            {
                _commandBlock = _commandBlock ?? new CommandBlock();
                return _commandBlock;
            }
        }

        private ICommand _commandNewGame;
        public ICommand CommandNewGame
        {
            get
            {
                _commandNewGame = _commandNewGame ?? new CommandNewGame();
                return _commandNewGame;
            }
        }

        private ICommand _commandHit;
        public ICommand CommandHit
        {
            get
            {
                _commandHit = _commandHit ?? new CommandHit();
                return _commandHit;
            }
        }

        public ViewModelGame()
        {
            _game = Game.GetInstance();
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
