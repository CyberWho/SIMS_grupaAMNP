/***********************************************************************
 * Module:  WorkHoursRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.WorkHoursRepository
 ***********************************************************************/

using System;
using System.Net.WebSockets;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    public class WorkHoursRepository
    {
        private DoctorRepository doctorRepository = new DoctorRepository();

        public WorkHours GetWorkHoursById(int id)
        {

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM work_hours WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int workHours_id = int.Parse(reader.GetString(0));
            DateTime shiftStartTime = reader.GetDateTime(1);
            DateTime shiftEndTime = reader.GetDateTime(2);
            Boolean approved = int.Parse(reader.GetString(3)) == 1 ? true : false;
            int doctor_id = int.Parse(reader.GetString(4));
            Doctor doctor = this.doctorRepository.GetDoctorById(doctor_id);

            WorkHours workHours = new
                WorkHours(
                    id,
                    shiftStartTime,
                    shiftEndTime,
                    approved,
                    doctor
                );


            
            
            return workHours;
        }

        public System.Collections.ArrayList GetAllWorkHoursByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllApprovedWorkHoursByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteWorkHoursById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllWorkHoursByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.WorkHours UpdateWorkHours(Hospital.Model.WorkHours workHours)
        {
            // TODO: implement
            return null;
        }

        public WorkHours NewWorkHours(WorkHours workHours)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
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

        public System.Collections.ArrayList GetAllPendingWorkHoursByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}