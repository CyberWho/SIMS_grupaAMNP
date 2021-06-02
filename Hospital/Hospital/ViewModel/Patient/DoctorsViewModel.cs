using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class DoctorsViewModel : BindableBase
    {
        private int userId;
        private bool tooltipChecked;
        private Window thisWindow;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private DoctorController doctorController = new DoctorController();
        private AppointmentController appointmentController = new AppointmentController();
        public ObservableCollection<Model.Doctor> doctors { get; set; }
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand DoctorRate { get; set; }
        public Model.Doctor SelectedItem { get; set; }
        public DoctorsViewModel()
        {

        }

        public DoctorsViewModel(int userId, bool tooltipChecked, Window thisWindow)
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
            DoctorRate = new MyICommand(OnDoctorRate);
            ShowAllDoctors();
        }

        private void OnDoctorRate()
        {
            if (appointmentController.CheckForAppointmentsByPatientIdAndDoctorId(patientController.GetPatientByUserId(userId).Id, SelectedItem.Id) == false)
            {
                MessageBox.Show("Ne mozete oceniti doktora kod kog niste bili na pregledu!", "Zdravo korporacija", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ShowDoctorRate();
            }
        }
        private void ShowDoctorRate()
        {
            var window = new DoctorRateView(userId, SelectedItem.Id);
            window.Show();
        }
        private void ShowAllDoctors()
        {
            doctors = doctorController.GetAllDoctors();
        }

        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, tooltipChecked);
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
        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

    }
}
