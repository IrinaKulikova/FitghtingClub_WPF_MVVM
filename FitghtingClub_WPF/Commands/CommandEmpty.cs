using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitghtingClub_WPF
{
    public class CommandEmpty : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) => false;
        public void Execute(object parameter) { }
    }
}
