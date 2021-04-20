/***********************************************************************
 * Module:  UserRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.UserRepository
 ***********************************************************************/

using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class UserRepository
    {
        PatientRepository patientRepository = new PatientRepository();
        HealthRecordRepository healthRecordRepository = new HealthRecordRepository();


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


        public User GuestUser()
        {
            setConnection();

            int last_id = this.GetLastId();

            User user = new User();
            user.Id = last_id + 1;
            user.Username = "guestUser" + user.Id;
            user.Password = "guestPass" + user.Id;
            user = this.NewUser(user, 1);

            Patient patient = new Patient();
            patient.user_id = user.Id;
            patient = this.patientRepository.NewPatient(patient, 1);

            HealthRecord healthRecord = new HealthRecord();
            healthRecord.patient_id = patient.Id;
            healthRecord = this.healthRecordRepository.NewHealthRecord(healthRecord, 1);

            return user;
        }


        public User GetUserById(int id)
        {
            setConnection();

            User user = new User();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE id = " + id;
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();

            user.Id = id;
            user.Username = reader.GetString(1);

            if (user.Username.Contains("guestUser"))
            {
                return user;
            }

            user.Name = reader.GetString(3);
            user.Surname = reader.GetString(4);
            user.PhoneNumber = reader.GetString(5);
            user.EMail = reader.GetString(6);

            connection.Close();

            return user;
        }

        public User GetUserByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            setConnection();

            ObservableCollection<User> users = new ObservableCollection<User>();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT users.id, users.username, users.name, users.surname, users.phone_number, users.email, " +
                "patient.jmbg, patient.date_of_birth " +
                "FROM users, patient " +
                "WHERE users.id = patient.user_id";
            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User nUser;
                if (reader.GetString(1).Contains("guestUser"))
                {
                    nUser = new User
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Username = reader.GetString(1)
                    };
                }
                else
                {
                    nUser = new User
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Username = reader.GetString(1),
                        Name = reader.GetString(3),
                        Surname = reader.GetString(4),
                        PhoneNumber = reader.GetString(5),
                        EMail = reader.GetString(6)
                    };
                }

                users.Add(nUser);
            }

            return users;
        }

        public Boolean DeleteUserById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteUserByUsername(String username)
        {
            // TODO: implement
            return false;
        }

        public User UpdateUser(User user)
        {
            // TODO: implement
            return null;
        }

        public User NewUser(User user, int guest = 0)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();

            // kreiranje guest naloga
            if (guest == 1)
            {
                command.CommandText = "INSERT INTO users (id, username, password) VALUES (:id, :username, :password)";

                command.Parameters.Add("id", OracleDbType.Int32).Value = user.Id;
                command.Parameters.Add("username", OracleDbType.Varchar2).Value = user.Username;
                command.Parameters.Add("password", OracleDbType.Varchar2).Value = user.Password;

                if (command.ExecuteNonQuery() > 0)
                {
                    connection.Close();
                    return user;
                }
            }
            // kreiranje obicnog korisnika
            else
            {

            }


            connection.Close();
            return null;
        }

        public int GetLastId()
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM users";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            connection.Close();

            return last_id;
        }

    }
}