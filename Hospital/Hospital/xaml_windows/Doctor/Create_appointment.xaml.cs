﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;
using System.Windows.Controls;

using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Create_appointment.xaml
    /// </summary>
    public partial class Create_appointment : Window
    {
        int doctor_id_as_user; //as a user
        int id_doc;
        //for focus switching, to make less calls to DB
        private ListBoxItem patient_for_create;
        private ListBoxItem time_slot_for_create;

        private Model.Doctor doctor;
        private Room doctrorsRoom;

        //controllers
        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        private RoomController roomController = new RoomController();
        private DoctorController doctorController = new DoctorController();
        private TimeSlotController timeSlotController = new TimeSlotController();
        
        public Create_appointment(int doctor_id_as_user, int id_doc)
        {
            InitializeComponent();
            this.doctor_id_as_user = doctor_id_as_user;
            this.id_doc = id_doc;
            this.doctrorsRoom = roomController.GetRoomByDoctorId(id_doc);
            this.doctor = doctorController.GetDoctorById(id_doc);

            FillFreeTimeSlotsToUi();
            FillPatientsToUi();

        }

        void AddAppointment(object sender, RoutedEventArgs e)
        {
            if (patient_for_create != null)
            {
                int id_app = appointmentController.GetLastId() + 1;
                int duration = 30;
                Appointment newAppointment = new Appointment(id_app, duration, getDateTimeFromUi(), AppointmentType.EXAMINATION,
                    AppointmentStatus.RESERVED, doctor, getPatientFromUi(), doctrorsRoom);
                appointmentController.ReserveAppointment(newAppointment);
                timeSlotController.TakeTimeSlot(getTimeSlotFromUi());

            }
        }

        //UI fillers
        private void FillFreeTimeSlotsToUi()
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

        private void FillPatientsToUi()
        {
            foreach (Model.Patient patient in patientController.GetAllPatients())
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = patient.Id + "|" + patient.JMBG + " " + patient.User.Name + " " + patient.User.Surname;
                lb_patients.Items.Add(item);
            }
        }


        //list box focus switch 
        void PatientFocusSwitch(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                patient_for_create = lbi;
            }
        }
        private void TimeSlotFocusSwitch(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                time_slot_for_create = lbi;
            }
        }

        //object creation from ui information
        private DateTime getDateTimeFromUi()
        {
            string[] split1 = time_slot_for_create.Content.ToString().Split('|');
            string[] dateAndTime = split1[1].Split(' ');
            string[] onlyDate = dateAndTime[0].Split('/');
            string[] onlyTime = dateAndTime[1].Split(':');
            return new DateTime(int.Parse(onlyDate[2]), int.Parse(onlyDate[1]), int.Parse(onlyDate[0]),
                int.Parse(onlyTime[0]), int.Parse(onlyTime[1]), 0);
        }

        private TimeSlot getTimeSlotFromUi()
        {
            string[] split1 = time_slot_for_create.Content.ToString().Split('|');
            return timeSlotController.GetTimeSlotById(int.Parse(split1[0]));

        }

        private Model.Patient getPatientFromUi()
        {
            string[] split1 = patient_for_create.Content.ToString().Split('|');
            int id_patient = int.Parse(split1[0]);
            return patientController.GetPatientById(id_patient);
        }

        //go back to prev window
        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.doctor_id_as_user);
            s.Show();
            this.Close();
        }
    }
}
