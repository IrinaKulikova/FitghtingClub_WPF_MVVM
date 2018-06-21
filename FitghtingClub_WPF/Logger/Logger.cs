using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    //синглетон
    public sealed class Logger : ILogger
    {
        static Logger _logger;

        String _status;

        public event PropertyChangedEventHandler PropertyChanged;

        Logger() { }

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

       
        public static Logger GetInstance()
        {
            _logger = _logger ?? new Logger();
            return _logger;
        }

        public void Log(String data)
        {
            Status = data;
        }

        public void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }
    }
}
