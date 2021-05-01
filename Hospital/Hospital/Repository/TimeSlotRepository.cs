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
        OracleConnection connection = null;
        DoctorRepository doctorRepository = new DoctorRepository();
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public TimeSlot GetTimeSlotById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
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

            connection.Close();
            connection.Dispose();

            return timeSlot;
        }

        public ObservableCollection<TimeSlot> GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetTimeSlotsByDatesAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";

            command.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            OracleDataReader reader = command.ExecuteReader();
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

            connection.Close();
            connection.Dispose();

            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetAllFreeTimeSlotsByDates(DateTime startTime, DateTime endTime)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.SPEC_ID=1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            OracleDataReader reader = command.ExecuteReader();
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

            connection.Close();
            connection.Dispose();

            return timeSlots;

        }

        public ObservableCollection<TimeSlot> GetlAllFreeTimeSlotsBySpecializationId(int specializationId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "SELECT * FROM time_slot, work_hours, doctor WHERE time_slot.free = 1 AND time_slot.work_hours_id = work_hours.id AND work_hours.doctor_id = doctor.id AND doctor.spec_id = :specialization_id";
            OracleDataReader reader = command.ExecuteReader();

            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();

            while (reader.Read())
            {
                int time_slot_id = int.Parse(reader.GetString(0));
                DateTime start_time = DateTime.Parse(reader.GetString(2));
                int doctor_id = int.Parse(reader.GetString(8));


                TimeSlot ts = new TimeSlot();
                ts.Id = time_slot_id;
                ts.StartTime = start_time;

                timeSlots.Add(ts);
            }

            ObservableCollection<TimeSlot> sortedTimeSlots =
                new ObservableCollection<TimeSlot>(timeSlots.OrderBy(ts => ts));

            connection.Close();
            connection.Dispose();

            return sortedTimeSlots;

        }

        public ObservableCollection<TimeSlot> GetAllFreeTimeSlotsByDoctorId(int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();

            OracleDataReader reader = command.ExecuteReader();
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

            connection.Close();
            connection.Dispose();

            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            setConnection();
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = connection.CreateCommand();
            DateTime lastDate = date.AddHours(48);
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM WORK_HOURS,TIME_SLOT WHERE TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.START_TIME BETWEEN :start_date AND :last_date";
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            command.Parameters.Add("start_date", OracleDbType.Date).Value = date;
            command.Parameters.Add("last_date", OracleDbType.Date).Value = lastDate;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TimeSlot timeSlot = new TimeSlot();
                timeSlot.Id = reader.GetInt32(5);
                timeSlot.StartTime = reader.GetDateTime(7);
                timeSlots.Add(timeSlot);
            }

            connection.Close();
            connection.Dispose();

            return timeSlots;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date, int doctorId)
        {
            setConnection();
            TimeSlot timeSlot = new TimeSlot();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM WORK_HOURS,TIME_SLOT WHERE TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.START_TIME = :start_time";
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            command.Parameters.Add("start_time", OracleDbType.Date).Value = date;
            OracleDataReader reader = command.ExecuteReader();
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

            connection.Close();
            connection.Dispose();

            return timeSlot;
        }

        public ObservableCollection<TimeSlot> GetAllByDateRangeAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
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
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE TIME_SLOT SET FREE = 0 WHERE ID = " + timeSlot.Id;

            if (command.ExecuteNonQuery() > 0)
            {

                connection.Close();
                connection.Dispose();

                return true;
            }

            connection.Close();
            connection.Dispose();

            return false;
        }

        public Boolean FreeTimeSlot(TimeSlot timeSlot)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command = connection.CreateCommand();
            command.CommandText = "UPDATE TIME_SLOT SET FREE = 1 WHERE ID = " + timeSlot.Id;

            if (command.ExecuteNonQuery() > 0)
            {

                connection.Close();
                connection.Dispose();

                return true;
            }

            connection.Close();
            connection.Dispose();

            return false;
        }

    }
}