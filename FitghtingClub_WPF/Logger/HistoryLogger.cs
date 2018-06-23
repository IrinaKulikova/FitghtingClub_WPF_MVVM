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
        static ILogger _logger;

        public List<String> Messages { get; set; } = new List<string>();

        private String _log;

        public string Log
        {
            get => _log;
            set
            {
                _log = "<" + DateTime.Now.ToLocalTime() + "> " + value;
                Messages.Add(Log);
                OnPropertyChanged("Messages");
                OnPropertyChanged("Log");
            }
        }

        HistoryLogger() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public static ILogger GetInstance()
        {
            _logger = _logger ?? new HistoryLogger();
            _logger.Log = "Start application";
            return _logger;
        }

        public void Clear() => Messages.Clear();
    }
}