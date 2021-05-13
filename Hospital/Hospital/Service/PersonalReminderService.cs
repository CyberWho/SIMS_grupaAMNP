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
            return null;
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
            return null;
        }
        public Boolean DeletePersonalReminderById(int id)
        {
            return false;
        }
        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public PersonalReminderRepository personalReminderRepository = new PersonalReminderRepository();
    }
}
