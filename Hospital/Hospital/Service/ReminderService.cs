/***********************************************************************
 * Module:  ReminderService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.ReminderService
 ***********************************************************************/

using System;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Service
{
   public class ReminderService
   {
      public Hospital.Model.Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
        public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            reminders = reminderRepository.GetAllPastRemindersByPatientId(patientId);
            return reminders;
        }

       public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            reminders = reminderRepository.GetAllFutureRemindersByPatientId(patientId);
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

      public Boolean AddNewReminderByMedicalTreatment(MedicalTreatment medicalTreatment)
        {
            DateTime start = medicalTreatment.StartTime;
           while(start <= medicalTreatment.EndTime)
            {
                Reminder reminder = new Reminder();
                DateTime startTime = start;
                DateTime alarmTime = start.AddHours(-1);
                reminder.AlarmTime = alarmTime;
                reminder.Name = "Konzumacija leka";
                reminder.Description = "Za sat vremena popijte lek" + medicalTreatment.Drug.InventoryItem.Name;
                reminder.Patient = medicalTreatment.anamnesis.healthRecord.Patient;
                start = start.AddHours(medicalTreatment.Period);
                reminderRepository.NewReminder(reminder);
            }
         
            return true;
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
   
      public Hospital.Repository.ReminderRepository reminderRepository = new Repository.ReminderRepository();
   
   }
}