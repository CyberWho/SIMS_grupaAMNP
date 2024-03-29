﻿using System;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Windows.Navigation;
using Hospital.IRepository;
using Hospital.Repository;


/***********************************************************************
 * Module:  TimeSlotService.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Service.TimeSlotService
 ***********************************************************************/


namespace Hospital.Service
{
    public class TimeSlotService
    {
        // edge case time is :30 maybe

        private IAppointmentRepo<Appointment> appointmentRepository;
        private IWorkHoursRepo<WorkHours> workHoursRepository;
        private IDoctorRepo<Doctor> doctorRepository;
        private ITimeSlotRepo<TimeSlot> timeSlotRepository;
        private IFreeDaysRepo<FreeDays> freeDaysRepository;

        public TimeSlotService(ITimeSlotRepo<TimeSlot> iTimeSlotRepo,IAppointmentRepo<Appointment> iAppointmentRepo,IWorkHoursRepo<WorkHours> iWorkHoursRepo,IFreeDaysRepo<FreeDays> iFreeDaysRepo,IDoctorRepo<Doctor> iDoctorRepo)
        {
            timeSlotRepository = iTimeSlotRepo;
            appointmentRepository = iAppointmentRepo;
            workHoursRepository = iWorkHoursRepo;
            freeDaysRepository = iFreeDaysRepo;
            doctorRepository = iDoctorRepo;
        }
        public void generateTimeSlots()
        {
            timeSlotRepository.GenerateTimeSlots();
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetById(id);
            return timeSlot;
        }

        public Appointment MoveReservedAppointment(int timeSlot_id)
        {
            DateTime now = fix_time();
            
            // testing
            // now = new DateTime(2021, 5, 4, 12, 0, 0);
            
            TimeSlot timeSlot = this.timeSlotRepository.GetById(timeSlot_id);
            int workHours_id = timeSlot.workHours_id;
            WorkHours workHours = this.workHoursRepository.GetById(workHours_id);
            int doctor_id = workHours.doctor.Id;
            Doctor doctor = this.doctorRepository.GetById(doctor_id);

            // now = new DateTime(2021, 4, 20, 9, 0, 0);

            Appointment appointment = this.appointmentRepository.GetByDoctorIdAndTime(doctor, now);

            appointment = this.appointmentRepository.UpdateStartTime(appointment, timeSlot.StartTime);

            if (appointment != null)
            {
                appointment.StartTime = now;
                return appointment;
            }

            return null;
        }

