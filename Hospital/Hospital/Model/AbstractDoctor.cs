using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class AbstractDoctor : AbstractEmployee
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


        public string _employee_type { get; set; }
        public int _employee_id { get; set; }
        public int _room_id { get; set; }
        public int _specialization_id { get; set; }
        public int _doctor_id { get; set; }






        public override string getEmployeeType()
        {
            return "doctor";
        }

        public AbstractDoctor(int id, string username, string password, string name, string surname, string phone_number, string email, string jmbg, DateTime date_of_birth, int salary, int years_of_service, Role role, int room_id, int specialization_id, int employee_id, int doctor_id) : base(id, username, password, name, surname, phone_number, email, jmbg, date_of_birth, salary, years_of_service, role)
        {
            this._employee_type = "doctor";
            this._room_id = room_id;
            this._specialization_id = specialization_id;
            this._employee_id = employee_id;
            this._doctor_id = doctor_id;
        }

        public AbstractDoctor()
        {
        }


        #region  get, set
        public override string user_type
        {
            get { return _user_type; }
        }

        public override int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public override string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public override string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public override string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public override string surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public override string phone_number
        {
            get { return _phone_number; }
            set { _phone_number = value; }
        }

        public override string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public override string jmbg
        {
            get { return _jmbg; }
            set { _jmbg = value; }
        }

        public override DateTime date_of_birth
        {
            get { return _date_of_birth; }
            set { _date_of_birth = value; }
        }

        public int salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public int years_of_service
        {
            get { return _years_of_service; }
            set { _years_of_service = value; }
        }

        public Role role
        {
            get { return _role; }
            set { _role = value; }
        }

        public int room_id
        {
            get { return _room_id; }
            set { _room_id = value; }
        }

        public int specialization_id
        {
            get { return _specialization_id; }
            set { _specialization_id = value; }
        }

        #endregion
    }
}
