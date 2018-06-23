using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    //синглетон
    public sealed class SimpleLogger : ILogger
    {
        static ILogger _logger;
        String _log;
        public event PropertyChangedEventHandler PropertyChanged;

        SimpleLogger() { }

        public String Log
        {
            get => _log;
            set
            {
                _log = value;
                OnPropertyChanged("Log");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public static ILogger GetInstance()
        {
            _logger = _logger ?? new SimpleLogger();
            return _logger;
        }
    }
}
