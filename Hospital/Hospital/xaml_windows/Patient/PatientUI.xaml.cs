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
        private ReminderController reminderController = new ReminderController();
        private PatientController patientController = new PatientController();
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private AppointmentController appointmentController = new AppointmentController();
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientUI(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            ResetPatientLogsCounter();
            
        }

        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            reminders = reminderController.GetAllFutureRemindersByPatientId(patient.Id);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (Reminder reminder in reminders)
            {
                if ((reminder.AlarmTime - now).Minutes == 0)
                {
                    MessageBox.Show(reminder.Description);
                }
            }
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
            var window = new PatientReminders(userId);
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
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
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
