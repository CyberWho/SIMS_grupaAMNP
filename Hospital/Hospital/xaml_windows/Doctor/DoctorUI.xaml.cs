using Oracle.ManagedDataAccess.Client;
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

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorUI.xaml
    /// </summary>
    public partial class DoctorUI : Window
    {
        private int id { set; get; } //ID kao radnik
        private int id_doc { set; get; } //ID kao doktor
        public DoctorUI(int id)
        {
            InitializeComponent();
            this.id = id;

            //MessageBox.Show(id.ToString());
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "select doctor.id from employees, doctor where user_id = "+ id.ToString() + " and doctor.EMPLOYEE_ID =  employees.ID";// RIGHT JOIN employees ON users.ID == employees.USER_ID";
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
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window s = new Doctor_crud_appointments(id, id_doc);
            s.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window s = new Create_appointment(id, id_doc);
            s.Show();
            this.Close();
        }
    }
}
