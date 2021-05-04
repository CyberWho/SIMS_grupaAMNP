using System;
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

        public Review AddReview(Review review)
        {
            return reviewRepository.NewReview(review);
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

        public Repository.ReviewRepository reviewRepository = new Repository.ReviewRepository();
    }
}
