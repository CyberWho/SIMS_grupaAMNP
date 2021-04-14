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
      
      public Room Room { get; set; }
      public HealthRecord HealthRecord { get; set; }

        public ClinicalTreatment(int id, DateTime startTime, DateTime endTime, Room room, HealthRecord healthRecord)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Room = room;
            HealthRecord = healthRecord;
        }

        public ClinicalTreatment()
        {
        }
    }
}