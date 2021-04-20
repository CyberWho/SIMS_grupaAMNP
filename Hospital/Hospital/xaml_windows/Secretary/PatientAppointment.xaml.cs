using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientAppointment.xaml
    /// </summary>
    public partial class PatientAppointment : Window, INotifyPropertyChanged
    {
        int patient_id;
        PatientController patientController = new PatientController();
        AppointmentController appointmentController = new AppointmentController();
        ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();

        #region NotifyProperties
        private string _room_id;
        private string _doctor_id;
        private string _doctor_name;
        private string _doctor_surname;
        public string RoomId
        {
            get
            {
                return _room_id;
            }
            set
            {
                if (value != _room_id)
                {
                    _room_id = value;
                    OnPropertyChanged("RoomId");
                }
            }
        }
        public string DoctorId
        {
            get
            {
                return _doctor_id;
            }
            set
            {
                if (value != _doctor_id)
                {
                    _doctor_id = value;
                    OnPropertyChanged("DoctorId");
                }
            }
        }
        public string DoctorName
        {
            get
            {
                return _doctor_name;
            }
            set
            {
                if (value != _doctor_name)
                {
                    _doctor_name = value;
                    OnPropertyChanged("DoctorName");
                }
            }
        }
        public string DoctorSurname
        {
            get
            {
                return _doctor_surname;
            }
            set
            {
                if (value != _doctor_surname)
                {
                    _doctor_surname = value;
                    OnPropertyChanged("DoctorSurname");
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

        public PatientAppointment(int id)
        {
            InitializeComponent();
            this.patient_id = id;
            update();
        }
        private void update()
        {
            this.DataContext = this;
            appointments = this.appointmentController.GetAllByAppointmentsPatientId(patient_id);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = appointments;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            int appointmentId = int.Parse(app_id_txt.Text);
            appointment = appointmentController.GetAppointmentById(appointmentId);
            var hours = (appointment.StartTime - DateTime.Now).TotalHours;

            if (hours > 24)
            {
                var s = new PatientUpdateAppointment(this.patient_id, appointmentId);
                s.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nije moguce promeniti vreme odrzavanja termina jer je ostalo manje od 24h");
            }
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            int appointmentId = int.Parse(app_id_txt.Text);
            if (appointmentController.CancelAppointmentById(appointmentId))
            {
                update();
            }


        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientNewAppointment(patient_id);
            s.Show();
            this.Close();
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
