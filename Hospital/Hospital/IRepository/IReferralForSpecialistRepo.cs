using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IReferralForSpecialistRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<ReferralForSpecialist> GetAllByPatientId(int patientId);
        ObservableCollection<ReferralForSpecialist> GetAllByHealthRecordId(int healthRecordId);
        ObservableCollection<ReferralForSpecialist> GetAllByDoctorId(int doctorId);
        ObservableCollection<ReferralForSpecialist> GetAllActiveByPatientId(int patientId);
        Boolean DeleteAllByPatientId(int patientId);
        Boolean DeleteAllByDoctorId(int doctorId);

    }
}
