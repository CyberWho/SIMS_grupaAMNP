/***********************************************************************
 * Module:  AppointmentService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.AppointmentService
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class AppointmentService
    {
        private IAppointmentRepo<Appointment> appointmentRepository;

        public AppointmentService()
        {
            appointmentRepository = new AppointmentRepository();
        }
        public Appointment GetAppointmentByDoctorIdAndTime(Doctor doctor, DateTime time)
        {
            return this.appointmentRepository.GetByDoctorIdAndTime(doctor, time);
        }

        public Hospital.Model.Appointment GetAppointmentById(int id)
        {
            Appointment appointment = new Appointment();
            appointment = appointmentRepository.GetById(id);
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
            return new AppointmentRepository().GetAllByDoctorId(doctorId);
        }

        public ObservableCollection<Appointment> GetAllReservedAppointmentsByPatientId(int patientId)
        {
            return appointmentRepository.GetAllReservedByPatientId(patientId);
        }

        public Boolean CancelAppointmentById(int id)
        {
            appointmentRepository.DeleteById(id);
            return true;
        }

        public Boolean DeleteAllReservedAppointmentsByPatientId(int patientId)
        {

            return appointmentRepository.DeleteAllReservedByPatientId(patientId); 
        }

        public Appointment ReserveAppointment(Appointment appointment)
        {
            appointmentRepository.Add(appointment);
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
            appointmentRepository.UpdateStartTime(appointment, newStartTime);
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

        public Boolean DeleteAppointmentById(int id)
        {
            return appointmentRepository.DeleteById(id);
        }
        public int GetLastId()
        {
            return appointmentRepository.GetLastId();
        }

       

    }
}