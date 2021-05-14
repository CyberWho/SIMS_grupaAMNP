using System;
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
        public PersonalReminder UpdatePersonalReminder(PersonalReminder personalReminder)
        {
            return null;
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
            ObservableCollection<Reminder> reminders = reminderRepository.GetAllRemindersByPersonalReminderId(personalReminderId);
            foreach(Reminder reminder in reminders)
            {
                reminderRepository.DeleteReminderById(reminder.Id);
            }
            return true;
        }
        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public PersonalReminderRepository personalReminderRepository = new PersonalReminderRepository();
        public ReminderRepository reminderRepository = new ReminderRepository();
    }
}
