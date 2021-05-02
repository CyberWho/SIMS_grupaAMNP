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
        private ObservableCollection<Model.Doctor> doctors;
        private ObservableCollection<TimeSlot> timeSlots;
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
            this.id = id;
            this.DataContext = this;
            Update();
        }

        public void Update()
        {
            if (id > 0)
            {
                user = this.userController.GetUserById(id);

                PatName.Text = user.Name;
                Surname.Text = user.Surname;
                Username.Text = user.Username;
                PhoneNumber.Text = user.PhoneNumber;
                Email.Text = user.EMail;
            }
            else
            {
                user = this.userController.GuestUser();
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
                // id = current_user_id
                selectedSpecialization = selection.SelectedItem.ToString();
                User user = this.userController.GetUserById(id);
                Model.Patient patient = this.patientController.GetPatientByUserId(id);
                HealthRecord healthRecord = this.healthRecordController.GetHealthRecordByPatientId(patient.Id);
                int specialization_id = this.specializationContoller.GetSpecializationByType(selectedSpecialization);
                doctors = this.doctorController.GetAllDoctorsBySpecializationId(specialization_id);
                // up to this point everything is ok



                // i don't need to call this 
                timeSlots = this.timeSlotController.GetlAllFreeTimeSlotsBySpecializationId(specialization_id,
                    patient.Id);


                /*  patient_id + specialization_id + datetime_now => 1. v 2. 
                 *  1. found at least one doctor within that specialization, free right now 
                 *  => return successfully reserved appointment for first free doctor and for the timeslot that is right now 
                 *  2. ok so found no free doctors with timeslots that are available right now 
                 *  -> take in all the doctors by that specialization 
                 *  -> look at all their timeslots and sort them by next available timeslot 
                 *  -> secretary chooses which timeslot to occupy, since the urgent appointment needs to be right now 
                 *  -> both the patient and the doctor need to be notified about this change 
                 *  
                 */



                // this is what i don't need, the datatable should be filled with timeslots and not by doctors
                DataTable dt = new DataTable();
                available_timeslots.DataContext = timeSlots;
                available_timeslots.ItemsSource = timeSlots;
            }
        }

        private void Create_Urgent_Appointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();

            DateTime time = fix_time();



            appointment = this.appointmentController.ReserveAppointment(appointment);
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

                    /*
                     *  i have to get the timeslot that is already reserved, but the timeslot of the doctor which timeslot i selected to move the already made appointment
                     *  from the selected timeslot i get workhours and then the doctor, from that doctor and from the current time i can get said appointment and move it
                     */

                    TimeSlot currentTimeSlot = this.timeSlotController.GetTimeSlotById(selected_time_slot_id);
                    //int workHours_id = currentTimeSlot.workHours_id;

                    this.timeSlotController.MoveReservedAppointment(selected_time_slot_id);

                }
            }
        }
    }
}
