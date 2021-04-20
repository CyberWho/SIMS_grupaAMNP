/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AppointmentController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
    public class AppointmentController
    {
        public Hospital.Model.Appointment GetAppointmentById(int id)
        {
            Appointment appointment = new Appointment();
            appointment = appointmentService.GetAppointmentById(id);
            return appointment;
        }

        public ObservableCollection<Appointment> GetAllReservedAppointments()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllReservedAppointmentsWeekly()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllAppointmentsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllByAppointmentsPatientId(int patientId)
        {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
            appointments = appointmentService.GetAllByAppointmentsPatientId(patientId);
            return appointments;
        }

        public Boolean CancelAppointmentById(int id)
        {
            appointmentService.CancelAppointmentById(id);
            return true;
        }

        public Boolean DeleteAppointmentByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.Appointment ReserveAppointment(Hospital.Model.Appointment appointment)
        {
            appointmentService.ReserveAppointment(appointment);
            return appointment;
        }

        public Hospital.Model.Appointment ChangeAppointmentStatus(Hospital.Model.Appointment appointment)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Appointment ChangeRoom(Hospital.Model.Appointment appointment, int roomId)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Appointment ChangeStartTime(Hospital.Model.Appointment appointment, DateTime newStartTime)
        {
            appointmentService.ChangeStartTime(appointment, newStartTime);
            return appointment;
        }

        public ObservableCollection<Appointment> GetAllFreeAppointmentsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllFreeAppointmentsByDesiredTime(DateTime startTime, DateTime endTime)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Service.AppointmentService appointmentService = new Service.AppointmentService();

    }
}