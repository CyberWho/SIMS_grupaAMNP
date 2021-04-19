/***********************************************************************
 * Module:  ReminderController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.ReminderController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
   public class ReminderController
   {
      public Hospital.Model.Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Reminder> GetAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
        public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            reminders = reminderService.GetAllPastRemindersByPatientId(patientId);
            return reminders;
        }

        public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            reminders = reminderService.GetAllFutureRemindersByPatientId(patientId);
            return reminders;
        }
      public Boolean DeleteReminderById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
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
   
      public Hospital.Service.ReminderService reminderService = new Service.ReminderService();
   
   }
}