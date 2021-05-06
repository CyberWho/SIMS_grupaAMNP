﻿using System;
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
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private ObservableCollection<Appointment> Appointments = new ObservableCollection<Appointment>();
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private ReminderController reminderController = new ReminderController();
        private PatientLogsController patientLogsController = new PatientLogsController();

        public PatientAppointments(int userId)
        {
            
            InitializeComponent();
            this.userId = userId;
            this.DataContext = this;
            updateDataGrid();
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
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender,RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }
        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            int appointmentId = int.Parse(app_id_txt.Text);
            appointmentController.CancelAppointmentById(appointmentId);
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patient.Id)) 
            { 
                MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
                appointmentController.DeleteAllReservedAppointmentsByPatientId(patient.Id);
                var windowLogOut = new MainWindow();
                windowLogOut.Show();
                this.Close();
                return;
            }
            updateDataGrid();
        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientNewAppointment(userId);
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
