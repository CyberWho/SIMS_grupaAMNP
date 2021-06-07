using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IFreeDaysRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByDoctorId(int doctorId);
        ObservableCollection<T> GetAllPending();
        T Approve(T t);
        T Reject(T t);
    }
}