        public ObservableCollection<TimeSlot> GetlAllFreeTimeSlotsBySpecializationId(int specializationId, int patient_id)
        {
            ObservableCollection<TimeSlot> timeSlots = this.timeSlotRepository.GetAllFreeBySpecializationId(specializationId);
            // special case, if the time slot isn't taken, return type will be the same, only it will contain only one element
            ObservableCollection<TimeSlot> timeSlot = new ObservableCollection<TimeSlot>();
            DateTime now = fix_time();


            // testing
            // now = new DateTime(2021, 5, 4, 12, 0, 0);

            // testing purposes
            // this time is used when there is a free timeslot that that is right now
            // now = new DateTime(2021, 4, 20, 9, 0, 0);

            // this time is used when the current timeslot is occupied
            // now = new DateTime();

            foreach (TimeSlot ts in timeSlots) 
            {
                if (ts.StartTime.Equals(now))
                {
                    WorkHours workHours = this.workHoursRepository.GetById(ts.workHours_id);
                    Doctor doctor = workHours.doctor;
                    
                    Appointment appointment = new Appointment();
                    appointment.StartTime = now;
                    appointment.doctor = doctor;
                    appointment.Room_Id = doctor.room_id;
                    appointment.Doctor_Id = doctor.Id;
                    appointment.Patient_Id = patient_id;

                    this.appointmentRepository.Add(appointment); 
                    
                    timeSlot.Add(ts);

                    return timeSlot;
                }

            }

            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetlAllFreeTimeSlotsBySpecializationIdAfterCurrentTime(
            int specializationId, int patientId)
        {
            DateTime now = fix_time();

            // testing
            // now = new DateTime(2021, 5, 4, 12, 0, 0);

            ObservableCollection<TimeSlot> timeSlots = this.timeSlotRepository.GetAllFreeBySpecializationIdAfterCurrentTime(specializationId, now);
            // special case, if the time slot isn't taken, return type will be the same, only it will contain only one element
            ObservableCollection<TimeSlot> timeSlot = new ObservableCollection<TimeSlot>();

            foreach (TimeSlot ts in timeSlots)
            {
                if (isDateEqual(ts.StartTime, now))
                // if (/*ts.StartTime.Equals(now)*/ DateTime.Compare(now, ts.StartTime) == 0)
                {
                    WorkHours workHours = this.workHoursRepository.GetById(ts.workHours_id);
                    Doctor doctor = workHours.doctor;

                    Appointment appointment = new Appointment();
                    appointment.StartTime = now;
                    appointment.doctor = doctor;
                    appointment.Room_Id = doctor.room_id;
                    appointment.Doctor_Id = doctor.Id;
                    appointment.Patient_Id = patientId;

                    this.appointmentRepository.Add(appointment);

                    timeSlot.Add(ts);

                    return timeSlot;
                }

            }

            return timeSlots;
        }

        private bool isDateEqual(DateTime date1, DateTime date2)
        {
            if (date1.Day != date2.Day || date1.Month != date2.Month || date1.Year != date2.Year || date1.Hour != date2.Hour || date1.Minute != date2.Minute || date1.Second != date2.Second)
            {
                return false;
            }

            return true;
        }

        private DateTime fix_time()
        {
            // TODO: fix this jumbo mess 

            DateTime now = DateTime.Now;
            string time = now.ToString();
            string[] split1 = time.Split(' ');
            string[] split2 = split1[1].Split(':');
            int minutes = int.Parse(split2[1]);
            int seconds = int.Parse(split2[2]);

            TimeSpan ts;

            // if the time right now is less than :30, then add up to :30
            if (now.Minute <= 30)
            {
                ts = new TimeSpan(0, 30 - minutes, -seconds);
            }
            // else, time is between :30 and :00, and so appointment must be reserved in hour+1:00 slot
            else
            {
                ts = new TimeSpan(0, 60 - minutes, -seconds);
            }

            now = now.Add(ts);

            return now;
        }



        public System.Array GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }
        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotRepository.GetAllFreeForNext48HoursByDateAndDoctorId(date, doctorId);
            return timeSlots;
        }

        public Array GetAllByDateRangeAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetAllFreeTimeSlotsByDoctorId(int doctorId)
        {
            return timeSlotRepository.GetAllFreeByDoctorId(doctorId);
        }
        public ObservableCollection<TimeSlot> GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(DateTime startTime,DateTime endTime,int doctorId,int priority)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotRepository.GetAllByDatesAndDoctorId(startTime, endTime, doctorId);

            if (timeSlots.Count == 0)
            {
                if (priority == 0)
                {
                    timeSlots = timeSlotRepository.GetAllFreeByDoctorId(doctorId);
                } 
                else
                {
                    timeSlots = timeSlotRepository.GetAllFreeByDates(startTime, endTime);
                }
            }

            // marko kt5

            return this.reduceTimeSlots(timeSlots, doctorId);
        }

        private ObservableCollection<TimeSlot> reduceTimeSlots(ObservableCollection<TimeSlot> timeSlots, int doctor_id)
        {
            ObservableCollection<FreeDays> freeDays = this.freeDaysRepository.GetAllByDoctorId(doctor_id);
            ObservableCollection<TimeSlot> reducedTimeSlots = new ObservableCollection<TimeSlot>();

            bool flag = false;

            foreach (TimeSlot ts in timeSlots)
            {
                foreach (FreeDays fd in freeDays)
                {
                    DateRange dr = new DateRange(ts.StartTime, ts.StartTime.AddMinutes(30));

                    if (WithinDateRange(fd.dateRange, dr))
                    {
                        flag = true;
                    }
                }

                if (!flag)
                {
                    reducedTimeSlots.Add(ts);
                }

                flag = false;
            }

            return reducedTimeSlots;
        }

        private Boolean WithinDateRange(DateRange outer, DateRange inner)
        {
            if (inner.StartTime > outer.StartTime && inner.EndTime < outer.EndTime) return true;
            return false;
        }

        // marko kt5 kraj

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

        public Array NewTimeSlots(int workHoursId)
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

    }
}