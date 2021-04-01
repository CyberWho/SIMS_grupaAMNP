using Hospital.Model;
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
    /// Interaction logic for Doctor_crud_appointments.xaml
    /// </summary>
    public partial class Doctor_crud_appointments : Window
    {
        private int id { set; get; }
        private int id_doc { set; get; }

        ListBoxItem selected = null;
        ListBoxItem room_for_update = null;

        public Doctor_crud_appointments(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            //MessageBox.Show(id.ToString());
            con.Open();
            cmd.CommandText = "select * from appointment where doctor_id = " + id_doc.ToString();// RIGHT JOIN employees ON users.ID == employees.USER_ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())//prebaciti u appointments pa videti dalje
            {

                cmd.CommandText = "select surname from patient, users where users.ID = patient.USER_ID and patient.ID = " + reader.GetString(4);
                OracleDataReader reader_info = cmd.ExecuteReader();
                reader_info.Read();
                cmd.CommandText = "select surname from patient, users where users.ID = patient.USER_ID and patient.ID = " + reader.GetString(4);

                ListBoxItem itm = new ListBoxItem();
                itm.Content = reader.GetDateTime(2).ToString() + " " + reader_info.GetString(0) + "\nsoba: " + reader.GetString(3) + " id_pregleda =" + reader.GetString(0);

                lb_appointments.Items.Add(itm);
            }
            cmd.CommandText = "select * from room";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "soba: " + reader.GetString(0);
                lb_rooms.Items.Add(itm);
            }

            con.Close();
            con.Dispose();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            more_info.Text = "";
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                string[] split = lbi.Content.ToString().Split('=');
                int id_app = int.Parse(split[1]);
                string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
                OracleConnection con = new OracleConnection(conString);
                OracleCommand cmd = con.CreateCommand();
                //MessageBox.Show(id.ToString());
                con.Open();
                //MessageBox.Show(id_app.ToString());
                cmd.CommandText = "select * from appointment where appointment.id = " + id_app.ToString();
                OracleDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string trajanje = reader.GetString(1);
                string datum = reader.GetDateTime(2).ToString();


                cmd.CommandText = "select JMBG, date_of_birth, name, surname, phone_number, email  from patient, users where users.ID = patient.USER_ID and patient.ID = " + reader.GetString(4);
                OracleDataReader reader_info = cmd.ExecuteReader();
                reader_info.Read();

                more_info.Text += reader_info.GetString(2) + " " + reader_info.GetString(3) + "\nrodjen: " + reader_info.GetString(1)
                                + "\nJMBG " + reader_info.GetString(0) + "\ntermin " + datum + "\ntrajanja " + trajanje
                                + "minuta\n\ntelefon:" + reader_info.GetString(4) + "\nemail: " + reader_info.GetString(5);
                con.Close();
                con.Dispose();
                selected = lbi;
            }
            else
            {
                more_info.Text = "";
            }

        }
        void SelekcijaSobe(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                room_for_update = lbi;
            }

        }

        private void UpdateAppointment(object sender, RoutedEventArgs e)
        {
            if (selected != null)
            {
                string[] split = room_for_update.Content.ToString().Split(':');
                int id_sobe = int.Parse(split[1]); //id za novu sobu
                string[] split1 = selected.Content.ToString().Split('=');
                int id_app = int.Parse(split1[1]); //id app koji menjamo
                string[] split2 = time_for_update.Text.Split(':');
                string[] split3 = (date_for_update.SelectedDate.ToString().Split(' '))[0].Split('/');
                DateTime dt = new DateTime(int.Parse(split3[2]), int.Parse(split3[1]), int.Parse(split3[0]), int.Parse(split2[0]), int.Parse(split2[1]), 0);
                string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
                OracleConnection con = new OracleConnection(conString);
                OracleCommand cmd = con.CreateCommand();
                con.Open();

                string[] niz = dt.ToString().Split(' ');
                string dat = niz[0] + " " + niz[1];

                cmd.CommandText = "update appointment set room_id = " + id_sobe.ToString()
                                  + ", date_time = to_date('" + dat + "', 'DD/MM/YYYY HH24:MI:SS') where id =" + id_app.ToString();


                int a = cmd.ExecuteNonQuery();
                //MessageBox.Show(a.ToString());
                con.Close();
                con.Dispose();
                string[] split4 = selected.Content.ToString().Split(' ');
                selected.Content = dt.ToString() + " " + split4[2] + " " + id_sobe + " " + split4[4] + " " + split4[5];

            }
        }


        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
            s.Show();
            this.Close();
        }

        private void DelateAppointment(object sender, RoutedEventArgs e)
        {
            string[] split1 = selected.Content.ToString().Split('=');
            int id_app = int.Parse(split1[1]); //id app koji menjamo

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            con.Open();

            cmd.CommandText = "delete from appointment where id = " + id_app;

            int a = cmd.ExecuteNonQuery();
            lb_appointments.Items.Remove(selected);
            //MessageBox.Show(a.ToString());
            more_info.Text = "";
            selected = null;
        }
    }
}
