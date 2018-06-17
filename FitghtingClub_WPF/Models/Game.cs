using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        int _firstPlayer;

        Timer pauseHit = new Timer();
        Timer pauseBlock = new Timer();

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public List<BasePlayer> Players { get; private set; }

        int _round;

        public int Round
        {
            get => _round;
            set
            {
                _round = value;
                OnPropertyChanged("Round");
            }
        }

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

        String _currentPlayerName;
        public String CurrentPlayerName
        {
            get => _currentPlayerName;
            set
            {
                _currentPlayerName = value;
                OnPropertyChanged("CurrentPlayerName");
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
            Round = 1;
            IsNotOver = true;
            CurrentPlayer = new Random().Next(0, Players.Count);
            CurrentPlayerName = Players[CurrentPlayer].Name;
            _firstPlayer = CurrentPlayer;
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

            foreach (BasePlayer player in Players)
            {
                player.BlockEvent += Game_BlockEvent;
                player.DeathEvent += Game_DeathEvent;
                player.HitEvent += Game_HitEvent;
                _game.NewGameEvent += player.NewGame;
                _game.WoundEventRouted += player.GetHit;
            }

            pauseHit.Interval = 1000;
            pauseBlock.Interval = 1000;
            pauseBlock.Tick += PauseBlock_Tick;
            pauseHit.Tick += PauseHit_Tick;
        }

        private void PauseHit_Tick(object sender, EventArgs e)
        {
            Players[CurrentPlayer].MakeHit(BodyPart.Head);
            pauseHit.Stop();
        }

        private void PauseBlock_Tick(object sender, EventArgs e)
        {
            Players[CurrentPlayer].MakeBlock(BodyPart.Head);
            pauseBlock.Stop();
        }

        private void Game_HitEvent(object sender, EventArgsHit e)
        {
            if (sender is BasePlayer)
            {
                WoundEventRouted?.Invoke(sender, new EventArgsWoundRouted(e.Part, e.Power));
                (sender as BasePlayer).HaveToSetHit = false;
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
                if (Players[CurrentPlayer] is AIPlayer)
                {
                    pauseHit.Start();
                }
            }
        }
        
        public void Play()
        {
            Players[CurrentPlayer].HaveToSetBlock = true;
            if (Players[CurrentPlayer] is AIPlayer)
            {
                pauseBlock.Start();
            }
        }

        private void NextPlayer()
        {
            CurrentPlayer++;
            CurrentPlayer = CurrentPlayer >= Players.Count ? 0 : CurrentPlayer;
            CurrentPlayerName = Players[CurrentPlayer].Name;
            Round = (_firstPlayer == CurrentPlayer) ? ++Round : Round;
        }
    }
}