using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using Hospital.Repository;
using MedicalTreatment = Hospital.Model.MedicalTreatment;

namespace Hospital.ViewModel.Patient
{
    class ReportCalendarViewModel
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
        public MyICommand Print { get; set; }
        public string ReportGenerated { get; set; }

        public ReportCalendarViewModel()
        {

        }

        public ReportCalendarViewModel(int userId,MedicalTreatment medicalTreatment,DateTime startTime,DateTime endTime,Window thisWindow)
        {
            this.userId = userId;
            this.medicalTreatment = medicalTreatment;
            this.startTime = startTime;
            this.endTime = endTime;
            this.thisWindow = thisWindow;
            DateTime now = DateTime.Now;
            DateTime nowDate = now.Date;
            ReportGenerated = nowDate.ToString();
            Print = new MyICommand(OnPrint);
            ShowReportInfo();
        }
        private void OnPrint()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(thisWindow, "Izvestaj");
                }
            }
            finally
            {

            }
        }

        private void ShowReportInfo()
        {
            PatientName = new UserRepository().GetUserById(userId).Name;
            PatientSurname = new UserRepository().GetUserById(userId).Surname;
            DrugName = medicalTreatment.Drug.Name;

        }
    }
}
