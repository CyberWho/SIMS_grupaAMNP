using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface ITimeSlotRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllByDateAndDoctorId(DateTime date, int doctorId);
        ObservableCollection<T> GetAllByDatesAndDoctorId(DateTime startTime, DateTime endTime, int doctorId);
        ObservableCollection<T> GetAllFreeByDates(DateTime startTime, DateTime endTime);
        ObservableCollection<T> GetAllFreeBySpecializationId(int specializationId);
        ObservableCollection<T> GetAllFreeBySpecializationIdAfterCurrentTime(int specializationId, DateTime now);
        ObservableCollection<T> GetAllFreeByDoctorId(int doctorId);
        ObservableCollection<T> GetAllFreeForNext48HoursByDateAndDoctorId(DateTime date, int doctorId);
        T GetAppointmentTimeSlotByDateAndDoctorId(DateTime date, int doctorId);
        Boolean DeleteByWorkhoursId(int workHoursId);
        void GenerateTimeSlots();
        Boolean TakeTimeSlot(T t);
        Boolean FreeTimeSlot(T t);
    }
}
