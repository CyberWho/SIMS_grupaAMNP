using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class PersonalReminder:Reminder
    {
        public int Id { get; set; }

        public PersonalReminderFrequency PersonalReminderFrequency { get; set; }

        public int reminderId { get; set; }
        public PersonalReminder()
        {

        }
        public PersonalReminder(int id,PersonalReminderFrequency personalReminderFreqeuncy)
        {
            Id = id;
            PersonalReminderFrequency = PersonalReminderFrequency;
        }
    }
}
