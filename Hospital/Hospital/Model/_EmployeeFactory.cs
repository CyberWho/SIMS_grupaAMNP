using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class _EmployeeFactory : _UserFactory
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
        // employee fields
        private int _salary;
        private int _years_of_service;
        private Role _role;

        public _EmployeeFactory(int id, string username, string password, string name, string surname, string phone_number, string email, string jmbg, DateTime date_of_birth)
        {
            this._id = id;
            this._username = username;
            this._password = password;
            this._name = name;
            this._surname = surname;
            this._phone_number = phone_number;
            this._jmbg = jmbg;
            this._date_of_birth = date_of_birth;

            this._salary = salary_calculator();
            this._years_of_service = 0;
            this._role = new Role(1, "Doctor");
        }

        private int salary_calculator()
        {
            int salary = 0;




            return salary;
        }

        public override AbstractUser getAbstractUser()
        {
            return new AbstractEmployee(_id, _username, _password, _name, _surname, _phone_number, _email, _jmbg, _date_of_birth, _salary, _years_of_service, _role);
        }
    }
}
