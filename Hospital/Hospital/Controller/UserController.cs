/***********************************************************************
 * Module:  Class20.cs
 * Author:  todor
 * Purpose: Definition of the Class Hospital.Controller.Class20
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Hospital.xaml_windows.Doctor;
using Hospital.xaml_windows.Manager;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;
using System.Windows;
using System.Windows.Annotations;
using Hospital.Repository;
using Hospital.Service;
using Hospital.View.Doctor;
using Hospital.View.Patient;

namespace Hospital.Controller
{
    public class UserController
    {
        public UserService userService = new UserService(new UserRepository());
        PatientController patientController = new PatientController();
        PatientLogsController patientLogsController = new PatientLogsController();
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


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// kt5 marko
            if (username.Length == 0 && password.Length == 0)
            {
                id = 4;
            }
            else
            {
                while (reader.Read())
                    if (username == reader.GetString(1) & password == reader.GetString(2))
                        id = int.Parse(reader.GetString(0));
            }

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


            Window s;
            switch (uloga)
            {
                case "":
                    Patient patient = patientController.GetPatientByUserId(id);
                    if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patient.Id) == true)
                    {
                        MessageBox.Show("Blokirani ste i nije moguce da se ulogujete!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                    }
                    else
                    {
                        bool logedInfo = patientController.CheckIfPatientHasBeenLogedByPatientId(patient.Id);
                        if (!logedInfo)
                        {
                            patientController.UpdateHasBeenLogedByPatientId(patient.Id);
                            s = new WizardHomeView(id);
                            s.Show();
                        }
                        else
                        {
                            s = new PatientUIView(id);
                            s.Show();
                        }
                    }
                    break;
                case "Doctor":
                    s = new DoctorUIwindow(id);
                    s.Show();
                    break;
                case "Manager":
                    s = new View.Manager.ManagerUIView();
                    //s = new Wizard1();
                    s.Show();
                    break;
                case "Secretary":
                    s = new SecretaryUI(id);
                    s.Show();
                    break;
            }

            return true;
        }

        public AbstractUser makeAbstractUser(AbstractUser abstractUser)
        {
            return this.userService.makeAbstractUser(abstractUser);
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
            return userService.DeleteUserById(id);
        }

        public Boolean DeleteUserByUsername(String username)
        {
            // TODO: implement
            return false;
        }

        public User UpdateUser(User user)
        {
            return userService.UpdateUser(user);
        }

        public void makeDoctorUser()
        {
            this.userService.makeDoctorUser();
        }

        public User newUser(User user)
        {
            return this.userService.newUser(user);
        }

    }
}