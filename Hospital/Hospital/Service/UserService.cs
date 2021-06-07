/***********************************************************************
 * Module:  UserService.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Service.UserService
 ***********************************************************************/

using Hospital.Model;
using Hospital.Repository;
using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;

namespace Hospital.Service
{
    public class UserService
    {
        public IUserRepo<User> userRepository;

        public Boolean IsGuest;
        public int MinPasswordLength;

        public UserService()
        {
            userRepository = new UserRepository();
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
            return this.userRepository.GetById(id);
        }

        public User GetUserByUsername(String username)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<User> GetAllUsers()
        {
            return this.userRepository.GetAll();
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
            return this.userRepository.Update(user);
        }

        public void makeDoctorUser()
        {
            this.userRepository.MakeDoctorUser();
        }

        public User newUser(User user)
        {
            return this.userRepository.NewUser(user);
        }
        #endregion

    }
}