using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private WorkHoursRepository workHoursRepository = new WorkHoursRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();


        public TimeSlot GetTimeSlotById(int id)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot = timeSlotRepository.GetTimeSlotById(id);
            return timeSlot;
        }

        public Appointment MoveReservedAppointment(int timeSlot_id)
        {
            DateTime now = fix_time();
            TimeSlot timeSlot = this.timeSlotRepository.GetTimeSlotById(timeSlot_id);
            int workHours_id = timeSlot.workHours_id;
            WorkHours workHours = this.workHoursRepository.GetWorkHoursById(workHours_id);
            int doctor_id = workHours.doctor.Id;
            Doctor doctor = this.doctorRepository.GetDoctorById(doctor_id);

            Appointment appointment = this.appointmentRepository.GetAppointmentByDoctorIdAndTime(doctor, now);

            appointment = this.appointmentRepository.UpdateAppointmentStartTime(appointment, timeSlot.StartTime);

            if (appointment != null)
            {
                return appointment;
            }

            return null;
        }


        public ObservableCollection<TimeSlot> GetlAllFreeTimeSlotsBySpecializationId(int specializationId, int patient_id)
        {
            ObservableCollection<TimeSlot> timeSlots = this.timeSlotRepository.GetlAllFreeTimeSlotsBySpecializationId(specializationId);
            // special case, if the time slot isn't taken, return type will be the same, only it will contain only one element
            ObservableCollection<TimeSlot> timeSlot = new ObservableCollection<TimeSlot>();
            DateTime now = fix_time();
            
            // testing purposes
            //now = new DateTime(2021, 4, 21, 9, 0, 0);

            foreach (TimeSlot ts in timeSlots) 
            {
                if (ts.StartTime.Equals(now))
                {
                    WorkHours workHours = this.workHoursRepository.GetWorkHoursById(ts.workHours_id);
                    Doctor doctor = workHours.doctor;
                    
                    Appointment appointment = new Appointment();
                    appointment.StartTime = now;
                    appointment.doctor = doctor;
                    appointment.Room_Id = doctor.room_id;
                    appointment.Doctor_Id = doctor.Id;
                    appointment.Patient_Id = patient_id;

                    this.appointmentRepository.NewAppointment(appointment); 
                    
                    timeSlot.Add(ts);

                    return timeSlot;
                }

            }

            return timeSlots;
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
            timeSlots = timeSlotRepository.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(date, doctorId);
            return timeSlots;
        }

        public System.Array GetAllByDateRangeAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetTimeSlotRecomendationsByDatesAndDoctorIdAndPriority(DateTime startTime,DateTime endTime,int doctorId,int priority)
        {
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            timeSlots = timeSlotRepository.GetTimeSlotsByDatesAndDoctorId(startTime, endTime, doctorId);
            if(timeSlots.Count == 0)
            {
                if(priority == 0)
                {
                    timeSlots = timeSlotRepository.GetAllFreeTimeSlotsByDoctorId(doctorId);
                } else
                {
                    timeSlots = timeSlotRepository.GetAllFreeTimeSlotsByDates(startTime, endTime);
                }
            }
            return timeSlots;
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