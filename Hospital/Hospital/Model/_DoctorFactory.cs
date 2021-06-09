using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class _DoctorFactory : _EmployeeFactory
    {
        private int _room_id;
        private int _specialization_id;
        private int _doctor_id;
        private int _employee_id;



        public _DoctorFactory(int id, string username, string password, string name, string surname, string phone_number, string email, string jmbg, DateTime date_of_birth, Role role, int room_id, int specialization_id, int employee_id, int doctor_id) : base(id, username, password, name, surname, phone_number, email, jmbg, date_of_birth, role)
        {
            this._room_id = room_id;
            this._specialization_id = specialization_id;

            this._employee_id = employee_id;
            this._doctor_id = doctor_id;
        }

        public override AbstractUser getAbstractUser()
        {
            throw new NotImplementedException();
        }
    }
}
