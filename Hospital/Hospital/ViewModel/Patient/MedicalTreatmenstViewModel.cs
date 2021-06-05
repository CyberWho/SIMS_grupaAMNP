using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class MedicalTreatmenstViewModel : BindableBase
    {
        private int userId;
        private int healthRecordId;
        public bool ToolTipChecked { get; set; }
        private Window thisWindow;
        private DispatcherTimerForReminder dispatcherTimerForReminder;

        private AnamnesisController anamnesisController = new AnamnesisController();
        public ObservableCollection<Model.MedicalTreatment> medicalTreatments { get; set; }
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand Undo { get; set; }
        public MyICommand Help { get; set; }
        public MyICommand GenerateReport { get; set; }
        public string reportStartTime { get; set; }
        public string reportEndTime { get; set; }
        public DateTime minDate { get; set; }
        public DateTime maxDate { get; set; }
        public MedicalTreatment SelectedItem { get; set; }
        private string _reportError;
        public string ReportError
        {
            get { return _reportError; }
            set
            {
                SetProperty(ref _reportError, value);
            }
        }
        public MedicalTreatmenstViewModel()
        {

        }

        public MedicalTreatmenstViewModel(int userId, int healthRecordId, bool toolTipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            this.ToolTipChecked = toolTipChecked;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            InstanceMyICommands();
            ShowMedicalTreatments();
            minDate = DateTime.Now;
            maxDate = DateTime.Now;
        }

        private void InstanceMyICommands()
        {
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            Undo = new MyICommand(OnHealthRecord);
            ShowDoctors = new MyICommand(OnShowDoctors);
            MyReminders = new MyICommand(OnMyReminders);
            ShowNotifications = new MyICommand(OnShowNotifications);
            Help = new MyICommand(OnHelp);
            GenerateReport = new MyICommand(OnGenerateReport);
        }

        private void OnGenerateReport()
        {
            if (!DataValidation()) return;
            ObservableCollection<Reminder> reminders = GenerateRemindersForMedicalTreatment(SelectedItem, reportStartTime, reportEndTime);
            Window window = new ReportView(userId, reminders, SelectedItem, DateTime.Parse(reportStartTime),
                DateTime.Parse(reportEndTime));
            window.Show();
        }

        private ObservableCollection<Reminder> GenerateRemindersForMedicalTreatment(MedicalTreatment selectedItem, string reportStartTime, string reportEndTime)
        {
            DateTime startDateTime = DateTime.Parse(reportStartTime);
            DateTime endDateTime = DateTime.Parse(reportEndTime);
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            DateTime alarmTime = selectedItem.dateRange.StartTime;
            while (startDateTime <= endDateTime)
            {
                Reminder reminder = new Reminder();
                DateTime startTime = SelectedItem.dateRange.StartTime;
                reminder.AlarmTime = alarmTime;
                reminder.Name = "Konzumacija leka";
                reminder.Description = "Za sat vremena popijte lek " + selectedItem.Drug.Name;
                startDateTime = startDateTime.AddHours(selectedItem.Period);
                alarmTime = alarmTime.AddHours(SelectedItem.Period);
                reminders.Add(reminder);
            }
            return reminders;
        }

        private bool SelectionValidation()
        {
            if (SelectedItem == null)
            {
                this.ReportError = "Potrebno je da označite terapiju!";
                return false;
            }

            return true;
        }
        private bool DataValidation()
        {
            if (!SelectionValidation()) return false;
            minDate = SelectedItem.dateRange.StartTime;
            maxDate = SelectedItem.dateRange.EndTime;
            if (!StartTimeVal()) return false;
            if (!EndTimeVal()) return false;
            DateTime startDateTime = DateTime.Parse(reportStartTime);
            DateTime endDateTime = DateTime.Parse(reportEndTime);
            if (!ValidateDates(startDateTime, endDateTime)) return false;
            if (!StartTimeValidation(startDateTime)) return false;
            if (!EndTimeValidation(endDateTime)) return false;
            return true;
        }

        private bool EndTimeVal()
        {
            if (reportEndTime == null)
            {
                this.ReportError = "Morate uneti datum završetka izveštaja!";
                return false;

            }

            return true;
        }

        private bool StartTimeVal()
        {
            if (reportStartTime == null)
            {
                this.ReportError = "Morate uneti datum početka izveštaja!";
                return false;

            }

            return true;
        }

        private bool EndTimeValidation(DateTime endDateTime)
        {
            if (endDateTime > SelectedItem.dateRange.EndTime)
            {
                this.ReportError = "Datum završetka izveštaja ne može biti veći od kraja terapije!";
                return false;
            }

            return true;
        }

        private bool StartTimeValidation(DateTime startDateTime)
        {
            if (startDateTime < SelectedItem.dateRange.StartTime)
            {
                this.ReportError = "Datum početka izveštaja ne može biti manji od početka terapije";
                return false;
            }

            return true;
        }

        private bool ValidateDates(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime > endDateTime)
            {
                this.ReportError = "Krajnji datum ne može biti veći od početnog!";
                return false;
            }

            return true;
        }

        private void OnHelp()
        {
            string str = "PatientHealthRecordHelp";
            HelpProvider.ShowHelp(str, thisWindow);

        }
        private void OnShowNotifications()
        {
            Window window = new NotificationsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnMyReminders()
        {
            Window window = new RemindersView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void ShowMedicalTreatments()
        {
            medicalTreatments = anamnesisController.GetAllMedicalTreatmentsByHealthRecordId(healthRecordId);
        }

        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnLogOut()
        {
            Window window = new MainWindow();
            window.Show();
            thisWindow.Close();
        }

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }

        public void OnHomePage()
        {
            Window window = new PatientUIView(userId, ToolTipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
