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
        private bool tooltipChecked;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private DoctorController doctorController = new DoctorController();
        private ObservableCollection<Model.Doctor> doctors = new ObservableCollection<Model.Doctor>();
        private AppointmentController appointmentController = new AppointmentController();
        public Doctors(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            myDataGrid_Update();
            Oceni.IsEnabled = false;
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
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId,tooltipChecked);
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
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Oceni.IsEnabled = true;

        }

        private int GetDoctorIdFromForm()
        {
            Model.Doctor doctor = (Model.Doctor)myDataGrid.SelectedValue;
            return doctor.Id;
        }

        private void Oceni_Click(object sender, RoutedEventArgs e)
        {
            if(appointmentController.CheckForAppointmentsByPatientIdAndDoctorId(patientController.GetPatientByUserId(userId).Id,GetDoctorIdFromForm()) == false) {
                MessageBox.Show("Ne mozete oceniti doktora kod kog niste bili na pregledu!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
            } else
            {
                ShowDoctorRate();
            }
        }

        private void ShowDoctorRate()
        {
            var window = new DoctorRate(userId, GetDoctorIdFromForm());
            window.Show();
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
