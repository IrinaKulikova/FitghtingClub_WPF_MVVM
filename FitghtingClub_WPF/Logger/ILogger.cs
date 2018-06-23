using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitghtingClub_WPF
{
    public interface ILogger : INotifyPropertyChanged
    {
        String Status { get; set; }
        void Log(String data);
    }
}