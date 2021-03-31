using Hospital.xaml_windows.Doctor;
using Hospital.xaml_windows.Manager;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OracleConfiguration.TnsAdmin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Oracle\network\admin\DBTIM1";
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "SELECT * FROM users";// RIGHT JOIN employees ON users.ID == employees.USER_ID";
            OracleDataReader reader = cmd.ExecuteReader();

            string user = Username.Text;
            string pass = Password.Password;

            //vidim da li je ispravno uneto ako da uzmem id i trazim sta je
            int id = -1;
            while (reader.Read())
            {
                if (user == reader.GetString(1) & pass == reader.GetString(2))
                {
                    //MessageBox.Show("IMA BOGA");
                    id = int.Parse(reader.GetString(0));
                    MessageBox.Show(id.ToString());
                }
            }
            if (id == -1)
            {
                MessageBox.Show("Pogresan unos");
                return;
            }
            //Select users.ID FROM users MINUS SELECT users.ID FROM users, employees, role where users.ID = employees.USER_ID and employees.ROLE_ID = role.ID;
            //id pacijenata
            //SELECT users.ID, users.role FROM users, employees, role where users.ID = employees.USER_ID and employees.ROLE_ID = role.ID;
            //id radnika sa role
            bool isPatient = false;
            string uloga = "";
            cmd.CommandText = "select users.ID, role.roletype FROM users, employees, role where users.ID = employees.USER_ID and employees.ROLE_ID = role.ID";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (id == int.Parse(reader.GetString(0)))
                {
                    uloga = reader.GetString(1);
                }
            }
            if (uloga == "")
                isPatient = true;
            MessageBox.Show(isPatient.ToString() + " " + user);
            //sada znamo koji role koji id da li pacijent
            con.Close();
            con.Dispose();
            //paljenje drugih prozora
            Window s;
            switch (uloga)
            {
                case "":
                    s = new PatientUI();
                    s.Show();
                    break;
                case "Doctor":
                    s = new DoctorUI();
                    s.Show();
                    break;
                case "Manager":
                    s = new ManagerUI();
                    s.Show();
                    break;
                case "Secretary":
                    s = new SecretaryUI(id);
                    s.Show();
                    break;
            }
            this.Close();

        }
    }
}
