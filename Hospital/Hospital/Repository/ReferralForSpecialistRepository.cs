/***********************************************************************
 * Module:  ReferralForSpecialistRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReferralForSpecialistRepository
 ***********************************************************************/

using System;
using Oracle.ManagedDataAccess.Client;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.Repository
{
    public class ReferralForSpecialistRepository
    {
        OracleConnection connection = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            connection = new OracleConnection(conString);
            try
            {
                connection.Open();

            }
            catch (Exception exp)
            {

            }
        }

        public System.Collections.ArrayList GetAllReferralsForSpecialist()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForSpecialist> GetAllReferralsForSpecialistByPatientId(int patientId)
        {
            //TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForSpecialist> GetReferralForSpecialistsByHealthRecordId(int healthRecordId)
        {
            setConnection();
            ObservableCollection<ReferralForSpecialist> referralForSpecialists = new ObservableCollection<ReferralForSpecialist>();
            OracleCommand command = connection.CreateCommand();
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

        public System.Collections.ArrayList GetAllReferralsForSpecialistByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteReferralForSpecialistById(int id)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM REFERRAL_FOR_SPECIALIST WHERE ID = :id";
            command.Parameters.Add("id", OracleDbType.Int32).Value = id.ToString();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        public Boolean DeleteReferralForSpecialistByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteReferralForSpecialistByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Model.ReferralForSpecialist UpdateReferralForSpecialist(Hospital.Model.ReferralForSpecialist referralForSpecialist)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.ReferralForSpecialist NewReferralForSpecialist(Hospital.Model.ReferralForSpecialist referralForSpecialist)
        {
            setConnection();

            OracleCommand command = connection.CreateCommand();
            command.CommandText = "insert into  REFERRAL_FOR_SPECIALIST (description, doctor_id, health_record_id, appointment_id) values " +
                              "('" + referralForSpecialist.Description + "'," + referralForSpecialist.doctor_id + "," + referralForSpecialist.doctor_id
                              + ", " + referralForSpecialist.appointment_id + ")";
            command.ExecuteReader();
            connection.Close();
            connection.Dispose();
            return referralForSpecialist;

        }

        public System.Collections.ArrayList GetAllActiveReferralsForSpecialistByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.ReferralForSpecialist GetReferralForSpecialistById(int id)
        {
            // TODO: implement
            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }

    }
}