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
      
      public System.Collections.ArrayList GetAllAppointmentsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllByAppointmentsPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAppointmentById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return false;
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