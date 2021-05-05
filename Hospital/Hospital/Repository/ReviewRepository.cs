using System;
using System.Collections.ObjectModel;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;


namespace Hospital.Repository
{
    class ReviewRepository
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
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO REVIEW (RATE,DESCRIPTION,PATIENT_ID,DOCTOR_ID) VALUES (:rate,:description,:patient_id,:doctor_id)";
            command.Parameters.Add("rate", OracleDbType.Int32).Value = review.Rate.ToString();
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = review.Description;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = review.patient.Id;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = review.doctor.Id;
            int executer = command.ExecuteNonQuery();
            connection.Close();
            return review;
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

    }
}
