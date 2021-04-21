using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Model;
using Hospital.xaml_windows;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientNewAppointmentRecommendations.xaml
    /// </summary>
    public partial class PatientNewAppointmentRecommendations : Window
    {
        int id;
        DateTime startTime;
        DateTime endTime;
        int doctorId;
        int priority = 0;
        TimeSlotController timeSlotController = new TimeSlotController();
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();
        ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        DoctorController doctorController = new DoctorController();
        public PatientNewAppointmentRecommendations(int id, DateTime startTime, DateTime endTime, int doctorId, int priority)
        {
            InitializeComponent();
            this.id = id;
            this.startTime = startTime;
            this.endTime = endTime;
            this.doctorId = doctorId;
            this.priority = priority;
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

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientById(id);
            appointment.patient = patient;
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotController.GetTimeSlotById(int.Parse(timeslot_id_txt.Text));
            appointment.StartTime = timeSlot.StartTime;
            Hospital.Model.Doctor doctor = new Model.Doctor();
            doctor = doctorController.GetWorkHoursDoctorById(int.Parse(doctor_id_txt.Text));
            appointment.doctor = doctor;
            Room room = new Room();
            appointment.room = room;
            appointment.room.Id = int.Parse(room_id_txt.Text);
            appointmentController.ReserveAppointment(appointment);
            var s = new PatientAppointment(id);
            s.Show();
            this.Close();
        }
    }
}