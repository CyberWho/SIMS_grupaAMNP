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
            setConnection();
            ObservableCollection<ReferralForClinicalTreatment> referralForClinicalTreatments = new ObservableCollection<ReferralForClinicalTreatment>();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM REFERRAL_FOR_CLINICAL_TREATMENT WHERE HEALTH_RECORD_ID = :health_record_id AND ACTIVE = 1";
            command.Parameters.Add("health_record_id", OracleDbType.Int32).Value = healthRecordId.ToString();
            OracleDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                ReferralForClinicalTreatment referralForClinicalTreatment = new ReferralForClinicalTreatment();
                referralForClinicalTreatment.Id = reader.GetInt32(0);
                referralForClinicalTreatment.IsActive = true;
                referralForClinicalTreatment.dateRange.StartTime = reader.GetDateTime(2);
                referralForClinicalTreatment.dateRange.EndTime = reader.GetDateTime(3);
                referralForClinicalTreatment.appointmentId = reader.GetInt32(4);
                referralForClinicalTreatment.healthRecordId = reader.GetInt32(5);
                referralForClinicalTreatment.Description = reader.GetString(6);
                referralForClinicalTreatments.Add(referralForClinicalTreatment);
            }

            connection.Close();
            return referralForClinicalTreatments;
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
      
      public Model.ReferralForClinicalTreatment NewReferralForClinicalTreatment(Model.ReferralForClinicalTreatment referralForClinicalTreatment)
      {
         // TODO: implement
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
   
   }
}