using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientUI.xaml
    /// </summary>
    public partial class PatientUI : Window
    {
        private int userId;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private AppointmentController appointmentController = new AppointmentController();
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientUI(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            ResetPatientLogsCounter();
            
        }

     
        private void ResetPatientLogsCounter()
        {
            PatientLogs patientLogs = patientLogsController.GetPatientLogsByPatientId(patientController.GetPatientByUserId(userId).Id);
            if((DateTime.Now - patientLogs.LastCounterReset).TotalDays >= 7)
            {
                patientLogsController.ResetPatientLogCounterByPatientId(patientController.GetPatientByUserId(userId).Id);
            }
        }
       

        
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
            window.Show();
            this.Close();
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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }

        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            if(appointmentController.CheckForAnyAppointmentsByPatientId(patientController.GetPatientByUserId(userId).Id) == false)
            {
                MessageBox.Show("Nazalost nije moguce da ocenite bolnicu jer nikada niste bili na pregledu!");
            } else
            {
                var window = new HospitalRate(userId);
                window.Show();
            }
           
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }
    }
}
