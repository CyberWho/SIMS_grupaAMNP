/***********************************************************************
 * Module:  SystemNotificationRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.SystemNotificationRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;

namespace Hospital.Repository
{
    public class SystemNotificationRepository
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

        public Hospital.Model.SystemNotification GetSystemNotificationById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllSystemNotificationsByUserId(int userId)
        {
            // TODO: implement
            return null;
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

        public SystemNotification UpdateSystemNotification(SystemNotification systemNotification)
        {



            return null;
        }

        public SystemNotification NewSystemNotification(SystemNotification systemNotification)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            int viewed = 0;

            // thinking about using the viewed field when creating system wide notifications to say that the notification expiration date has gone by, and so using this field, when generating the notification board im making sure the expired ones don't get pulled
            // i don't wanna make another field in the db just for this, since it isn't being used anyway 
            // so 0 means it is still in effect
            // and 1 means that it isn't in effect anymore

            if (!systemNotification.applicationWideNotification)
            {
                cmd.CommandText = "INSERT INTO system_notification (name, description, user_id, viewed, global, creation_date) VALUES (:name, :description, :user_id, :viewed, 0, :c_date)";
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
                cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description;
                cmd.Parameters.Add("user_id", OracleDbType.Int32).Value = systemNotification.user_id.ToString();
                cmd.Parameters.Add("viewed", OracleDbType.Int32).Value = viewed.ToString();
                //cmd.Parameters.Add("global", OracleDbType.Int32).Value = systemNotification.applicationWideNotification.ToString();
                cmd.Parameters.Add("c_date", OracleDbType.Date).Value = systemNotification.creationDateTime;
            }
            else
            {
                cmd.CommandText = "INSERT INTO system_notification (name, description, viewed, global, creation_date, expiration_date) VALUES (:name, :description, 0, 1, :c_date, :e_date)";
                cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
                cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description;
                //cmd.Parameters.Add("global", OracleDbType.Int32).Value = systemNotification.applicationWideNotification.ToString();
                cmd.Parameters.Add("c_date", OracleDbType.Date).Value = systemNotification.creationDateTime;
                cmd.Parameters.Add("e_date", OracleDbType.Date).Value = systemNotification.expirationDateTime;
            }

            if (cmd.ExecuteNonQuery() > 0)
            {
                con.Close();
                return systemNotification;
            }

            return null;
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
            con.Close();
            return id;
        }

    }
}