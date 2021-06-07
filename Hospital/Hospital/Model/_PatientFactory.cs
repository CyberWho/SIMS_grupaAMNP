using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class _PatientFactory : _UserFactory
    {
        private string _user_type;
        private int _id;
        private string _username;
        private string _password;
        private string _name;
        private string _surname;
        private string _phone_number;
        private string _email;
        private string _jmbg;
        private DateTime _date_of_birth;

        public _PatientFactory(int id, string username, string password, string name, string surname, string phone_number, string email, string jmbg, DateTime date_of_birth)
        {
            this._id = id;
            this._username = username;
            this._password = password;
            this._name = name;
            this._surname = surname;
            this._phone_number = phone_number;
            this._email = email;
            this._jmbg = jmbg;
            this._date_of_birth = date_of_birth;
        }

        public override AbstractUser getAbstractUser()
        {
            return new AbstractPatient(_id, _username, _password, _name, _surname, _phone_number, _email, _jmbg, _date_of_birth);
        }
    }
}
