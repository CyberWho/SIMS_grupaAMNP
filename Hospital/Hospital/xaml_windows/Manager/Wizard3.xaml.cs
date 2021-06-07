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
    /// Interaction logic for Wizard3.xaml
    /// </summary>
    public partial class Wizard3 : Window
    {
        public Wizard3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new View.Manager.ManagerUIView();
            newWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window newWindow = new Wizard2();
            newWindow.Show();
            this.Close();
        }
    }
}
