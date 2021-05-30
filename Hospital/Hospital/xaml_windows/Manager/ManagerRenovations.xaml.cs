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

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRenovations.xaml
    /// </summary>
    public partial class ManagerRenovations : Window
    {
        public ManagerRenovations()
        {
            InitializeComponent();
        }

        private void activeRenovationsBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerActiveRenovations();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }

        private void renovationHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRenovationHistory();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }
        private void scheduleRenovationBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerNewRenovation();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerUI(2);
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }

    }
}
