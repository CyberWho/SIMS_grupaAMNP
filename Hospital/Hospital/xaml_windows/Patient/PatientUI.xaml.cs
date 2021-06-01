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
        private bool tooltipChecked;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private AppointmentController appointmentController = new AppointmentController();
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientUI(int userId,bool tooltipChecked = true)
        {
            InitializeComponent();
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            ResetPatientLogsCounter();
            ToolTipChecked(tooltipChecked);

        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
            }
        }
        private void ToggleButton_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            tooltipChecked = false;
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
            var window = new Reminders(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId,tooltipChecked);
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
            var window = new PatientHealthRecord(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void OceniBolnicu_Click(object sender, RoutedEventArgs e)
        {
            if(appointmentController.CheckForAnyAppointmentsByPatientId(patientController.GetPatientByUserId(userId).Id) == false)
            {
                MessageBox.Show("Nazalost nije moguce da ocenite bolnicu jer nikada niste bili na pregledu!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
            } else
            {
                ShowHospitalRate();
            }
           
        }

        private void ShowHospitalRate()
        {
            var window = new HospitalRate(userId);
            window.Show();
        }

        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId,tooltipChecked);
            window.Show();
            this.Close();
        }


        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty,true);
            tooltipChecked = true;
        }

       
    }
}
