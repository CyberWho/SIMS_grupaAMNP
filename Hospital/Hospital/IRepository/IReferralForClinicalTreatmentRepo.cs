using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IReferralForClinicalTreatmentRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByPatientId(int patientId);
        ObservableCollection<T> GetAllByDoctorId(int doctorId);
        ObservableCollection<T> GetAllByRoomId(int roomId);
        ObservableCollection<T> GetAllActiveByHealthRecordId(int healthRecordId);
        Boolean DeleteAllByPatientId(int patientId);
        Boolean DeleteAllByDoctorId(int doctorId);
        int GetMaxTakenBeds(int room_id, DateRange dateRange);
        ClinicalTreatment Create(ClinicalTreatment clinicalTreatment);
    }
}
