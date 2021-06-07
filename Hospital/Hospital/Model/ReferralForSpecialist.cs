/***********************************************************************
 * Module:  ReferralForSpecialist.cs
 * Author:  Nikola
 * Purpose: Definition of the Class Hospital.Model.ReferralForSpecialist
 ***********************************************************************/

namespace Hospital.Model
{
    public class ReferralForSpecialist : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public Doctor Doctor { get; set; }
        public int doctor_id { get; set; }
        public HealthRecord HealthRecord { get; set; }
        public int healthRecord_id { get; set; }
        public Appointment Appointment { get; set; }
        public int appointment_id { get; set; }
        public ReferralForSpecialist(int id, string description, Doctor doctor, HealthRecord healthRecord, Appointment appointment)
        {
            Id = id;
            Description = description;
            Doctor = doctor;
            HealthRecord = healthRecord;
            Appointment = appointment;
        }

        public ReferralForSpecialist()
        {
        }
    }
}