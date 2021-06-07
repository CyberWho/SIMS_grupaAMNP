/***********************************************************************
 * Module:  ReferralForClinicalTreatmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReferralForClinicalTreatmentRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using Hospital.IRepository;
using Hospital.Model;

namespace Hospital.Repository
{
    public class ReferralForClinicalTreatmentRepository : IReferralForClinicalTreatmentRepo<ReferralForClinicalTreatment>
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public ObservableCollection<ReferralForClinicalTreatment> GetAll()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveByHealthRecordId(int healthRecordId)
        {
            setConnection();
            ObservableCollection<ReferralForClinicalTreatment> referralForClinicalTreatments = new ObservableCollection<ReferralForClinicalTreatment>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REFERRAL_FOR_CLINICAL_TREATMENT WHERE HEALTH_RECORD_ID = :health_record_id AND ACTIVE = 1";
            command.Parameters.Add("health_record_id", OracleDbType.Int32).Value = healthRecordId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var referralForClinicalTreatment = ParseReferralForClinicalTreatment(reader);
                referralForClinicalTreatments.Add(referralForClinicalTreatment);
            }

            connection.Close();
            return referralForClinicalTreatments;
        }

        private static ReferralForClinicalTreatment ParseReferralForClinicalTreatment(OracleDataReader reader)
        {
            ReferralForClinicalTreatment referralForClinicalTreatment = new ReferralForClinicalTreatment();
            referralForClinicalTreatment.Id = reader.GetInt32(0);
            referralForClinicalTreatment.IsActive = true;
            referralForClinicalTreatment.dateRange.StartTime = reader.GetDateTime(2);
            referralForClinicalTreatment.dateRange.EndTime = reader.GetDateTime(3);
            referralForClinicalTreatment.appointmentId = reader.GetInt32(4);
            referralForClinicalTreatment.healthRecordId = reader.GetInt32(5);
            referralForClinicalTreatment.Description = reader.GetString(6);
            return referralForClinicalTreatment;
        }

        public Model.ReferralForClinicalTreatment GetById(int id)
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteById(int id)
        {
            // TODO: implement
            return false;
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

        public Model.ReferralForClinicalTreatment Update(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Model.ReferralForClinicalTreatment Add(Model.ReferralForClinicalTreatment referral)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO referral_for_clinical_treatment (active, start_time, end_time, appointment_id, health_record_id, description) VALUES " +
                "('false', " + referral.dateRange.StartTime + ", " + referral.dateRange.EndTime + ", "
                + referral.appointmentId + ", " + referral.healthRecordId + ", '" + referral.Description + "')";
            /*
            INSERT INTO referral_for_clinical_treatment (active, start_time, end_time ,appointment_id, health_record_id, description) VALUES
           (0, '20-JUN-1999', '20-JUN-1999' ,1, 1, 'AAA')
            */
            try
            {
                command.ExecuteNonQuery();
                return referral;
            }
            catch (Exception exp)
            {
                Trace.WriteLine(exp.ToString());
                return null;
            }

            return null;
        }

        public int GetLastId()
        {
            // TODO: implement
            return 0;
        }


        public int GetMaxTakenBeds(int room_id, DateRange dateRange)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "select count(*) from(" +
                                  "select * from clinical_treatment where not start_date < :DATE_TIME " +
                                  "or not end_date < :DATE_TIME1 union " +
                                  "select * from clinical_treatment where not start_date > :DATE_TIME2 " +
                                  "or not end_date > :DATE_TIME3" +
                                  ") group by room_id having room_id = " + room_id;

            command.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = dateRange.StartTime;
            command.Parameters.Add("DATE_TIME1", OracleDbType.Date).Value = dateRange.StartTime;
            command.Parameters.Add("DATE_TIME2", OracleDbType.Date).Value = dateRange.EndTime;
            command.Parameters.Add("DATE_TIME3", OracleDbType.Date).Value = dateRange.EndTime;


            OracleDataReader reader = command.ExecuteReader();
            int ret = 0;

            if (reader.Read())
                ret = reader.GetInt32(0);
            connection.Close();
            connection.Dispose();
            return ret;
        }

        public ClinicalTreatment Create (ClinicalTreatment clinicalTreatment)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "insert into clinical_treatment(health_record_id, room_id, start_date, end_date) " +
                                  "values (" + clinicalTreatment.HealthRecordId + ", " + clinicalTreatment.RoomId + 
                                  ", :DATE_TIME1 , :DATE_TIME2)";
            command.Parameters.Add("DATE_TIME1", OracleDbType.Date).Value = clinicalTreatment.dateRange.StartTime;
            command.Parameters.Add("DATE_TIME2", OracleDbType.Date).Value = clinicalTreatment.dateRange.EndTime;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
            return clinicalTreatment;
        }

    }
}