using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class FreeDays : IEntity
    {
        public int id { get; set; }
        public FreeDaysStatus status { get; set; }
        public DateRange dateRange { get; set; }

        public string description { get; set; }

        public Doctor doctor { get; set; }
        public int doctor_id { get; set; }

        public FreeDays()
        {

        }

        public FreeDays(int id, FreeDaysStatus status, DateRange dateRange, string description, Doctor doctor = null,
            int doctor_id = 0)
        {
            this.id = id;
            this.status = status;
            this.dateRange = dateRange;
            this.description = description;

            if (doctor != null)
            {
                this.doctor = doctor;
            }

            if (doctor_id != 0)
            {
                this.doctor_id = doctor_id;
            }
        }
    }
}
