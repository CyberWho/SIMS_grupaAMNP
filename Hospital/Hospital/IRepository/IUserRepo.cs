using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IUserRepo<T> : IRepo<T> where T : IEntity
    {
        T GuestUser();
        T GetByUsername(string username);
        Boolean DeleteByUsername(string username);
        void MakeDoctorUser();
        T NewUser(T t, int guest = 0);
        AbstractUser makeAbstractUser(AbstractUser abstractUser);
    }
}
