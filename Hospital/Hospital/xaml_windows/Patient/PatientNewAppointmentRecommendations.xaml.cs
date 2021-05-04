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
        DateTime startTime;
        DateTime endTime;
        int doctorId;
        int priority = 0;
        int referralForSpecialistId;
        TimeSlotController timeSlotController = new TimeSlotController();
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();
        ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        DoctorController doctorController = new DoctorController();
        ReminderController reminderController = new ReminderController();
        RefferalForSpecialistController refferalForSpecialistController = new RefferalForSpecialistController();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        PatientLogsController patientLogsController = new PatientLogsController();
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
        }
        private void updateDataGrid()
        {

            this.DataContext = this;

            TimeSlots = timeSlotController.GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(startTime, endTime, doctorId, priority);
            DataTable dt = new DataTable();
            myGrid.DataContext = dt;
            myGrid.ItemsSource = TimeSlots;
        }
        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            reminders = reminderController.GetAllFutureRemindersByPatientId(patient.Id);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (Reminder reminder in reminders)
            {
                if ((reminder.AlarmTime - now).Minutes == 0)
                {
                    MessageBox.Show(reminder.Description);
                }
            }
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientReminders(userId);
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

        
        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            appointment.patient = patient;
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotController.GetTimeSlotById(int.Parse(timeslot_id_txt.Text));
            appointment.StartTime = timeSlot.StartTime;
            Model.Doctor doctor = new Model.Doctor();
            doctor = doctorController.GetWorkHoursDoctorById(int.Parse(doctor_id_txt.Text));
            appointment.doctor = doctor;
            Room room = new Room();
            appointment.room = room;
            appointment.room.Id = int.Parse(room_id_txt.Text);
            appointmentController.ReserveAppointment(appointment);
            if(referralForSpecialistId != 0)
            {
                refferalForSpecialistController.DeleteReferralById(referralForSpecialistId);
            }
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patient.Id))
            {
                MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
                appointmentController.DeleteAppointmentByPatientId(patient.Id);
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
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
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
    }
}
