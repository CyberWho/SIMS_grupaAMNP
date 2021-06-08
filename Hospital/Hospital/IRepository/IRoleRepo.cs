using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IRoleRepo<T> : IRepo<T> where T : IEntity
    {

    }
}
