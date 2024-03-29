﻿using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Linq;
using Hospital.IRepository;

/***********************************************************************
 * Module:  TimeSlotRepository.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Repository.TimeSlotRepository
 ***********************************************************************/

namespace Hospital.Repository
{
    public class TimeSlotRepository : ITimeSlotRepo<TimeSlot>
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            Globals.globalConnection = new OracleConnection(conString);
            try
            {
                Globals.globalConnection.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public TimeSlot GetById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
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
            timeSlot.workHours_id = int.Parse(reader.GetString(3));

            
            

            return timeSlot;
        }

        public ObservableCollection<TimeSlot> GetAllByDateAndDoctorId(DateTime date, int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<TimeSlot> GetAllByDatesAndDoctorId(DateTime startTime, DateTime endTime, int doctorId)
        {
            
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";

            command.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                TimeSlot timeSlot = ParseTimeSlot(reader); 
                timeSlots.Add(timeSlot);

            }

            
            

            return timeSlots;
        }

        private TimeSlot ParseTimeSlot(OracleDataReader reader)
        {
            TimeSlot timeSlot = new TimeSlot();
            timeSlot.Id = reader.GetInt32(0);
            if (reader.GetInt32(1) == 0)
            {
                timeSlot.Free = false;
            }
            else
            {
                timeSlot.Free = true;
            }

            timeSlot.StartTime = reader.GetDateTime(2);
            timeSlot.WorkHours = new WorkHoursRepository().GetById(reader.GetInt32(3));
            timeSlot.workHours_id = timeSlot.WorkHours.Id;
            return timeSlot;
        }

        public ObservableCollection<TimeSlot> GetAllFreeByDates(DateTime startTime, DateTime endTime)
        {
            
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND TIME_SLOT.START_TIME BETWEEN :start_time AND :end_time AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.SPEC_ID=1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("start_time", OracleDbType.Date).Value = startTime;
            command.Parameters.Add("end_time", OracleDbType.Date).Value = endTime;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var timeSlot = ParseTimeSlot(reader);
                timeSlots.Add(timeSlot);
            }

            
            

