/***********************************************************************
 * Module:  ReminderController.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.ReminderController
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Repository;
using MedicalTreatment = Hospital.Model.MedicalTreatment;

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
            return reminderService.GetAllRemindersByPatientId(patientId);
      }
        public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
        {
            return reminderService.GetAllPastRemindersByPatientId(patientId);
        }

        public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            return reminderService.GetAllFutureRemindersByPatientId(patientId);
        }
      public Boolean DeleteReminderById(int id)
      {
         // TODO: implement
         return false;
      }

        public Boolean AddNewReminderByMedicalTreatment(MedicalTreatment medicalTreatment)
        {
           
            return reminderService.AddNewReminderByMedicalTreatment(medicalTreatment);
           
        }

        public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Reminder UpdateReminder(Reminder reminder)
      {
            return reminderService.UpdateReminder(reminder);
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
        public int GetLastId()
        {
            return reminderService.GetLastId();
        }


      public Service.ReminderService reminderService = new Service.ReminderService();
   
   }
}