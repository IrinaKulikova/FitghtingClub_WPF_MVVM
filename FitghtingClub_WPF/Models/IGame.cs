using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    interface IGame
    {
        void NewGame();
        void Play();
        void NextPlayer();
        int CurrentPlayer { get; set; }
        void SetName(String name);
        List<BasePlayer> Players { get; set; }
        int Round { get; set; }
    }
}
