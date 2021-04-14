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
    /// Interaction logic for PatientNewAppointment.xaml
    /// </summary>
    public partial class PatientNewAppointment : Window
    {
        int id;
        OracleConnection con = null;
        public PatientNewAppointment(int id)
        {
            setConnection();
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

            }
            catch (Exception exp)
            {

            }
        }

        private int getPatientId()
        {
            int patient_id = 0;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM PATIENT";
            cmd.Parameters.Add(new OracleParameter("id", id));
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (id == int.Parse(dr.GetString(4)))
                {

                    patient_id = int.Parse(dr.GetString(0));

                }
            }

            return patient_id;
        }

        private void updateDataGrid()
        {


            OracleCommand cmd = con.CreateCommand();

            cmd.CommandText = "SELECT DOCTOR.ID,DOCTOR.ROOM_ID,USERS.NAME,USERS.SURNAME FROM DOCTOR,EMPLOYEE,USERS WHERE DOCTOR.SPEC_ID = 1 AND DOCTOR.EMPLOYEE_ID = EMPLOYEE.ID AND EMPLOYEE.USER_ID = USERS.ID";

            cmd.CommandType = CommandType.Text;
            OracleDataReader drugi = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(drugi);
            myDataGrid.ItemsSource = dt.DefaultView;
            drugi.Close();

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

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }

        

        private void Zakazi_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO APPOINTMENT (ID,DURATIONS_MINS,DATE_TIME,ROOM_ID,PATIENT_ID,DOCTOR_ID,APPTYPE_ID,APPSTAT_ID) VALUES (:ID,30,:DATE_TIME,:ROOM_ID,:PATIENT_ID,:DOCTOR_ID,1,1)";

            int id = lastId();
            int next_id = id + 1;
            int patient_id = getPatientId();
            cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = next_id.ToString();
            DateTime date = DateTime.Parse(date_txt.Text);
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = date;
            cmd.Parameters.Add("ROOM_ID", OracleDbType.Int32).Value = room_id_txt.Text;
            cmd.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = patient_id.ToString();
            cmd.Parameters.Add("DOCTOR_ID", OracleDbType.Int32).Value = doc_id_txt.Text;
            int a = cmd.ExecuteNonQuery();
            MessageBox.Show("Uspesno zakazan pregled!");
        }

        private int lastId()
        {
            int id = 0;
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT MAX(ID) FROM APPOINTMENT";
            OracleDataReader reader = cmd.ExecuteReader();
            reader = cmd.ExecuteReader();
            reader.Read();
            id = int.Parse(reader.GetString(0));

            return id;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void myDataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                doc_id_txt.Text = dr["ID"].ToString();
                
                doc_name_txt.Text = dr["NAME"].ToString();
                doc_surname_txt.Text = dr["SURNAME"].ToString();
                room_id_txt.Text = dr["ROOM_ID"].ToString();

            }
        }
    }

}
