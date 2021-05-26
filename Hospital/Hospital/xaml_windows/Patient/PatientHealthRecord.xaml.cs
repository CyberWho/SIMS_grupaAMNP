using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientHealthRecord.xaml
    /// </summary>
    public partial class PatientHealthRecord : Window, INotifyPropertyChanged
    {
        #region NotifyProperties
       
        private int _healthRecordId;
        private Gender _gender;
        private MaritalStatus _maritalStatus;
        private string _placeOfBirth;
        
        public int HealthRecordId
        {
            get
            {
                return _healthRecordId;
            }
            set
            {
                if (value != _healthRecordId)
                {
                    _healthRecordId = value;
                    OnPropertyChanged("HealthRecordId");
                }
            }
        }
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }
        public MaritalStatus MaritalStatus
        {
            get
            {
                return _maritalStatus;
            }
            set
            {
                if (value != _maritalStatus)
                {
                    _maritalStatus = value;
                    OnPropertyChanged("MaritalStatus");
                }
            }
        }
        public string PlaceOfBirth
        {
            get
            {
                return _placeOfBirth;
            }
            set
            {
                if (value != _placeOfBirth)
                {
                    _placeOfBirth = value;
                    OnPropertyChanged("PlaceOfBirth");
                }
            }
        }
       
        #endregion
        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        
        private int userId;
        private HealthRecordController healthRecordController = new HealthRecordController();
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        
        public PatientHealthRecord(int userId)
        {
            
            this.userId = userId;
            InitializeComponent();
            Model.Patient patient = GetPatientByUserId(userId);
            HealthRecord healthRecord = GetHealthRecordByPatientId(patient.Id);
            this.DataContext = this;
            HealthRecordId = healthRecord.Id;
            Gender = healthRecord.Gender;
            MaritalStatus = healthRecord.MaritalStatus;
            PlaceOfBirth = healthRecord.PlaceOfBirth.Name;
        }
        
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }

        private Model.Patient GetPatientByUserId(int userId)
        {
            return patientController.GetPatientByUserId(userId);
        }

        private HealthRecord GetHealthRecordByPatientId(int patientId)
        {
            return healthRecordController.GetHealthRecordByPatientId(patientId);
        }

        private void MojiUputi_Click(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new PatientReferrals(userId,healthRecord.Id);
            window.Show();
            this.Close();
        }

        private HealthRecord GetHealthRecord()
        {
            Model.Patient patient = GetPatientByUserId(userId);
            HealthRecord healthRecord = GetHealthRecordByPatientId(patient.Id);
            return healthRecord;
        }

        private void MojeAlergije_Click(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new Allergies(userId, healthRecord.Id);
            window.Show();
            this.Close();
        }

        private void MojeAnamneze_Click(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new PatientAnamnesis(userId, healthRecord.Id);
            window.Show();
            this.Close();
        }

       
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }

        private void MojiRecepti_Click(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new PatientPerscriptions(userId, healthRecord.Id);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }

        private void BolnickoLecenje_Click(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new ClinicalTreatmentReferrals(userId, healthRecord.Id);
            window.Show();
            this.Close();
        }

        private void Terapije_OnClick(object sender, RoutedEventArgs e)
        {
            var healthRecord = GetHealthRecord();
            var window = new MedicalTreatments(userId, healthRecord.Id);
            window.Show();
            this.Close();
        }
    }
}
