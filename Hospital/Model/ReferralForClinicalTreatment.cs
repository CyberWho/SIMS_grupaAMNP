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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public String Description { get; set; }

        public Appointment appointment { get; set; }
        public HealthRecord healthRecord { get; set; }

    }
}