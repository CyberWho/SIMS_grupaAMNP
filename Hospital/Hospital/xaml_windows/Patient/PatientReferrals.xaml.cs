﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Controller;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientReferrals.xaml
    /// </summary>
    public partial class PatientReferrals : Window
    {
        private int userId;
        private int healthRecordId;
        private ObservableCollection<ReferralForSpecialist> ReferralForSpecialists = new ObservableCollection<ReferralForSpecialist>();
        private ReminderController reminderController = new ReminderController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientController patientController = new PatientController();

        public PatientReferrals(int userId,int healthRecordId)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            updateDataGrid();
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
        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = int.Parse(doc_id_txt.Text);
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            DateValidationForAppointmentRecommendations(endDate, startDate, doctorId);
        }

        private void DateValidationForAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            if (endDate <= startDate)
            {
                MessageBox.Show("Nije moguce da oznacite vremenski interval gde je krajnji datum manji od pocetnog!");
            }
            else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if (dayDifference > 5)
                {
                    MessageBox.Show("Interval ne sme biti duzi od 5 dana!");
                }
                else
                {
                    var window = new PatientNewAppointmentRecommendations(userId, startDate, endDate, doctorId, 0,
                        int.Parse(ref_id_txt.Text));
                    window.Show();
                    this.Close();
                }
            }
        }

        private void updateDataGrid()
        {

            this.DataContext = this;
            ReferralForSpecialists = new RefferalForSpecialistController().GetReferralForSpecialistsByHealthRecordId(healthRecordId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = ReferralForSpecialists;



        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



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
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }
    }
}
