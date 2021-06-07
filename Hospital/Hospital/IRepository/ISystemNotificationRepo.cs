using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface ISystemNotificationRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllSystemWideSystemNotifications();
        ObservableCollection<T> GetAllByUserId(int userId);
        Boolean DeleteAllByUserId(int userId);

    }
}
