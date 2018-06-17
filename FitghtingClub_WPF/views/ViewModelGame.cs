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

        public ObservableCollection<ViewModelPlayer> Players { get; set;}

        public int CurrentPlayer
        {
            get => _game.CurrentPlayer;
        }

        public int Round
        {
            get => _game.Round;
        }

        private ICommand _commandBlockHead;
        public ICommand CommandBlockHead
        {
            get
            {
                _commandBlockHead = _commandBlockHead ?? new CommandBlock(BodyPart.Head);
                return _commandBlockHead;
            }
        }

        private ICommand _commandBlockTrunk;
        public ICommand CommandBlockTrunk
        {
            get
            {
                _commandBlockTrunk = _commandBlockTrunk ?? new CommandBlock(BodyPart.Trunk);
                return _commandBlockTrunk;
            }
        }

        private ICommand _commandBlockLegs;
        public ICommand CommandBlockLegs
        {
            get
            {
                _commandBlockLegs = _commandBlockLegs ?? new CommandBlock(BodyPart.Legs);
                return _commandBlockLegs;
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

        private ICommand _commandHitHead;
        public ICommand CommandHitHead
        {
            get
            {
                _commandHitHead = _commandHitHead ?? new CommandHit(BodyPart.Head);
                return _commandHitHead;
            }
        }

        private ICommand _commandHitTrunk;
        public ICommand CommandHitTrunk
        {
            get
            {
                _commandHitTrunk = _commandHitTrunk ?? new CommandHit(BodyPart.Trunk);
                return _commandHitTrunk;
            }
        }

        private ICommand _commandHitLegs;
        public ICommand CommandHitLegs
        {
            get
            {
                _commandHitLegs = _commandHitLegs ?? new CommandHit(BodyPart.Legs);
                return _commandHitLegs;
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
