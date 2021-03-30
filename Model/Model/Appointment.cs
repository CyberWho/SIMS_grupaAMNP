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
   
      public int Id { get; set; }
      public DateTime StartTime { get; set; }
      public double DurationInHours { get; set; }

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
      public Patient patient;
      
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
      public Room room;
      
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
      public AppointmentType appointmentType;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public AppointmentType GetAppointmentType()
      {
         return appointmentType;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newAppointmentType</param>
      public void SetAppointmentType(AppointmentType newAppointmentType)
      {
         if (this.appointmentType != newAppointmentType)
         {
            if (this.appointmentType != null)
            {
               AppointmentType oldAppointmentType = this.appointmentType;
               this.appointmentType = null;
               oldAppointmentType.RemoveAppointment(this);
            }
            if (newAppointmentType != null)
            {
               this.appointmentType = newAppointmentType;
               this.appointmentType.AddAppointment(this);
            }
         }
      }
      public AppointmentStatus appointmentStatus;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public AppointmentStatus GetAppointmentStatus()
      {
         return appointmentStatus;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newAppointmentStatus</param>
      public void SetAppointmentStatus(AppointmentStatus newAppointmentStatus)
      {
         if (this.appointmentStatus != newAppointmentStatus)
         {
            if (this.appointmentStatus != null)
            {
               AppointmentStatus oldAppointmentStatus = this.appointmentStatus;
               this.appointmentStatus = null;
               oldAppointmentStatus.RemoveAppointment(this);
            }
            if (newAppointmentStatus != null)
            {
               this.appointmentStatus = newAppointmentStatus;
               this.appointmentStatus.AddAppointment(this);
            }
         }
      }
   
   }
}