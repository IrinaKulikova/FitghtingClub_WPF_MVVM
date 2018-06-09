using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FightClub
{
    /// <summary>
    /// класс игра
    /// </summary>
    class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// счётчик раундов
        /// </summary>
        public int Round { get; private set; }

        /// <summary>
        /// колличество играков по умолчанию
        /// </summary>
        int _count = 2;

        /// <summary>
        /// коллекция играков
        /// </summary>
        public BasePlayer[] Players { get; }

        /// <summary>
        /// индекс игрока, чей ход
        /// </summary>
        int _currentPlayer;

        /// <summary>
        /// событие изминения свойств игры
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// состояние игры- игра не окончена
        /// </summary>
        private bool _gameIsNotOwer;

        /// <summary>
        /// проеверка что игра не окончена
        /// </summary>
        /// <returns></returns>
        public bool GameIsNotOwer
        {
            get => Players[0].HealthPoints > 0 && Players[1].HealthPoints > 0;
            private set { _gameIsNotOwer = value; }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="name"></param>
        public Game(BasePlayer player, BasePlayer aiPlayer)
        {
            GameIsNotOwer = true;
            Players = new BasePlayer[_count];
            Players[0] = player;
            Players[1] = aiPlayer;
            _currentPlayer = new Random().Next(0, _count);
        }



        /// <summary>
        /// метод старта игры
        /// </summary>
        public void Play()
        {
            while (_gameIsNotOwer)
            {
                Players[_currentPlayer].Block();
                Next();
                Players[_currentPlayer].Step();
            }
        }

        /// <summary>
        /// метод перехода хода
        /// </summary>
        private void Next()
        {
            _currentPlayer++;
            _currentPlayer = _currentPlayer >= _count ? 0 : _currentPlayer;
        }
    }
}
