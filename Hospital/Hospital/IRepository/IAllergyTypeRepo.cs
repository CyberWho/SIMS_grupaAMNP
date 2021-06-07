using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IAllergyTypeRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByType(string type);
        ObservableCollection<T> GetAllMissingTypesByUserId(int userId);
        ObservableCollection<T> GetAllByHealthRecordId(int healthRecordId);
    }
}
