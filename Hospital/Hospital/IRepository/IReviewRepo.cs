using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IReviewRepo<T> : IRepo<T> where  T : IEntity
    {
        ObservableCollection<T> GetAllByDoctorId(int doctorId);
        ObservableCollection<T> GetAllHospitalReviews();

    }
}
