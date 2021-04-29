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
    /// Interaction logic for Doctors.xaml
    /// </summary>
    public partial class Doctors : Window
    {
        private int userId;
        PatientController patientController = new PatientController();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        DoctorController doctorController = new DoctorController();
        ObservableCollection<Hospital.Model.Doctor> doctors = new ObservableCollection<Model.Doctor>();
        AppointmentController appointmentController = new AppointmentController();
        public Doctors(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            myDataGrid_Update();
        }
        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Hospital.Model.Patient patient = new Model.Patient();
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
        private void myDataGrid_Update()
        {
            this.DataContext = this;
            doctors = doctorController.GetAllDoctors();
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = doctors;
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
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            if(appointmentController.CheckForAppointmentsByPatientIdAndDoctorId(patientController.GetPatientByUserId(userId).Id,int.Parse(doc_id_txt.Text)) == false) {
                MessageBox.Show("Ne mozete oceniti doktora kod kog niste bili na pregledu!");
            } else
            {
                var window = new DoctorRate(userId, int.Parse(doc_id_txt.Text));
                window.Show();
                this.Close();
            }
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
