using System;

namespace Hospital.Model
{
    public class DateRange
    {
        public DateRange(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }

        public DateRange()
        {
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}