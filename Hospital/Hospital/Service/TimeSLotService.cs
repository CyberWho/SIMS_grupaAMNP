using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

/***********************************************************************
 * Module:  TimeSlotService.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Service.TimeSlotService
 ***********************************************************************/


namespace Hospital.Service
{
    public class TimeSlotService
    {
        public TimeSlot GetTimeSlotById(int id)
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

        public Boolean TakeTimeSlot(TimeSlot timeSlot)
        {
            // TODO: implement
            return false;
        }

        public Boolean FreeTimeSlot(TimeSlot timeSlot)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Repository.TimeSlotRepository timeSlotRepository;

    }
}