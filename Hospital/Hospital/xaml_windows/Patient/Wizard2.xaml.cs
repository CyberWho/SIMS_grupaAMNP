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

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for Wizard2.xaml
    /// </summary>
    public partial class Wizard2 : Window
    {
        private int userId;
        public Wizard2(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }
        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new WizardHome(userId);
            window.Show();
            this.Close();
        }

        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Wizard3(userId);
            window.Show();
            this.Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }
    }
}
