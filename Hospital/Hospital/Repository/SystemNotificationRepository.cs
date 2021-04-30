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
        private OracleCommand command;
        private OracleDataReader reader;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();
                command = connection.CreateCommand();
            }
            catch (Exception exp)
            {

            }
        }

        public ObservableCollection<SystemNotification> GetAllSystemWideSystemNotifications()
        {
            setConnection();

            command.CommandText =
                "SELECT id, name, description, creation_date, expiration_date FROM system_notification WHERE viewed = 0 AND global = 1";

            reader = command.ExecuteReader();
            ObservableCollection<SystemNotification> systemNotifications = new ObservableCollection<SystemNotification>();

            while (reader.Read())
            {
                int id = int.Parse(reader.GetString(0));
                string name = reader.GetString(1);
                string description = reader.GetString(2);
                DateTime creationDateTime = reader.GetDateTime(3);
                DateTime expirationDateTime = reader.GetDateTime(4);
                bool applicationWideNotification = true;

                SystemNotification systemNotification = new 
                    SystemNotification(
                        id,
                        creationDateTime,
                        expirationDateTime,
                        name,
                        description,
                        applicationWideNotification
                    );

                systemNotifications.Add(systemNotification);
            }

            return systemNotifications;
        }

        public SystemNotification GetSystemNotificationById(int id)
        {
            setConnection();
            command.CommandText = "SELECT * FROM system_notification WHERE id = " + id;
            reader = command.ExecuteReader();
            reader.Read();

            SystemNotification systemNotification;
            
            int intApplicationWideNotification = int.Parse(reader.GetString(5));
            bool applicationWideNotification = intApplicationWideNotification == 1 ?  true : false;

            string name = reader.GetString(1);
            string description = reader.GetString(2);
            
            if (applicationWideNotification)
            {
                DateTime creationDateTime = reader.GetDateTime(6);
                DateTime expirationDateTime = reader.GetDateTime(7);

                systemNotification = new
                    SystemNotification(
                        id,
                        creationDateTime,
                        expirationDateTime,
                        name,
                        description,
                        applicationWideNotification
                    );
            }
            // TODO: add enums for fields in the db so that they are known in model classes
            else
            {
                int userId = int.Parse(reader.GetString(3));

                systemNotification = new 
                    SystemNotification(
                        id,
                        name, 
                        description,
                        userId
                    );
            }

            connection.Close();
            return systemNotification;
        }

        public ObservableCollection<SystemNotification> GetAllSystemNotificationsByUserId(int userId)
        {
            setConnection();
            ObservableCollection<SystemNotification> systemNotifications = new ObservableCollection<SystemNotification>();

            command.CommandText = "SELECT * FROM SYSTEM_NOTIFICATION WHERE USER_ID = :user_id";
            command.Parameters.Add("user_id", OracleDbType.Int32).Value = userId.ToString();
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                SystemNotification systemNotification = new SystemNotification();

                // TODO: add id's as well, not sure how patient gets this data, there might be some difficulty with it

                systemNotification.Id = reader.GetInt32(0);
                systemNotification.Name = reader.GetString(1);
                systemNotification.Description = reader.GetString(2);

                systemNotifications.Add(systemNotification);
            }

            return systemNotifications;
        }

        public Boolean DeleteSystemNotificationById(int id)
        {
            setConnection();
            command.CommandText = "DELETE FROM system_notification WHERE id = " + id;

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return true;
            }

            connection.Close();
            return false;
        }

        public Boolean DeleteAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return false;
        }

        public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
        {
            setConnection();
            // maybe this is where were having issues, opening a connection while another one is open

            command.CommandText =
                "UPDATE system_notification SET name = :name, description = :description, creation_date = :creation_date, expiration_date = :expiration_date WHERE id = :id";
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description;
            command.Parameters.Add("creation_date", OracleDbType.Date).Value = systemNotification.creationDateTime;
            command.Parameters.Add("expiration_date", OracleDbType.Date).Value = systemNotification.expirationDateTime;
            command.Parameters.Add("id", OracleDbType.Int32).Value = systemNotification.Id;

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return systemNotification;
            }

            connection.Close();
            return null;
        }

        public SystemNotification NewSystemNotification(SystemNotification systemNotification)
        {
            setConnection();
            command = connection.CreateCommand();
            int viewed = 0;

            // thinking about using the viewed field when creating system wide notifications to say that the notification expiration date has gone by, and so using this field, when generating the notification board im making sure the expired ones don't get pulled
            // i don't wanna make another field in the db just for this, since it isn't being used anyway 
            // so 0 means it is still in effect
            // and 1 means that it isn't in effect anymore

            if (!systemNotification.applicationWideNotification)
            {
                command.CommandText = "INSERT INTO system_notification (name, description, user_id, viewed, global, creation_date) VALUES (:name, :description, :user_id, :viewed, 0, :c_date)";
                command.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
                command.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description;
                command.Parameters.Add("user_id", OracleDbType.Int32).Value = systemNotification.user_id.ToString();
                command.Parameters.Add("viewed", OracleDbType.Int32).Value = viewed.ToString();
                //command.Parameters.Add("global", OracleDbType.Int32).Value = systemNotification.applicationWideNotification.ToString();
                command.Parameters.Add("c_date", OracleDbType.Date).Value = systemNotification.creationDateTime;
            }
            else
            {
                command.CommandText = "INSERT INTO system_notification (name, description, viewed, global, creation_date, expiration_date) VALUES (:name, :description, 0, 1, :c_date, :e_date)";
                command.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
                command.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description;
                //command.Parameters.Add("global", OracleDbType.Int32).Value = systemNotification.applicationWideNotification.ToString();
                command.Parameters.Add("c_date", OracleDbType.Date).Value = systemNotification.creationDateTime;
                command.Parameters.Add("e_date", OracleDbType.Date).Value = systemNotification.expirationDateTime;
            }

            if (command.ExecuteNonQuery() > 0)
            {
                connection.Close();
                return systemNotification;
            }

            connection.Close();
            return null;
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