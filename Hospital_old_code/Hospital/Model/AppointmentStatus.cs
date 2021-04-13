/***********************************************************************
 * Module:  AppointmentStatus.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.AppointmentStatus
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class AppointmentStatus
    {

        private string Type { get; set; }

        public System.Collections.ArrayList Appointment;

        public System.Collections.ArrayList GetAppointment()
        {
            if (Appointment == null)
                Appointment = new System.Collections.ArrayList();
            return Appointment;
        }

        public void SetAppointment(System.Collections.ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.Appointment == null)
                this.Appointment = new System.Collections.ArrayList();
            if (!this.Appointment.Contains(newAppointment))
            {
                this.Appointment.Add(newAppointment);
                newAppointment.SetAppointmentStatus(this);
            }
        }

        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.Appointment != null)
                if (this.Appointment.Contains(oldAppointment))
                {
                    this.Appointment.Remove(oldAppointment);
                    oldAppointment.SetAppointmentStatus((AppointmentStatus)null);
                }
        }

        public void RemoveAllAppointment()
        {
            if (Appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in Appointment)
                    tmpAppointment.Add(oldAppointment);
                Appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetAppointmentStatus((AppointmentStatus)null);
                tmpAppointment.Clear();
            }
        }

    }
}