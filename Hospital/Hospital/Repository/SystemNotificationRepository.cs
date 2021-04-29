/***********************************************************************
 * Module:  SystemNotificationRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.SystemNotificationRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class SystemNotificationRepository
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

        public Hospital.Model.SystemNotification GetSystemNotificationById(int id)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
        {
            setConnection();
            ObservableCollection<SystemNotification> systemNotifications = new ObservableCollection<SystemNotification>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM SYSTEM_NOTIFICATION WHERE USER_ID = :user_id OR GLOBAL = 1";
            command.Parameters.Add("user_id", OracleDbType.Int32).Value = userId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                SystemNotification systemNotification = new SystemNotification();
                systemNotification.Id = reader.GetInt32(0);
                systemNotification.Name = reader.GetString(1);
                systemNotification.Description = reader.GetString(2);
                systemNotifications.Add(systemNotification);
            }
            return systemNotifications;
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.SystemNotification UpdateSystemNotification(Hospital.Model.SystemNotification systemNotification)
        {
            // TODO: implement
            return null;
        }

        public SystemNotification NewSystemNotification(SystemNotification systemNotification)
        {
            setConnection();
            OracleCommand cmd = connection.CreateCommand();

            cmd.CommandText = "INSERT INTO system_notification (name, description, user_id, viewed) VALUES (:name, :description, :user_id, 0)";
            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
            cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description.ToString();
            cmd.Parameters.Add("user_id", OracleDbType.Int32).Value = systemNotification.user_id.ToString();

            int a = cmd.ExecuteNonQuery();
            connection.Close();

            return systemNotification;
        }

        public int GetLastId()
        {
            setConnection();
            int id = 0;
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM APPOINTMENT";
            OracleDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));
            connection.Close();
            return id;
        }

    }
}