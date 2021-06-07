using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IAppointmentRepo<T> : IRepo<T> where T : IEntity
    {
        T GetByDoctorIdAndTime(Doctor doctor, DateTime time);
        ObservableCollection<T> GetAllReserved();
        ObservableCollection<T> GetAllReservedWeekly();
        ObservableCollection<T> GetAllByDoctorId(int doctorId);
        ObservableCollection<T> GetAllReservedByPatientId(int patientId);
        Boolean DeleteAllReservedByPatientId(int patientId);
        T UpdateStartTime(T t, DateTime startTime);
        T UpdateRoom(T t, Room room);
        Boolean CheckForAppointmentsByPatientIdAndDoctorId(int patientId, int doctorId);
        Boolean CheckForAnyAppointmentsByPatientId(int patientId);
        T UpdateStatus(T t, AppointmentStatus appointmentStatus);
        ObservableCollection<T> getOccupiedDateTimesForDoctorPatienRoom(int doc_id, int patient_id, int room_id);

    }
}
