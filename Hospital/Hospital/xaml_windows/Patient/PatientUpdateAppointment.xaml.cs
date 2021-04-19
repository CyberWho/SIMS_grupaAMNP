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
using System.Configuration;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientUpdateAppointment.xaml
    /// </summary>
    public partial class PatientUpdateAppointment : Window
    {
        int id;
        Appointment appointment;
        ObservableCollection<TimeSlot> TimeSlots = new ObservableCollection<TimeSlot>();
        TimeSlotController timeSlotController = new TimeSlotController();
        public PatientUpdateAppointment(int id,Appointment appointment)
        {
            InitializeComponent();
            this.id = id;
            this.appointment = appointment;
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(id);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(id);
            s.Show();
            this.Close();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateMyGrid()
        {
            this.DataContext = this;
            int doctorId = int.Parse(doctor_id_txt.Text);
            DateTime dateTime = appointment.StartTime;
            TimeSlots = timeSlotController.GetFreeTimeSlotsForNext48HoursByDateAndDoctorId(dateTime, doctorId);
            DataTable dt = new DataTable();
            myGrid.DataContext = dt;
            myGrid.ItemsSource = TimeSlots;
        }

    }
}
