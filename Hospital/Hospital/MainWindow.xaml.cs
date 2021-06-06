using System;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using Hospital.Controller;
using Hospital.xaml_windows.Secretary;
using Hospital.View.Secretary;


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

            if (new UserController().LoginUser(user, pass)) this.Close();

            #region MARKO HCI, OBRISATI
            WorkHoursController WHC = new WorkHoursController();
            TimeSlotController TSC = new TimeSlotController();

            //WHC.AddWorkHours(null);
            //TSC.generateTimeSlots(163);

            #endregion

            // Window s = new SecretaryUIWindow(); s.Show(); this.Close();
        }

    }
}
