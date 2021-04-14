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
      public int Id { get; set; }
      public Boolean IsActive { get; set; }
      
      public Doctor Doctor { get; set; }
      public HealthRecord HealthRecord { get; set; }
      public Appointment Appointment { get; set; }
   
   }
}