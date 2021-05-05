using System;
using System.Collections.ObjectModel;
using Hospital.Model;

namespace Hospital.Controller
{
    class ReviewController
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
            return reviewService.AddReview(review);
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

        public Service.ReviewService reviewService = new Service.ReviewService();

    }
}
