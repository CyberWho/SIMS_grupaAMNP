/***********************************************************************
 * Module:  Reminder.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Reminder
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Reminder
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime TimeOfAlarm { get; set; }
        public Patient Patient { get; set; }

    }
}