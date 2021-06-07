using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface ISpecializationRepo<T> : IRepo<T> where T : IEntity
    {
        int GetByType(string type);
        ObservableCollection<T> GetAll(bool withoutGPD);
    }
}
