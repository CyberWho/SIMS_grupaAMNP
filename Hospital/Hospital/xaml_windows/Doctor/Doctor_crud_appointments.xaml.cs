using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;
using Xceed.Wpf.Toolkit.Core.Converters;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hospital.View.Doctor;
using MVVM1;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Doctor_crud_appointments.xaml
    /// </summary>
    public partial class Doctor_crud_appointments : Window, INotifyPropertyChanged
    {
        private int id { set; get; }
        private int id_doc { set; get; }



        private Model.Doctor doctor;
        private Model.Patient selectePatientFromAppointment = new Model.Patient();

        public ObservableCollection<TimeSlot> timeSlots { get; set; }
        public TimeSlot selectedTimeSlot;
        public ObservableCollection<Appointment> appointments { get; set; }
        public Appointment selectedAppointment;
        //controllers
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private TimeSlotController timeSlotController = new TimeSlotController();
        private DoctorController doctorController = new DoctorController();
        public Doctor_crud_appointments(int id, int id_doc)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id = id;
            this.id_doc = id_doc;
            this.doctor = doctorController.GetDoctorById(id_doc);
            
            FillAppointmentsToUi();
            FillTimeSlotsToUi();

            this.DataContext = this;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);

        }

        public Appointment SelectedAppointment
        {
            get { return selectedAppointment; }
            set
            {
                btn_brisi.IsEnabled = true;
                if (selectedTimeSlot != null)
                    btn_azuriraj.IsEnabled = true;
                selectedAppointment = value;
            }
        }

        public TimeSlot SelectedTimeSlot
        {
            get { return selectedTimeSlot; }
            set
            {
                if (selectedAppointment != null)
                    btn_azuriraj.IsEnabled = true;
                selectedTimeSlot = value;
            }
        }

        void FillTimeSlotsToUi()
        {
            timeSlots = new ObservableCollection<TimeSlot>();

            foreach (TimeSlot timeSlot in timeSlotController.GetAllFreeTimeSlotsByDoctorId(doctor.Id))
            {
                if (timeSlot.Free)
                {
                    timeSlots.Add(timeSlot);
                }
            }

        }
        void FillAppointmentsToUi()
        {
            appointments = appointmentController.GetAllAppointmentsByDoctorId(id_doc);
        }

        void fetchAppointmentAndPatient()
        {
            //string[] split = (selected_appointment.Content.ToString().Split('='))[1].Split(' ');
            selectedAppointment = appointmentController.GetAppointmentById(selectedAppointment.Id);
            selectePatientFromAppointment = patientController.GetPatientById(SelectedAppointment.patient.Id);
        }
        void updateMoreInfoOnPatient()
        {
            fetchAppointmentAndPatient();
            more_info.Text =
                selectePatientFromAppointment.User.Name + " " + selectePatientFromAppointment.User.Surname + "\nrođen: " +
                selectePatientFromAppointment.DateOfBirth + "\nJMBG: " + selectePatientFromAppointment.JMBG + "\ntermin: " +
                selectedAppointment.StartTime + "\ntrajanje: " + selectedAppointment.DurationInMinutes + " minuta\n\ntelefon: " +
                selectePatientFromAppointment.User.PhoneNumber + "\nemail: " + selectePatientFromAppointment.User.EMail;
        }


        private void UpdateAppointment(object sender, RoutedEventArgs e)
        {
            /*
            if (selected_appointment != null && time_slot_for_update != null)
            {
                TimeSlot toFree = timeSlotController.GetAppointmentTimeSlotByDateAndDoctorId(selectedAppointment.StartTime, doctor.Id);
                timeSlotController.FreeTimeSlot(toFree);
                TimeSlot newTimeSlot = getTimeSlotFromUi();
                timeSlotController.TakeTimeSlot(newTimeSlot);

                appointmentController.ChangeStartTime(selectedAppointment, newTimeSlot.StartTime);
                selectedAppointment.StartTime = newTimeSlot.StartTime;
                updateUi(toFree);


            }
            */
            if (selectedAppointment != null && selectedTimeSlot != null)
            {
                TimeSlot toFree = timeSlotController.GetAppointmentTimeSlotByDateAndDoctorId(selectedAppointment.StartTime, doctor.Id);
                timeSlotController.FreeTimeSlot(toFree);
                TimeSlot newTimeSlot = selectedTimeSlot;
                timeSlotController.TakeTimeSlot(newTimeSlot);
                //appointments.Remove(selectedAppointment);
                selectedAppointment.doctor = this.doctor;
                appointmentController.ChangeStartTime(selectedAppointment, newTimeSlot.StartTime);
                selectedAppointment.StartTime = newTimeSlot.StartTime;
                //MessageBox.Show(SelectedAppointment.StartTime.ToString());

                timeSlots.Remove(selectedTimeSlot);
                updateMoreInfoOnPatient();
                MessageBox.Show("Uspesno azuriranje termina");
                btn_azuriraj.IsEnabled = false;
                btn_brisi.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Postarajte se da izaberete i vreme i termin");
            }

        }

        /*void updateUi(TimeSlot toFree)
        {

                time_slot_for_update.Content = toFree.Id + "|" + toFree.StartTime;
                selected_appointment.Content = selectedAppointment.StartTime + " " + selectePatientFromAppointment.User.Surname + " " + "\nsoba:" +
                                               selectedAppointment.Room_Id + " id_pregleda =" +
                                               selectedAppointment.Id + " " + selectedAppointment.Type;
                more_info.Text =
                    selectePatientFromAppointment.User.Name + " " + selectePatientFromAppointment.User.Surname + "\nrođen: " +
                    selectePatientFromAppointment.DateOfBirth + "\nJMBG: " + selectePatientFromAppointment.JMBG + "\ntermin: " +
                    selectedAppointment.StartTime + "\ntrajanje: " + selectedAppointment.DurationInMinutes + " minuta\n\ntelefon: " +
                    selectePatientFromAppointment.User.PhoneNumber + "\nemail: " + selectePatientFromAppointment.User.EMail;

        }*/
        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUIwindow(this.id);
            s.Show();
            this.Close();
        }

        private void DelateAppointment(object sender, RoutedEventArgs e)
        {
            selectedAppointment.doctor = this.doctor;
            appointmentController.DeleteAppointmentById(selectedAppointment.Id);
            more_info.Text = "";
            selectedAppointment = null;
            appointments.Remove(selectedAppointment);
            btn_azuriraj.IsEnabled = false;
            btn_brisi.IsEnabled = false;
            MessageBox.Show("Termin uspesno obrisan.");
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selectedAppointment != null)
            {
                //MessageBox.Show(selectedAppointment.Id.ToString());
                updateMoreInfoOnPatient();
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        /***************************
        ***
        Dodavanje navigacije
        ***
        ***************************/
        public MyICommand ReturnOptionCommand { get; set; }
        public MyICommand GoToDrugOperationCommand { get; set; }
        public MyICommand GoToAppointmentsCommand { get; set; }
        public MyICommand GoToCreateAppointmentCommand { get; set; }
        public MyICommand GoToScheduleCommand { get; set; }
        public MyICommand GoToPatientSearchCommand { get; set; }

        public void ReturnOption()
        {
            Window s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void GoToAppointments()
        {
            Window s = new Doctor_crud_appointments(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateAppointment()
        {
            Window s = new Create_appointment(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToSchedule()
        {
            Window s = new Schedule(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToPatientSearch()
        {
            Window s = new SearchPatientMVVM(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToDrugOperation() // Obradjuje se
        {

            Window s = new View.Doctor.DrugOperations(id, id_doc);
            s.Show();
            this.Close();
        }

    }
}
