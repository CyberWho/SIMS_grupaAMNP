/***********************************************************************
 * Module:  ReminderRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReminderRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Windows;

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
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            Reminder reminder = new Reminder();
            reminder.Id = reader.GetInt32(0);
            reminder.Name = reader.GetString(1);
            reminder.Description = reader.GetString(2);
            reminder.AlarmTime = reader.GetDateTime(3);
            connection.Close();
            return reminder;
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
                if (reminder.AlarmTime >= DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }

            connection.Close();
            connection.Dispose();

            return reminders;
        }
        public ObservableCollection<Reminder> GetReminderByAlarmTimeAndPatientId(DateTime alarmTime, int patientId)
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
            connection.Dispose();

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
            connection.Dispose();

            return reminders;
        }
      
        public ObservableCollection<Reminder> GetAllRemindersByPatientId(int patientId)
        {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id AND PERSONAL_REMINDER_ID = 0";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Id = reader.GetInt32(0);
                reminder.Name = reader.GetString(1);
                reminder.Description = reader.GetString(2);
                reminder.AlarmTime = reader.GetDateTime(3);
                reminders.Add(reminder);
            }

            connection.Close();
            connection.Dispose();

            return reminders;
        }
        public ObservableCollection<Reminder> GetAllRemindersByPersonalReminderId(int personalReminderId)
        {
            setConnection();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PERSONAL_REMINDER_ID = :personal_reminder_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = personalReminderId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = new Reminder();
                reminder.Id = reader.GetInt32(0);
                reminder.Name = reader.GetString(1);
                reminder.Description = reader.GetString(2);
                reminder.AlarmTime = reader.GetDateTime(3);
                reminders.Add(reminder);
            }

            connection.Close();
            connection.Dispose();

            return reminders;
        }

        public Boolean DeleteReminderById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM REMINDER WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
      
      public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Reminder UpdateReminder(Reminder reminder)
      {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE REMINDER SET NAME= :name, DESCRIPTION = :description, ALARM_TIME = :alarm_time WHERE PERSONAL_REMINDER_ID = :id";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            command.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            command.Parameters.Add("id", OracleDbType.Int32).Value = reminder.personalReminderId.ToString();
            
            command.ExecuteNonQuery();
            
            connection.Close();
            connection.Dispose();
            return reminder;
      }
      
      public Reminder NewReminder(Reminder reminder)
      {
            setConnection();
            OracleCommand command = new OracleCommand();
            command = connection.CreateCommand();
            command.CommandText = "INSERT INTO REMINDER (NAME,DESCRIPTION,ALARM_TIME,PATIENT_ID,PERSONAL_REMINDER_ID) VALUES (:name,:description,:alarm_time,:patient_id,:personal_reminder_id)";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            command.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = reminder.Patient.Id;
            command.Parameters.Add("personal_reminder_id", OracleDbType.Int32).Value = reminder.personalReminderId;
            int executer = command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            return reminder;
        }

        public int GetLastId()
        {
            setConnection();
            int id = 0;
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM REMINDER";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return id;
        }

    }
}