using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitghtingClub_WPF
{
    //синглетон
    public sealed class Game : INotifyPropertyChanged
    {
        public event EventHandler<EventArgsBlockRouted> BlockEvent;
        public event EventHandler<EventArgsDeathRouted> DeathEvent;
        public event EventHandler<EventArgsWoundRouted> WoundEventRouted;
        public event EventHandler NewGameEvent;

        public int Round { get; set; }
        public List<BasePlayer> Players { get; private set; }
        private bool _isNotOver;
        int _currentPlayer;
        public int CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                OnPropertyChanged("Current");
            }
        }

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsNotOver
        {
            get => Players[0].HealthPoints > 0 && Players[1].HealthPoints > 0;
            private set => _isNotOver = value;
        }

        private static Game _game;

        public static Game GetInstance()
        {
            _game = _game ?? new Game();
            return _game;
        }

        public void NewGame()
        {
            _game = new Game();
            NewGameEvent?.Invoke(this, new EventArgs());
        }

        Game()
        {
            _game = this;
            _isNotOver = true;

            Players = new List<BasePlayer>
            {
                new Player("Player"),
                new AIPlayer("AIPlayer")
            };

            _currentPlayer = 1;
            Round = 1;

            foreach (BasePlayer player in Players)
            {
                player.BlockEvent += Game_BlockEvent;
                player.DeathEvent += Game_DeathEvent;
                player.HitEvent += Game_HitEvent;
                _game.NewGameEvent += player.NewGame;
                _game.WoundEventRouted += player.GetHit;
            }
        }


        private void Game_HitEvent(object sender, EventArgsHit e)
        {
            if (sender is BasePlayer)
            {
                BasePlayer player = sender is AIPlayer ? Players[0] : Players[1];
                player.GetHit(sender, new EventArgsWoundRouted(e.Part, e.Power));
                (sender as BasePlayer).HaveToSetHit = false;
                NextPlayer();
                Players[CurrentPlayer].HaveToSetBlock = true;
                if (CurrentPlayer == 1)
                {
                    Players[_currentPlayer].MakeBlock(null, null);
                }
            }
        }


        private void Game_DeathEvent(object sender, EventArgsDeath e)
        {
            if (sender is BasePlayer)
            {
                DeathEvent?.Invoke(this, new EventArgsDeathRouted(sender as BasePlayer));
                foreach (BasePlayer player in Players)
                {
                    player.HaveToSetBlock = false;
                    player.HaveToSetHit = false;
                }
            }
        }


        private void Game_BlockEvent(object sender, EventArgsBlock e)
        {
            if (sender is BasePlayer)
            {
                (sender as BasePlayer).HaveToSetBlock = false;
                NextPlayer();
                Players[CurrentPlayer].HaveToSetHit = true;
                if (CurrentPlayer == 1)
                {
                    Players[_currentPlayer].MakeHit(null, null);
                }
            }
        }


        public void Play()
        {
            Players[_currentPlayer].HaveToSetBlock = true;
            if (CurrentPlayer == 1)
            {
                Players[_currentPlayer].MakeBlock(null, null);
            }
        }


        private void NextPlayer()
        {
            _currentPlayer++;
            CurrentPlayer = _currentPlayer >= Players.Count ? 0 : _currentPlayer;
        }
    }
}
