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
        List<Window> views = new List<Window>();
        public MainViewLogger()
        {
            InitializeComponent();
            WindowGetName getName = new WindowGetName();
            getName.ShowDialog();
            Window windowPlayer = new ViewGame() { Left = 100, Top = 100 };
            windowPlayer.Show();
            Window windowAIPlayer = new ViewGame() { Left = 1020, Top = 100 };
            windowAIPlayer.Show();
            views.Add(windowPlayer);
            views.Add(windowAIPlayer);
            Closed += MainViewLogger_Closed;
        }

        private void MainViewLogger_Closed(object sender, EventArgs e)
        {
            foreach (Window window in views) window.Close();
        }
    }
}
