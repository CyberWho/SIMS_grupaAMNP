/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AppointmentController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Controller
{
   public class AppointmentController
   {
      public Hospital.Model.Appointment GetAppointmentById(int id)
      {
         // TODO: implement
         return null;
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
      
      public ObservableCollection<Appointment> GetAllByAppointmentsPatientId(int patientId)
      {
         return new AppointmentService().GetAllByAppointmentsPatientId(patientId);
      }
      
      public Boolean CancelAppointmentById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Appointment ReserveAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
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
         // TODO: implement
         return null;
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
   
      public Hospital.Service.AppointmentService appointmentService;
   
   }
}