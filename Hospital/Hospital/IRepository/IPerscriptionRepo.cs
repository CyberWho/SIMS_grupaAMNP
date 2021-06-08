using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IPerscriptionRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByAnamnesisId(int anamnesisId);
        ObservableCollection<T> GetAllActive();
        ObservableCollection<T> GetAllActiveByAnamnesisId(int anamnesisId);
        Boolean DeleteAllByAnamnesisId(int anamnesisId);

    }
}