            return timeSlots;

        }


        public ObservableCollection<TimeSlot> GetAllFreeBySpecializationId(int specializationId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText =
                "SELECT * FROM time_slot, work_hours, doctor WHERE time_slot.free = 1 AND time_slot.work_hours_id = work_hours.id AND work_hours.doctor_id = doctor.id AND doctor.spec_id = :specialization_id";
            command.Parameters.Add("specialization_id", OracleDbType.Int32).Value = specializationId;

            OracleDataReader reader = command.ExecuteReader();

            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();

            while (reader.Read())
            {
                int time_slot_id = int.Parse(reader.GetString(0));
                DateTime start_time = reader.GetDateTime(2);
                int doctor_id = int.Parse(reader.GetString(8));
                int workHours_id = int.Parse(reader.GetString(3));


                TimeSlot ts = new TimeSlot();
                ts.Id = time_slot_id;
                ts.StartTime = start_time;
                ts.workHours_id = workHours_id;

                timeSlots.Add(ts);
            }

            ObservableCollection<TimeSlot> sortedTimeSlots =
                new ObservableCollection<TimeSlot>(from i in timeSlots orderby i.StartTime select i);

            
            

            return sortedTimeSlots;
        }

        public ObservableCollection<TimeSlot> GetAllFreeBySpecializationIdAfterCurrentTime(int specializationId, DateTime now)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText =
                "SELECT * FROM time_slot, work_hours, doctor WHERE time_slot.free = 1 AND time_slot.work_hours_id = work_hours.id AND work_hours.doctor_id = doctor.id AND doctor.spec_id = :specialization_id AND time_slot.start_time >= :start_time";
            command.Parameters.Add("specialization_id", OracleDbType.Int32).Value = specializationId;
            command.Parameters.Add("start_time", OracleDbType.Date).Value = now;

            OracleDataReader reader = command.ExecuteReader();

            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            
            while (reader.Read())
            {
                int time_slot_id = int.Parse(reader.GetString(0));
                DateTime start_time = reader.GetDateTime(2);
                int doctor_id = int.Parse(reader.GetString(8));
                int workHours_id = int.Parse(reader.GetString(3));


                TimeSlot ts = new TimeSlot();
                ts.Id = time_slot_id;
                ts.StartTime = start_time;
                ts.workHours_id = workHours_id;

                timeSlots.Add(ts);
            }

            ObservableCollection<TimeSlot> sortedTimeSlots =
                new ObservableCollection<TimeSlot>(from i in timeSlots orderby i.StartTime select i);

            
            

            return sortedTimeSlots;
        }


        public ObservableCollection<TimeSlot> GetAllFreeByDoctorId(int doctorId)
        {
            
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM TIME_SLOT,WORK_HOURS,DOCTOR,EMPLOYEE,USERS WHERE TIME_SLOT.FREE = 1 AND WORK_HOURS.DOCTOR_ID = :doctor_id AND TIME_SLOT.WORK_HOURS_ID = WORK_HOURS.ID AND WORK_HOURS.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctorId.ToString();

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TimeSlot timeSlot = ParseTimeSlot(reader);
                
                timeSlots.Add(timeSlot);
            }

            
            

            return timeSlots;
        }

        public ObservableCollection<TimeSlot> GetAllFreeForNext48HoursByDateAndDoctorId(DateTime date, int doctorId)
        {
            
            ObservableCollection<TimeSlot> timeSlots = new ObservableCollection<TimeSlot>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            DateTime lastDate = date.AddHours(48);
            command = Globals.globalConnection.CreateCommand();
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

            
            

            return timeSlots;
        }

        public TimeSlot GetAppointmentTimeSlotByDateAndDoctorId(DateTime date, int doctorId)
        {
            
            TimeSlot timeSlot = new TimeSlot();
            OracleCommand command = Globals.globalConnection.CreateCommand();
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

            
            

            return timeSlot;
        }


        // not necessary 
        public Boolean DeleteByWorkhoursId(int workHoursId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            workHoursId = 56;
            command.CommandText = "DELETE FROM time_slot WHERE work_hours_id = " + workHoursId;


            return false;
        }

        public void GenerateTimeSlots()
        {
            //TimeSlot timeSlot = new TimeSlot();
            //timeSlot.StartTime = new DateTime(2021, 5, 4, 21, 0, 0);
            //timeSlot.workHours_id = 57;
            //timeSlot.Free = true;
            //New(timeSlot);

            TimeSlot timeSlot = new TimeSlot();

            // month i day se menjaju
            DateTime dateTime = new DateTime(2021, 5, 26, 8, 0, 0);
            TimeSpan timeSpan = new TimeSpan(0, 30, 0);

            for (int j = 0; j < 17; j++)
            {
                timeSlot.Free = true;
                timeSlot.StartTime = dateTime;

                // work_hours_id se menja
                timeSlot.workHours_id = 122;

                Add(timeSlot);

                dateTime = dateTime.Add(timeSpan);
            }


        }

        public TimeSlot Add(TimeSlot timeSlot)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "INSERT INTO time_slot (free, start_time, work_hours_id) VALUES (:free, :start_time, :work_hours_id)";

            Boolean free = timeSlot.Free;
            DateTime start_time = timeSlot.StartTime;
            int work_hours_id = timeSlot.workHours_id;

            command.Parameters.Add("free", OracleDbType.Int32).Value = free;
            command.Parameters.Add("start_time", OracleDbType.Date).Value = start_time;
            command.Parameters.Add("work_hours_id", OracleDbType.Int32).Value = work_hours_id;

            if (command.ExecuteNonQuery() > 0)
            {
                return timeSlot;
            }

            return null;
        }


        public Boolean TakeTimeSlot(TimeSlot timeSlot)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE TIME_SLOT SET FREE = 0 WHERE ID = " + timeSlot.Id;

            if (command.ExecuteNonQuery() > 0)
            {

                
                

                return true;
            }

            
            

            return false;
        }

        public Boolean FreeTimeSlot(TimeSlot timeSlot)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE TIME_SLOT SET FREE = 1 WHERE ID = " + timeSlot.Id;

            if (command.ExecuteNonQuery() > 0)
            {

                
                

                return true;
            }

            
            

            return false;
        }

        public ObservableCollection<TimeSlot> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public TimeSlot Update(TimeSlot t)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }
    }
}