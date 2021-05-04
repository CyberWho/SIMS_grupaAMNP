/***********************************************************************
 * Module:  ReminderRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReminderRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class ReminderRepository
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
        public Reminder GetReminderById(int id)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
      {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
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
            connection.Close();
         return reminders;
      }
        public ObservableCollection<Reminder> GetReminderByAlarmTimeAndPatientId(DateTime alarmTime,int patientId)
        {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Id = reader.GetInt32(0);
                reminder.Name = reader.GetString(1);
                reminder.Description = reader.GetString(2);
                reminder.AlarmTime = reader.GetDateTime(3);
                if (reminder.AlarmTime != DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }
            connection.Close();
            return reminders;
        }

        public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
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
            connection.Close();
            return reminders;
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
      
      public Reminder UpdateReminder(Reminder reminder)
      {
         // TODO: implement
         return null;
      }
      
      public Reminder NewReminder(Reminder reminder)
      {
            setConnection();
            OracleCommand command = new OracleCommand();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO REMINDER (NAME,DESCRIPTION,ALARM_TIME,PATIENT_ID) VALUES (:name,:description,:alarm_time,:patient_id)";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            command.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = reminder.Patient.Id;
            int executer = command.ExecuteNonQuery();
            connection.Close();
            return reminder;
      }
      
      public int GetLastId()
      {
         // TODO: implement
         return 0;
      }
   
   }
}