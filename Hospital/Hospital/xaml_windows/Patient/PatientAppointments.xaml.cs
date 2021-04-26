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
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
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
        int id;
        AppointmentController appointmentController = new AppointmentController();
        PatientController patientController = new PatientController();
        ObservableCollection<Appointment> Appointments = new ObservableCollection<Appointment>();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        Appointment app = new Appointment();
        Appointment Appointment = new Appointment();

        public PatientAppointments(int id)
        {
            
            InitializeComponent();
            this.id = id;
            this.DataContext = this;
            updateDataGrid();
        }

        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(id);
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

        private int getPatientId()
        {

            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(id);
            return patient.Id;
        }

        private void updateDataGrid()
        {

            this.DataContext = this;
            int patientId = getPatientId();
            Appointments = appointmentController.GetAllByAppointmentsPatientId(patientId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Appointments;



        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(id);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(id);
            s.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(id);
            s.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            int appointmentId = int.Parse(app_id_txt.Text);
            int patientId = getPatientId();
            appointment = appointmentController.GetAppointmentById(appointmentId);
            var hours = (appointment.StartTime - DateTime.Now).TotalHours;
            
         
                if (hours > 24)
                {
                    var s = new PatientUpdateAppointment(patientId,appointmentId);
                    s.Show();
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Nije moguce promeniti vreme odrzavanja termina jer je ostalo manje od 24h");
                }
            
           
        }

        private void Doktori_Click(object sender,RoutedEventArgs e)
        {

        }
        private void ZdravstveniKarton_Click(object sender,RoutedEventArgs e)
        {

        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            int appointmentId = int.Parse(app_id_txt.Text);
            appointmentController.CancelAppointmentById(appointmentId);
            updateDataGrid();
        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientNewAppointment(id);
            s.Show();
            this.Close();
        }

        
        
          
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            
        }
    }
}
