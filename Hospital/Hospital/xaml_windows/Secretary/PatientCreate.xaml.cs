using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Hospital.Controller;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class PatientCreate : Window
    {

        int user_id;
        int patient_id;
        PatientLogsController patientLogsController = new PatientLogsController();
        #region NotifyProperties
        private string _dob;
        private string _jmbg;
        private string _id_address;
        public string Dob
        {
            get
            {
                return _dob;
            }
            set
            {
                if (value != _dob)
                {
                    _dob = value;
                    OnPropertyChanged("Dob");
                }
            }
        }
        public string Jmbg
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public string Id_address
        {
            get
            {
                return _id_address;
            }
            set
            {
                if (value != _id_address)
                {
                    _id_address = value;
                    OnPropertyChanged("Id_address");
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

        public PatientCreate(int current_user_id)
        {
            InitializeComponent();
            this.DataContext = this;
            this.user_id = current_user_id;
        }

        private void Sacuvaj_podatke(object sender, RoutedEventArgs e)
        {
            Window s = new SecretaryUI(user_id);
            s.Show();

            Model.Patient nPatient = new Model.Patient();

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();

            cmd.CommandText = "SELECT MAX(id) FROM patient";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int max_id = int.Parse(reader.GetString(0));
            patient_id = max_id + 1;

            cmd.CommandText = "SELECT MAX(id) FROM users";
            reader = cmd.ExecuteReader();
            reader.Read();
            this.user_id = int.Parse(reader.GetString(0));

            cmd.CommandText = "SELECT * FROM users WHERE id = " + this.user_id;
            reader = cmd.ExecuteReader();
            reader.Read();


            User user = new User
            {
                Id = int.Parse(reader.GetString(0)),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                Name = reader.GetString(3),
                Surname = reader.GetString(4),
                PhoneNumber = reader.GetString(5),
                EMail = reader.GetString(6)
            };

            nPatient.User = user;

            cmd.CommandText = "SELECT * FROM address, city, state WHERE address.id = " + int.Parse(Id_address) + " AND address.CITY_ID = city.ID AND city.STATE_ID = state.ID";
            reader = cmd.ExecuteReader();
            reader.Read();

            State state = new State
            {
                Id = int.Parse(reader.GetString(8)),
                Name = reader.GetString(9)
            };

            City city = new City
            {
                Id = int.Parse(reader.GetString(4)),
                Name = reader.GetString(5),
                PostalCode = reader.GetString(6),
                State = state
            };

            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                
                City = city
            };

            nPatient.Address = address;
            nPatient.JMBG = Jmbg;
            string dob = Dob; 
            string[] split3 = (Dob.ToString().Split(' '))[0].Split('/');
            DateTime dt = new DateTime(int.Parse(split3[2]), int.Parse(split3[1]), int.Parse(split3[0]), 0, 0, 0);

            cmd.CommandText = "INSERT INTO patient (id, jmbg, date_of_birth, address_id, user_id) " +
                "VALUES (" + patient_id + ", " + nPatient.JMBG + ", to_date('" + Dob.ToString() + "', 'DD/MM/YYYY HH24:MI:SS')" + ", " + address.Id + ", " + this.user_id + ")";
            cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            //ovo je dodato
            patientLogsController.AddPatientLogs(patient_id);
            this.Close();

        }
    }
}
