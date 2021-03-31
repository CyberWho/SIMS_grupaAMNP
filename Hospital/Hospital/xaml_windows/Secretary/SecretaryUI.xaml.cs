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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryUI.xaml
    /// </summary>
    public partial class SecretaryUI : Window, INotifyPropertyChanged
    {
        int id;

        public event PropertyChangedEventHandler PropertyChanged;

        User secretary { get; set; } 

        public SecretaryUI(int id)
        {
            InitializeComponent();
            this.id = id;
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

        }

        private void Izmeni_karton(object sender, RoutedEventArgs e)
        {

        }

        private void Dodaj_karton(object sender, RoutedEventArgs e)
        {

        }
    }
}
