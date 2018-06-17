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
        public event EventHandler<EventArgsDeathRouted> DeathEvent;
        public event EventHandler<EventArgsWoundRouted> WoundEventRouted;
        public event EventHandler NewGameEvent;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
        public int Round { get; set; }

        public List<BasePlayer> Players { get; private set; }

        int _currentPlayer;
        public int CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                _currentPlayer = value;
                OnPropertyChanged("CurrentPlayer");
            }
        }
                
        public bool IsNotOver { get; private set; }

        private static Game _game;

        public static Game GetInstance()
        {
            _game = _game ?? new Game();
            return _game;
        }

        public void NewGame()
        {
            Round = 0;
            IsNotOver = true;
            CurrentPlayer = 1;
            NewGameEvent?.Invoke(this, new EventArgs());
        }

        Game()
        {
            _game = this;
            IsNotOver = false;

            Players = new List<BasePlayer>
            {
                new Player("Player"),
                new AIPlayer("AIPlayer")
            };

            CurrentPlayer = 1;

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
                WoundEventRouted?.Invoke(sender, new EventArgsWoundRouted(e.Part, e.Power));
                (sender as BasePlayer).HaveToSetHit = false;
                NextPlayer();
                Play();
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
                IsNotOver = false;
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
                    Players[_currentPlayer].MakeHit(BodyPart.Head);
                }
            }
        }


        public void Play()
        {
            Round++;
            Players[_currentPlayer].HaveToSetBlock = true;
            if (CurrentPlayer == 1)
            {
                Players[_currentPlayer].MakeBlock(BodyPart.Head);
            }
        }


        private void NextPlayer()
        {
            _currentPlayer++;
            CurrentPlayer = _currentPlayer >= Players.Count ? 0 : _currentPlayer;
        }
    }
}
