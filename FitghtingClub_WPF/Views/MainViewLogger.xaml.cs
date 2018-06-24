using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FitghtingClub_WPF
{
    /// <summary>
    /// Interaction logic for WindowLogger.xaml
    /// </summary>
    public partial class MainViewLogger : Window
    {
        public MainViewLogger()
        {
            InitializeComponent();
            WindowGetName getName = new WindowGetName();
            getName.ShowDialog();
            String name = getName.NamePlayer;
            ViewGame windowPlayer = new ViewGame(false,name) { Left = 100, Top = 100 };
            windowPlayer.Show();
            ViewGame windowAIPlayer = new ViewGame(true, name) { Left = 1020, Top = 100 };
            windowAIPlayer.Show();
        }
    }
}
