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
           // cmd.Parameters.Add("date_now", OracleDbType.Date).Value = DateTime.Now.ToString();
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