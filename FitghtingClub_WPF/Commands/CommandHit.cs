using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    //команда удара
    class CommandHit : ICommand
    {
        //делегат удара
        private Action<BasePlayer, BodyPart, int> actionHit;

        //может ли игрок ходить
        private Func<object, bool> canActionHit;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CommandHit(Action<BasePlayer,BodyPart,int> action, Func<object,bool> canExcecute=null)
        {
            this.actionHit = action;
            this.canActionHit = canExcecute;
        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(BasePlayer player, BodyPart part, int power)
        {
            this.actionHit?.Invoke(player, part, power);
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
