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
        public Reminder GetReminderById(int id)
      {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            var reminder = ParseReminder(reader);
            
            return reminder;
      }

        private static Reminder ParseReminder(OracleDataReader reader)
        {
            Reminder reminder = new Reminder();
            reminder.Id = reader.GetInt32(0);
            reminder.Name = reader.GetString(1);
            reminder.Description = reader.GetString(2);
            reminder.AlarmTime = reader.GetDateTime(3);
            return reminder;
        }

        public ObservableCollection<Reminder> GetAllPastRemindersByPatientId(int patientId)
      {
            
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Reminder reminder = ParseReminder(reader);
                
                if (reminder.AlarmTime >= DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }

            
            

            return reminders;
        }
        public ObservableCollection<Reminder> GetReminderByAlarmTimeAndPatientId(DateTime alarmTime, int patientId)
        {
            
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = ParseReminder(reader);
                if (reminder.AlarmTime != DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }

            
            

            return reminders;
        }

        public ObservableCollection<Reminder> GetAllFutureRemindersByPatientId(int patientId)
        {
            
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = ParseReminder(reader);
                
                if (reminder.AlarmTime < DateTime.Now)
                {
                    continue;
                }
                else
                {
                    reminders.Add(reminder);
                }

            }

            
            

            return reminders;
        }
      
        public ObservableCollection<Reminder> GetAllRemindersByPatientId(int patientId)
        {
            
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PATIENT_ID = :patient_id AND PERSONAL_REMINDER_ID = 0";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = ParseReminder(reader);
                
                reminders.Add(reminder);
            }

            
            

            return reminders;
        }
        public ObservableCollection<Reminder> GetAllRemindersByPersonalReminderId(int personalReminderId)
        {
            
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REMINDER WHERE PERSONAL_REMINDER_ID = :personal_reminder_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = personalReminderId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reminder reminder = ParseReminder(reader);
                
                reminders.Add(reminder);
            }

            
            

            return reminders;
        }

        public Boolean DeleteReminderById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "DELETE FROM REMINDER WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            
            return true;
        }
      
      public Boolean DeleteAllRemindersByPatientId(int patientId)
      {
         // TODO: implement
         return false;
      }
      
      public Reminder UpdateReminder(Reminder reminder)
      {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE REMINDER SET NAME= :name, DESCRIPTION = :description, ALARM_TIME = :alarm_time WHERE PERSONAL_REMINDER_ID = :id";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            command.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            command.Parameters.Add("id", OracleDbType.Int32).Value = reminder.personalReminderId.ToString();
            
            command.ExecuteNonQuery();
            
            
            
            return reminder;
      }
      
      public Reminder NewReminder(Reminder reminder)
      {
            
            OracleCommand command = new OracleCommand();
            command = Globals.globalConnection.CreateCommand();
            command.CommandText = "INSERT INTO REMINDER (NAME,DESCRIPTION,ALARM_TIME,PATIENT_ID,PERSONAL_REMINDER_ID) VALUES (:name,:description,:alarm_time,:patient_id,:personal_reminder_id)";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = reminder.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = reminder.Description;
            command.Parameters.Add("alarm_time", OracleDbType.Date).Value = reminder.AlarmTime;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = reminder.Patient.Id;
            command.Parameters.Add("personal_reminder_id", OracleDbType.Int32).Value = reminder.personalReminderId;
            int executer = command.ExecuteNonQuery();
            
            
            return reminder;
        }

        public int GetLastId()
        {
            
            int id = 0;
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT MAX(ID) FROM REMINDER";
            OracleDataReader reader = command.ExecuteReader();
            reader = command.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));

            
            

            return id;
        }

    }
}