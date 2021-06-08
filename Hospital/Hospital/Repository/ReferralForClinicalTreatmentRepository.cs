/***********************************************************************
 * Module:  ReferralForClinicalTreatmentRepository.cs
 * Author:  Dell
 * Purpose: Definition of the Class Hospital.Repository.ReferralForClinicalTreatmentRepository
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;
using Hospital.Model;

namespace Hospital.Repository
{
    public class ReferralForClinicalTreatmentRepository
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
                Trace.WriteLine(exp.ToString());
            }
        }
        public System.Collections.ArrayList GetAllReferralsForClinicalTreatment()
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public System.Collections.ArrayList GetAllReferralsForClinicalTreatmentByRoomId(int roomId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<ReferralForClinicalTreatment> GetAllActiveReferralsForClinicalTreatmentByHealthRecordId(int healthRecordId)
        {
            
            ObservableCollection<ReferralForClinicalTreatment> referralForClinicalTreatments = new ObservableCollection<ReferralForClinicalTreatment>();
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "SELECT * FROM REFERRAL_FOR_CLINICAL_TREATMENT WHERE HEALTH_RECORD_ID = :health_record_id AND ACTIVE = 1";
            command.Parameters.Add("health_record_id", OracleDbType.Int32).Value = healthRecordId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var referralForClinicalTreatment = ParseReferralForClinicalTreatment(reader);
                referralForClinicalTreatments.Add(referralForClinicalTreatment);
            }

            
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

        public Model.ReferralForClinicalTreatment GetReferralForClinicalTreatmentById()
        {
            // TODO: implement
            return null;
        }

        public Boolean DeleteReferralForClinicalTreatmentById(int id)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteReferralForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return false;
        }

        public Boolean DeleteReferralForClinicalTreatmentByDoctorId(int doctorId)
        {
            // TODO: implement
            return false;
        }

        public Model.ReferralForClinicalTreatment UpdateReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
        {
            // TODO: implement
            return null;
        }

        public Model.ReferralForClinicalTreatment NewReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referral)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
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

        public System.Collections.ArrayList GetAllActiveReferralsForClinicalTreatmentByPatientId(int patientId)
        {
            // TODO: implement
            return null;
        }

        public int GetMaxTakenBeds(int room_id, DateRange dateRange)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
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
            
            
            return ret;
        }

        public ClinicalTreatment createClinicalTreatment (ClinicalTreatment clinicalTreatment)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "insert into clinical_treatment(health_record_id, room_id, start_date, end_date) " +
                                  "values (" + clinicalTreatment.HealthRecordId + ", " + clinicalTreatment.RoomId + 
                                  ", :DATE_TIME1 , :DATE_TIME2)";
            command.Parameters.Add("DATE_TIME1", OracleDbType.Date).Value = clinicalTreatment.dateRange.StartTime;
            command.Parameters.Add("DATE_TIME2", OracleDbType.Date).Value = clinicalTreatment.dateRange.EndTime;

            command.ExecuteNonQuery();
            
            
            return clinicalTreatment;
        }

    }
}