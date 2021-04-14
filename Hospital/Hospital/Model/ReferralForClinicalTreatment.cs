/***********************************************************************
 * Module:  Referral.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Model.Referral
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class ReferralForClinicalTreatment
   {
      public int Id { get; set; }
      public Boolean IsActive { get; set; }
      public String Description { get; set; }
      public DateTime StartTime { get; set; }
      public DateTime EndTime { get; set; }
      
      public Appointment Appointment { get; set; }
      public HealthRecord HealthRecord { get; set; }

        public ReferralForClinicalTreatment(int id, bool isActive, string description, DateTime startTime, DateTime endTime, Appointment appointment, HealthRecord healthRecord)
        {
            Id = id;
            IsActive = isActive;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            Appointment = appointment;
            HealthRecord = healthRecord;
        }

        public ReferralForClinicalTreatment()
        {
        }
    }
}