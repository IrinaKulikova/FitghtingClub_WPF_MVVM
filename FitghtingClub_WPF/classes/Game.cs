using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitghtingClub_WPF
{
    //синглетон
    public sealed class Game : INotifyPropertyChanged
    {

        public event EventHandler<EventArgsWoundRouted> WoundEvent;
        public event EventHandler<EventArgsBlockRouted> BlockEvent;
        public event EventHandler<EventArgsDeathRouted> DeathEvent;

        public int Round { get; private set; }
        public List<BasePlayer> Players { get; private set; }
        private bool _gameIsNotOwer;
        int _currentPlayer;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool GameIsNotOwer
        {
            get => Players[0].HealthPoints > 0 && Players[1].HealthPoints > 0;
            private set { _gameIsNotOwer = value; }
        }

        private static Game _game;

        //получение ссылки на игру
        public static Game GetInstance()
        {
            if (_game == null)
            {
                _game = new Game();
            }
            return _game;
        }

        Game()
        {
            GameIsNotOwer = true;
            Players = new List<BasePlayer>
            {
                new Player("Player"),
                new AIPlayer("AIPlayer")
            };
            _currentPlayer = new Random().Next(0, Players.Count);

            foreach (BasePlayer player in Players)
            {
                player.BlockEvent += Game_BlockEvent;
                player.DeathEvent += Game_DeathEvent;
                player.WoundEvent += Game_WoundEvent;
            }
        }

        private void Game_WoundEvent(object sender, EventArgsWound e)
        {
            if (sender is BasePlayer)
            {
                WoundEvent?.Invoke(this, new EventArgsWoundRouted(sender as BasePlayer, e.Part, e.Wound));
            }
        }

        private void Game_DeathEvent(object sender, EventArgsDeath e)
        {
            if (sender is BasePlayer)
            {
                DeathEvent?.Invoke(this, new EventArgsDeathRouted(sender as BasePlayer));
            }
        }

        private void Game_BlockEvent(object sender, EventArgsBlock e)
        {
            if (sender is BasePlayer)
            {
                BlockEvent?.Invoke(this, new EventArgsBlockRouted(sender as BasePlayer, e.Part));
            }
        }

        public void Play()
        {
            while (_gameIsNotOwer)
            {
                Players[_currentPlayer].Block();
                Next();
                Players[_currentPlayer].Step();
            }
        }

        private void Next()
        {
            _currentPlayer++;
            _currentPlayer = _currentPlayer >= Players.Count ? 0 : _currentPlayer;
        }
    }
}
