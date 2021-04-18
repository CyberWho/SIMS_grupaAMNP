using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***********************************************************************
 * Module:  TimeSlot.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.TimeSlot
 ***********************************************************************/
namespace Hospital.Model
{
    public class TimeSlot
    {
        public int Id;
        public Boolean Free;
        public DateTime StartTime;

        public TimeSlot()
        {

        }
        public TimeSlot(int id,Boolean free,DateTime startTime)
        {
            this.Id = id;
            this.Free = free;
            this.StartTime = startTime;
        }

    }
}