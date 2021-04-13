/***********************************************************************
 * Module:  ReferralForSpecialist.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.ReferralForSpecialist
 ***********************************************************************/

using System;

namespace Hospital.Model
{
   public class ReferralForSpecialist
   {
      public int Id;
      public Boolean IsActive;
      
      public Doctor doctor;
      public HealthRecord healthRecord;
      public Appointment appointment;
   
   }
}