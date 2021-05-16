﻿using System;
using System.Windows;
using System.Windows.Controls;
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
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private ReminderController reminderController = new ReminderController();
        private DoctorController doctorController = new DoctorController();
        private ObservableCollection<Model.Doctor> doctors = new ObservableCollection<Model.Doctor>();
        private AppointmentController appointmentController = new AppointmentController();
        public Doctors(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            myDataGrid_Update();
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
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
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
                
            }
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
