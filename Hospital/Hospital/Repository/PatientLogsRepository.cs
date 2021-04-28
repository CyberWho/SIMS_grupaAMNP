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
            //TODO : implement
            return null;
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
            return false;
            
        }

        public Hospital.Model.PatientLogs UpdatePatientLogs(Hospital.Model.PatientLogs patientLogs)
        {
            // TODO: implement
            return null;
        }

        public Boolean ResetAllPatientLogs()
        {
            // TODO: implement
            return false;
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

        public Hospital.Model.PatientLogs NewPatientLogs()
        {
            // TODO: implement
            return null;
        }

       
    }
}
