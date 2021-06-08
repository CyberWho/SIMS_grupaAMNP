using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Repository;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;
using Xceed.Wpf.Toolkit.Core;

namespace Hospital.ViewModel.Patient
{
    class DoctorsViewModel : BindableBase
    {
        private int userId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private DoctorController doctorController = new DoctorController();
        private AppointmentController appointmentController = new AppointmentController();
        private ObservableCollection<Model.Doctor> _doctors;

        public ObservableCollection<Model.Doctor> doctors
        {
            get { return _doctors; }
            set
            {
                SetProperty(ref _doctors,value);
            }
        }
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand Help { get; set; }
        public MyICommand DoctorRate { get; set; }
        public Model.Doctor SelectedItem { get; set; }
        private string _searchString;

        public string SearchString
        {
            /* get { return _searchString; }
             set
             {
                 this.doctors = new DoctorRepository().SearchByNameAndSurname(SearchString);
                 SetProperty(ref _searchString,value);
             }*/
            get
            {
                return _searchString;
            }
            set
            {
                if (value != _searchString)
                {
                    this.doctors = new DoctorRepository().SearchByNameAndSurname(value);
                    _searchString = value;
                }
            }
        }
        public bool CanRate { get; set; }
        private string _rateError;


        public string RateError
        {
            get { return _rateError; }
            set
            {
                SetProperty(ref _rateError, value);
            }
        }
        public DoctorsViewModel()
        {

        }

        public DoctorsViewModel(int userId, bool toolTipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            this.SearchString = null;
            InstanceMyICommands();
            ShowAllDoctors();
            CanRate = false;
        }
        private void OnHelp()
        {
            string str = "DoctorsHelp";
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
            DoctorRate = new MyICommand(OnDoctorRate);
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
        private void OnDoctorRate()
        {
            this.RateError = "";
            if(!ValidateSelection()) return;
            ;
            if (appointmentController.CheckForAppointmentsByPatientIdAndDoctorId(patientController.GetPatientByUserId(userId).Id, SelectedItem.Id) == false)
            {
                MessageBox.Show("Ne mozete oceniti doktora kod kog niste bili na pregledu!", "Zdravo korporacija", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ShowDoctorRate();
            }
        }

        private bool ValidateSelection()
        {
            if (SelectedItem == null)
            {
                this.RateError = "Potrebno je da označite željenog doktora!";
                return false;
            }

            return true;
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
            Window window = new DoctorsView(userId, ToolTipChecked);
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
        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

    }
}
