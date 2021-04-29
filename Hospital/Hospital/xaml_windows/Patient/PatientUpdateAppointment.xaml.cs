﻿using System;
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
using System.Configuration;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;
using System.ComponentModel;

namespace Hospital.xaml_windows.Patient
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
        private int userId;
        int appointmentId;
        ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        AppointmentController appointmentController = new AppointmentController();
        TimeSlotController timeSlotController = new TimeSlotController();
        Appointment appointment = new Appointment();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        ReminderController reminderController = new ReminderController();
        PatientController patientController = new PatientController();
        PatientLogsController patientLogsController = new PatientLogsController();
        public PatientUpdateAppointment(int userId,int appointmentId)
        {
            InitializeComponent();
            this.userId = userId;
            this.appointmentId = appointmentId;
            
            appointment = appointmentController.GetAppointmentById(appointmentId);
            AppointmentStatus = appointment.Status;
            AppointmentType = appointment.Type;
            AppointmentId = appointment.Id;
            DurationInMinutes = appointment.DurationInMinutes;
            DoctorId = appointment.doctor.Id;
            RoomId = appointment.room.Id;
            NName = appointment.doctor.User.Name;
            Surname = appointment.doctor.User.Surname;
            updateMyGrid();
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

        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
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

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            
           
            TimeSlot timeSlot = new TimeSlot();
            int timeSlotId = int.Parse(timeslot_id_txt.Text);
            timeSlot = timeSlotController.GetTimeSlotById(timeSlotId);
            appointmentController.ChangeStartTime(appointment, timeSlot.StartTime);
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            if (patientLogsController.IncrementLogCounterByPatientId(patient.Id) == false)
            {
                MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
                appointmentController.DeleteAppointmentByPatientId(patient.Id);
                var windowLogOut = new MainWindow();
                windowLogOut.Show();
                this.Close();
                return;
            }
            
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }

        private void updateMyGrid()
        {
            this.DataContext = this;
           
            Appointment appointment = new Appointment();
            
            appointment = appointmentController.GetAppointmentById(appointmentId);
            int doctorId = appointment.doctor.Id;
            DateTime dateTime = appointment.StartTime;
            TimeSlots = timeSlotController.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(dateTime, doctorId);
            DataTable dt = new DataTable();
            myGrid.DataContext = dt;
            myGrid.ItemsSource = TimeSlots;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
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
    }
}
