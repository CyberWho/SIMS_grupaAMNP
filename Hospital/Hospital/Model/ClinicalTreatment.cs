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
        public DateRange dateRange;
        public int Id { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set; }
        public HealthRecord HealthRecord { get; set; }
        public int HealthRecordId { get; set; }
        public ClinicalTreatment(int id, DateTime startTime, DateTime endTime, Room room, HealthRecord healthRecord)
        {
            Id = id;
            dateRange = new DateRange(startTime, endTime);
            Room = room;
            HealthRecord = healthRecord;
        }

        public ClinicalTreatment(int id, DateTime startTime, DateTime endTime, int roomId, int healthRecordId)
        {
            this.Id = id;
            this.dateRange = new DateRange(startTime, endTime);
            this.RoomId = roomId;
            this.HealthRecordId = healthRecordId;
        }

        public ClinicalTreatment()
        {
            dateRange = new DateRange();
        }
    }
}