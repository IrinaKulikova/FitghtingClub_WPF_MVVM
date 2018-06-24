using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    interface IGame : INotifyPropertyChanged
    {
        event EventHandler<EventArgsDeath> DeathEvent;
        event EventHandler<EventArgsWound> WoundEvent;
        event EventHandler<EventArgsBlock> BlockEvent;
        event EventHandler<EventArgsProtected> ProtectedEvent;
        event EventHandler NewGameEvent;

        void NewGame();
        void Play();
        void NextPlayer();
        int CurrentPlayer { get; set; }
        void SetName(String name);
        List<BasePlayer> Players { get; set; }
        int Round { get; set; }
    }
}
