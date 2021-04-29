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
        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            reminders = reminderController.GetAllFutureRemindersByPatientId(patient.Id);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (Reminder reminder in reminders)
            {
                if ((reminder.AlarmTime - now).Minutes == 0)
                {
                    MessageBox.Show(reminder.Description);
                }
            }
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
            var window = new PatientReferrals(userId,healthRecord.Id);
            window.Show();
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
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }

        private void MojiRecepti_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
