using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using System.Collections.ObjectModel;


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
            //TODO: implement
            return null;
        }

        public System.Array GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }
        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotRepository.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(date, doctorId);
            return timeSlots;
        }

        public System.Array GetAllByDateRangeAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date,int doctorId)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetAppointmentTimeSlotByDateAndDoctorId(date, doctorId);
            return timeSlot;
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
            timeSlotRepository.TakeTimeSlot(timeSlot);
            return true;
        }

        public Boolean FreeTimeSlot(TimeSlot timeSlot)
        {
            timeSlotRepository.FreeTimeSlot(timeSlot);
            return true;
        }

        public Hospital.Repository.TimeSlotRepository timeSlotRepository = new Repository.TimeSlotRepository();

    }
}