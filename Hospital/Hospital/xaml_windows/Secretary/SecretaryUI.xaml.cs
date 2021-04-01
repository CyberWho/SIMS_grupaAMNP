using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
using Oracle.ManagedDataAccess.Client;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryUI.xaml
    /// </summary>
    public partial class SecretaryUI : Window, INotifyPropertyChanged
    {
        int id;
        int current_user_id;

        public System.Collections.IEnumerable Patients { get; set; }

        User secretary { get; set; }
        #region NotifyProperties
        private string _username;
        private string _nname;
        private string _surname;
        private string _phonenumber;
        private string _email;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        public string NName
        {
            get
            {
                return _nname;
            }
            set
            {
                if (value != _nname)
                {
                    _nname = value;
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
        public string PhoneNumber
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                if (value != _phonenumber)
                {
                    _phonenumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
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



        public SecretaryUI(int id)
        {
            InitializeComponent();
            this.DataContext = this;
            this.id = id;

            ObservableCollection<User> users = new ObservableCollection<User>();
            ObservableCollection<Model.Patient> patients = new ObservableCollection<Model.Patient>();

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();

            /*md.CommandText = "SELECT users.id, users.username, users.name, users.surname, users.phone_number, users.email " +
                "FROM users " +
                "MINUS SELECT users.id, users.username, users.name, users.surname, users.phone_number, users.email " +
                "FROM users, employees, role where users.ID = employees.USER_ID and employees.ROLE_ID = role.ID";*/

            cmd.CommandText = "SELECT users.id, users.username, users.name, users.surname, users.phone_number, users.email, " +
                "patient.jmbg, patient.date_of_birth " +
                "FROM users, patient " +
                "WHERE users.id = patient.user_id";


            /*OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            MessageBox.Show(reader.GetString(6));*/

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            dataGridPatients.DataContext = dt;

            connection.Close();

            foreach (DataRow row in dt.Rows)
            {
                User nUser = new User
                {
                    Id = int.Parse(row["id"].ToString()),
                    Username = row["username"].ToString(),
                    Name = row["name"].ToString(),
                    Surname = row["surname"].ToString(),
                    PhoneNumber = row["phone_number"].ToString(),
                    EMail = row["email"].ToString()
                };
                users.Add(nUser);
                /*patients.Add(new Model.Patient
                {
                    DateOfBirth = DateTime.Parse(row["date_of_birth"].ToString()),
                    JMBG = row["jmbg"].ToString(),
                    User = nUser
                });*/
            }

            dataGridPatients.ItemsSource = users;

        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var p = new Profile(id);
            p.Show();

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            // dobijam konkretnog sekretara, on ce sigurno postojati jer je uspesno ulogovan i sigurno je sekretar
            cmd.CommandText = "SELECT * FROM users WHERE ID = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string username = reader.GetString(1);

            secretary = new User();
            secretary.Id = int.Parse(reader.GetString(0));
            secretary.Username = reader.GetString(1);
            secretary.Password = reader.GetString(2);
            secretary.Name = reader.GetString(3);
            secretary.Surname = reader.GetString(4);
            secretary.PhoneNumber = reader.GetString(5);
            secretary.EMail = reader.GetString(6);

            connection.Close();
            connection.Dispose();
        }

        private void Obrisi_karton(object sender, RoutedEventArgs e)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();

            connection.Open();

            cmd.CommandText = "DELETE FROM patient where user_id = " + current_user_id;
            int patientRowsAffected = cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM users WHERE id = " + current_user_id;
            int userRowsAffected = cmd.ExecuteNonQuery();

            MessageBox.Show("Uspesno izmenjeno " + userRowsAffected.ToString() + " redova u bazi!");

            connection.Close();
            connection.Dispose();
        }

        private void Izmeni_karton(object sender, RoutedEventArgs e)
        {
            Window sp = new PatientUpdate(current_user_id);
            sp.Show();

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT * FROM users WHERE ID = " + current_user_id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            User uUser = new User();

            uUser.Username = Username;
            uUser.Name = NName;
            uUser.Surname = Surname;
            uUser.PhoneNumber = PhoneNumber;
            uUser.EMail = Email;

            Update(uUser);

            connection.Close();
            connection.Dispose();
            // KADA SE KORISTI LISTVIEW NE KREIRA SE NPR NEW ROOM OBJEKAT NEGO SAMO OBJEKAT NEW {} I TO JE TO
        }

        private void Dodaj_karton(object sender, RoutedEventArgs e)
        {
            User nUser = new User();

            nUser.Username = Username;
            nUser.Name = NName;
            nUser.Surname = Surname;
            nUser.PhoneNumber = PhoneNumber;
            nUser.EMail = Email;

            MessageBox.Show(nUser.Name);

        }

        public void Update(User uUser)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE users set username=:username, " +
                "name=:name, " +
                "surname=:surname, " +
                "phone_number=:phone_number, " +
                "email=:email " +
                "WHERE ID = " + current_user_id;

            cmd.Parameters.Add("@username", uUser.Username);
            cmd.Parameters.Add("@name", uUser.Name);
            cmd.Parameters.Add("@surname", uUser.Surname);
            cmd.Parameters.Add("@phone_number", uUser.PhoneNumber);
            cmd.Parameters.Add("@email", uUser.EMail);

            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            //MessageBox.Show("Uspesno izmenjeno " + rowsAffected.ToString() + " redova u bazi!");

            connection.Close();
            connection.Dispose();

            this.Close();
        }

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = dataGridPatients.SelectedCells[0];
            var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
            current_user_id = int.Parse(content.ToString());

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT * FROM users WHERE id = " + current_user_id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            Username = reader.GetString(1);
            NName = reader.GetString(3);
            Surname = reader.GetString(4);
            PhoneNumber = reader.GetString(5);
            Email = reader.GetString(6);

            connection.Close();
            connection.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT date_of_birth FROM patient where id = 1";

            connection.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            MessageBox.Show(reader.GetString(0));

            connection.Close();
            connection.Dispose();
        
        }
    }
}
