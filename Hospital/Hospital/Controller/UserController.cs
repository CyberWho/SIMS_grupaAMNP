/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Hospital.xaml_windows.Doctor;
using Hospital.xaml_windows.Manager;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;
using System.Windows;
using Hospital.Service;

namespace Hospital.Controller
{
    public class UserController
    {
        public UserService userService = new UserService();

        public bool LoginUser(String username, String password)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "SELECT * FROM users";
            OracleDataReader reader = cmd.ExecuteReader();


            //vidim da li je ispravno uneto ako da uzmem id i trazim sta je
            int id = -1;
            while (reader.Read())
                if (username == reader.GetString(1) & password == reader.GetString(2))
                    id = int.Parse(reader.GetString(0));

            if (id == -1)
            {
                MessageBox.Show("Pogresan unos");
                return false;
            }

            string uloga = "";
            cmd.CommandText = "select users.ID, role.roletype FROM users, employee, role where users.ID = employee.USER_ID and employee.ROLE_ID = role.ID";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (id == int.Parse(reader.GetString(0)))
                    uloga = reader.GetString(1);
            }
            con.Close();
            con.Dispose();

            //paljenje drugih prozora
            Window s;
            switch (uloga)
            {
                case "":
                    s = new PatientUI(id);
                    s.Show();
                    break;
                case "Doctor":
                    s = new DoctorUI(id);
                    s.Show();
                    break;
                case "Manager":
                    s = new ManagerUI(id);
                    s.Show();
                    break;
                case "Secretary":
                    s = new SecretaryUI(id);
                    s.Show();
                    break;
            }

            return true;
        }

        public User GuestUser()
        {
            return this.userService.GuestUser();
        }
        public User RegisterUser(String username, String password)
        {
            // TODO: implement
            return null;
        }

        public User Unguest(User user)
        {
            // TODO: implement
            return null;
        }

        public Boolean IsValidUsername()
        {
            // TODO: implement
            return false;
        }

        public Boolean IsValidPassword()
        {
            // TODO: implement
            return false;
        }

        public User GetUserById(int id)
        {
            return this.userService.GetUserById(id);
        }

        public User GetUserByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return this.userService.GetAllUsers();
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

        public void makeDoctorUser()
        {
            this.userService.makeDoctorUser();
        }

    }
}