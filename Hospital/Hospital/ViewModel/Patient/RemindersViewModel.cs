using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class RemindersViewModel : BindableBase
    {
        private int userId;
        private bool tooltipChecked;
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private Window thisWindow;
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand PersonalReminders { get; set; }
        public MyICommand MedicalReminders { get; set; }
        public RemindersViewModel()
        {

        }

        public RemindersViewModel(int userId, bool tooltipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            ShowDoctors = new MyICommand(OnShowDoctors);
            MyReminders = new MyICommand(OnMyReminders);
            PersonalReminders = new MyICommand(OnPersonalReminders);
            MedicalReminders = new MyICommand(OnMedicalReminders);
            ShowNotifications = new MyICommand(OnShowNotifications);
        }
        private void OnShowNotifications()
        {
            Window window = new NotificationsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnMedicalReminders()
        {
            Window window = new PatientRemindersView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnPersonalReminders()
        {
            Window window = new PersonalReminders(userId, tooltipChecked);
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
