using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientNewAppointmentRecommendations.xaml
    /// </summary>
    public partial class PatientNewAppointmentRecommendations : Window
    {
        private int userId;
        private DateTime startTime;
        private DateTime endTime;
        private int doctorId;
        private int priority = 0;
        private int referralForSpecialistId;
        private TimeSlotController timeSlotController = new TimeSlotController();
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        private RoomController roomController = new RoomController();
        private ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        private DoctorController doctorController = new DoctorController();
        private ReminderController reminderController = new ReminderController();
        private RefferalForSpecialistController refferalForSpecialistController = new RefferalForSpecialistController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientNewAppointmentRecommendations(int userId,DateTime startTime,DateTime endTime,int doctorId,int priority,int referralForSpecialistId)
        {
            InitializeComponent();
            this.userId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctorId = doctorId;
            this.priority = priority;
            this.referralForSpecialistId = referralForSpecialistId;
            updateDataGrid();
            Zakazi.IsEnabled = false;
        }
        private void updateDataGrid()
        {

            this.DataContext = this;

            TimeSlots = timeSlotController.GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(startTime, endTime, doctorId, priority);
            DataTable dt = new DataTable();
            myGrid.DataContext = dt;
            myGrid.ItemsSource = TimeSlots;
        }
       
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }

        private int GetTimeSlotId()
        {
            TimeSlot timeSlot = (TimeSlot) myGrid.SelectedValue;
            return timeSlot.Id;
        }
        
        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Room room = roomController.GetAppointmentRoomById(int.Parse(room_id_txt.Text));
            Model.Doctor doctor = doctorController.GetWorkHoursDoctorById(doctorId);
            TimeSlot timeSlot = timeSlotController.GetTimeSlotById(GetTimeSlotId());
            Appointment appointment = new Appointment(30, timeSlot.StartTime, AppointmentType.EXAMINATION, AppointmentStatus.RESERVED, doctor, patient, room);
            appointmentController.ReserveAppointment(appointment);
            if(referralForSpecialistId != 0)
            {
                refferalForSpecialistController.DeleteReferralById(referralForSpecialistId);
            }
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
        }

        private void CheckIfPatientIsBlocked(int patientId)
        {
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patientId))
            {
                MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
                appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
                var windowLogOut = new MainWindow();
                windowLogOut.Show();
                this.Close();
                return;
            }
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }

        private void myGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Zakazi.IsEnabled = true;
        }
    }
}
