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
        public DateTime AlarmTime { get; set; }

        public Patient Patient { get; set; }

        public int personalReminderId { get; set; }

        public Reminder(int id, string name, string description, DateTime alarmTime, Patient patient)
        {
            Id = id;
            Name = name;
            Description = description;
            AlarmTime = alarmTime;
            Patient = patient;
        }
        public Reminder(string name, string description, DateTime alarmTime, Patient patient, int personalReminderId)
        {
            Name = name;
            Description = description;
            AlarmTime = alarmTime;
            Patient = patient;
            this.personalReminderId = personalReminderId;
        }

        public Reminder()
        {
        }
    }
}