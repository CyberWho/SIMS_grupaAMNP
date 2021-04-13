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
        public int DurationInMinutes { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentType Type { get; set; }
        public AppointmentStatus Status { get; set; }

        public Doctor doctor;
        public Patient patient;
        public Room room;


        public Boolean SaveNewAppointment(Doctor doctor, Patient patient, DateTime startTime, double duration)
        {
            // TODO: implement
            return null;
        }

        public Boolean ModifyAppointment(DateTime startTime, int appointmentId, double duration)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteAppointment(int appointmentId)
        {
            // TODO: implement
            return null;
        }


        /// <pdGenerated>default parent getter</pdGenerated>
        public Doctor GetDoctor()
        {
            return doctor;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newDoctor</param>
        public void SetDoctor(Doctor newDoctor)
        {
            if (this.doctor != newDoctor)
            {
                if (this.doctor != null)
                {
                    Doctor oldDoctor = this.doctor;
                    this.doctor = null;
                    oldDoctor.RemoveAppointment(this);
                }
                if (newDoctor != null)
                {
                    this.doctor = newDoctor;
                    this.doctor.AddAppointment(this);
                }
            }
        }

        /// <pdGenerated>default parent getter</pdGenerated>
        public Patient GetPatient()
        {
            return patient;
        }

        /// <pdGenerated>default parent setter</pdGenerated>
        /// <param>newPatient</param>
        public void SetPatient(Patient newPatient)
        {
            if (this.patient != newPatient)
            {
                if (this.patient != null)
                {
                    Patient oldPatient = this.patient;
                    this.patient = null;
                    oldPatient.RemoveAppointments(this);
                }
                if (newPatient != null)
                {
                    this.patient = newPatient;
                    this.patient.AddAppointments(this);
                }
            }
        }

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
                    oldRoom.RemoveAppointment(this);
                }
                if (newRoom != null)
                {
                    this.room = newRoom;
                    this.room.AddAppointment(this);
                }
            }
        }

    }
}