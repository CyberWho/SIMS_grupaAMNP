/***********************************************************************
 * Module:  ClinicalTreatment.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.ClinicalTreatment
 ***********************************************************************/

using System;

namespace Hospital.Model
{
    public class ClinicalTreatment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Room room { get; set; }
        public HealthRecord healthRecord { get; set; }

    }
}