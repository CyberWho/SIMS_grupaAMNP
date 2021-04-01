/***********************************************************************
 * Module:  Appointment.cs
 * Author:  Dell
 * Purpose: Definition of the Class Bolnica.Model.Patient.Appointment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public double DurationInMinutes { get; set; }
        public DateTime StartTime { get; set; }

        public Doctor Doctor;
        public Patient Patient;
        public Room Room;
        public AppointmentType AppointmentType;
        public AppointmentStatus AppointmentStatus;

        public Boolean SaveNewAppointment(Patient patient, DateTime startTime, double duration)
        {
            // TODO: implement
            return false;
        }

        public Boolean ModifyAppointment(DateTime startTime, int appointmentId, double duration)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAppointment(int appointmentId)
        {
            // TODO: implement
            return false;
        }

        public Doctor GetDoctor()
        {
            return Doctor;
        }

        public void SetDoctor(Doctor newDoctor)
        {
            if (this.Doctor != newDoctor)
            {
                if (this.Doctor != null)
                {
                    Doctor oldDoctor = this.Doctor;
                    this.Doctor = null;
                    oldDoctor.RemoveAppointment(this);
                }
                if (newDoctor != null)
                {
                    this.Doctor = newDoctor;
                    this.Doctor.AddAppointment(this);
                }
            }
        }

        public Patient GetPatient()
        {
            return Patient;
        }

        public void SetPatient(Patient newPatient)
        {
            if (this.Patient != newPatient)
            {
                if (this.Patient != null)
                {
                    Patient oldPatient = this.Patient;
                    this.Patient = null;
                    oldPatient.RemoveAppointments(this);
                }
                if (newPatient != null)
                {
                    this.Patient = newPatient;
                    this.Patient.AddAppointments(this);
                }
            }
        }

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
                    oldRoom.RemoveAppointment(this);
                }
                if (newRoom != null)
                {
                    this.Room = newRoom;
                    this.Room.AddAppointment(this);
                }
            }
        }

        public AppointmentType GetAppointmentType()
        {
            return AppointmentType;
        }

        public void SetAppointmentType(AppointmentType newAppointmentType)
        {
            if (this.AppointmentType != newAppointmentType)
            {
                if (this.AppointmentType != null)
                {
                    AppointmentType oldAppointmentType = this.AppointmentType;
                    this.AppointmentType = null;
                    oldAppointmentType.RemoveAppointment(this);
                }
                if (newAppointmentType != null)
                {
                    this.AppointmentType = newAppointmentType;
                    this.AppointmentType.AddAppointment(this);
                }
            }
        }

        public AppointmentStatus GetAppointmentStatus()
        {
            return AppointmentStatus;
        }

        public void SetAppointmentStatus(AppointmentStatus newAppointmentStatus)
        {
            if (this.AppointmentStatus != newAppointmentStatus)
            {
                if (this.AppointmentStatus != null)
                {
                    AppointmentStatus oldAppointmentStatus = this.AppointmentStatus;
                    this.AppointmentStatus = null;
                    oldAppointmentStatus.RemoveAppointment(this);
                }
                if (newAppointmentStatus != null)
                {
                    this.AppointmentStatus = newAppointmentStatus;
                    this.AppointmentStatus.AddAppointment(this);
                }
            }
        }

    }
}