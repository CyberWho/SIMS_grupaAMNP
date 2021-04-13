/***********************************************************************
 * Module:  ReminderRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReminderRepository
 ***********************************************************************/

using System;

namespace Hospital.Repository
{
   public class ReminderRepository
   {
      public Hospital.Model.Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Array<Reminder> GetAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Reminder UpdateReminder(Hospital.Model.Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Reminder NewReminder(Hospital.Model.Reminder reminder)
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