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
      public Reminder GetReminderById(int id)
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

        public Boolean AddNewReminderByMedicalTreatment(MedicalTreatment medicalTreatment)
        {
           
            reminderService.AddNewReminderByMedicalTreatment(medicalTreatment);
            return true;
        }

        public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Reminder UpdateReminder(Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Reminder AddReminder(Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Reminder ChangeAlarmTime(Reminder reminder, DateTime newAlarmTime)
      {
         // TODO: implement
         return null;
      }
   
      public Service.ReminderService reminderService = new Service.ReminderService();
   
   }
}