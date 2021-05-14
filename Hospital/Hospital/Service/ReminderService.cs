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
      public Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Reminder> GetReminderByAlarmTimeAndPatientId(DateTime alarmTime, int patientId)
        {
            return reminderRepository.GetReminderByAlarmTimeAndPatientId(alarmTime, patientId);
        }


      public ObservableCollection<Reminder> GetAllRemindersByPatientId(int patientId)
      {
            return reminderRepository.GetAllRemindersByPatientId(patientId);
      }
        public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
        {
            return reminderRepository.GetAllPastRemindersByPatientId(patientId);
        }

       public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            return reminderRepository.GetAllFutureRemindersByPatientId(patientId);
        }

        public ObservableCollection<Reminder> GetAllRemindersByPersonalReminderId(int personalReminderId)
        {
            return reminderRepository.GetAllRemindersByPersonalReminderId(personalReminderId);
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
                reminder.Description = "Za sat vremena popijte lek " + medicalTreatment.Drug.Name;
                reminder.Patient = medicalTreatment.anamnesis.healthRecord.Patient;
                start = start.AddHours(medicalTreatment.Period);
                reminder.personalReminderId = 0;
                reminderRepository.NewReminder(reminder);
            }
         
            return true;
        }
       
      public Reminder UpdateReminder(Reminder reminder)
      {
            return reminderRepository.UpdateReminder(reminder);
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
   
      public Repository.ReminderRepository reminderRepository = new Repository.ReminderRepository();
   
   }
}