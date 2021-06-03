using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Model;
using Hospital.Repository;
using MedicalTreatment = Hospital.Model.MedicalTreatment;

namespace Hospital.ViewModel.Patient
{
    class ReportViewModel : BindableBase
    {
        private int userId;
        public ObservableCollection<Reminder> reminders { get; set; }
        private Window thisWindow;
        private MedicalTreatment medicalTreatment;
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string PatientName { get; set; }
        public string PatientSurname { get; set; }
        public string DrugName { get; set; }
        public ReportViewModel()
        {

        }

        public ReportViewModel(int userId, ObservableCollection<Reminder> reminders, MedicalTreatment medicalTreatment,
           DateTime startTime,DateTime endTime, Window thisWindow)
        {
            this.userId = userId;
            this.reminders = reminders;
            this.medicalTreatment = medicalTreatment;
            this.thisWindow = thisWindow;
            this.startTime = startTime;
            this.endTime = endTime;
            ShowReportInfo();
        }

        private void ShowReportInfo()
        {
            PatientName = new UserRepository().GetUserById(userId).Name;
            PatientSurname = new UserRepository().GetUserById(userId).Surname;
            DrugName = medicalTreatment.Drug.Name;

        }
    }
}
