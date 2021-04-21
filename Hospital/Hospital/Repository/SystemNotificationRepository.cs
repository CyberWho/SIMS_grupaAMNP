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

        public Hospital.Model.SystemNotification UpdateSystemNotification(Hospital.Model.SystemNotification systemNotification)
        {
            // TODO: implement
            return null;
        }

        public SystemNotification NewSystemNotification(SystemNotification systemNotification)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();

            cmd.CommandText = "INSERT INTO system_notification (name, description, user_id, viewed) VALUES (:name, :description, :user_id, 0)";
            cmd.Parameters.Add("name", OracleDbType.Varchar2).Value = systemNotification.Name;
            cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = systemNotification.Description.ToString();
            cmd.Parameters.Add("user_id", OracleDbType.Int32).Value = systemNotification.user_id.ToString();

            int a = cmd.ExecuteNonQuery();
            con.Close();

            return systemNotification;
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