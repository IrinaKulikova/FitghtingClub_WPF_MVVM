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
        String Log { get; set; }
    }
}