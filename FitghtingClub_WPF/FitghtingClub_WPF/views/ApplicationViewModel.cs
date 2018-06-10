using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF.views
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        public ApplicationViewModel()
        {
            BasePlayer player = new Player("Player");
            BasePlayer aiPlayer = new AIPlayer("AIPlayer");
            Game game = new Game(player, aiPlayer);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
