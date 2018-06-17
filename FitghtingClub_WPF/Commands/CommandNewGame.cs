using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    class CommandNewGame : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return !Game.GetInstance().IsNotOver;
        }

        public void Execute(object parameter)
        {
            Game game = Game.GetInstance();
            game.NewGame();
            game.Play();
        }
    }
}