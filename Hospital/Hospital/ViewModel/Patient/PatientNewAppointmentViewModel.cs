using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class PatientNewAppointmentViewModel : BindableBase
    {
        private int userId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        public ObservableCollection<Model.Doctor> Doctors { get; set; }
        private DoctorController doctorController = new DoctorController();
        private int priority = 0;
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
        public MyICommand SelectionChanged { get; set; }
        public MyICommand ChooseDoctor { get; set; } 
        public MyICommand CheckedTime { get; set; }
        public MyICommand CheckedDoctor { get; set; }
        public Model.Doctor SelectedItem { get; set; }
        public MyICommand Undo { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        private string _selectionError;


        public string SelectionError
        {
            get { return _selectionError; }
            set
            {
                SetProperty(ref _selectionError, value);
            }
        }


        public PatientNewAppointmentViewModel()
        {

        }

        public PatientNewAppointmentViewModel(int userId, bool toolTipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            ShowGeneralPurposeDoctors();
        }
        private void OnHelp()
        {
            string str = "PatientNewAppointmentHelp";
            HelpProvider.ShowHelp(str, thisWindow);

        }
        private void InstanceMyICommands()
        {
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            Undo = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            CheckedDoctor = new MyICommand(OnCheckedDoctor);
            CheckedTime = new MyICommand(OnCheckedTime);
            ChooseDoctor = new MyICommand(OnChooseDoctor);
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
        private void ShowGeneralPurposeDoctors()
        {
            Doctors = doctorController.GetAllGeneralPurposeDoctors();
        }

        private int GetDoctorId()
        {
            Model.Doctor doctor = SelectedItem;
            return doctor.Id;
        }
        private void OnChooseDoctor()
        {
            if(!SelectionValidation()) return;
            int doctorId = GetDoctorId();
            DateTime startDate = DateTime.Parse(StartTime);
            DateTime endDate = DateTime.Parse(EndTime);
            DateValidationForAppointmentRecommendations(endDate, startDate, doctorId);
        }

        private bool SelectionValidation()
        {
            if (SelectedItem == null)
            {
                this.SelectionError = "Potrebno je da označite željenog doktora!";
                return false;
            }

            return true;
        }

        private void DateValidationForAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            if (endDate <= startDate)
            {
                this.SelectionError =
                    "Nije moguće da označite vremenski interval gde je krajnji datum manji od početnog!";
            }
            else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if (dayDifference > 5)
                {
                    this.SelectionError = "Interval ne sme biti duži od 5 dana!";
                }
                else
                {
                    if(endDate < DateTime.Now || startDate < DateTime.Now)
                    {
                        this.SelectionError = "Ne smete označiti datum u prošlosti!";
                    }
                    else
                    {
                        ShowNewAppointmentRecommendations(endDate, startDate, doctorId);
                    }
                } 
                
            }
        }

        private void ShowNewAppointmentRecommendations(DateTime endDate, DateTime startDate, int doctorId)
        {
            var s = new PatientNewAppointmentRecommendationsView(userId, startDate, endDate, doctorId, priority, 0, ToolTipChecked);
            s.Show();
            thisWindow.Close();
        }
        private void OnCheckedTime()
        {
            this.priority = 1;
        }

        private void OnCheckedDoctor()
        {
            this.priority = 0;
        }

        private void OnLogOut()
        {
            Window window = new MainWindow();
            window.Show();
            thisWindow.Close();
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnHomePage()
        {
            Window window = new PatientUIView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
