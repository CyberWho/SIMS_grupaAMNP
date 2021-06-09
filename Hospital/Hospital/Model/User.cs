/***********************************************************************
 * Module:  User.cs
 * Author:  Pedja
 * Purpose: Definition of the Class User
 ***********************************************************************/

using Hospital.Controller;

namespace Hospital.Model
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }

        public User(int id, string username, string password, string name, string surname, string phoneNumber, string eMail)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            EMail = eMail;
        }
        public User()
        {
        }

        public void CreateNewUser()
        {
            new UserController().newUser(this);
        }

        public void UpdateUser()
        {
            new UserController().UpdateUser(this);
        }

        public void DeleteUser()
        {
            new UserController().DeleteUserById(Id);
        }
    }
}