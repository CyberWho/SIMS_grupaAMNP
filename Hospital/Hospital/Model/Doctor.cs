/***********************************************************************
 * Module:  Doctor.cs
 * Author:  Pedja
 * Purpose: Definition of the Class Doctor
 ***********************************************************************/

using System;
using System.Collections;

namespace Hospital.Model
{
    public class Doctor : Employee
    {
        public Room room { get; set; }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Room GetRoom()
        {
            return room;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newRoom</param>
        public void SetRoom(Room newRoom)
        {
            if (this.room != newRoom)
            {
                if (this.room != null)
                {
                    Room oldRoom = this.room;
                    this.room = null;
                    oldRoom.RemoveDoctor(this);
                }
                if (newRoom != null)
                {
                    this.room = newRoom;
                    this.room.AddDoctor(this);
                }
            }
        }
        public System.Collections.ArrayList workHours;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetWorkHours()
        {
            if (workHours == null)
                workHours = new System.Collections.ArrayList();
            return workHours;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetWorkHours(System.Collections.ArrayList newWorkHours)
        {
            RemoveAllWorkHours();
            foreach (WorkHours oWorkHours in newWorkHours)
                AddWorkHours(oWorkHours);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddWorkHours(WorkHours newWorkHours)
        {
            if (newWorkHours == null)
                return;
            if (this.workHours == null)
                this.workHours = new System.Collections.ArrayList();
            if (!this.workHours.Contains(newWorkHours))
            {
                this.workHours.Add(newWorkHours);
                newWorkHours.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveWorkHours(WorkHours oldWorkHours)
        {
            if (oldWorkHours == null)
                return;
            if (this.workHours != null)
                if (this.workHours.Contains(oldWorkHours))
                {
                    this.workHours.Remove(oldWorkHours);
                    oldWorkHours.SetDoctor((Doctor)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllWorkHours()
        {
            if (workHours != null)
            {
                System.Collections.ArrayList tmpWorkHours = new System.Collections.ArrayList();
                foreach (WorkHours oldWorkHours in workHours)
                    tmpWorkHours.Add(oldWorkHours);
                workHours.Clear();
                foreach (WorkHours oldWorkHours in tmpWorkHours)
                    oldWorkHours.SetDoctor((Doctor)null);
                tmpWorkHours.Clear();
            }
        }
        public Specialization specialization;

        /// <pdGenerated>default parent getter</pdGenerated>
        public Specialization GetSpecialization()
        {
            return specialization;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newSpecialization</param>
        public void SetSpecialization(Specialization newSpecialization)
        {
            if (this.specialization != newSpecialization)
            {
                if (this.specialization != null)
                {
                    Specialization oldSpecialization = this.specialization;
                    this.specialization = null;
                    oldSpecialization.RemoveDoctor(this);
                }
                if (newSpecialization != null)
                {
                    this.specialization = newSpecialization;
                    this.specialization.AddDoctor(this);
                }
            }
        }
        public System.Collections.ArrayList appointment;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetAppointment()
        {
            if (appointment == null)
                appointment = new System.Collections.ArrayList();
            return appointment;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointment(System.Collections.ArrayList newAppointment)
        {
            RemoveAllAppointment();
            foreach (Appointment oAppointment in newAppointment)
                AddAppointment(oAppointment);
        }

        /// <pdGenerated>default Add</pdGenerated>
        public void AddAppointment(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.appointment == null)
                this.appointment = new System.Collections.ArrayList();
            if (!this.appointment.Contains(newAppointment))
            {
                this.appointment.Add(newAppointment);
                newAppointment.SetDoctor(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointment(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.appointment != null)
                if (this.appointment.Contains(oldAppointment))
                {
                    this.appointment.Remove(oldAppointment);
                    oldAppointment.SetDoctor((Doctor)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointment()
        {
            if (appointment != null)
            {
                System.Collections.ArrayList tmpAppointment = new System.Collections.ArrayList();
                foreach (Appointment oldAppointment in appointment)
                    tmpAppointment.Add(oldAppointment);
                appointment.Clear();
                foreach (Appointment oldAppointment in tmpAppointment)
                    oldAppointment.SetDoctor((Doctor)null);
                tmpAppointment.Clear();
            }
        }

        public Doctor(Room room, ArrayList workHours, Specialization specialization, ArrayList appointment)
        {
            this.room = room;
            this.workHours = workHours;
            this.specialization = specialization;
            this.appointment = appointment;
        }

        public Doctor()
        {
        }

        public Doctor(int id, int salary, int yearsOfService, User user, Role role) : base(id, salary, yearsOfService, user, role)
        {

        }
    }
}