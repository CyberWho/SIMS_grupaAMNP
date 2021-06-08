/***********************************************************************
 * Module:  UserService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.UserService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;
using System.Drawing.Printing;

namespace Hospital.Service
{
    public class UserService
    {
        public UserRepository userRepository = new UserRepository();
        private EmployeesRepository employeesRepository = new EmployeesRepository();
        private DoctorRepository doctorRepository = new DoctorRepository();
        private PatientRepository patientRepository = new PatientRepository();
        private HealthRecordRepository healthRecordRepository = new HealthRecordRepository();

        public Boolean IsGuest;
        public int MinPasswordLength;


        public AbstractUser makeAbstractUser(AbstractUser abstractUser)
        {
            abstractUser = this.userRepository.makeAbstractUser(abstractUser);
            if (abstractUser.getUserType().Equals("employee"))
            {
                abstractUser = this.employeesRepository.insertAbstractEmployeeData((AbstractEmployee) abstractUser);

                abstractUser = this.doctorRepository.insertAbstractDoctorData((AbstractEmployee) abstractUser);
            }
            else
            {
                abstractUser = this.patientRepository.insertAbstractPatientData((AbstractPatient) abstractUser);

                abstractUser = this.healthRecordRepository.insertAbstractHealthRecordData((AbstractPatient) abstractUser);
            }

            return abstractUser;
        }


        public User GuestUser()
        {
            return this.userRepository.GuestUser();
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
            return this.userRepository.GetUserById(id);
        }

        public User GetUserByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return this.userRepository.GetAllUsers();
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

        #region marko_kt5
        public User UpdateUser(User user)
        {
            return this.userRepository.UpdateUser(user);
        }

        public void makeDoctorUser()
        {
            this.userRepository.makeDoctorUser();
        }

        public User newUser(User user)
        {
            return this.userRepository.NewUser(user);
        }
        #endregion

    }
}