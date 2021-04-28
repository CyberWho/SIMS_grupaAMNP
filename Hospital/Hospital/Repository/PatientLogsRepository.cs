using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Windows.Data;
using System.Windows;

namespace Hospital.Repository
{
    class PatientLogsRepository
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
        public ObservableCollection<PatientLogs> GetAllPatientLogs()
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.PatientLogs GetPatientLogsById(int id)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.PatientLogs GetPatientLogsByPatientId(int patientId)
        {
            setConnection();
            PatientLogs patientLogs = new PatientLogs();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT_LOGS WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            patientLogs.Id = reader.GetInt32(0);
            patientLogs.patient = new PatientRepository().GetPatientById(patientId);
            patientLogs.LogCounter = reader.GetInt32(2);
            patientLogs.LastCounterReset = reader.GetDateTime(3);
            return patientLogs;
        }
        public Boolean CheckIfPatientIsBlockedByPatientId(int patientId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT_LOGS WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int logCounter = reader.GetInt32(2);
           
            if(logCounter >= 10)
            {
                return true;
            }
            connection.Close();
            return false;
            
        }

        public Hospital.Model.PatientLogs UpdatePatientLogs(Hospital.Model.PatientLogs patientLogs)
        {
            // TODO: implement
            return null;
        }

        public Boolean ResetAllPatientLogs()
        {
            
            return false;
        }
        public Boolean ResetPatientLogCounterByPatientId(int patientId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE PATIENT_LOGS SET LOG_COUNTER = 0 WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            int executer = command.ExecuteNonQuery();
            OracleCommand command1 = connection.CreateCommand();
            command1.CommandText = "UPDATE PATIENT_LOGS SET LAST_COUNTER_RESET = :last_counter_reset WHERE PATIENT_ID = :patient_id";
            command1.Parameters.Add("last_counter_reset", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            command1.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            int executer1 = command1.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public Boolean DeletePatientLogsByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeletePatientLogsById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean NewPatientLogs(int patientId)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO PATIENT_LOGS (PATIENT_ID,LOG_COUNTER,LAST_COUNTER_RESET) VALUES (:patient_id,0,:last_counter_reset)";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            command.Parameters.Add("last_counter_reset", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

       
    }
}
