/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PatientRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;

namespace Hospital.Repository
{
    public class PatientRepository
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

        public Patient GetPatientByUserId(int id)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE user_id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();


            Patient patient = new Patient
            {
                Id = int.Parse(reader.GetString(0)),
                JMBG = reader.GetString(1),
                DateOfBirth = DateTime.Parse(reader.GetString(2)),
                addres_id = int.Parse(reader.GetString(3)),
                user_id = int.Parse(reader.GetString(4))                
            };

            return patient;
        }


        public Patient GetPatientById(int id)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllPatients()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllPatientsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeletePatientById(int id)
        {
            // TODO: implement
            return false;
        }

        public Patient UpdatePatient(Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Patient NewPatient(Patient patient)
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