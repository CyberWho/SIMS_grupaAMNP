/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AppointmentRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class AppointmentRepository
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
      
      public Boolean DeleteAppointmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment UpdateAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Appointment NewAppointment(Hospital.Model.Appointment appointment)
      {
         // TODO: implement
         return null;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}