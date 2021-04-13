/***********************************************************************
 * Module:  Patient.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Patient
 ***********************************************************************/

using System;
using System.Collections.Generic;

namespace Hospital.Model
{
    public class Patient
    {
        public DateTime DateOfBirth { get; set; }
        public string JMBG { get; set; }
        public Adress Address { get; set; }
        public User User { get; set; }

        public System.Collections.ArrayList Appointments;

        public List<Appointment> GetAllReservedApointments()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAppointments()
        {
            if (Appointments == null)
                Appointments = new System.Collections.ArrayList();
            return Appointments;
        }

        public void SetAppointments(System.Collections.ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

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

    }
}