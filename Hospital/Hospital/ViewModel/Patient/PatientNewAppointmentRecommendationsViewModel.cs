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
    class PatientNewAppointmentRecommendationsViewModel : BindableBase
    {
        private int userId;
        private DateTime startTime;
        private DateTime endTime;
        private int doctorId;
        private int priority = 0;
        private int referralForSpecialistId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private TimeSlotController timeSlotController = new TimeSlotController();
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        private RoomController roomController = new RoomController();
        public ObservableCollection<TimeSlot> TimeSlots { get; set; }
        private DoctorController doctorController = new DoctorController();
        private RefferalForSpecialistController refferalForSpecialistController = new RefferalForSpecialistController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientLogsController patientLogsController = new PatientLogsController();
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
        public MyICommand SelectionChanged { get; set; }
        public MyICommand New { get; set; }
        public TimeSlot SelectedItem { get; set; }
        public MyICommand Undo { get; set; }
        private string _selectionError;
        public string SelectionError
        {
            get { return _selectionError; }
            set
            {
                SetProperty(ref _selectionError, value);
            }
        }

        public PatientNewAppointmentRecommendationsViewModel()
        {

        }

        public PatientNewAppointmentRecommendationsViewModel(int userId,DateTime startTime,DateTime endTime,int doctorId,int priority,int referralForSpecialist,bool toolTipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctorId = doctorId;
            this.priority = priority;
            this.referralForSpecialistId = referralForSpecialist;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            updateDataGrid();
        }

        private void InstanceMyICommands()
        {
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            New = new MyICommand(OnNew);
            LogOut = new MyICommand(OnLogOut);
            Undo = new MyICommand(OnUndo);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            ShowDoctors = new MyICommand(OnShowDoctors);
            MyReminders = new MyICommand(OnMyReminders);
            ShowNotifications = new MyICommand(OnShowNotifications);
            Help = new MyICommand(OnHelp);
        }
        private void OnHelp()
        {
            string str = "PatientNewAppointmentRecommendationsHelp";
            HelpProvider.ShowHelp(str, thisWindow);

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

        private void OnUndo()
        {
            Window window = new PatientNewAppointmentView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void updateDataGrid()
        {
            TimeSlots = timeSlotController.GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(startTime, endTime, doctorId, priority);
        }

        private void OnNew()
        {
            if(!SelectionValidation()) return;
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Room room = roomController.GetAppointmentRoomById(SelectedItem.WorkHours.doctor.room_id);
            Model.Doctor doctor = doctorController.GetWorkHoursDoctorById(doctorId);
            TimeSlot timeSlot = timeSlotController.GetTimeSlotById(SelectedItem.Id);
            Appointment appointment = new Appointment(30, timeSlot.StartTime, AppointmentType.EXAMINATION, AppointmentStatus.RESERVED, doctor, patient, room);
            Execute(appointment,new ModifyAppointment(),new AppointmentCommand(appointment,AppointmentAction.ADD));
            CheckIfReferralForSpecialistIsUsed();
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
        }
        private static void Execute(Appointment appointment, ModifyAppointment modifyAppointment, ICommand appointmentCommand)
        {
            modifyAppointment.SetCommand(appointmentCommand);
            modifyAppointment.Invoke();
        }
        private bool SelectionValidation()
        {
            if (SelectedItem == null)
            {
                this.SelectionError = "Potrebno je da označite željeno vreme!";
                return false;
            }

            return true;
        }

        private void CheckIfReferralForSpecialistIsUsed()
        {
            if (referralForSpecialistId != 0)
            {
                refferalForSpecialistController.DeleteReferralById(referralForSpecialistId);
            }
        }

        private void CheckIfPatientIsBlocked(int patientId)
        {
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patientId))
            {
                ShowPatientIsBlocked(patientId);
                return;
            }
            var window = new PatientAppointmentsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void ShowPatientIsBlocked(int patientId)
        {
            MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!", "Zdravo korporacija",
                MessageBoxButton.OK, MessageBoxImage.Error);
            appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
            var windowLogOut = new MainWindow();
            windowLogOut.Show();
            thisWindow.Close();
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
