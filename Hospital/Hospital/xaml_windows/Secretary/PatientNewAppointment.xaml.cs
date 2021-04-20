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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientNewAppointment.xaml
    /// </summary>
    public partial class PatientNewAppointment : Window
    {
        int id;
        ObservableCollection<Hospital.Model.Doctor> Doctors = new ObservableCollection<Hospital.Model.Doctor>();
        DoctorController doctorController = new DoctorController();
        int priority = 0;

        public PatientNewAppointment(int id)
        {
            InitializeComponent();
            this.id = id;
            this.DataContext = this;
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            this.DataContext = this;

            Doctors = doctorController.GetAllGeneralPurposeDoctors();
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Doctors;
        }

        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = int.Parse(doc_id_txt.Text);
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            if (endDate <= startDate)
            {
                MessageBox.Show("Nije moguce da oznacite vremenski interval gde je krajnji datum manji od pocetnog!");
            }
            else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if (dayDifference > 5)
                {
                    MessageBox.Show("Interval ne sme biti duzi od 5 dana!");
                }
                else
                {
                    var s = new PatientNewAppointmentRecommendations(id, startDate, endDate, doctorId, priority);
                    s.Show();
                    this.Close();
                }
            }
        }
        private void DoktorPrioritet_Checked(object sender, RoutedEventArgs e)
        {
            this.priority = 0;
        }

        private void VremePrioritet_Checked(object sender, RoutedEventArgs e)
        {
            this.priority = 1;
        }

        private void myDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
