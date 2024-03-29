using System;
using System.Collections;

namespace Hospital.Model
{
    public class Patient : IEntity
    {

        public int Id { get; set; }
        public int addres_id { get; set; }
        public int user_id { get; set; }
        public string JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }
        


        public User User { get; set; }
        public ArrayList Appointments;

        /// <pdGenerated>default getter</pdGenerated>
        public ArrayList GetAppointments()
        {
            if (Appointments == null)
                Appointments = new ArrayList();
            return Appointments;
        }

        /// <pdGenerated>default setter</pdGenerated>
        public void SetAppointments(ArrayList newAppointments)
        {
            RemoveAllAppointments();
            foreach (Appointment oAppointment in newAppointments)
                AddAppointments(oAppointment);
        }

        /// <pdGenerated>default New</pdGenerated>
        public void AddAppointments(Appointment newAppointment)
        {
            if (newAppointment == null)
                return;
            if (this.Appointments == null)
                this.Appointments = new ArrayList();
            if (!this.Appointments.Contains(newAppointment))
            {
                this.Appointments.Add(newAppointment);
                newAppointment.SetPatient(this);
            }
        }

        /// <pdGenerated>default Remove</pdGenerated>
        public void RemoveAppointments(Appointment oldAppointment)
        {
            if (oldAppointment == null)
                return;
            if (this.Appointments != null)
                if (this.Appointments.Contains(oldAppointment))
                {
                    this.Appointments.Remove(oldAppointment);
                    oldAppointment.SetPatient((Patient)null);
                }
        }

        /// <pdGenerated>default removeAll</pdGenerated>
        public void RemoveAllAppointments()
        {
            if (Appointments != null)
            {
                ArrayList tmpAppointments = new ArrayList();
                foreach (Appointment oldAppointment in Appointments)
                    tmpAppointments.Add(oldAppointment);
                Appointments.Clear();
                foreach (Appointment oldAppointment in tmpAppointments)
                    oldAppointment.SetPatient((Patient)null);
                tmpAppointments.Clear();
            }
        }
        public Address Address { get; set; }
        public HealthRecord HealthRecord { get; set; }

        public Patient(int id, string jMBG, DateTime dateOfBirth, User user, ArrayList appointments, Address address, HealthRecord healthRecord)
        {
            Id = id;
            JMBG = jMBG;
            DateOfBirth = dateOfBirth;
            User = user;
            Appointments = appointments;
            Address = address;
            HealthRecord = healthRecord;
        }

        public Patient(int id, string JMBG, DateTime dateOfBirth, User user, Address address)
        {
            this.Id = id;
            this.JMBG = JMBG;
            this.DateOfBirth = dateOfBirth;
            this.User = user;
            this.user_id = user.Id;
            this.Address = address;
            this.addres_id = address.Id;
        } 

        public Patient(int id, int addres_id, int user_id, string jMBG, DateTime dateOfBirth, User user, ArrayList appointments, Address address, HealthRecord healthRecord)
        {
            Id = id;
            this.addres_id = addres_id;
            this.user_id = user_id;
            JMBG = jMBG;
            DateOfBirth = dateOfBirth;
            User = null;
            Appointments = appointments;
            Address = null;
            HealthRecord = healthRecord;
        }

        public Patient()
        {
        }
    }
}