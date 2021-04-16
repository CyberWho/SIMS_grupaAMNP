/***********************************************************************
 * Module:  AppointmentController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.AppointmentController
 ***********************************************************************/

using System;

namespace Hospital.Controller
{
   public class AppointmentController
   {
      public Hospital.Model.Appointment GetAppointmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appointment> GetAllReservedAppointments()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appointment> GetAllReservedAppointmentsWeekly()
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appontment> GetAllAppointmentsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appointment> GetAllByAppointmentsPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean CancelAppointmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
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
      
      public System.Array<Appointment> GetAllFreeAppointmentsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Appointment> GetAllFreeAppointmentsByDesiredTime(DateTime startTime, DateTime endTime)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Service.AppointmentService appointmentService;
   
   }
}