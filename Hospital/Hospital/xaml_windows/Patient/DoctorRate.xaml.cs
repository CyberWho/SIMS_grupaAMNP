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
        PatientController patientController = new PatientController();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        public DoctorRate(int userId,int doctorId)
        {
            InitializeComponent();
            this.userId = userId;
            this.doctorId = doctorId;
            this.DataContext = this;
            Model.Doctor doctor = new Model.Doctor();
            doctor = new DoctorController().GetDoctorById(doctorId);
            Id = doctor.Id;
            NName = doctor.User.Name;
            Surname = doctor.User.Surname;
            Specialization = doctor.specialization.Type;
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
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void OceniDoktora_Click(object sender, RoutedEventArgs e)
        {
            Review review = new Review();
            review.Rate = int.Parse(rate_txt.Text);
            review.Description = description_txt.Text;
            review.patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new DoctorController().GetDoctorById(doctorId);
            review.doctor = doctor;
            new ReviewController().AddReview(review);
            MessageBox.Show("Uspesno ste ocenili doktora " + doctor.User.Name + " " + doctor.User.Surname);
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }

    }
}
