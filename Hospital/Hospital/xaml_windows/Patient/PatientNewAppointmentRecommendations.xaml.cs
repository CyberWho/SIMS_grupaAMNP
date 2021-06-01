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
        private bool tooltipChecked;
        private TimeSlotController timeSlotController = new TimeSlotController();
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        private RoomController roomController = new RoomController();
        private ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        private DoctorController doctorController = new DoctorController();
        private RefferalForSpecialistController refferalForSpecialistController = new RefferalForSpecialistController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientLogsController patientLogsController = new PatientLogsController();
        public PatientNewAppointmentRecommendations(int userId,DateTime startTime,DateTime endTime,int doctorId,int priority,int referralForSpecialistId,bool tooltipChecked)
        {
            InitializeComponent();
            this.userId = userId;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctorId = doctorId;
            this.tooltipChecked = tooltipChecked;
            this.priority = priority;
            this.referralForSpecialistId = referralForSpecialistId;
            updateDataGrid();
            Zakazi.IsEnabled = false;
            ToolTipChecked(tooltipChecked);
        }
        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
            }
        }
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            tooltipChecked = true;
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
            var window = new Reminders(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId,tooltipChecked);
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
            var window = new PatientAppointments(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void ShowPatientIsBlocked(int patientId)
        {
            MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!", "Zdravo korporacija",
                MessageBoxButton.OK, MessageBoxImage.Error);
            appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
            var windowLogOut = new MainWindow();
            windowLogOut.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId,tooltipChecked);
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
            var window = new Notifications(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void myGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Zakazi.IsEnabled = true;
        }

        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new PatientNewAppointment(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            tooltipChecked = false;
        }
    }
}
