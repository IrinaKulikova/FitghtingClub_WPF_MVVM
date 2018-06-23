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
        ILogger historyLogger;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Message> Messages { get; set; }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModelLogger()
        {
            historyLogger = HistoryLogger.GetInstance();
            Messages = new ObservableCollection<Message>((historyLogger as HistoryLogger).Messages);
            historyLogger.PropertyChanged += HistoryLogger_PropertyChanged;
        }

        private void HistoryLogger_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
           // Messages.Add(new Message((sender as HistoryLogger).Log));
            OnPropertyChanged(e.PropertyName);
        }
    }
}
