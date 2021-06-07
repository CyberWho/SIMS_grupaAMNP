using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IDoctorRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByUserId(int userId);
        T GetWorkHoursDoctorById(int id);
        ObservableCollection<T> GetAllGeneralPurposeDoctors();
        T GetAppointmentDoctorById(int id);
        ObservableCollection<T> GetAllBySpecializationId(int specializationId);
        ObservableCollection<T> SearchByNameAndSurname(string identifyString);
        List<int> GetAllUsedRoomsId();

    }
}
