using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public class ViewModelLogger:INotifyPropertyChanged
    {
        ILogger logger;

        public event PropertyChangedEventHandler PropertyChanged;

        public String Log
        {
            get => logger.Status;
            set
            {
                logger.Status = value;
                OnPropertyChanged("Log");
            }
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModelLogger()
        {
            logger = HistoryLogger.GetInstance();
            logger.PropertyChanged += Logger_PropertyChanged;
        }

        private void Logger_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (logger as HistoryLogger).Messages.Add("");
        }
    }
}
