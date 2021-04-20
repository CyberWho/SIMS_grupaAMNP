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

        OracleConnection con = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try { 
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }

        public Patient GetPatientByUserId(int id)
        {
            setConnection();

            OracleCommand command = con.CreateCommand();
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

            con.Close();
            return patient;
        }


        public Patient GetPatientById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = :id AND USERS.ID = PATIENT.USER_ID";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User();
            user.Id = int.Parse(reader.GetString(0));
            user.Username = reader.GetString(1);
            user.Password = reader.GetString(2);
            user.Name = reader.GetString(3);
            user.Surname = reader.GetString(4);
            user.PhoneNumber = reader.GetString(5);
            user.EMail = reader.GetString(6);

            Patient patient = new Patient();
            patient.User = user;
            patient.Id = int.Parse(reader.GetString(7));
            patient.JMBG = reader.GetString(8);
            patient.DateOfBirth = reader.GetDateTime(9);
            int addressId = reader.GetInt32(10);

            //Address address = addressRepository.GetAddressById(addressId);
            //patient.Address = address;
            con.Close();
            return patient;
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