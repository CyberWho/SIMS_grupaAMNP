﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.Repository;

namespace Hospital.Service
{
    class PersonalReminderService
    {
        public PersonalReminder GetPersonalReminderById(int id)
        {
            return personalReminderRepository.GetPersonalReminderById(id);
        }
        public ObservableCollection<PersonalReminder> GetAllPersonalRemindersByPatientId(int patientId)
        {
            return personalReminderRepository.GetAllPersonalRemindersByPatientId(patientId);
        }
        public PersonalReminder UpdatePersonalReminderFrequency(PersonalReminder personalReminder)
        {
            return personalReminderRepository.UpdatePersonalReminderFrequency(personalReminder);
        }
        public PersonalReminder AddPersonalReminder(PersonalReminder personalReminder)
        {
            return personalReminderRepository.AddPersonalReminder(personalReminder);
        }
        public Boolean DeletePersonalReminderById(int id)
        {
            personalReminderRepository.DeletePersonalReminderById(id);
            DeleteAllRemindersByPersonalReminderId(id);
            return false;
        }
        public Boolean DeleteAllRemindersByPersonalReminderId(int personalReminderId)
        {
            ObservableCollection<Reminder> reminders = reminderRepository.GetAllByPersonalReminderId(personalReminderId);
            foreach(Reminder reminder in reminders)
            {
                reminderRepository.DeleteById(reminder.Id);
            }
            return true;
        }
        public Boolean GenerateOnlyOnceReminder(PersonalReminder personalReminder)
        {
            DeleteAllRemindersExceptFirstReminder(personalReminder);
            return true;
        }
        public Boolean GenerateDailyReminder(PersonalReminder personalReminder)
        {
            DeleteAllRemindersExceptFirstReminder(personalReminder);
            NewDailyReminder(personalReminder);
            return true;
        }
        public Boolean GenerateWeeklyReminder(PersonalReminder personalReminder)
        {
            DeleteAllRemindersExceptFirstReminder(personalReminder);
            NewWeeklyReminder(personalReminder);
            return true;
        }
        public Boolean NewOnlyOnceReminder(PersonalReminder personalReminder)
        {
            Reminder reminder = new Reminder(personalReminder.Name, personalReminder.Description, personalReminder.AlarmTime, personalReminder.Patient, personalReminder.Id);
            reminderRepository.Add(reminder);
            return true;
        }
        public Boolean NewWeeklyReminder(PersonalReminder personalReminder)
        {
            DateTime endTime = personalReminder.AlarmTime.AddDays(31);
            DateTime alarmTime = personalReminder.AlarmTime;
            while (alarmTime <= endTime)
            {
                Reminder reminder = new Reminder(personalReminder.Name, personalReminder.Description, alarmTime, personalReminder.Patient, personalReminder.Id);
                alarmTime = alarmTime.AddDays(7);
                reminderRepository.Add(reminder);
            }
            return true;
        }
        public Boolean NewDailyReminder(PersonalReminder personalReminder)
        {
            DateTime endTime = personalReminder.AlarmTime.AddDays(7);
            DateTime alarmTime = personalReminder.AlarmTime;
            while (alarmTime <= endTime)
            {
                Reminder reminder = new Reminder(personalReminder.Name, personalReminder.Description, alarmTime, personalReminder.Patient, personalReminder.Id);
                alarmTime = alarmTime.AddDays(1);
                reminderRepository.Add(reminder);
            }
            return true;

        }
        public Boolean DeleteAllRemindersExceptFirstReminder(PersonalReminder personalReminder)
        {
            ObservableCollection<Reminder> reminders = reminderRepository.GetAllByPersonalReminderId(personalReminder.Id);
            foreach (Reminder reminder in reminders)
            {
                if (reminder.Id == personalReminder.reminderId) continue;
                reminderRepository.DeleteById(reminder.Id);
            }
            return true;
        }

        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public int GetLastId()
        {
            return personalReminderRepository.GetLastId();
        }
        public PersonalReminderRepository personalReminderRepository = new PersonalReminderRepository();
        public ReminderRepository reminderRepository = new ReminderRepository();
    }
}
