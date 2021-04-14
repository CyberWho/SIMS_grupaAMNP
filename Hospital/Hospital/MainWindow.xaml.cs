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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Hospital.xaml_windows.Doctor;
using Hospital.xaml_windows.Manager;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;
using Hospital.Controller;


namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (OracleConfiguration.TnsAdmin == null)
                OracleConfiguration.TnsAdmin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Oracle\network\admin\DBTIM1";
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {

            string user = Username.Text;
            string pass = Password.Password;

            if(new UserController().LoginUser(user, pass))
                this.Close();
            
        }

    }
}
