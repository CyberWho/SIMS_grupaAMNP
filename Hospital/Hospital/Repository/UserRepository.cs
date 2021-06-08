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


        public User GuestUser()
        {
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

            User user = new User();

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM users WHERE id = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
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

            return user;
        }

        public User GetUserByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            ObservableCollection<User> users = new ObservableCollection<User>();

            OracleCommand command = Globals.globalConnection.CreateCommand();
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
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "DELETE FROM users WHERE id = " + id;

            if (command.ExecuteNonQuery() > 0)
            {
                return true;
            }
            
            return false;
        }

        public Boolean DeleteUserByUsername(String username)
        {
            // TODO: implement
            return false;
        }

        #region marko_kt5
        public User UpdateUser(User user)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "UPDATE users set username=:username, " +
                                  "name=:name, " +
                                  "surname=:surname, " +
                                  "phone_number=:phone_number, " +
                                  "email=:email " +
                                  "WHERE ID = " + user.Id;

            command.Parameters.Add("username", user.Username);
            command.Parameters.Add("name", user.Name);
            command.Parameters.Add("surname", user.Surname);
            command.Parameters.Add("phone_number", user.PhoneNumber);
            command.Parameters.Add("email", user.EMail);

            if (command.ExecuteNonQuery() > 0)
            {
                return user;
            }
            return null;
        }

        public User NewUser(User user, int guest = 0)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();

            // kreiranje guest naloga
            if (guest == 1)
            {
                command.CommandText = "INSERT INTO users (id, username, password) VALUES (:id, :username, :password)";

                command.Parameters.Add("id", OracleDbType.Int32).Value = user.Id;
                command.Parameters.Add("username", OracleDbType.Varchar2).Value = user.Username;
                command.Parameters.Add("password", OracleDbType.Varchar2).Value = user.Password;

                if (command.ExecuteNonQuery() > 0)
                {
                    return user;
                }
            }
            // kreiranje obicnog korisnika
            else
            {
                command.CommandText =
                    "INSERT INTO users (id, username, password, name, surname, phone_number, email) VALUES (:id, :username, :password, :name, :surname, :phone_number, :email)";
                user.Id = GetLastId() + 1;
                command.Parameters.Add("id", OracleDbType.Int32).Value = user.Id;
                command.Parameters.Add("username", OracleDbType.Varchar2).Value = user.Username;
                command.Parameters.Add("password", OracleDbType.Varchar2).Value = user.Password;
                command.Parameters.Add("name", OracleDbType.Varchar2).Value = user.Name;
                command.Parameters.Add("surname", OracleDbType.Varchar2).Value = user.Surname;
                command.Parameters.Add("phone_number", OracleDbType.Varchar2).Value = user.PhoneNumber;
                command.Parameters.Add("email", OracleDbType.Varchar2).Value = user.EMail;

                if (command.ExecuteNonQuery() > 0)
                {
                    return user;
                }
            }

            return null;
        }
        #endregion
        public int GetLastId()
        {
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT MAX(id) FROM users";
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            int last_id = int.Parse(reader.GetString(0));

            return last_id;
        }

        public void makeDoctorUser()
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();

            User user = new
                User(
                    id: 44,
                    username: "card1",
                    password: "card1",
                    name: "markocard1",
                    surname: "cardiolovic",
                    phoneNumber: "6128376178",
                    eMail: "fahsi@gmahdfias"
                    );

            command.CommandText =
                "INSERT INTO users (id, username, password, name, surname, phone_number, email) VALUES (:id, :username, :password, :name, :surname, :phone_number, :email)";
            command.Parameters.Add("id", OracleDbType.Int32).Value = 44;
            command.Parameters.Add("username", OracleDbType.Varchar2).Value = user.Username;
            command.Parameters.Add("password", OracleDbType.Varchar2).Value = user.Password;
            command.Parameters.Add("name", OracleDbType.Varchar2).Value = user.Name;
            command.Parameters.Add("surname", OracleDbType.Varchar2).Value = user.Surname;
            command.Parameters.Add("phone_number", OracleDbType.Varchar2).Value = user.PhoneNumber;
            command.Parameters.Add("email", OracleDbType.Varchar2).Value = user.EMail;

            command.ExecuteNonQuery();

            Role role = new
                Role(
                    id: 1,
                    roleType: "Doctor"
                    );

            Employee employee = new
                Employee(
                        id: 0,
                        salary: 95000,
                        yearsOfService: 5,
                        user: user,
                        role: role
                    );

            this.employeesRepository.NewEmployee(employee);

        }

        private EmployeesRepository employeesRepository = new EmployeesRepository();

    }
}