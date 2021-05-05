//using System.Data.OracleClient;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using Hospital.Controller;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorUI.xaml
    /// </summary>
    public partial class DoctorUI : Window
    {
        private int id { set; get; } //ID kao radnik
        private int id_doc { set; get; } //ID kao doktor
        private DoctorController doctorController = new DoctorController();

        public DoctorUI(int id)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = doctorController.GetDoctorByUserId(id).Id;
            //MessageBox.Show("id: " + id + " id_doc" + id_doc);
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            //logout
            Window s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window s = new Doctor_crud_appointments(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateAppointment(object sender, RoutedEventArgs e)
        {
            Window s = new Create_appointment(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToSchedule(object sender, RoutedEventArgs e)
        {
            Window s = new Schedule(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToPatientSearch(object sender, RoutedEventArgs e)
        {
            Window s = new SearchPatient(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToDrugOperation(object sender, RoutedEventArgs e)
        {
            Window s = new DrugOperations(id, id_doc);
            s.Show();
            this.Close();
        }
    }
}
