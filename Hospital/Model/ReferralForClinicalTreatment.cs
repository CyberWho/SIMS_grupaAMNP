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
      public int Id;
      public Boolean IsActive;
      public String Description;
      public DateTime StartTime;
      public DateTime EndTime;
      
      public Appointment appointment;
      public HealthRecord healthRecord;
   
   }
}