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
    /// Interaction logic for WindowGetName.xaml
    /// </summary>
    public partial class WindowGetName : Window
    {
        public WindowGetName()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Name = playerName.Text;
            Properties.Settings.Default.Save();
            Game.GetInstance().SetName(Properties.Settings.Default.Name);
            Close();
        }
    }
}
