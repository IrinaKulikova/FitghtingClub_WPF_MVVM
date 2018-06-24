using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public sealed class HistoryLogger : ILogger
    {
        static ILogger _logger;

        public List<Message> Messages { get; set; } = new List<Message>();

        private String _log;

        public string Log
        {
            get => _log;
            set
            {
                _log = value;
                OnPropertyChanged("Log");
                Messages.Add(new Message(_log));

                using (StreamWriter writer = new StreamWriter("log.txt", true))
                {
                    writer.WriteLine(Log);
                }
            }
        }

        HistoryLogger()
        {
            Log = "Start application";
        }

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

        public void Clear() => Messages.Clear();
    }
}