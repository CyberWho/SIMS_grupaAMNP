﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.Service;

namespace Hospital.Controller
{
    class PersonalReminderController
    {
        public PersonalReminder GetPersonalReminderById(int id)
        {
            return personalReminderService.GetPersonalReminderById(id);
        }
        public ObservableCollection<PersonalReminder> GetAllPersonalRemindersByPatientId(int patientId)
        {
            return personalReminderService.GetAllPersonalRemindersByPatientId(patientId);
        }
        public PersonalReminder UpdatePersonalReminderFrequency(PersonalReminder personalReminder)
        {
            return personalReminderService.UpdatePersonalReminderFrequency(personalReminder);
        }
        public PersonalReminder AddPersonalReminder(PersonalReminder personalReminder)
        {
            return null;
        }
        public Boolean GenerateOnlyOnceReminder(PersonalReminder personalReminder)
        {
            return personalReminderService.GenerateOnlyOnceReminder(personalReminder);
        }
        public Boolean GenerateDailyReminder(PersonalReminder personalReminder)
        {
            return personalReminderService.GenerateDailyReminder(personalReminder);
        }
        public Boolean GenerateWeeklyReminder(PersonalReminder personalReminder)
        {
            return personalReminderService.GenerateWeeklyReminder(personalReminder);
        }
        public Boolean DeletePersonalReminderById(int id)
        {
            return personalReminderService.DeletePersonalReminderById(id);
        }
        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public PersonalReminderService personalReminderService = new PersonalReminderService();
    }
}
