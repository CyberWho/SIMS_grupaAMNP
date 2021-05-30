/***********************************************************************
 * Module:  FreeDaysRepository.cs
 * Author:  DELL
 * Purpose: Definition of the Class Hospital.Repository.FreeDaysRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;

namespace Hospital.Repository
{
    public class FreeDaysRepository
    {
        OracleConnection connection = null;
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

        public ObservableCollection<FreeDays> GetFreeDaysByDoctorId(int doctor_id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM free_days WHERE doctor_id = " + doctor_id;
            OracleDataReader reader = command.ExecuteReader();

            ObservableCollection<FreeDays> freeDays = new ObservableCollection<FreeDays>();


            while (reader.Read())
            {
                int id = int.Parse(reader.GetString(0));
                DateTime startDateTime = reader.GetDateTime(1);
                DateTime endDateTime = reader.GetDateTime(2);
                FreeDaysStatus status = SetStatus(int.Parse(reader.GetString(3)));
                string description = reader.GetString(4);

                DateRange dateRange = new DateRange(startDateTime, endDateTime);

                FreeDays freeDay = new FreeDays(id, status, dateRange, description, null, doctor_id);

                freeDays.Add(freeDay);
            }
            
            connection.Close();
            connection.Dispose();
            
            return freeDays;

        }

        public FreeDays GetFreeDaysById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<FreeDays> GetAllPendingFreeDays()
        {
            // TODO: implement
            return null;
        }

        public FreeDays ApproveFreeDays(FreeDays freeDays)
        {
            // TODO: implement
            return null;
        }

        public FreeDays RejectFreeDays(FreeDays freeDays)
        {
            // TODO: implement
            return null;
        }

        public FreeDays AddFreeDays(FreeDays freeDays)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO free_days (id, start_date, end_date, status, description, doctor_id) VALUES (:id, :start_date, :end_date, :status, :description, :doctor_id)";

            int status = GetStatus(freeDays.status);
            int doctor_id = freeDays.doctor_id == 0 ? freeDays.doctor.Id : freeDays.doctor_id;
            freeDays.id = GetLastId() + 1;

            command.Parameters.Add("id", OracleDbType.Int32).Value = freeDays.id;
            command.Parameters.Add("start_date", OracleDbType.Date).Value = freeDays.dateRange.StartTime;
            command.Parameters.Add("end_date", OracleDbType.Date).Value = freeDays.dateRange.EndTime;
            command.Parameters.Add("status", OracleDbType.Int32).Value = status;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = freeDays.description;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = doctor_id;

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                connection.Dispose();

                return freeDays;
            }
            connection.Close();
            connection.Dispose();

            return null;
        }

        private int GetStatus(FreeDaysStatus status)
        {
            switch (status)
            {
                case FreeDaysStatus.APPROVED: return 1;
                case FreeDaysStatus.PENDING:  return 2;
                case FreeDaysStatus.REJECTED: return 3;
                default: return 0;
            }
        }

        private FreeDaysStatus SetStatus(int status)
        {
            switch (status)
            {
                case 1: return FreeDaysStatus.APPROVED;
                case 2: return FreeDaysStatus.PENDING;
                default: return FreeDaysStatus.REJECTED;
            }
        }

        public Boolean DeleteFreeDaysById(int id)
        {
            // TODO: implement
            return false;
        }

        private int GetLastId()
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM free_days";
            OracleDataReader reader = command.ExecuteReader();

            int id = 0;
            if (reader.Read())
            {
                id = int.Parse(reader.GetString(0));
            }

            connection.Close();
            connection.Dispose();

            return id;
        }

    }
}