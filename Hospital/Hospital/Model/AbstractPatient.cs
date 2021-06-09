using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class AbstractPatient : AbstractUser
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

        public int patient_id;
        public int health_record_id;

        public override string getUserType()
        {
            return "patient";
        }

        public AbstractPatient(int id, string username, string password, string name, string surname, string phone_number, string email, string jmbg, DateTime date_of_birth, int patient_id, int health_record_id)
        {
            this._user_type = "patient";
            this._id = id;
            this._username = username;
            this._password = password;
            this._name = name;
            this._surname = surname;
            this._phone_number = phone_number;
            this._email = email;
            this._jmbg = jmbg;
            this._date_of_birth = date_of_birth;

            this.patient_id = patient_id;
            this.health_record_id = health_record_id;
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
        #endregion
    }
}
