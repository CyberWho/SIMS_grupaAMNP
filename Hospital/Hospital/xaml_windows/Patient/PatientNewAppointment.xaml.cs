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
    /// Interaction logic for PatientNewAppointment.xaml
    /// </summary>
    public partial class PatientNewAppointment : Window
    {
        int id;
        ObservableCollection<Hospital.Model.Doctor> Doctors = new ObservableCollection<Hospital.Model.Doctor>();
        DoctorController doctorController = new DoctorController();
        int priority = 0;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        PatientController patientController = new PatientController();
        public PatientNewAppointment(int id)
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



        private void updateDataGrid()
        {

            this.DataContext = this;

            Doctors = doctorController.GetAllGeneralPurposeDoctors();
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Doctors;



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


        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(id);
            s.Show();
            this.Close();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void myDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = int.Parse(doc_id_txt.Text);
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            if(endDate <= startDate)
            {
                MessageBox.Show("Nije moguce da oznacite vremenski interval gde je krajnji datum manji od pocetnog!");
            } else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if(dayDifference > 5)
                {
                    MessageBox.Show("Interval ne sme biti duzi od 5 dana!");
                } else
                {
                    var s = new PatientNewAppointmentRecommendations(id, startDate, endDate, doctorId,priority);
                    s.Show();
                    this.Close();
                }
            }
        }

       

        private void DoktorPrioritet_Checked(object sender, RoutedEventArgs e)
        {
            this.priority = 0;
        }

        private void VremePrioritet_Checked(object sender, RoutedEventArgs e)
        {
            this.priority = 1;
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
