using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        private int userId;
        private SystemNotificationsController SystemNotificationsController = new SystemNotificationsController();
        private ObservableCollection<SystemNotification> SystemNotifications = new ObservableCollection<SystemNotification>();
        private PatientController patientController = new PatientController();
        private ReminderController reminderController = new ReminderController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public Notifications(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            updateDataGrid();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
       
        private void updateDataGrid()
        {

            this.DataContext = this;

            SystemNotifications = SystemNotificationsController.GetAllSystemNotificationsByUserId(userId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = SystemNotifications;



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
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
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
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }

        
    }
}
