using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Service
{
    class ReviewService
    {
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

        public Hospital.Model.Review AddReview(Hospital.Model.Review review)
        {
            return reviewRepository.NewReview(review);
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

        public Hospital.Repository.ReviewRepository reviewRepository = new Repository.ReviewRepository();
    }
}
