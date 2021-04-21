using System;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class PatientRepository
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

            return patient;
        }

        public Hospital.Model.Patient GetPatientById(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE patient.ID = :id AND USERS.ID = PATIENT.USER_ID";
            cmd.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = cmd.ExecuteReader();
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
                // password ne treba da se getuje?
                // user.Password = reader.GetString(2);
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

            //Address address = addressRepository.GetAddressById(addressId);
            //patient.Address = address;
            con.Close();
            return patient;
        }

        public Hospital.Model.Patient GetPatientByPatientId(int id)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = PATIENT.USER_ID and PATIENT.ID = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            User user = new User();
            int new_id = reader.GetInt32(0);


            user.Id = new_id;
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
            cmd.CommandText = "SELECT * FROM address, city, state WHERE address.id = " + addressId + " AND address.CITY_ID = city.ID AND city.STATE_ID = state.ID";
            reader = cmd.ExecuteReader();
            reader.Read();

            State state = new State
            {
                Id = int.Parse(reader.GetString(8)),
                Name = reader.GetString(9)
            };

            City city = new City
            {
                Id = int.Parse(reader.GetString(4)),
                Name = reader.GetString(5),
                PostalCode = reader.GetString(6),
                State = state
            };

            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),

                City = city
            };
            patient.Address = address;
            con.Close();
            return patient;
        }

        public  ObservableCollection<Patient> GetAllPatients()
        {
            setConnection();
            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM USERS,PATIENT WHERE USERS.ID = PATIENT.USER_ID";

            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

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

            patients.Add(patient);
            }

            con.Close();
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

        public Hospital.Model.Patient UpdatePatient(Hospital.Model.Patient patient)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Patient NewPatient(Hospital.Model.Patient patient)
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