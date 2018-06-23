using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    class CommandBlock : ICommand
    {
        BodyPart part;
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandBlock(BodyPart part)
        {
            this.part = part;
        }

        public bool CanExecute(object parameter)
        {
            return Game.GetInstance().Players[0].HaveToSetBlock && Game.GetInstance().IsNotOver;
        }

        public void Execute(object parameter)
        {
            Game.GetInstance().Players[0].MakeBlock(part);
            SimpleLogger.GetInstance().Log(Game.GetInstance().Players[0].Name + " set block " + part + " !");
        }
    }
}