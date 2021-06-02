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
        private bool tooltipChecked;
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
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand SelectionChanged { get; set; }
        public MyICommand New { get; set; }
        public TimeSlot SelectedItem { get; set; }
        public MyICommand Undo { get; set; }
        public PatientNewAppointmentRecommendationsViewModel()
        {

        }

        public PatientNewAppointmentRecommendationsViewModel(int userId,DateTime startTime,DateTime endTime,int doctorId,int priority,int referralForSpecialist,bool tooltipChecked,Window thisWindow)
        {
            this.userId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctorId = doctorId;
            this.priority = priority;
            this.referralForSpecialistId = referralForSpecialist;
            this.tooltipChecked = tooltipChecked;
            this.thisWindow = thisWindow;
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            New = new MyICommand(OnNew);
            LogOut = new MyICommand(OnLogOut);
            Undo = new MyICommand(OnUndo);
            updateDataGrid();
        }

        private void OnUndo()
        {
            Window window = new PatientNewAppointmentView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void updateDataGrid()
        {
            TimeSlots = timeSlotController.GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(startTime, endTime, doctorId, priority);
        }

        private void OnNew()
        {
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Room room = roomController.GetAppointmentRoomById(SelectedItem.WorkHours.doctor.room_id);
            Model.Doctor doctor = doctorController.GetWorkHoursDoctorById(doctorId);
            TimeSlot timeSlot = timeSlotController.GetTimeSlotById(SelectedItem.Id);
            Appointment appointment = new Appointment(30, timeSlot.StartTime, AppointmentType.EXAMINATION, AppointmentStatus.RESERVED, doctor, patient, room);
            appointmentController.ReserveAppointment(appointment);
            CheckIfReferralForSpecialistIsUsed();
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
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
            var window = new PatientAppointmentsView(userId, tooltipChecked);
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
            Window window = new PatientInfoView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnHomePage()
        {
            Window window = new PatientUIView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
