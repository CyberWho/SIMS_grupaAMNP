using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;


namespace Hospital.Repository
{
    class ReviewRepository : IReviewRepo<Review>
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
        public ObservableCollection<Review> GetAll()
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Review> GetAllByDoctorId(int doctorId)
        {
            // TODO: implement
            return null;
        }

        public ObservableCollection<Review> GetAllHospitalReviews()
        {
            // TODO: implement
            return null;
        }

        public Review Add(Review review)
        {
            setConnection();
            OracleCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO REVIEW (RATE,DESCRIPTION,PATIENT_ID,DOCTOR_ID,REVIEW_DATE) VALUES (:rate,:description,:patient_id,:doctor_id,:review_date)";
            command.Parameters.Add("rate", OracleDbType.Int32).Value = review.Rate.ToString();
            command.Parameters.Add("description", OracleDbType.Varchar2).Value = review.Description;
            command.Parameters.Add("patient_id", OracleDbType.Int32).Value = review.patient.Id;
            command.Parameters.Add("doctor_id", OracleDbType.Int32).Value = review.doctor.Id;
            command.Parameters.Add("review_date", OracleDbType.Date).Value = DateTime.Now.AddMilliseconds(-DateTime.Now.Millisecond);
            int executer = command.ExecuteNonQuery();
            connection.Close();
            return review;
        }

        public Boolean DeleteById(int reviewId)
        {
            // TODO: implement
            return false;
        }

        public Review GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Review Update(Review t)
        {
            throw new NotImplementedException();
        }

        public int GetLastId()
        {
            throw new NotImplementedException();
        }
    }
}
