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
   
      public int Id;
      public int DurationInMinutes;
      public DateTime StartTime;
      public AppointmentType Type;
      public AppointmentStatus Status;
      
      public Doctor doctor;
      
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
   
   }
}