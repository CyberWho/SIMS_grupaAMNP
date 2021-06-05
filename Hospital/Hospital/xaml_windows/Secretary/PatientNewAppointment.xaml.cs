using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using Hospital.Controller;
using System.Collections.ObjectModel;
using Xceed.Wpf.Toolkit.Core.Converters;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientNewAppointment.xaml
    /// </summary>
    public partial class PatientNewAppointment : Window
    {
        int id;
        private int user_id;
        private bool is_user;
        ObservableCollection<Model.Doctor> Doctors = new ObservableCollection<Model.Doctor>();
        DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController();
        int priority = 0;

        public PatientNewAppointment(int id, bool isUserId = false)
        {
            if (isUserId)
            {
                this.user_id = id;
                this.is_user = true;
            }
            else
            {
                this.id = id;
            }
            InitializeComponent();
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
                    Window s;
                    if (this.is_user)
                    {
                        int patient_id = this.patientController.GetPatientByUserId(this.user_id).Id;
                        s = new PatientNewAppointmentRecommendations(patient_id, startDate, endDate, doctorId, priority);
                    }
                    else
                    {
                        s = new PatientNewAppointmentRecommendations(id, startDate, endDate, doctorId, priority);
                    }
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
