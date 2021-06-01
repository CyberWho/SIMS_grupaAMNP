using System;
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
        private bool tooltipChecked;
        private ObservableCollection<ReferralForSpecialist> ReferralForSpecialists = new ObservableCollection<ReferralForSpecialist>();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        
        public PatientReferrals(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            this.tooltipChecked = tooltipChecked;
            updateDataGrid();
            Predlozi.IsEnabled = false;
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

        private int GetReferralId()
        {
            ReferralForSpecialist referralForSpecialist = (ReferralForSpecialist) myDataGrid.SelectedValue;
            return referralForSpecialist.Id;
        }

        private int GetDoctorId()
        {
            ReferralForSpecialist referralForSpecialist = (ReferralForSpecialist) myDataGrid.SelectedValue;
            return referralForSpecialist.Doctor.Id;
        }
        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
           
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            DateValidationForAppointmentRecommendations(endDate, startDate, GetDoctorId());
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
                    ShowPatientNewAppointmentRecommendations(endDate, startDate, doctorId);
                }
            }
        }

        private void ShowPatientNewAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            var window = new PatientNewAppointmentRecommendations(userId, startDate, endDate, doctorId, 0,
                GetReferralId(),tooltipChecked);
            window.Show();
            this.Close();
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
            Predlozi.IsEnabled = true;


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
            var window = new Notifications(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId,tooltipChecked);
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
