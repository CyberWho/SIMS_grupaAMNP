using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***********************************************************************
 * Module:  TimeSlotRepository.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Repository.TimeSlotRepository
 ***********************************************************************/

namespace Hospital.Repository
{
    public class TimeSlotRepository
    {
        public Hospital.Model.TimeSlot GetTimeSlotById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Array GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public System.Array GetAllByDateRangeAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteSlotByWorkhoursId(int workHoursId)
        {
            // TODO: implement
            return false;
        }

        public System.Array NewTimeSlots(int workHoursId)
        {
            // TODO: implement
            return null;
        }

        public Boolean TakeTimeSlot(Hospital.Model.TimeSlot timeSlot)
        {
            // TODO: implement
            return false;
        }

        public Boolean FreeTimeSlot(Hospital.Model.TimeSlot timeSlot)
        {
            // TODO: implement
            return false;
        }

    }
}
