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
    /// Interaction logic for Wizard2.xaml
    /// </summary>
    public partial class Wizard2 : Window
    {
        public Wizard2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new Wizard3();
            newWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window newWindow = new Wizard1();
            newWindow.Show();
            this.Close();
        }
    }
}
