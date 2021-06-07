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
    class PatientUpdateAppointmentViewModel : BindableBase
    {
        private int userId;
        private int appointmentId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private BindableBase currentViewModel;
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
        public MyICommand SelectionChanged { get; set; }
        public MyICommand Add { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public int AppointmentId { get; set; }
        public int DurationInMinutes { get; set; }
        public int DoctorId { get; set; }
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public TimeSlot SelectedItem { get; set; }
        private string _selectionError;
         public string SelectionError
        {
            get { return _selectionError; }
            set
            {
                SetProperty(ref _selectionError, value);
            }
        }
        public ObservableCollection<TimeSlot> TimeSlots { get; set; }
        private AppointmentController appointmentController = new AppointmentController();
        private TimeSlotController timeSlotController = new TimeSlotController();
        private Appointment appointment = new Appointment();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientController patientController = new PatientController();
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientUpdateAppointmentViewModel()
        {

        }

        public PatientUpdateAppointmentViewModel(int userId, int appointmentId, bool toolTipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.appointmentId = appointmentId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            ShowAppointmentInformations(appointmentId);
            appointment = appointmentController.GetAppointmentById(appointmentId);
            appointment.Doctor_Id = appointment.doctor.Id;
            updateMyGrid();
        }
        private void OnHelp()
        {
            string str = "PatientUpdateAppointmentHelp";
            HelpProvider.ShowHelp(str, thisWindow);

        }
        private void InstanceMyICommands()
        {
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            Add = new MyICommand(OnAdd);
            Undo = new MyICommand(OnUndo);
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
        private void OnAdd()
        {
            if(!SelectionValidation()) return;
            TimeSlot timeSlot = timeSlotController.GetTimeSlotById(SelectedItem.Id);
            appointmentController.ChangeStartTime(appointment, timeSlot.StartTime);
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
        }

        private bool SelectionValidation()
        {
            if (SelectedItem == null)
            {
                this.SelectionError = "Potrebno je da označite željeni termin";
                return false;
            }

            return true;
        }

        private void CheckIfPatientIsBlocked(int patientId)
        {
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patientId))
            {
                PatientIsBlocked(patientId);
                return;
            }

            ShowPatientAppointments();
        }
        private void PatientIsBlocked(int patientId)
        {
            MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!", "Zdravo korporacija",
                MessageBoxButton.OK, MessageBoxImage.Error);
            appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
            var windowLogOut = new MainWindow();
            windowLogOut.Show();
            thisWindow.Close();

        }

        private void ShowPatientAppointments()
        {
            var window = new PatientAppointmentsView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnUndo()
        {
            Window window = new PatientAppointmentsView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
            
        }
        private void updateMyGrid()
        {
            
            Appointment appointment = new Appointment();

            appointment = appointmentController.GetAppointmentById(appointmentId);
            int doctorId = appointment.doctor.Id;
            DateTime dateTime = appointment.StartTime;
            TimeSlots = timeSlotController.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(dateTime, doctorId);
            
        }

        private void ShowAppointmentInformations(int appointmentId)
        {
            Appointment appointment = appointmentController.GetAppointmentById(appointmentId);
            AppointmentStatus = appointment.Status;
            AppointmentType = appointment.Type;
            AppointmentId = appointment.Id;
            DurationInMinutes = appointment.DurationInMinutes;
            DoctorId = appointment.doctor.Id;
            RoomId = (int)appointment.room.Id;
            Name = appointment.doctor.User.Name;
            Surname = appointment.doctor.User.Surname;
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

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId,ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

    }
}
