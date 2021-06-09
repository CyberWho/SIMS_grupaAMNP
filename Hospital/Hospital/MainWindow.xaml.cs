using System;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using Hospital.Controller;
using Hospital.View.Patient;

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
            Globals.SetGlobalConnection();
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
