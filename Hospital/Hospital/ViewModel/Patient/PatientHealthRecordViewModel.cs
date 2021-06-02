using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class PatientHealthRecordViewModel : BindableBase
    {
        private int userId;
        private bool tooltipChecked;
        private Window thisWindow;
        private HealthRecordController healthRecordController = new HealthRecordController();
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand ShowAllergies { get; set; }
        public MyICommand ShowReferrals { get; set; }
        public MyICommand ShowClinicalReferrals { get; set; }
        public MyICommand ShowPerscriptions { get; set; }
        public MyICommand ShowMedicalTreatments { get; set; }
        public MyICommand ShowAnamnesis { get; set; }
        public int HealthRecordId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public string PlaceOfBirth { get; set; }
        public Gender Gender { get; set; }

        public PatientHealthRecordViewModel()
        {

        }

        public PatientHealthRecordViewModel(int userId, bool tooltipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            this.thisWindow = thisWindow;
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            LogOut = new MyICommand(OnLogOut);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            ShowReferrals = new MyICommand(OnShowReferrals);
            ShowClinicalReferrals = new MyICommand(OnShowClinicalReferrals);
            ShowAllergies = new MyICommand(OnShowAllergies);
            ShowAnamnesis = new MyICommand(OnShowAnamnesis);
            ShowPerscriptions = new MyICommand(OnShowPerscriptions);
            ShowMedicalTreatments = new MyICommand(OnShowMedicalTreatments);
            ShowDoctors = new MyICommand(OnShowDoctors);
            ShowPatientInfo();
        }
        private void OnShowDoctors()
        {
            Window window = new DoctorsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowMedicalTreatments()
        {
            Window window = new MedicalTreatmentsView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowPerscriptions()
        {
            Window window = new PatientPerscriptionsView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowAnamnesis()
        {
            Window window = new PatientAnamnesisView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowAllergies()
        {
            Window window = new AllergiesView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowClinicalReferrals()
        {
            Window window = new ClinicalTreatmentReferralsView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnShowReferrals()
        {
            Window window = new PatientReferralsView(userId, GetHealthRecord().Id, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void ShowPatientInfo()
        {
            HealthRecord healthRecord = GetHealthRecord();
            HealthRecordId = healthRecord.Id;
            Gender = healthRecord.Gender;
            MaritalStatus = healthRecord.MaritalStatus;
            PlaceOfBirth = healthRecord.PlaceOfBirth.Name;
        }
        private HealthRecord GetHealthRecord()
        {
            Model.Patient patient = GetPatientByUserId(userId);
            HealthRecord healthRecord = GetHealthRecordByPatientId(patient.Id);
            return healthRecord;
        }
        private Model.Patient GetPatientByUserId(int userId)
        {
            return patientController.GetPatientByUserId(userId);
        }

        private HealthRecord GetHealthRecordByPatientId(int patientId)
        {
            return healthRecordController.GetHealthRecordByPatientId(patientId);
        }

        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, tooltipChecked);
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
            Window window = new PatientAppointmentsView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        public void OnHomePage()
        {
            Window window = new PatientUIView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
