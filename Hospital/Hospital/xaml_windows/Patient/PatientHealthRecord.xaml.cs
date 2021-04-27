using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Model;
using Hospital.Controller;
using System.ComponentModel;
using System.Data;

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
        HealthRecordController healthRecordController = new HealthRecordController();
        PatientController patientController = new PatientController();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        public PatientHealthRecord(int userId)
        {
            
            this.userId = userId;
            InitializeComponent();
            Hospital.Model.Patient patient = GetPatientByUserId(userId);
            HealthRecord healthRecord = GetHealthRecordByPatientId(patient.Id);
            this.DataContext = this;
            HealthRecordId = healthRecord.Id;
            Gender = healthRecord.Gender;
            MaritalStatus = healthRecord.MaritalStatus;
            PlaceOfBirth = healthRecord.PlaceOfBirth.Name;
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(userId);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(userId);
            s.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(userId);
            s.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientHealthRecord(userId);
            s.Show();
            this.Close();
        }

        private Hospital.Model.Patient GetPatientByUserId(int userId)
        {
            return patientController.GetPatientByUserId(userId);
        }

        private HealthRecord GetHealthRecordByPatientId(int patientId)
        {
            return healthRecordController.GetHealthRecordByPatientId(patientId);
        }

        private void MojiUputi_Click(object sender, RoutedEventArgs e)
        {
            Hospital.Model.Patient patient = GetPatientByUserId(userId);
            HealthRecord healthRecord = GetHealthRecordByPatientId(patient.Id);
            var s = new PatientReferrals(userId,healthRecord.Id);
            s.Show();
            this.Close();
        }

        private void MojeAlergije_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MojeAnamneze_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MojeTerapije_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(userId);
            s.Show();
            this.Close();
        }

        private void MojiRecepti_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
