using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class PatientInfoViewModel : BindableBase
    {
        private int userId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand Help { get; set; }
        public PatientInfoViewModel()
        {

        }

        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }


        public PatientInfoViewModel(int userId,bool toolTipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            this.ToolTipChecked = toolTipChecked;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            ShowPatientInfo();
            InstanceMyICommands();
        }
        private void OnHelp()
        {
            string str = "PatientInfoHelp";
            HelpProvider.ShowHelp(str, thisWindow);

        }
        private void InstanceMyICommands()
        {
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            MyHealthRecord = new MyICommand(OnHealthRecord);
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
            Window window = new PatientAppointmentsView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void ShowPatientInfo()
        {

            Model.Patient patient = new PatientController().GetPatientByUserId(userId);
            Username = patient.User.Username;
            Name = patient.User.Name;
            Surname = patient.User.Surname;
            PhoneNumber = patient.User.PhoneNumber;
            EMail = patient.User.EMail;
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnHomePage()
        {
            Window window = new PatientUIView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
