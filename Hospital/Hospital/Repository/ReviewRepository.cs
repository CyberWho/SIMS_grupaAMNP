using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;


namespace Hospital.Repository
{
    class ReviewRepository
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

        public Review NewReview(Review review)
        {
            
            OracleCommand command = Globals.globalConnection.CreateCommand();
            command.CommandText = "INSERT INTO REVIEW (RATE,DESCRIPTION,PATIENT_ID,DOCTOR_ID,REVIEW_DATE) VALUES (:rate,:description,:patient_id,:doctor_id,:review_date)";
            command.Parameters.Add("rate", OracleDbType.Int32).Value = review.Rate.ToString();
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = review.Description;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = review.patient.Id;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = review.doctor.Id;
            command.Parameters.Add("review_date", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            int executer = command.ExecuteNonQuery();
            
            return review;
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

    }
}
