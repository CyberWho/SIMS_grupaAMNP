using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientUpdateAppointment.xaml
    /// </summary>
    public partial class PatientUpdateAppointment : Window, INotifyPropertyChanged
    {
        #region NotifyProperties
        private AppointmentStatus _appointmentStatus;
        private AppointmentType _appointmentType;
        private int _appointmentId;
        private string _name;
        private string _surname;
        private int _durationInMinutes;
        private int _doctorId;
        private int _roomId;
        public AppointmentStatus AppointmentStatus
        {
            get
            {
                return _appointmentStatus;
            }
            set
            {
                if (value != _appointmentStatus)
                {
                    _appointmentStatus = value;
                    OnPropertyChanged("AppointmentStatus");
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
        public AppointmentType AppointmentType
        {
            get
            {
                return _appointmentType;
            }
            set
            {
                if (value != _appointmentType)
                {
                    _appointmentType = value;
                    OnPropertyChanged("AppointmentType");
                }
            }
        }
        public int AppointmentId
        {
            get
            {
                return _appointmentId;
            }
            set
            {
                if (value != _appointmentId)
                {
                    _appointmentId = value;
                    OnPropertyChanged("AppointmentId");
                }
            }
        }

        public int DurationInMinutes
        {
            get
            {
                return _durationInMinutes;
            }
            set
            {
                if (value != _durationInMinutes)
                {
                    _durationInMinutes = value;
                    OnPropertyChanged("DurationInMinutes");
                }
            }
        }
        public int DoctorId
        {
            get
            {
                return _doctorId;
            }
            set
            {
                if (value != _doctorId)
                {
                    _doctorId = value;
                    OnPropertyChanged("DoctorId");
                }
            }
        }
        public int RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                if (value != _roomId)
                {
                    _roomId = value;
                    OnPropertyChanged("RoomId");
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
        int id;
        int appointmentId;
        ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        AppointmentController appointmentController = new AppointmentController();
        TimeSlotController timeSlotController = new TimeSlotController();
        Appointment appointment = new Appointment();

        public PatientUpdateAppointment(int id, int appointmentId)
        {
            InitializeComponent();
            this.id = id;
            this.appointmentId = appointmentId;

            appointment = appointmentController.GetAppointmentById(appointmentId);
            AppointmentStatus = appointment.Status;
            AppointmentType = appointment.Type;
            AppointmentId = appointment.Id;
            DurationInMinutes = appointment.DurationInMinutes;
            DoctorId = appointment.doctor.Id;
            RoomId = (int)appointment.room.Id;
            NName = appointment.doctor.User.Name;
            Surname = appointment.doctor.User.Surname;
            updateMyGrid();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        { 
            TimeSlot timeSlot = new TimeSlot();
            int timeSlotId = int.Parse(timeslot_id_txt.Text);
            timeSlot = timeSlotController.GetTimeSlotById(timeSlotId);
            new Executer(appointment, new Modify(),
                new AppointmentCommand(appointment, AppointmentAction.UPDATE, timeSlot.StartTime));
            var s = new PatientAppointment(id);
            s.Show();
            this.Close();
        }

        private void updateMyGrid()
        {
            this.DataContext = this;
            // int doctorId = int.Parse(doctor_id_txt.Text);
            Appointment appointment = new Appointment();

            appointment = appointmentController.GetAppointmentById(appointmentId);
            int doctorId = appointment.doctor.Id;
            DateTime dateTime = appointment.StartTime;
            TimeSlots = timeSlotController.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(dateTime, doctorId);
            DataTable dt = new DataTable();
            myGrid.DataContext = dt;
            myGrid.ItemsSource = TimeSlots;
        }

    }
}