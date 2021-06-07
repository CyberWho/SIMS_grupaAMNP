/***********************************************************************
 * Module:  WorkHoursRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.WorkHoursRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using Hospital.IRepository;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class WorkHoursRepository : IWorkHoursRepo<WorkHours>
    {
        private DoctorRepository doctorRepository = new DoctorRepository();

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


        public WorkHours GetById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM work_hours WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int workHours_id = int.Parse(reader.GetString(0));
            DateTime shiftStartTime = reader.GetDateTime(1);
            DateTime shiftEndTime = reader.GetDateTime(2);
            Boolean approved = int.Parse(reader.GetString(3)) == 1 ? true : false;
            int doctor_id = int.Parse(reader.GetString(4));
            Doctor doctor = this.doctorRepository.GetById(doctor_id);

            WorkHours workHours = new 
                WorkHours(  
                    id,
                    shiftStartTime,
                    shiftEndTime,
                    approved,
                    doctor
                );


            connection.Close();
            connection.Dispose();
            return workHours;
        }

        public ObservableCollection<WorkHours> GetAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<WorkHours> GetAllApprovedByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.WorkHours Update(Hospital.Model.WorkHours workHours)
        {
            // TODO: implement
            return null;
        }

        public WorkHours Add(WorkHours workHours)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO work_hours (shift_start, shift_end, approved, doctor_id) VALUES (:shift_start, :shift_end, :approved, :doctor_id)";

            // samo se menjaju dan i mesec
            DateTime start = new DateTime(2021, 5, 26, 8, 0, 0);
            DateTime end = new DateTime(2021, 5, 26, 16, 0, 0);

            command.Parameters.Add(":shift_start", OracleDbType.Date).Value = start;
            command.Parameters.Add("shift_end", OracleDbType.Date).Value = end;
            command.Parameters.Add("approved", OracleDbType.Int32).Value = 1;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = 6;

            if (command.ExecuteNonQuery() > 0)
            {
                return null;
            }


            return null;
        }

        public ObservableCollection<WorkHours> GetAllPendingByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

        public ObservableCollection<WorkHours> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}