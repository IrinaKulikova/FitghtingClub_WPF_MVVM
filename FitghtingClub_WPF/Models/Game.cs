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
    public sealed class Game : IGame, INotifyPropertyChanged
    {
        public event EventHandler<EventArgsDeath> DeathEvent;
        public event EventHandler<EventArgsWound> WoundEvent;
        public event EventHandler<EventArgsWound> GetHitEvent;
        public event EventHandler<EventArgsBlock> BlockEvent;
        public event EventHandler<EventArgsProtected> ProtectedEvent;
        public event EventHandler NewGameEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        int _firstPlayer;
        Timer pauseHit = new Timer();
        Timer pauseBlock = new Timer();

        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public List<BasePlayer> Players { get; set; }

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
            Play();
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
                player.WoundEvent += Player_WoundEvent;
                player.ProtectedEvent += Player_ProtectedEvent;
                _game.NewGameEvent += player.NewGame;
                _game.GetHitEvent += player.GetHit;
            }

            pauseHit.Interval = 2000;
            pauseBlock.Interval = 2000;
            pauseBlock.Tick += PauseBlock_Tick;
            pauseHit.Tick += PauseHit_Tick;
        }

        private void Player_WoundEvent(object sender, EventArgsWound e)
        {
            WoundEvent?.Invoke(sender, e);
        }

        private void Player_ProtectedEvent(object sender, EventArgsProtected e)
        {
            ProtectedEvent?.Invoke(sender, e);
        }

        private void PauseHit_Tick(object sender, EventArgs e)
        {
            if (IsNotOver)
            {
                Players[CurrentPlayer].MakeHit(BodyPart.Head);
                pauseHit.Stop();
            }
        }

        private void PauseBlock_Tick(object sender, EventArgs e)
        {
            if (IsNotOver)
            {
                Players[CurrentPlayer].MakeBlock(BodyPart.Head);
                pauseBlock.Stop();
            }
        }

        private void Game_HitEvent(object sender, EventArgsHit e)
        {
            if (sender is BasePlayer)
            {
                GetHitEvent?.Invoke(sender, new EventArgsWound(e.Part, e.Power));
                (sender as BasePlayer).HaveToSetHit = false;
                Play();
            }
        }

        private void Game_DeathEvent(object sender, EventArgsDeath e)
        {
            if (sender is BasePlayer)
            {
                foreach (BasePlayer player in Players)
                {
                    player.HaveToSetBlock = false;
                    player.HaveToSetHit = false;
                }
                IsNotOver = false;
                DeathEvent?.Invoke(sender as BasePlayer, new EventArgsDeath());
            }
        }

        private void Game_BlockEvent(object sender, EventArgsBlock e)
        {
            if (sender is BasePlayer)
            {
                (sender as BasePlayer).HaveToSetBlock = false;
                BlockEvent?.Invoke(Players[CurrentPlayer], new EventArgsBlock(Players[CurrentPlayer].Blocked));
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

        public void NextPlayer()
        {
            CurrentPlayer++;
            CurrentPlayer = CurrentPlayer >= Players.Count ? 0 : CurrentPlayer;
            CurrentPlayerName = Players[CurrentPlayer].Name;
            Round = (_firstPlayer == CurrentPlayer) ? ++Round : Round;
        }
    }
}