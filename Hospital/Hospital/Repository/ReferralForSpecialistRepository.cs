/***********************************************************************
 * Module:  ReferralForSpecialistRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReferralForSpecialistRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;
using Hospital.IRepository;

namespace Hospital.Repository
{
    public class ReferralForSpecialistRepository : IReferralForSpecialistRepo<ReferralForSpecialist>
    {
        
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            Globals.globalConnection = new OracleConnection(conString);
            try
            {
                Globals.globalConnection.Open();

            }
            catch (Exception exp)
            {

            }
        }

        public ObservableCollection<ReferralForSpecialist> GetAll()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForSpecialist> GetAllByPatientId(int patientId)
        {
            //TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForSpecialist> GetAllByHealthRecordId(int healthRecordId)
        {
            
            ObservableCollection<ReferralForSpecialist> referralForSpecialists = new ObservableCollection<ReferralForSpecialist>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REFERRAL_FOR_SPECIALIST WHERE HEALTH_RECORD_ID = :health_record_id";
            command.Parameters.Add("health_record_id", OracleDbType.Int32).Value = healthRecordId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var referralForSpecialist = ParseReferralForSpecialist(reader);
                referralForSpecialists.Add(referralForSpecialist);
            }
            return referralForSpecialists;
        }

        private static ReferralForSpecialist ParseReferralForSpecialist(OracleDataReader reader)
        {
            ReferralForSpecialist referralForSpecialist = new ReferralForSpecialist();
            referralForSpecialist.Id = reader.GetInt32(0);
            referralForSpecialist.Description = reader.GetString(1);
            referralForSpecialist.Doctor = new DoctorRepository().GetAppointmentDoctorById(reader.GetInt32(2));
            referralForSpecialist.HealthRecord = new HealthRecordRepository().GetById(reader.GetInt32(3));
            referralForSpecialist.Appointment = new AppointmentRepository().GetById(reader.GetInt32(4));
            return referralForSpecialist;
        }

        public ObservableCollection<ReferralForSpecialist> GetAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteById(int id)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "DELETE FROM REFERRAL_FOR_SPECIALIST WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            
            return true;
        }

        public Boolean DeleteAllByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.ReferralForSpecialist Update(Hospital.Model.ReferralForSpecialist referralForSpecialist)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.ReferralForSpecialist Add(Hospital.Model.ReferralForSpecialist referralForSpecialist)
        {
            

            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "insert into  REFERRAL_FOR_SPECIALIST (description, doctor_id, health_record_id, appointment_id) values " +
                              "('" + referralForSpecialist.Description + "'," + referralForSpecialist.doctor_id + "," + referralForSpecialist.doctor_id
                              + ", " + referralForSpecialist.appointment_id + ")";
            command.ExecuteReader();
            
            
            return referralForSpecialist;

        }

        public ObservableCollection<ReferralForSpecialist> GetAllActiveByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.ReferralForSpecialist GetById(int id)
        {
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "select * from referral_for_specialist where id = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            OracleDataReader reader = command.ExecuteReader();
            var referral = ParseReferralForSpecialist(reader);
            return referral;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}