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
    /// Interaction logic for PatientAppointments.xaml
    /// </summary>
    public partial class PatientAppointments : Window
    {
        int id;
        OracleConnection con = null;
        public PatientAppointments(int id)
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
            
            int patient_id = getPatientId();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT APPOINTMENT.ID,APPOINTMENT.APPTYPE_ID,APPOINTMENT.APPSTAT_ID,APPOINTMENT.DURATIONS_MINS,APPOINTMENT.DATE_TIME,APPOINTMENT.ROOM_ID,APPOINTMENT.DOCTOR_ID,USERS.NAME,USERS.SURNAME FROM APPOINTMENT,DOCTOR,EMPLOYEES,USERS WHERE APPOINTMENT.PATIENT_ID = :patient_id AND APPOINTMENT.DOCTOR_ID = DOCTOR.ID AND DOCTOR.EMPLOYEE_ID = EMPLOYEES.ID AND EMPLOYEES.USER_ID = USERS.ID";
            cmd.Parameters.Add(new OracleParameter("patient_id", patient_id));
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

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText =  "UPDATE APPOINTMENT SET DATE_TIME = :DATE_TIME WHERE ID = :ID";
            DateTime date = DateTime.Parse(date_txt.Text);
            cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = date;
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = app_id_txt.Text;
            int a = cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "delete from appointment where id = :id";
            cmd.Parameters.Add("ID", OracleDbType.Int32).Value = app_id_txt.Text;
            int a = cmd.ExecuteNonQuery();
            updateDataGrid();
        }

        private void ZakaziNoviTermin_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientNewAppointment(id);
            s.Show();
            this.Close();
        }

        private void ud_opp(String sql_stmnt,int state)
        {

            String msg = "";
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmnt;
            cmd.CommandType = CommandType.Text;

            switch(state)
            {
                case 0:
                    msg = "Uspesno ste otkazali termin!";
                    break;
                case 1:
                    msg = "Uspesno ste promenili vreme termina!";
                    /* cmd.Parameters.Add("PATIENT_ID", OracleDbType.Int32).Value = getPatientId();
                     cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = date_txt.Value;*/
                    MessageBox.Show("3");
                    
                    /*cmd.Parameters.Add("ID", OracleDbType.Int32).Value = app_id_txt.Text;
                    cmd.Parameters.Add("DATE_TIME", OracleDbType.Date).Value = date_txt.Value;*/
                    break;
                    
            }

            try
            {
                int n = cmd.ExecuteNonQuery();
                if(n>0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                } 
            } catch(Exception exp)
            {

            }

        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if(dr!=null)
            {
                app_id_txt.Text = dr["ID"].ToString();

                duration_mins_txtbx.Text = dr["DURATIONS_MINS"].ToString();
                room_id_txtbx.Text = dr["ROOM_ID"].ToString();
                doctor_id_txt.Text = dr["DOCTOR_ID"].ToString();
                doctor_name_txtbx.Text = dr["NAME"].ToString();
                doctor_surname_txtbx.Text = dr["SURNAME"].ToString();
                date_txt.Value = DateTime.Parse(dr["DATE_TIME"].ToString());
                app_stat_txt.Text = dr["APPSTAT_ID"].ToString();
                app_type_txt.Text = dr["APPTYPE_ID"].ToString();

            }
        }
    }
}
