using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IAllergyRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByUserId(int userId);
        ObservableCollection<T> GetAllByTypeId(int allergyTypeId);
        ObservableCollection<T> GetAllByHealthRecordId(int healthRecordId);
        Boolean DeleteByUserIdAndAllergyTypeId(int userId, int atId);
        Boolean DeleteAllByHealthRecordId(int healthRecordId);

    }
}
