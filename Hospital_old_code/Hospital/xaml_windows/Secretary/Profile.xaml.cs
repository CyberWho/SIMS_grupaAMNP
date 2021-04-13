using Hospital.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Window, INotifyPropertyChanged
    {

        #region NotifyProperties
        private User secretary;
        private string _username;
        private string _name;
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
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
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
                    OnPropertyChanged("Phone Number");
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


        public Profile(int id)
        {
            InitializeComponent();
            this.DataContext = this;

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            // dobijam konkretnog sekretara, on ce sigurno postojati jer je uspesno ulogovan i sigurno je sekretar
            cmd.CommandText = "SELECT * FROM users WHERE ID = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            secretary = new User();
            secretary.Id = int.Parse(reader.GetString(0));
            secretary.Username = reader.GetString(1);
            secretary.Password = reader.GetString(2);
            secretary.Name = reader.GetString(3);
            secretary.Surname = reader.GetString(4);
            secretary.PhoneNumber = reader.GetString(5);
            secretary.EMail = reader.GetString(6);

            Username = secretary.Username;
            NName = secretary.Name;
            Surname = secretary.Surname;
            PhoneNumber = secretary.PhoneNumber;
            Email = secretary.EMail;

            connection.Close();
            connection.Dispose();
        }

        private void Sacuvaj_nove_podatke(object sender, RoutedEventArgs e)
        {
            secretary.Username = Username;
            secretary.Name = NName;
            secretary.Surname = Surname;
            secretary.PhoneNumber = PhoneNumber;
            secretary.EMail = Email;

            Update(secretary);
        }

        public void Update(User uSecretary)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            int id = uSecretary.Id;
            cmd.CommandText = "UPDATE users set username=:username, " +
                "name=:name, " +
                "surname=:surname, " +
                "phone_number=:phone_number, " +
                "email=:email " +
                "WHERE ID = " + id;

            cmd.Parameters.Add("@username", secretary.Username);
            cmd.Parameters.Add("@name", secretary.Name);
            cmd.Parameters.Add("@surname", secretary.Surname);
            cmd.Parameters.Add("@phone_number", secretary.PhoneNumber);
            cmd.Parameters.Add("@email", secretary.EMail);

            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            this.Close();
        }
    }
}
