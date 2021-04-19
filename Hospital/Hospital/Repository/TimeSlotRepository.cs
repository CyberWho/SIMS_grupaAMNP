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
            // TODO: implement
            return null;
        }

        public System.Array GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date,int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            DateTime lastDate = date.AddHours(48);
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM WORK_HOURS,TIME_SLOT WHERE TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.START_TIME BETWEEN :date AND :last_date";
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            cmd.Parameters.Add("date", OracleDbType.Date).Value = date;
            cmd.Parameters.Add("last_date", OracleDbType.Date).Value = lastDate;
            OracleDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                TimeSlot timeSlot = new TimeSlot();
                timeSlot.Id = reader.GetInt32(5);
                timeSlot.StartTime = reader.GetDateTime(7);
                timeSlots.Add(timeSlot);
            }
            con.Close();
            return timeSlots;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date,int doctorId)
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
            if(free == 0)
            {
                timeSlot.Free = false;
            } else
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
