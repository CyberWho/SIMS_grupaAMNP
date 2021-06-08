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
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class PatientRepository : IPatientRepo<Patient>
    {

        
        private AddressRepository addressRepository = new AddressRepository();


        public Patient GetByUserId(int userId)
        {

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM patient WHERE user_id = :userId";
            command.Parameters.Add("userId", OracleDbType.Int32).Value = userId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            var patient = ParsePatient(reader);
            
            return patient;
        }


        public Patient GetById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            int idGetUserById = reader.GetInt32(4);
            Patient tmp = new Patient
            {
                Id = int.Parse(reader.GetString(0)),
                JMBG = reader.GetString(1),
                DateOfBirth = DateTime.Parse(reader.GetString(2)),
                addres_id = int.Parse(reader.GetString(3)),
                user_id = int.Parse(reader.GetString(4))
            };



            
            
            User user = new UserRepository().GetById(idGetUserById);
            tmp.User = user;
            return tmp;
        }

        public bool CheckIfPatientHasBeenLogedById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM HAS_BEEN_LOGED WHERE PATIENT_ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.GetInt32(2) == 0)
            {
                
                
                return false;

            }
            else
            {
                
                
                return true;
            }

        }

        public void UpdateHasBeenLogedById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE HAS_BEEN_LOGED SET HAS_BEEN_LOGED = 1 WHERE PATIENT_ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            
            

        }

        private static Patient ParsePatient(OracleDataReader reader)
        {
            Patient patient = new Patient();
            User user = new UserRepository().GetById(reader.GetInt32(4));
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

            //patient.Address = new AddressRepository().GetById(patient.addres_id);

            return patient;
        }

        /*public Patient GetPatientById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT WHERE ID = :userId";
            command.Parameters.Add("userId", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            var patient = ParsePatient(reader);
            
             

            return patient;
        }*/

        /*public ObservableCollection<Patient> GetAll()
        {
            
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM PATIENT";

            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new UserRepository().GetById(reader.GetInt32(4));
                user.Id = reader.GetInt32(4);
                if (user.Name == null) continue;
                var patient = new Patient(reader.GetInt32(0),reader.GetString(1),reader.GetDateTime(2),user,addressRepository.GetById(3));
                patient.addres_id = 
                patients.New(patient);
            }

            

            
            

            return patients;
        }*/


        public ObservableCollection<Patient> GetAll()
        {
            
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            OracleCommand command = Globals.globalConnection.CreateCommand();
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

            
            

            return patients;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
        }

        public Patient Update(Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Patient New(Patient patient, int guest = 0)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();

            int last_id = this.GetLastId() + 1;
            patient.Id = last_id;

            if (guest == 1)
            {
                command.CommandText = "INSERT INTO patient (userId, user_id) VALUES (:userId, :user_id)";

                command.Parameters.Add("userId", OracleDbType.Int32).Value = patient.Id;
                command.Parameters.Add("user_id", OracleDbType.Int32).Value = patient.user_id;

                if (command.ExecuteNonQuery() > 0)
                {
                    
                    

                    return patient;
                }
            }
            else
            {

            }

            
            

            return null;
        }

        public int GetLastId()
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM patient";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            
            

            return last_id;
        }

        public Patient Add(Patient t)
        {
            throw new NotImplementedException();
        }
    }
}