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
    /// Interaction logic for WizardHome.xaml
    /// </summary>
    public partial class WizardHome : Window
    {
        private int userId;
        public WizardHome(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            undo.IsEnabled = false;
        }

        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Wizard2(userId);
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
