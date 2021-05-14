using System;
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
            return null;
        }
        public ObservableCollection<PersonalReminder> GetAllPersonalRemindersByPatientId(int patientId)
        {
            return personalReminderService.GetAllPersonalRemindersByPatientId(patientId);
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
            return personalReminderService.DeletePersonalReminderById(id);
        }
        public Boolean DeleteAllPersonalRemindersByPatientId(int patientId)
        {
            return false;
        }
        public PersonalReminderService personalReminderService = new PersonalReminderService();
    }
}
