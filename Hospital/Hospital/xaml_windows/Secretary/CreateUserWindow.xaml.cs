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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        private string user_type;


        public CreateUserWindow()
        {
            InitializeComponent();
        }

        private void Doctor_OnChecked(object sender, RoutedEventArgs e)
        {
            this.user_type = "doctor";
        }

        private void Patient_OnChecked(object sender, RoutedEventArgs e)
        {
            this.user_type = "patient";
        }
    }
}
