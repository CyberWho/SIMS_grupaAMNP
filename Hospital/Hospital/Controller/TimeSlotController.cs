using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using System.Collections.ObjectModel;

/***********************************************************************
 * Module:  TimeSlotController.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Controller.TimeSlotController
 ***********************************************************************/


namespace Hospital.Controller
{
    public class TimeSlotController
    {
        public TimeSlot GetTimeSlotById(int id)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotService.GetTimeSlotById(id);
            return timeSlot;
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
        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotService.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(date, doctorId);
            return timeSlots;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date,int doctorId)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotService.GetAppointmentTimeSlotByDateAndDoctorId(date, doctorId);
            return timeSlot;
        }

        public Boolean DeleteSlotByWorkhoursId(int workHoursId)
        {
            // TODO: implement
            return false;
        }

        public ObservableCollection<TimeSlot> GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(DateTime startTime, DateTime endTime, int doctorId, int priority)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotService.GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(startTime, endTime, doctorId, priority);
            return timeSlots;
        }
        public System.Array NewTimeSlots(int workHoursId)
        {
            // TODO: implement
            return null;
        }

        public Boolean TakeTimeSlot(TimeSlot timeSlot)
        {
            timeSlotService.TakeTimeSlot(timeSlot);
            return true;
        }

        public Boolean FreeTimeSlot(TimeSlot timeSlot)
        {
            timeSlotService.FreeTimeSlot(timeSlot);
            return true;
        }

        public Hospital.Service.TimeSlotService timeSlotService = new Service.TimeSlotService();

    }
}