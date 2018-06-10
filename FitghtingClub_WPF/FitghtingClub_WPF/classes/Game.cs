using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitghtingClub_WPF
{
    class Game : INotifyPropertyChanged
    {
        public int Round { get; private set; }

        // колличество играков по умолчанию
        int _count = 2;
        BasePlayer[] Players;
        int _currentPlayer;        
        public event PropertyChangedEventHandler PropertyChanged;        
        private bool _gameIsNotOwer;

        public bool GameIsNotOwer
        {
            get => Players[0].HealthPoints > 0 && Players[1].HealthPoints > 0;
            private set { _gameIsNotOwer = value; }
        }
        
        public Game(BasePlayer player, BasePlayer aiPlayer)
        {
            GameIsNotOwer = true;
            Players = new BasePlayer[_count];
            Players[0] = player;
            Players[1] = aiPlayer;
            _currentPlayer = new Random().Next(0, _count);
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
            _currentPlayer = _currentPlayer >= _count ? 0 : _currentPlayer;
        }
    }
}
