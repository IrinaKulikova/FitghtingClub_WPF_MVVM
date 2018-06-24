using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class ViewModelLogger : INotifyPropertyChanged
    {
        ILogger _historyLogger;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Message> Messages { get; set; }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModelLogger()
        {
            _historyLogger = HistoryLogger.GetInstance();
            Messages = new ObservableCollection<Message>((_historyLogger as HistoryLogger).Messages);
            _historyLogger.PropertyChanged += HistoryLogger_PropertyChanged;
            Game _game = Game.GetInstance();
            _game.NewGameEvent += _game_NewGameEvent;            
            _game.BlockEvent += _game_BlockEvent;
            _game.DeathEvent += _game_DeathEvent;
            _game.WoundEvent += _game_WoundEvent;
            _game.ProtectedEvent += _game_ProtectedEvent;
        }
                
        private void HistoryLogger_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Messages.Add(new Message((sender as HistoryLogger).Log));
            OnPropertyChanged(e.PropertyName);
        }

        private void _game_WoundEvent(object sender, EventArgsWound e)
        {
            _historyLogger.Log = (sender as BasePlayer).Name + " hit in the " + e.Part +" with power "+ e.Power;
        }

        private void _game_ProtectedEvent(object sender, EventArgsProtected e)
        {
            _historyLogger.Log = (sender as BasePlayer).Name + " protected " + e.Part;
        }

        private void _game_NewGameEvent(object sender, EventArgs e)
        {
            _historyLogger.Log = "New game!";
        }

        private void _game_DeathEvent(object sender, EventArgsDeath e)
        {
            _historyLogger.Log = (sender as BasePlayer).Name + " died!!!";
        }

        private void _game_BlockEvent(object sender, EventArgsBlock e)
        {
            _historyLogger.Log = (sender as BasePlayer).Name + " set block " + e.Part;
        }
    }
}
