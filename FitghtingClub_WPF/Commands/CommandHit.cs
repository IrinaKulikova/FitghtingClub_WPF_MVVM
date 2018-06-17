using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    class CommandHit : ICommand
    {
        BodyPart part;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandHit(BodyPart part)
        {
            this.part = part;
        }

        public bool CanExecute(object parameter)
        {
            return Game.GetInstance().Players[0].HaveToSetHit;
        }

        public void Execute(object parameter)
        {
            Game game = Game.GetInstance();
            game.Players[0].MakeHit(BodyPart.Trunk);
        }
    }
}
