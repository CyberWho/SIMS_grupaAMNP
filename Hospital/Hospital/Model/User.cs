/***********************************************************************
 * Module:  User.cs
 * Author:  Pedja
 * Purpose: Definition of the Class User
 ***********************************************************************/

namespace Hospital.Model
{
    public class User
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
    }
}