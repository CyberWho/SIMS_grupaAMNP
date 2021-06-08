using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Model;

namespace Hospital.IRepository
{
    public interface IReminerRepo<T> : IRepo<T> where T : IEntity
    {
        ObservableCollection<T> GetAllPastRemindersByPatientId(int patientId);
        ObservableCollection<T> GetAllByAlarmTimeAndPatientId(DateTime alarmTime, int patientId);
        ObservableCollection<T> GetAllFutureRemindersByPatientId(int patientId);
        ObservableCollection<T> GetAllByPatientId(int patientId);
        ObservableCollection<T> GetAllByPersonalReminderId(int personalReminderId);

    }
}
