using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IRepo<T> where T : IEntity
    {
        T GetById(int id);
        ObservableCollection<T> GetAll();
        T Add(T t);
        bool DeleteById(int id);
        T Update(T t);
        int GetLastId();
    }
}
