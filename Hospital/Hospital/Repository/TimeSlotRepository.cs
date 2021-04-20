using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;

/***********************************************************************
 * Module:  TimeSlotRepository.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Repository.TimeSlotRepository
 ***********************************************************************/

namespace Hospital.Repository
{
    public class TimeSlotRepository
    {
        OracleConnection con = null;
        DoctorRepository doctorRepository = new DoctorRepository();
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public Hospital.Model.TimeSlot GetTimeSlotById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TIME_SLOT WHERE ID = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            TimeSlot timeSlot = new TimeSlot();
            timeSlot.Id = reader.GetInt32(0);
            int free = reader.GetInt32(1);
            if (free == 0)
            {
                timeSlot.Free = false;
            }
            else
            {
                timeSlot.Free = true;
            }
            timeSlot.StartTime = reader.GetDateTime(2);
            con.Close();
            return timeSlot;
        }

        public System.Array GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetTimeSlotsByDatesAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";

            cmd.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            cmd.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                TimeSlot timeSlot = new TimeSlot();
                timeSlot.Id = reader.GetInt32(0);
                int free = reader.GetInt32(1);
                if (free == 0)
                {
                    timeSlot.Free = false;
                }
                else
                {
                    timeSlot.Free = true;
                }
                timeSlot.StartTime = reader.GetDateTime(2);
                WorkHours workHours = new WorkHours();
                workHours.Id = reader.GetInt32(4);
                workHours.ShiftStart = reader.GetDateTime(5);
                workHours.ShiftEnd = reader.GetDateTime(6);
                int approved = reader.GetInt32(7);
                if (approved == 0)
                {
                    workHours.Approved = false;
                }
                else
                {
                    workHours.Approved = true;
                }

                Doctor doctor = new Doctor();
                doctor = doctorRepository.GetWorkHoursDoctorById(doctorId);
                workHours.doctor = doctor;
                timeSlot.WorkHours = workHours;
                timeSlots.Add(timeSlot);

            }
            con.Close();
            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetAllFreeTimeSlotsByDates(DateTime startTime, DateTime endTime)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.SPEC_ID=1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            cmd.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            cmd.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TimeSlot timeSlot = new TimeSlot();
                int timeSlotId = reader.GetInt32(0);
                timeSlot = GetTimeSlotById(timeSlotId);
                WorkHours workHours = new WorkHours();
                workHours.Id = reader.GetInt32(4);
                workHours.ShiftStart = reader.GetDateTime(5);
                workHours.ShiftEnd = reader.GetDateTime(6);
                int approved = reader.GetInt32(7);
                if (approved == 0)
                {
                    workHours.Approved = false;
                }
                else
                {
                    workHours.Approved = true;
                }
                int doctorId = reader.GetInt32(8);
                Doctor doctor = new Doctor();
                doctor = doctorRepository.GetWorkHoursDoctorById(doctorId);
                workHours.doctor = doctor;
                timeSlot.WorkHours = workHours;
                timeSlots.Add(timeSlot);
            }
            return timeSlots;

        }

        public ObservableCollection<TimeSlot> GetAllFreeTimeSlotsByDoctorId(int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TimeSlot timeSlot = new TimeSlot();
                int timeSlotId = reader.GetInt32(0);
                timeSlot = GetTimeSlotById(timeSlotId);
                WorkHours workHours = new WorkHours();
                workHours.Id = reader.GetInt32(4);
                workHours.ShiftStart = reader.GetDateTime(5);
                workHours.ShiftEnd = reader.GetDateTime(6);
                int approved = reader.GetInt32(7);
                if (approved == 0)
                {
                    workHours.Approved = false;
                }
                else
                {
                    workHours.Approved = true;
                }

                Doctor doctor = new Doctor();
                doctor = doctorRepository.GetWorkHoursDoctorById(doctorId);
                workHours.doctor = doctor;
                timeSlot.WorkHours = workHours;
                timeSlots.Add(timeSlot);
            }
            con.Close();
            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            DateTime lastDate = date.AddHours(48);
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM WORK_HOURS,TIME_SLOT WHERE TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.START_TIME BETWEEN :start_date AND :last_date";
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            cmd.Parameters.Add("start_date", OracleDbType.Date).Value = date;
            cmd.Parameters.Add("last_date", OracleDbType.Date).Value = lastDate;
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TimeSlot timeSlot = new TimeSlot();
                timeSlot.Id = reader.GetInt32(5);
                timeSlot.StartTime = reader.GetDateTime(7);
                timeSlots.Add(timeSlot);
            }
            con.Close();
            return timeSlots;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date, int doctorId)
        {
            setConnection();
            TimeSlot timeSlot = new TimeSlot();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM WORK_HOURS,TIME_SLOT WHERE TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.START_TIME = :start_time";
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            cmd.Parameters.Add("start_time", OracleDbType.Date).Value = date;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            timeSlot.Id = reader.GetInt32(5);
            int free = reader.GetInt32(6);
            if (free == 0)
            {
                timeSlot.Free = false;
            }
            else
            {
                timeSlot.Free = true;
            }
            timeSlot.StartTime = reader.GetDateTime(7);
            con.Close();
            return timeSlot;
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
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE TIME_SLOT SET FREE = 0 WHERE ID = " + timeSlot.Id;
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

        public Boolean FreeTimeSlot(Hospital.Model.TimeSlot timeSlot)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE TIME_SLOT SET FREE = 1 WHERE ID = " + timeSlot.Id;
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return true;
        }

    }
}