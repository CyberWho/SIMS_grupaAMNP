/***********************************************************************
 * Module:  User.cs
 * Author:  Pedja
 * Purpose: Definition of the Class User
 ***********************************************************************/

using System;

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

    }
}