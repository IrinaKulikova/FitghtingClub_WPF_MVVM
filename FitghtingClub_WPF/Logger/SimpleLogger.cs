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
        static SimpleLogger _logger;
        String _status;
        public event PropertyChangedEventHandler PropertyChanged;

        SimpleLogger() { }

        public String Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
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

        public void Log(String data) => Status = data;
    }
}
