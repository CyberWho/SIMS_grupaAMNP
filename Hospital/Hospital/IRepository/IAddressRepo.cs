using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IAddressRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByPatientId(int patientId);

    }
}
