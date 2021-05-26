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
    /// Interaction logic for PatientNewAppointment.xaml
    /// </summary>
    public partial class PatientNewAppointment : Window
    {
        private int userId;
        private ObservableCollection<Model.Doctor> Doctors = new ObservableCollection<Model.Doctor>();
        private DoctorController doctorController = new DoctorController();
        private int priority = 0;
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        
        public PatientNewAppointment(int userId)
        {
            
            InitializeComponent();
            this.userId = userId;
            this.DataContext = this;
            updateDataGrid();
            Predlozi.IsEnabled = false;
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
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }

        private void myDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Predlozi.IsEnabled = true;
        }

        private int GetDoctorId()
        {
            Model.Doctor doctor = (Model.Doctor)myDataGrid.SelectedValue;
            return doctor.Id;
        }

        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = GetDoctorId();
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            DateValidationForAppointmentRecommendations(endDate, startDate, doctorId);
        }

        private void DateValidationForAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            if (endDate <= startDate)
            {
                MessageBox.Show("Nije moguce da oznacite vremenski interval gde je krajnji datum manji od pocetnog!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if (dayDifference > 5)
                {
                    MessageBox.Show("Interval ne sme biti duzi od 5 dana!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else
                {
                    ShowNewAppointmentRecommendations(endDate, startDate, doctorId);
                }
            }
        }

        private void ShowNewAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            var s = new PatientNewAppointmentRecommendations(userId, startDate, endDate, doctorId, priority, 0);
            s.Show();
            this.Close();
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
