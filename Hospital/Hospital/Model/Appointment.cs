using System;
using Hospital.Controller;

namespace Hospital.Model
{
    public class Appointment : IEntity
    {


        public int Id { get; set; }
        public int DurationInMinutes { get; set; }
        public DateTime StartTime { get; set; }
        public AppointmentType Type { get; set; }
        public AppointmentStatus Status { get; set; }

        public int Doctor_Id { get; set; }
        public int Patient_Id { get; set; }
        public int Room_Id { get; set; }

        public Doctor doctor { get; set; }



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
        public Patient patient { get; set; }

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
                    oldRoom.RemoveAppointment(this);
                }
                if (newRoom != null)
                {
                    this.room = newRoom;
                    this.room.AddAppointment(this);
                }
            }
        }

        public Appointment(int id, int durationInMinutes, DateTime startTime, AppointmentType type, AppointmentStatus status, Doctor doctor, Patient patient, Room room)
        {
            Id = id;
            DurationInMinutes = durationInMinutes;
            StartTime = startTime;
            Type = type;
            Status = status;
            this.doctor = doctor;
            this.patient = patient;
            this.room = room;
            Doctor_Id = doctor.Id;
            Patient_Id = patient.Id;
            Room_Id = (int)room.Id;
        }
        public Appointment(int durationInMinutes, DateTime startTime, AppointmentType type, AppointmentStatus status, Doctor doctor, Patient patient, Room room)
        {
            
            DurationInMinutes = durationInMinutes;
            StartTime = startTime;
            Type = type;
            Status = status;
            this.doctor = doctor;
            this.patient = patient;
            this.room = room;
            Doctor_Id = doctor.Id;
            Patient_Id = patient.Id;
            Room_Id = (int)room.Id;
        }

        public Appointment(int id, int durationInMinutes, DateTime startTime, AppointmentType type, AppointmentStatus status, int doctor_Id, int patient_Id, int room_Id)
        {
            Id = id;
            DurationInMinutes = durationInMinutes;
            StartTime = startTime;
            Type = type;
            Status = status;
            this.doctor = null;
            this.patient = null;
            this.room = null;
            Doctor_Id = doctor_Id;
            Patient_Id = patient_Id;
            Room_Id = room_Id;
        }

        public Appointment()
        {
        }

        public void CreateNewAppointment()
        {
            new AppointmentController().ReserveAppointment(this);
        }

        public void DeleteAppointment()
        {
            new AppointmentController().DeleteAppointmentById(Id);
        }

        public void UpdateAppointmentStartTime(DateTime newStartTime)
        {
            new AppointmentController().ChangeStartTime(this, newStartTime);
        }
    }
}