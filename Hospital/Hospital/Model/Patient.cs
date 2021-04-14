/***********************************************************************
 * Module:  Patient.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Patient
 ***********************************************************************/

using System;
using System.Collections;

namespace Hospital.Model
{
    public class Patient
    {

        public int Id { get; set; }
        public string JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }

        public User User { get; set; }
        public System.Collections.ArrayList Appointments;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAppointments()
        {
            if (Appointments == null)
                Appointments = new System.Collections.ArrayList();
            return Appointments;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointments(System.Collections.ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddAppointments(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.Appointments == null)
                this.Appointments = new System.Collections.ArrayList();
            if (!this.Appointments.Contains(newAppointment))
            {
                this.Appointments.Add(newAppointment);
                newAppointment.SetPatient(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointments(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.Appointments != null)
                if (this.Appointments.Contains(oldAppointment))
                {
                    this.Appointments.Remove(oldAppointment);
                    oldAppointment.SetPatient((Patient)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointments()
        {
            if (Appointments != null)
            {
                System.Collections.ArrayList tmpAppointments = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in Appointments)
                    tmpAppointments.Add(oldAppointment);
                Appointments.Clear();
                foreach (Appointment oldAppointment in tmpAppointments)
                    oldAppointment.SetPatient((Patient)null);
                tmpAppointments.Clear();
            }
        }
        public Address Address { get; set; }
        public HealthRecord HealthRecord { get; set; }

        public Patient(int id, string jMBG, DateTime dateOfBirth, User user, ArrayList appointments, Address address, HealthRecord healthRecord)
        {
            Id = id;
            JMBG = jMBG;
            DateOfBirth = dateOfBirth;
            User = user;
            Appointments = appointments;
            Address = address;
            HealthRecord = healthRecord;
        }

        public Patient()
        {
        }
    }
}