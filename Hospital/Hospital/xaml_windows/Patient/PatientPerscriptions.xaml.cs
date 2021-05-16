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
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientPerscriptions.xaml
    /// </summary>
    public partial class PatientPerscriptions : Window
    {
        private int userId;
        private int healthRecordId;
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private ReminderController reminderController = new ReminderController();
        private PatientController patientController = new PatientController();
        private AnamnesisController anamnesisController = new AnamnesisController();
        private ObservableCollection<Perscription> perscriptions = new ObservableCollection<Perscription>();
        public PatientPerscriptions(int userId,int healthRecordId)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            myDataGrid_Update();
        }
       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }
        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void myDataGrid_Update()
        {
            this.DataContext = this;
            perscriptions = anamnesisController.GetAllActivePerscriptionsByHealthRecordId(healthRecordId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = perscriptions;
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }
    }
}
