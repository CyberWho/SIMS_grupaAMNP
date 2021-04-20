/***********************************************************************
 * Module:  ReminderRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReminderRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Hospital.Repository
{
   public class ReminderRepository
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
        public Hospital.Model.Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
      {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Id = reader.GetInt32(0);
                reminder.Name = reader.GetString(1);
                reminder.Description = reader.GetString(2);
                reminder.AlarmTime = reader.GetDateTime(3);
                if(reminder.AlarmTime >= DateTime.Now)
                {
                    continue;
                } else
                {
                    reminders.Add(reminder);
                }
                
            }
            con.Close();
         return reminders;
      }

        public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Id = reader.GetInt32(0);
                reminder.Name = reader.GetString(1);
                reminder.Description = reader.GetString(2);
                reminder.AlarmTime = reader.GetDateTime(3);
                if (reminder.AlarmTime < DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }
            con.Close();
            return null;
        }
      
      public Boolean DeleteReminderById(int id)
      {
         // TODO: implement
         return false;
      }
      
      public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Hospital.Model.Reminder UpdateReminder(Hospital.Model.Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Hospital.Model.Reminder NewReminder(Hospital.Model.Reminder reminder)
      {
            setConnection();
            OracleCommand cmd = new OracleCommand();
            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO REMINDER (NAME,DESCRIPTION,ALARM_TIME,PATIENT_ID) VALUES (:name,:description,:alarm_time,:patient_id)";
            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            cmd.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = reminder.Patient.Id;
            int a = cmd.ExecuteNonQuery();
            con.Close();
            return reminder;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}