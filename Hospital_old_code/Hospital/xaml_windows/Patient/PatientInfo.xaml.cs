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

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        int id;
        OracleConnection con = null;
        public PatientInfo(int id)
        {
            this.setConnection();
            InitializeComponent();
            this.id = id;
        }

        private void setConnection()
        {
            String conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            con = new OracleConnection(conString);
            try
            {
                con.Open();
            } catch(Exception exp)
            {

            }
        }

        private void updateDataGrid()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT USERS.USERNAME,USERS.NAME,USERS.SURNAME,USERS.PHONE_NUMBER,USERS.EMAIL,PATIENT.JMBG FROM USERS,PATIENT WHERE USERS.ID = :id AND USERS.ID = PATIENT.USER_ID";
            cmd.Parameters.Add(new OracleParameter("id",id));
            cmd.CommandType = CommandType.Text;
           
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            myDataGrid.ItemsSource = dt.DefaultView;
            dr.Close();

        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(id);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(id);
            s.Show();
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }
    }
}
