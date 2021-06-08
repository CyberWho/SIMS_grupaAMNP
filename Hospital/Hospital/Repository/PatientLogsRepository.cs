using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.Repository
{
    class PatientLogsRepository
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public ObservableCollection<PatientLogs> GetAllPatientLogs()
        {
            // TODO: implement
            return null;
        }

        public PatientLogs GetPatientLogsById(int id)
        {
            // TODO: implement
            return null;
        }

        public PatientLogs GetPatientLogsByPatientId(int patientId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT_LOGS WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            PatientLogs patientLogs = ParsePatientLogs(patientId, reader);
            return patientLogs;
        }

        private PatientLogs ParsePatientLogs(int patientId,OracleDataReader reader)
        {
            PatientLogs patientLogs = new PatientLogs(reader.GetInt32(0), reader.GetInt32(2),
                new PatientRepository().GetPatientById(patientId), reader.GetDateTime(3));
            return patientLogs;
        }

        public Boolean CheckIfPatientIsBlockedByPatientId(int patientId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT_LOGS WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int logCounter = reader.GetInt32(2);
           
            if(logCounter >= 10)
            {
                return true;
            }
            
            return false;
            
        }

        public PatientLogs UpdatePatientLogs(PatientLogs patientLogs)
        {
            // TODO: implement
            return null;
        }
        public Boolean IncrementLogCounterByPatientId(int patientId)
        {
            PatientLogs patientLogs = GetPatientLogsByPatientId(patientId);
            int nextLogCounter = patientLogs.LogCounter;
            nextLogCounter += 1;
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE PATIENT_LOGS SET LOG_COUNTER = :log_counter WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("log_counter", OracleDbType.Int32).Value = nextLogCounter.ToString();
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            command.ExecuteNonQuery();
            
            return true;
        }


        public Boolean ResetAllPatientLogs()
        {
            
            return false;
        }
        public Boolean ResetPatientLogCounterByPatientId(int patientId)
        {
            UpdateLogCounterByPatientId(patientId);
            UpdateLastCounterResetByPatientId(patientId);
            return true;
        }
        public Boolean UpdateLogCounterByPatientId(int patientId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE PATIENT_LOGS SET LOG_COUNTER = 0 WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            int executer = command.ExecuteNonQuery();
            
            return true;
        }
        public Boolean UpdateLastCounterResetByPatientId(int patientId)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE PATIENT_LOGS SET LAST_COUNTER_RESET = :last_counter_reset WHERE PATIENT_ID = :patient_id";
            command.Parameters.Add("last_counter_reset", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            int executer = command.ExecuteNonQuery();
            
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
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "INSERT INTO PATIENT_LOGS (PATIENT_ID,LOG_COUNTER,LAST_COUNTER_RESET) VALUES (:patient_id,0,:last_counter_reset)";
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = patientId.ToString();
            command.Parameters.Add("last_counter_reset", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            command.ExecuteNonQuery();
            
            return true;
        }

       
    }
}
