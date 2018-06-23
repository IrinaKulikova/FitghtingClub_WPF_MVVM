using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public sealed class HistoryLogger : ILogger
    {
        static HistoryLogger _logger;
        public List<String> Messages { get; set; } = new List<string>();
        public string Status { get; set; }

        HistoryLogger() {}

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public static ILogger GetInstance()
        {
            _logger = _logger ?? new HistoryLogger();
            return _logger;
        }

        void ILogger.Log(string data)
        {
            Status = data;
            Messages.Add(Status);
            OnPropertyChanged("Messages");
            OnPropertyChanged("Status");
        }

        public void Clear() => Messages.Clear();
    }
}