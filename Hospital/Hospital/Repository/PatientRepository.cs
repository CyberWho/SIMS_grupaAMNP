/***********************************************************************
 * Module:  PatientRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.PatientRepository
 ***********************************************************************/

using Hospital.Model;
using System;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class PatientRepository
    {

        OracleConnection connection = null;
        AddressRepository addressRepository = new AddressRepository();
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
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserById(id);

            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE user_id = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            //int user_id = int.Parse(reader.GetString(4));

            Patient patient = new Patient();
            // User user = userRepository.GetUserById(user_id);

            if (user.Username.Contains("guestUser"))
            {
                patient.Id = int.Parse(reader.GetString(0));
                patient.user_id = user.Id;
            }
            else
            {
                patient = new Patient
                {
                    Id = int.Parse(reader.GetString(0)),
                    JMBG = reader.GetString(1),
                    DateOfBirth = DateTime.Parse(reader.GetString(2)),
                    addres_id = int.Parse(reader.GetString(3)),
                    user_id = int.Parse(reader.GetString(4))
                };
                patient.User = user;
            }

            connection.Close();
            connection.Dispose();

            return patient;
        }


        public Patient GetPatientById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,PATIENT WHERE patient.ID = :id AND USERS.ID = PATIENT.USER_ID";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            User user = new User();
            Patient patient = new Patient();

            user.Id = int.Parse(reader.GetString(0));
            user.Username = reader.GetString(1);

            if (user.Username.Contains("guestUser"))
            {

            }
            else
            {

                user.Name = reader.GetString(3);
                user.Surname = reader.GetString(4);
                user.PhoneNumber = reader.GetString(5);
                user.EMail = reader.GetString(6);

                patient.JMBG = reader.GetString(8);
                patient.DateOfBirth = reader.GetDateTime(9);
                int addressId = reader.GetInt32(10);
            }

            patient.Id = int.Parse(reader.GetString(7));
            patient.User = user;
            patient.user_id = int.Parse(reader.GetString(11));

            // Address address = addressRepository.GetAddressById(addressId);
            // patient.Address = address;
            connection.Close();
            connection.Dispose(); 
            
            return patient;
        }

        public Patient GetPatientByPatientId(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = PATIENT.USER_ID and PATIENT.ID = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            User user = new User();
            user = new UserRepository().GetUserById(reader.GetInt32(0));
            /*int userId = reader.GetInt32(0);


            user.Id = userId;
            user.Username = reader.GetString(1);
            user.Password = reader.GetString(2);
            user.Name = reader.GetString(3);
            user.Surname = reader.GetString(4);
            user.PhoneNumber = reader.GetString(5);
            user.EMail = reader.GetString(6);*/

            Patient patient = new Patient();
            patient.User = user;
            patient.Id = int.Parse(reader.GetString(7));
            patient.JMBG = reader.GetString(8);
            patient.DateOfBirth = reader.GetDateTime(9);
            int addressId = reader.GetInt32(10);
            Address address = addressRepository.GetAddressById(addressId);
            patient.Address = address;

            connection.Close();
            connection.Dispose(); 

            return patient;
        }

        public ObservableCollection<Patient> GetAllPatients()
        {
            setConnection();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = PATIENT.USER_ID";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();

                try
                {
                    user.Name = reader.GetString(3);
                }
                catch (Exception e)
                {
                    continue;
                }

                user.Id = int.Parse(reader.GetString(0));
                user.Username = reader.GetString(1);
                user.Password = reader.GetString(2);

                user.Surname = reader.GetString(4);
                user.PhoneNumber = reader.GetString(5);
                user.EMail = reader.GetString(6);

                Patient patient = new Patient();
                patient.User = user;
                patient.Id = int.Parse(reader.GetString(7));
                patient.JMBG = reader.GetString(8);
                patient.DateOfBirth = reader.GetDateTime(9);
                int addressId = reader.GetInt32(10);

                patients.Add(patient);
            }

            connection.Close();
            connection.Dispose();

            return patients;
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

        public Patient NewPatient(Patient patient, int guest = 0)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            int last_id = this.GetLastId() + 1;
            patient.Id = last_id;

            if (guest == 1)
            {
                command.CommandText = "INSERT INTO patient (id, user_id) VALUES (:id, :user_id)";

                command.Parameters.Add("id", OracleDbType.Int32).Value = patient.Id;
                command.Parameters.Add("user_id", OracleDbType.Int32).Value = patient.user_id;

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    connection.Dispose();

                    return patient;
                }
            }
            else
            {

            }

            connection.Close();
            connection.Dispose();

            return null;
        }

        public int GetLastId()
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM patient";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            connection.Close();
            connection.Dispose();

            return last_id;
        }

    }
}