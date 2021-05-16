using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for DoctorRate.xaml
    /// </summary>
    public partial class DoctorRate : Window, INotifyPropertyChanged
    {
        #region NotifyProperties
        private int _doctorId;
        private string _name;
        private string _surname;
        private string _specialization;
        public int Id
        {
            get
            {
                return _doctorId;
            }
            set
            {
                if (value != _doctorId)
                {
                    _doctorId= value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string NName
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("NName");
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public string Specialization
        {
            get
            {
                return _specialization;
            }
            set
            {
                if (value != _specialization)
                {
                    _specialization = value;
                    OnPropertyChanged("Specialization");
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
        private int doctorId;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private ReminderController reminderController = new ReminderController();
        public DoctorRate(int userId,int doctorId)
        {
            InitializeComponent();
            this.userId = userId;
            this.doctorId = doctorId;
            this.DataContext = this;
            ShowDoctorInformations(doctorId);
        }

        private void ShowDoctorInformations(int doctorId)
        {
            Model.Doctor doctor = new Model.Doctor();
            doctor = new DoctorController().GetDoctorById(doctorId);
            Id = doctor.Id;
            NName = doctor.User.Name;
            Surname = doctor.User.Surname;
            Specialization = doctor.specialization.Type;
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
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void OceniDoktora_Click(object sender, RoutedEventArgs e)
        {
            
            Model.Patient patient= patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new DoctorController().GetDoctorById(doctorId);
            Review review = new Review(int.Parse(rate_txt.Text), description_txt.Text, patient, doctor);
            new ReviewController().AddReview(review);
            MessageBox.Show("Uspesno ste ocenili doktora " + doctor.User.Name + " " + doctor.User.Surname);
           
            this.Close();
        }

    }
}
