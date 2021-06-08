using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital.Model
{
    public abstract class AbstractUser
    {
        public abstract string user_type { get; }
        public abstract int id { get; set; }
        public abstract string username { get; set; }
        public abstract string password { get; set; }
        public abstract string name { get; set; }
        public abstract string surname { get; set; }
        public abstract string phone_number { get; set; }
        public abstract string email { get; set; }
        public abstract string jmbg { get; set; }
        public abstract DateTime date_of_birth { get; set; }


        public abstract string getUserType();

    }
}
