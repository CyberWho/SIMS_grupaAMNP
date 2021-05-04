using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
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
using Hospital.Controller;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Doctor_crud_appointments.xaml
    /// </summary>
    public partial class Doctor_crud_appointments : Window
    {
        private int id { set; get; }
        private int id_doc { set; get; }

        ListBoxItem selected_appointment = null;
        ListBoxItem time_slot_for_update = null;

        private Model.Doctor doctor;
        private Appointment selectedAppointment;
        private Model.Patient selectePatientFromAppointment;

        //controllers
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private TimeSlotController timeSlotController = new TimeSlotController();
        private DoctorController doctorController = new DoctorController();
        public Doctor_crud_appointments(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;
            this.doctor = doctorController.GetDoctorById(id_doc);


            FillAppointmentsToUi();
            FillTimeSlotsToUi();

        }

        void FillTimeSlotsToUi()
        {
            foreach (TimeSlot timeSlot in timeSlotController.GetAllFreeTimeSlotsByDoctorId(doctor.Id))
            {
                if (timeSlot.Free)
                {
                    ListBoxItem item = new ListBoxItem();
                    item.Content = timeSlot.Id + "|" + timeSlot.StartTime;
                    lb_time_slots.Items.Add(item);
                }
            }

        }
        void FillAppointmentsToUi()
        {
            MessageBox.Show(id_doc.ToString());
            foreach (Appointment appointment in appointmentController.GetAllAppointmentsByDoctorId(id_doc))
            {
                Model.Patient patien = patientController.GetPatientById(appointment.Patient_Id);
                ListBoxItem item = new ListBoxItem();
                item.Content = appointment.StartTime + " " + patien.User.Surname + " " + "\nsoba:" +
                               appointment.Room_Id + " id_pregleda =" +
                               appointment.Id + " " + appointment.Type;

                lb_appointments.Items.Add(item);
            }

        }

        void fetchAppointmentAndPatient()
        {
            string[] split = (selected_appointment.Content.ToString().Split('='))[1].Split(' ');
            selectedAppointment = appointmentController.GetAppointmentById(int.Parse(split[0]));
            selectePatientFromAppointment = patientController.GetPatientById(selectedAppointment.patient.Id);
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

        void appointmentFokus(object sender, SelectionChangedEventArgs args)
        {
            more_info.Text = "";
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                selected_appointment = lbi;
                updateMoreInfoOnPatient();
            }
            else
            {
                more_info.Text = "";
            }

        }


        private TimeSlot getTimeSlotFromUi()
        {
            string[] split1 = time_slot_for_update.Content.ToString().Split('|');
            return timeSlotController.GetTimeSlotById(int.Parse(split1[0]));

        }

        void timeSlotFokus(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                time_slot_for_update = lbi;
            }

        }

        private void UpdateAppointment(object sender, RoutedEventArgs e)
        {
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
        }

        void updateUi(TimeSlot toFree)
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

        }
        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
            s.Show();
            this.Close();
        }

        private void DelateAppointment(object sender, RoutedEventArgs e)
        {
            
            appointmentController.DeleteAppointmentById(selectedAppointment.Id);
            lb_appointments.Items.Remove(selected_appointment);
            more_info.Text = "";
            selected_appointment = null;
           
        }
    }
}
