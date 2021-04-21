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
        public int Id { get; set; }
        public Boolean Free { get; set; }
        public DateTime StartTime { get; set; }

    }
}