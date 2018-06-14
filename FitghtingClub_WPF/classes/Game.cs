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
    public sealed class  Game : INotifyPropertyChanged
    {
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
