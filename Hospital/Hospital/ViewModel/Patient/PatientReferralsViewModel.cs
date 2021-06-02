using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class PatientReferralsViewModel : BindableBase
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private Window thisWindow;
        public ObservableCollection<ReferralForSpecialist> ReferralForSpecialists { get; set; }
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand Undo { get; set; }
        public MyICommand ShowRecommendations { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public ReferralForSpecialist SelectedItem { get; set; }
        public PatientReferralsViewModel()
        {

        }

        public PatientReferralsViewModel(int userId, int healthRecordId, bool tooltipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            this.tooltipChecked = tooltipChecked;
            this.thisWindow = thisWindow;
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            Undo = new MyICommand(OnHealthRecord);
            ShowRecommendations = new MyICommand(OnShowRecommendations);
            ShowDoctors = new MyICommand(OnShowDoctors);
            MyReminders = new MyICommand(OnMyReminders);
            ShowNotifications = new MyICommand(OnShowNotifications);
            ShowReferrals();
        }
        private void OnShowNotifications()
        {
            Window window = new NotificationsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnMyReminders()
        {
            Window window = new RemindersView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void ShowReferrals()
        {
            ReferralForSpecialists = new RefferalForSpecialistController().GetReferralForSpecialistsByHealthRecordId(healthRecordId);
        }

        private void OnShowRecommendations()
        {
            DateTime startDate = DateTime.Parse(startTime);
            DateTime endDate = DateTime.Parse(endTime);
            DateValidationForAppointmentRecommendations(endDate, startDate, SelectedItem.Doctor.Id);
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
            var window = new PatientNewAppointmentRecommendationsView(userId, startDate, endDate, doctorId, 0,
                SelectedItem.Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnLogOut()
        {
            Window window = new MainWindow();
            window.Show();
            thisWindow.Close();
        }

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        public void OnHomePage()
        {
            Window window = new PatientUIView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
