using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;


namespace Hospital.Repository
{
    class ReviewRepository
    {
        OracleConnection con = null;
        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();

            }
            catch (Exception exp)
            {

            }
        }
        public ObservableCollection<Review> GetAllReviews()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Review> GetAllReviewsByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Review> GetAllHospitalReviews()
        {
            // TODO: implement
            return null;
        }

        public Hospital.Model.Review NewReview(Hospital.Model.Review review)
        {
            setConnection();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO REVIEW (RATE,DESCRIPTION,PATIENT_ID,DOCTOR_ID) VALUES (:rate,:description,:patient_id,:doctor_id)";
            cmd.Parameters.Add("rate", OracleDbType.Int32).Value = review.Rate.ToString();
            cmd.Parameters.Add("description", OracleDbType.Varchar2).Value = review.Description;
            cmd.Parameters.Add("patient_id", OracleDbType.Int32).Value = review.patient.Id;
            cmd.Parameters.Add("doctor_id", OracleDbType.Int32).Value = review.doctor.Id;
            int executer = cmd.ExecuteNonQuery();
            con.Close();
            return review;
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

    }
}
