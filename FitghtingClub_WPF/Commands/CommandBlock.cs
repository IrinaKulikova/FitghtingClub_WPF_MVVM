using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    //команда удара
    class CommandBlock : ICommand
    {
        //делегат удара
        private Action<BasePlayer, BodyPart> actionBlock;

        //может ли игрок ходить
        private Func<object, bool> canActionBlock;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandBlock(Action<BasePlayer, BodyPart> action, Func<object, bool> canExcecute = null)
        {
            this.actionBlock = action;
            this.canActionBlock = canExcecute;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(BasePlayer player, BodyPart part)
        {
            this.actionBlock?.Invoke(player, part);
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
