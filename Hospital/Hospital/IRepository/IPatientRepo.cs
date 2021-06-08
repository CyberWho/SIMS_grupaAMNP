using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IPatientRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByUserId(int userId);
        bool CheckIfPatientHasBeenLogedById(int id);
        void UpdateHasBeenLogedById(int id);
        T New(T t, int guest = 0);
    }
}
