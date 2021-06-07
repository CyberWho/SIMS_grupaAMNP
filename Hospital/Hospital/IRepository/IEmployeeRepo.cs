using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IEmployeeRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByUserId(int userId);
        int GetUserIdById(int id);
        ObservableCollection<T> GetAllByRoleId(int roleId);
        int GetIdByDoctorId(int doctorId);
    }
}
