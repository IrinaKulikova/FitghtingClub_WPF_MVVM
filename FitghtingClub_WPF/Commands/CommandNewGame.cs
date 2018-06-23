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

        bool _canExecute;

        public bool CanExecutePrperty
        {
            get => !Game.GetInstance().IsNotOver;
            set => _canExecute = value;
        }

        public bool CanExecute(object parameter)
        {
            return CanExecutePrperty;
        }

        public void Execute(object parameter)
        {
            Game.GetInstance().NewGame();
            (HistoryLogger.GetInstance() as HistoryLogger).Clear();
            _canExecute = false;
        }
    }
}