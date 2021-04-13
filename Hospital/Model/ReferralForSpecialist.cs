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

        public Doctor doctor { get; set; }
        public HealthRecord healthRecord { get; set; }
        public Appointment appointment { get; set; }

    }
}