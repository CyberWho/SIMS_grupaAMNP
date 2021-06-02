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
    class AllergiesViewModel : BindableBase
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private Window thisWindow;
        private PatientController patientController = new PatientController();
        private ReminderController reminderController = new ReminderController();
        private AllergyController allergyController = new AllergyController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
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


        public AllergiesViewModel()
        {

        }

        public AllergiesViewModel(int userId, int healthRecordId, bool tooltipChecked, Window thisWindow)
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
            ShowDoctors = new MyICommand(OnShowDoctors);
            ShowAllergies();
        }
        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void ShowAllergies()
        {
            allergies = allergyController.GetAllAllergiesByHealthRecordId(healthRecordId);
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
