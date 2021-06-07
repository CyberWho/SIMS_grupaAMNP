/***********************************************************************
 * Module:  Referral.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.Referral
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class ReferralForClinicalTreatment : IEntity
   {
      public int Id { get; set; }
      public Boolean IsActive { get; set; }
      public String Description { get; set; }
      
      public DateRange dateRange { get; set; }
      public Appointment Appointment { get; set; }
      public HealthRecord HealthRecord { get; set; }

      public int appointmentId { get; set; }
      
        public int healthRecordId { get; set; }

        public ReferralForClinicalTreatment(int id, bool isActive, string description, DateTime startTime, DateTime endTime, Appointment appointment, HealthRecord healthRecord)
        {
            Id = id;
            IsActive = isActive;
            Description = description;
            dateRange = new DateRange(startTime, endTime);
            Appointment = appointment;
            HealthRecord = healthRecord;
            appointmentId = appointment.Id;
            healthRecordId = healthRecord.Id;
        }

        public ReferralForClinicalTreatment()
        {
            dateRange = new DateRange();
        }
    }
}