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
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientAppointments.xaml
    /// </summary>
    public partial class PatientAppointments : Window
    {
        int id;
        AppointmentController appointmentController = new AppointmentController();
        PatientController patientController = new PatientController();
        ObservableCollection<Appointment> Appointments = new ObservableCollection<Appointment>();
        Appointment app = new Appointment();
        Appointment Appointment = new Appointment();

        public PatientAppointments(int id)
        {
            
            InitializeComponent();
            this.id = id;
            this.DataContext = this;
            updateDataGrid();
        }

        
        private int getPatientId()
        {

            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(id);
            return patient.Id;
        }

        private void updateDataGrid()
        {

            this.DataContext = this;
            int patientId = getPatientId();
            Appointments = appointmentController.GetAllByAppointmentsPatientId(patientId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Appointments;



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

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            
            
            updateDataGrid();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            int appointmentId = int.Parse(app_id_txt.Text);
            appointmentController.CancelAppointmentById(appointmentId);
            updateDataGrid();
        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientNewAppointment(id);
            s.Show();
            this.Close();
        }

        
        
          
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            
        }
    }
}
