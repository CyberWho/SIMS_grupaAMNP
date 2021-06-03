using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
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
        public bool ToolTipChecked { get; set; }
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
        public MyICommand Help { get; set; }
        public MyICommand Undo { get; set; }
        public MyICommand ShowRecommendations { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public ReferralForSpecialist SelectedItem { get; set; }
        private string _selectionError;


        public string SelectionError
        {
            get { return _selectionError; }
            set
            {
                SetProperty(ref _selectionError, value);
            }
        }


        public PatientReferralsViewModel()
        {

        }

        public PatientReferralsViewModel(int userId, int healthRecordId, bool toolTipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            ShowReferrals();
        }
        private void OnHelp()
        {
            string str = "PatientHealthRecordHelp";
            HelpProvider.ShowHelp(str, thisWindow);

        }

        private void InstanceMyICommands()
        {
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
            Help = new MyICommand(OnHelp);
        }

        private void OnShowNotifications()
        {
            Window window = new NotificationsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnMyReminders()
        {
            Window window = new RemindersView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void ShowReferrals()
        {
            ReferralForSpecialists = new RefferalForSpecialistController().GetReferralForSpecialistsByHealthRecordId(healthRecordId);
        }

        private void OnShowRecommendations()
        {
            if(!SelectionValidation()) return;
            DateTime startDate = DateTime.Parse(startTime);
            DateTime endDate = DateTime.Parse(endTime);
            DateValidationForAppointmentRecommendations(endDate, startDate, SelectedItem.Doctor.Id);
        }

        private bool SelectionValidation()
        {
            if (SelectedItem == null)
            {
                this.SelectionError = "Potrebno je označite željeni uput!";
                return false;
            }

            return true;
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
                SelectedItem.Id, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, ToolTipChecked);
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
            Window window = new PatientAppointmentsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        public void OnHomePage()
        {
            Window window = new PatientUIView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
