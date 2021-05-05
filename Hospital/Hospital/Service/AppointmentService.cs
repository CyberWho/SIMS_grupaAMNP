/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AppointmentService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AppointmentService
    {

        public Appointment GetAppointmentByDoctorIdAndTime(Doctor doctor, DateTime time)
        {
            return this.appointmentRepository.GetAppointmentByDoctorIdAndTime(doctor, time);
        }

        public Hospital.Model.Appointment GetAppointmentById(int id)
        {
            Appointment appointment = new Appointment();
            appointment = appointmentRepository.GetAppointmentById(id);
            return appointment;
        }

        public System.Collections.ArrayList GetAllReservedAppointments()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllReservedAppointmentsWeekly()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Appointment> GetAllAppointmentsByDoctorId(int doctorId)
        {
            return new AppointmentRepository().GetAllAppointmentsByDoctorId(doctorId);
        }

        public ObservableCollection<Appointment> GetAllReservedAppointmentsByPatientId(int patientId)
        {
            return appointmentRepository.GetAllReservedAppointmentsByPatientId(patientId);
        }

        public Boolean CancelAppointmentById(int id)
        {
            appointmentRepository.DeleteAppointmentById(id);
            return true;
        }

        public Boolean DeleteAllReservedAppointmentsByPatientId(int patientId)
        {

            return appointmentRepository.DeleteAllReservedAppointmentsByPatientId(patientId); 
        }

        public Appointment ReserveAppointment(Appointment appointment)
        {
            appointmentRepository.NewAppointment(appointment);
            return appointment;
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

        public Appointment ChangeStartTime(Appointment appointment, DateTime newStartTime)
        {
            appointmentRepository.UpdateAppointmentStartTime(appointment, newStartTime);
            return appointment;
        }

        public Appointment ChangeStartTimePatient(Appointment appointment, DateTime newStartTime)
        {
            //TODO: implement
            return null;
        }
        public Boolean CheckForAppointmentsByPatientIdAndDoctorId(int patientId, int doctorId)
        {
            return appointmentRepository.CheckForAppointmentsByPatientIdAndDoctorId(patientId, doctorId);
        }
        public Boolean CheckForAnyAppointmentsByPatientId(int patientId)
        {
            return appointmentRepository.CheckForAnyAppointmentsByPatientId(patientId);
        }

        public System.Collections.ArrayList GetAllFreeAppointmentsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllFreeAppointmentsByDesiredTime(DateTime startTime, DateTime endTime)
        {
            // TODO: implement
            return null;
        }

        public AppointmentRepository appointmentRepository = new AppointmentRepository();

    }
}