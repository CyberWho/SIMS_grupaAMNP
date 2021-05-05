using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

/***********************************************************************
 * Module:  TimeSlot.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.TimeSlot
 ***********************************************************************/
namespace Hospital.Model
{
    public class TimeSlot : IComparable 
    {
        public int Id { get; set; }

        public int workHours_id { get; set; }
        public Boolean Free { get; set; }
        public DateTime StartTime { get; set; }

        public WorkHours WorkHours { get; set; }
        public TimeSlot()
        {

        }
        public TimeSlot(int id, Boolean free, DateTime startTime)
        {
            this.Id = id;
            this.Free = free;
            this.StartTime = startTime;
        }

        public int CompareTo(object obj)
        {
            TimeSlot timeSlot = obj as TimeSlot;

            if (timeSlot == null)
            {
                throw new ArgumentException("Object is not TimeSlot");
            }

            return this.StartTime.CompareTo(timeSlot.StartTime);
        }
    }
}