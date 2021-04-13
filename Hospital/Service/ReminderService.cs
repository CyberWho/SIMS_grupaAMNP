/***********************************************************************
 * Module:  ReminderService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReminderService
 ***********************************************************************/

using System;

namespace Hospital.Service
{
   public class ReminderService
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
      
      public Hospital.Model.Reminder AddReminder(Hospital.Model.Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Reminder ChangeAlarmTime(Hospital.Model.Reminder reminder, DateTime newAlarmTime)
      {
         // TODO: implement
         return null;
      }
   
      public Hospital.Repository.ReminderRepository reminderRepository;
   
   }
}