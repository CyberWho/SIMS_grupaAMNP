/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AppointmentController
 ***********************************************************************/

using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Controller
{
    public class AppointmentController
    {

        public Appointment GetAppointmentByDoctorIdAndTime(Doctor doctor, DateTime time)
        {
            return this.appointmentService.GetAppointmentByDoctorIdAndTime(doctor, time);
        }
        public Appointment GetAppointmentById(int id)
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
            return new AppointmentService().GetAllAppointmentsByDoctorId(doctorId);
        }

        public ObservableCollection<Appointment> GetAllReservedAppointmentsByPatientId(int patientId)
        {
            return appointmentService.GetAllReservedAppointmentsByPatientId(patientId);
        }

        public Boolean CancelAppointmentById(int id)
        {
            return appointmentService.CancelAppointmentById(id);
        }

        public Boolean DeleteAllReservedAppointmentsByPatientId(int patientId)
        {

            return appointmentService.DeleteAllReservedAppointmentsByPatientId(patientId);
        }

        public Appointment ReserveAppointment(Appointment appointment)
        {
            return appointmentService.ReserveAppointment(appointment);
        }

        public Appointment ChangeAppointmentStatus(Appointment appointment)
        {
            // TODO: implement
            return null;
        }

        public Appointment ChangeRoom(Appointment appointment, int roomId)
        {
            // TODO: implement
            return null;
        }

        public Boolean CheckForAppointmentsByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            return appointmentService.CheckForAppointmentsByPatientIdAndDoctorId(patientId, doctorId);
        }
        public Boolean CheckForAnyAppointmentsByPatientId(int patientId)
        {
            return appointmentService.CheckForAnyAppointmentsByPatientId(patientId);
        }
        public Appointment ChangeStartTime(Appointment appointment, DateTime newStartTime)
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

        public AppointmentService appointmentService = new AppointmentService();

    }
}