/***********************************************************************
 * Module:  AppointmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.AppointmentRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;

namespace Hospital.Repository
{
   public class AppointmentRepository
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
        public Hospital.Model.Appointment GetAppointmentById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReservedAppointments()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllReservedAppointmentsWeekly()
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllAppointmentsByDoctorId(int doctorId)
      {
         // TODO: implement
         return null;
      }
      
      public System.Collections.ArrayList GetAllByAppointmentsPatientId(int patientId)
      {
         // TODO: implement
         return null;
      }
      
      public Boolean DeleteAppointmentById(int id)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "delete from appointment where id = :id";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            int a = cmd.ExecuteNonQuery();
            return true;
      }
      
      public Boolean DeleteAppointmentByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Appointment UpdateAppointmentStartTime(Hospital.Model.Appointment appointment,DateTime startTime)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE APPOINTMENT SET DATE_TIME = :DATE_TIME WHERE ID = :ID";
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = startTime;
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            return null;
      }
      
       public Hospital.Model.Appointment UpdateAppointmentRoom(Hospital.Model.Appointment appointment,Hospital.Model.Room room)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE APPOINTMENT SET ROOOM_ID = :ROOM_ID WHERE ID = :ID";
            cmd.Parameters.Add("ROOM_ID", OracleDbType.Date).Value = room.Id.ToString();
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            return null;
           
        }

      public Hospital.Model.Appointment UpdateAppointmentStatus(Hospital.Model.Appointment appointment,Hospital.Model.AppointmentStatus appointmentStatus)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE APPOINTMENT SET APPOINTMENT_STATUS = :APPOINTMENT_STATUS WHERE ID = :ID";
            cmd.Parameters.Add("APPOINTMENT_STATUS", OracleDbType.Date).Value = appointmentStatus.ToString();
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = appointment.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            
            return null;
        }

      public Hospital.Model.Appointment NewAppointment(Hospital.Model.Appointment appointment)
      {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO APPOINTMENT (ID,DURATIONS_MINS,DATE_TIME,ROOM_ID,PATIENT_ID,DOCTOR_ID,APPTYPE_ID,APPSTAT_ID) VALUES (:ID,30,:DATE_TIME,:ROOM_ID,:PATIENT_ID,:DOCTOR_ID,1,1)";

            int id = GetLastId();
            int next_id = id + 1;
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = next_id.ToString();
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = appointment.StartTime;
            cmd.Parameters.Add("ROOM_ID", OracleDbType.Int32).Value = appointment.room.Id.ToString();
            cmd.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = appointment.patient.Id.ToString();
            cmd.Parameters.Add("DOCTOR_ID", OracleDbType.Int32).Value = appointment.doctor.Id.ToString();
            int a = cmd.ExecuteNonQuery();
            return appointment;
      }
      
      public int GetLastId()
      {
            setConnection();
            int id = 0;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM APPOINTMENT";
            OracleDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));
            return 0;
      }
   
   }
}