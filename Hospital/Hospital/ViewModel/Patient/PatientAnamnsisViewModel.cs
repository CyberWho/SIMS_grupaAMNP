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
    class PatientAnamnsisViewModel  : BindableBase
    {
        private int userId;
        private int healthRecordId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private AnamnesisController anamnesisController = new AnamnesisController();
        public ObservableCollection<Anamnesis> anamneses { get; set; }
        public ObservableCollection<Allergy> allergies { get; set; }
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
        public MyICommand Help { get; set; }
        public PatientAnamnsisViewModel()
        {

        }

        public PatientAnamnsisViewModel(int userId, int healthRecordId, bool toolTipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            ShowAnamensis();

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
        private void ShowAnamensis()
        {
            anamneses = anamnesisController.GetAllAnamnesesByHealthRecordId(healthRecordId);
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
