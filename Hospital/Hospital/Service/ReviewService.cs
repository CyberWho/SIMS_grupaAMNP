using System;
using System.Collections.ObjectModel;
using Hospital.IRepository;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    class ReviewService
    {
        private IReviewRepo<Review> reviewRepository;
        public ReviewService()
        {
            reviewRepository = new ReviewRepository();
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

        public Review AddReview(Review review)
        {
            return reviewRepository.Add(review);
        }

        public Boolean DeleteReviewById(int reviewId)
        {
            // TODO: implement
            return false;
        }

    }
}
