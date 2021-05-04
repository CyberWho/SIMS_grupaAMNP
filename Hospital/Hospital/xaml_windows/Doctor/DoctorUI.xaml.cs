//using System.Data.OracleClient;
using System.Windows;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorUI.xaml
    /// </summary>
    public partial class DoctorUI : Window
    {
        private int id { set; get; } //ID kao radnik
        private int id_doc { set; get; } //ID kao doktor
        private OracleConnection con = null;
        public DoctorUI(int id)
        {
            InitializeComponent();
            this.id = id;
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            //MessageBox.Show(id.ToString());
            OracleCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "select doctor.id from employee, doctor where user_id = "+ id.ToString() + " and doctor.EMPLOYEE_ID =  employee.ID";// RIGHT JOIN employees ON users.ID == employees.USER_ID";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            id_doc = int.Parse(reader.GetString(0));
            //MessageBox.Show("id je: " + id + " id_doc je: " + id_doc);

        }

        private void ReturnOption (object sender, RoutedEventArgs e)
        {
            //logout
            Window s = new MainWindow();
            s.Show();
            con.Close();
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
    }
}
