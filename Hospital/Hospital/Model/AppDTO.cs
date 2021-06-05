using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class AppDTO
    {
        public int doctor_id { get; set; }
        public string doctor_name { get; set; }
        public string doctor_surname { get; set; }
        public int room_id { get; set; }

        public AppDTO()
        {

        }

        public AppDTO(int did, string dname, string dsurname, int rid)
        {
            this.doctor_id = did;
            this.doctor_name = dname;
            this.doctor_surname = dsurname;
            this.room_id = rid;
        }




    }
}
