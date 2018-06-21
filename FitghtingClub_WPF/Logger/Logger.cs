using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    //синглетон
    public sealed class Logger : INotifyPropertyChanged
    {
        static Logger _logger;

        String _status;


        public String Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        Logger()
        {

        }

        public static Logger GetInstance()
        {
            _logger = _logger ?? new Logger();
            return _logger;
        }
    }
}
