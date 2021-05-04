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

        public ObservableCollection<Appointment> GetAllByAppointmentsPatientId(int patientId)
        {
            ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
            appointments = appointmentRepository.GetAllByAppointmentsPatientId(patientId);
            return appointments;
        }

        public Boolean CancelAppointmentById(int id)
        {
            appointmentRepository.DeleteAppointmentById(id);
            return true;
        }

        public Boolean DeleteAppointmentByPatientId(int patientId)
        {

            return appointmentRepository.DeleteAppointmentByPatientId(patientId); 
        }

        public Hospital.Model.Appointment ReserveAppointment(Hospital.Model.Appointment appointment)
        {
            appointmentRepository.NewAppointment(appointment);
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
            appointmentRepository.UpdateAppointmentStartTime(appointment, newStartTime);
            return appointment;
        }

        public Hospital.Model.Appointment ChangeStartTimePatient(Hospital.Model.Appointment appointment, DateTime newStartTime)
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

        public Boolean DeleteAppointmentById(int id)
        {
            return appointmentRepository.DeleteAppointmentById(id);
        }
        public int GetLastId()
        {
            return appointmentRepository.GetLastId();
        }

        public Hospital.Repository.AppointmentRepository appointmentRepository = new Repository.AppointmentRepository();

    }
}