using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IAnamnesisRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByHealthRecordId(int healthRecordId);
        Boolean DeleteAllByHealthRecordId(int healthRecordId);

    }
}
