using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for UrgentAppointment.xaml
    /// </summary>
    public partial class UrgentAppointment : Window
    {
        private int id;
        private int selected_time_slot_id;
        private string selectedSpecialization;
        private User user;
        private ObservableCollection<TimeSlot> timeSlots { get; set; }
        private UserController userController = new UserController();
        private PatientController patientController = new PatientController();
        private HealthRecordController healthRecordController = new HealthRecordController();
        private DoctorController doctorController = new DoctorController();
        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private AppointmentController appointmentController = new AppointmentController();
        private TimeSlotController timeSlotController = new TimeSlotController();

        public UrgentAppointment(int id)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id = id;
            Update();
        }

        public void Update()
        {
            if (id > 0)
            {
                user = this.userController.GetUserById(id);
                
            }
            else
            {
                user = this.userController.GuestUser();
                this.id = user.Id;
            }



        }

        private void selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Specialization> specializations = this.specializationContoller.GetAllSpecializations();
            ObservableCollection<String> types = new ObservableCollection<string>();

            foreach (Specialization sp in specializations)
            {
                types.Add(sp.Type);
            }

            this.selection.ItemsSource = types;
        }

        private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selection.SelectedItem != null)
            {
                selectedSpecialization = selection.SelectedItem.ToString();
                User user = this.userController.GetUserById(id);
                Model.Patient patient = this.patientController.GetPatientByUserId(id);
                HealthRecord healthRecord = this.healthRecordController.GetHealthRecordByPatientId(patient.Id);
                int specialization_id = this.specializationContoller.GetSpecializationByType(selectedSpecialization);

                timeSlots = this.timeSlotController.GetlAllFreeTimeSlotsBySpecializationIdAfterCurrentTime(specialization_id,
                    patient.Id);

                if (timeSlots.Count == 1)
                {
                    MessageBox.Show(
                        "Hitan termin je uspesno zakazan, i to bez ikakvog pomeranja prethodno zakazanih termina");
                }
                else
                {
                    DataTable dt = new DataTable();
                    available_timeslots.DataContext = timeSlots;
                    available_timeslots.ItemsSource = timeSlots;
                }
            }
        }

        private void Move_Reserved_Appointment(object sender, RoutedEventArgs e)
        {
            TimeSlot currentTimeSlot = this.timeSlotController.GetTimeSlotById(selected_time_slot_id);

            Appointment appointment = this.timeSlotController.MoveReservedAppointment(selected_time_slot_id);

            appointment.patient = this.patientController.GetPatientByUserId(id);
            appointment.Patient_Id = appointment.patient.Id;

            this.appointmentController.ReserveAppointment(appointment);

            MessageBox.Show(
                "Hitan termin je zakazan u odabrani termin, a lekar i pacijent prethodno zakazanog termina su obavesteni");
        }

        private DateTime fix_time()
        {
            // TODO: fix this jumbo mess 

            DateTime now = DateTime.Now;
            string time = now.ToString();
            string[] split1 = time.Split(' ');
            string[] split2 = split1[1].Split(':');
            int minutes = int.Parse(split2[1]);
            int seconds = int.Parse(split2[2]);

            TimeSpan ts;

            // if the time right now is less than :30, then add up to :30
            if (now.Minute <= 30)
            {
                ts = new TimeSpan(0, 30 - minutes, -seconds);
            }
            // else, time is between :30 and :00, and so appointment must be reserved in hour+1:00 slot
            else
            {
                ts = new TimeSpan(0, 60 - minutes, -seconds);
            }

            now = now.Add(ts);

            return now;
        }

        private void Selected_TimeSlot_In_Which_To_Move_Appointment(object sender, SelectionChangedEventArgs e)
        {
            if (available_timeslots.SelectedCells[0] != null)
            {
                var info = available_timeslots.SelectedCells[0];
                if (info.Column.GetCellContent(info.Item) != null)
                {
                    var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
                    selected_time_slot_id = int.Parse(content);
                }
            }
        }
    }
}
