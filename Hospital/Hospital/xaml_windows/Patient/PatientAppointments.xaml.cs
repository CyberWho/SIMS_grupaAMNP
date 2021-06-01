using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientAppointments.xaml
    /// </summary>
    public partial class PatientAppointments : Window
    {
        private int userId;
        private bool tooltipChecked;
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private ObservableCollection<Appointment> Appointments = new ObservableCollection<Appointment>();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientLogsController patientLogsController = new PatientLogsController();

        public PatientAppointments(int userId,bool tooltipChecked)
        {
            
            InitializeComponent();
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            this.DataContext = this;
            updateDataGrid();
            ZakaziNoviTermin.IsEnabled = true;
            Izmeni.IsEnabled = false;
            Obrisi.IsEnabled = false;
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

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            tooltipChecked = true;
        }
        private int getPatientId()
        {

            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            return patient.Id;
        }

        private void updateDataGrid()
        {

            this.DataContext = this;
            int patientId = getPatientId();
            Appointments = appointmentController.GetAllReservedAppointmentsByPatientId(patientId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Appointments;



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

       
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }

        private int GetAppointmentId()
        {
            Appointment appointment = (Appointment) myDataGrid.SelectedValue;
            return appointment.Id;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            
            int patientId = getPatientId();
            appointment = appointmentController.GetAppointmentById(GetAppointmentId());
            var hours = (appointment.StartTime - DateTime.Now).TotalHours;
             DateValidationForUpdate(hours, patientId, GetAppointmentId());
            
           
        }

        private void DateValidationForUpdate(double hours, int patientId, int appointmentId)
        {
            if (hours > 24)
            {
                ShowPatientUpdateAppointment(patientId, appointmentId);
            }
            else
            {
                MessageBox.Show("Nije moguce promeniti vreme odrzavanja termina jer je ostalo manje od 24h","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void ShowPatientUpdateAppointment(int patientId, int appointmentId)
        {
            var s = new PatientUpdateAppointment(patientId, appointmentId,tooltipChecked);
            s.Show();
            this.Close();
        }

        private void Doktori_Click(object sender,RoutedEventArgs e)
        {
            var window = new Doctors(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender,RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            
            appointmentController.CancelAppointmentById(GetAppointmentId());
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
            updateDataGrid();
        }

        private void CheckIfPatientIsBlocked(int patientId)
        {
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patientId))
            {
                ShowPatientIsBlocked(patientId);
                
            }
        }

        private void ShowPatientIsBlocked(int patientId)
        {
            MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
            appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
            var windowLogOut = new MainWindow();
            windowLogOut.Show();
            this.Close();
        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientNewAppointment(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        
        
          
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ZakaziNoviTermin.IsEnabled = true;
            Obrisi.IsEnabled = true;
            Izmeni.IsEnabled = true;
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            tooltipChecked = false;
        }
    }
}
