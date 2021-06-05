/***********************************************************************
 * Module:  UserService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.UserService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;

namespace Hospital.Service
{
    public class UserService
    {
        public UserRepository userRepository = new UserRepository();
        private HealthRecordRepository healthRecordRepository = new HealthRecordRepository();
        private PatientRepository patientRepository = new PatientRepository();

        public Boolean IsGuest;
        public int MinPasswordLength;

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
            int patient_id = this.patientRepository.GetPatientByUserId(id).Id;

            return (this.healthRecordRepository.DeleteHealthRecordByPatientId(patient_id) &&
                    this.patientRepository.DeletePatientById(patient_id) &&
                    this.userRepository.DeleteUserById(id));
        }

        public Boolean DeleteUserByUsername(String username)
        {
            return this.userRepository.DeleteUserByUsername(username);
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