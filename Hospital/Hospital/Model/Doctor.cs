/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Doctor
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Doctor : Employees
    {
        public Room Room;
        public Specialization Specialization;
        public System.Collections.ArrayList WorkHours;
        public System.Collections.ArrayList Appointment;

        public Room GetRoom()
        {
            return Room;
        }

        public void SetRoom(Room newRoom)
        {
            if (this.Room != newRoom)
            {
                if (this.Room != null)
                {
                    Room oldRoom = this.Room;
                    this.Room = null;
                    oldRoom.RemoveDoctor(this);
                }
                if (newRoom != null)
                {
                    this.Room = newRoom;
                    this.Room.AddDoctor(this);
                }
            }
        }
        
        public Specialization GetSpecialization()
        {
            return Specialization;
        }

        public void SetSpecialization(Specialization newSpecialization)
        {
            if (this.Specialization != newSpecialization)
            {
                if (this.Specialization != null)
                {
                    Specialization oldSpecialization = this.Specialization;
                    this.Specialization = null;
                    oldSpecialization.RemoveDoctor(this);
                }
                if (newSpecialization != null)
                {
                    this.Specialization = newSpecialization;
                    this.Specialization.AddDoctor(this);
                }
            }
        }

        public System.Collections.ArrayList GetWorkHours()
        {
            if (WorkHours == null)
                WorkHours = new System.Collections.ArrayList();
            return WorkHours;
        }

        public void SetWorkHours(System.Collections.ArrayList newWorkHours)
        {
            RemoveAllWorkHours();
            foreach (WorkHours oWorkHours in newWorkHours)
                AddWorkHours(oWorkHours);
        }

        public void AddWorkHours(WorkHours newWorkHours)
        {
            if (newWorkHours == null)
                return;
            if (this.WorkHours == null)
                this.WorkHours = new System.Collections.ArrayList();
            if (!this.WorkHours.Contains(newWorkHours))
            {
                this.WorkHours.Add(newWorkHours);
                newWorkHours.SetDoctor(this);
            }
        }

        public void RemoveWorkHours(WorkHours oldWorkHours)
        {
            if (oldWorkHours == null)
                return;
            if (this.WorkHours != null)
                if (this.WorkHours.Contains(oldWorkHours))
                {
                    this.WorkHours.Remove(oldWorkHours);
                    oldWorkHours.SetDoctor((Doctor)null);
                }
        }

        public void RemoveAllWorkHours()
        {
            if (WorkHours != null)
            {
                System.Collections.ArrayList tmpWorkHours = new System.Collections.ArrayList();
                foreach (WorkHours oldWorkHours in WorkHours)
                    tmpWorkHours.Add(oldWorkHours);
                WorkHours.Clear();
                foreach (WorkHours oldWorkHours in tmpWorkHours)
                    oldWorkHours.SetDoctor((Doctor)null);
                tmpWorkHours.Clear();
            }
        }

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
                newAppointment.SetDoctor(this);
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
                    oldAppointment.SetDoctor((Doctor)null);
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
                    oldAppointment.SetDoctor((Doctor)null);
                tmpAppointment.Clear();
            }
        }

    }
}