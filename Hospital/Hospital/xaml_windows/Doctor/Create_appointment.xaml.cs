using Oracle.ManagedDataAccess.Client;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Create_appointment.xaml
    /// </summary>
    public partial class Create_appointment : Window
    {
        int id;
        int id_doc;
        ListBoxItem room_for_create;
        ListBoxItem patient_for_create;
        int last_id;
        int termin_type = 1;
        public Create_appointment(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;


            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection con = new OracleConnection(conString);
            OracleCommand cmd = con.CreateCommand();
            //MessageBox.Show(id.ToString());
            con.Open();

            cmd.CommandText = "select patient.id, patient.JMBG, users.name, users.surname from patient, users where patient.USER_ID = users.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = reader.GetString(0) + "|" + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);
                lb_patients.Items.Add(itm);
            }

            cmd.CommandText = "select max(id) from appointment";
            reader = cmd.ExecuteReader();
            reader.Read();
            last_id = int.Parse(reader.GetString(0));


            cmd.CommandText = "select * from room where room.DESCRIPTION like 'Soba za preglede' or room.DESCRIPTION = 'Operaciona sala'";
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = "soba: " + reader.GetString(0) + " " + reader.GetString(3);
                lb_rooms.Items.Add(itm);
            }

            con.Close();
            con.Dispose();
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
            s.Show();
            this.Close();
        }
        void SelectListBox1(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                room_for_create = lbi;
            }
        }
        void SelectListBox2(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                patient_for_create = lbi;
            }
        }

        void AddAppointment(object sender, RoutedEventArgs e)
        {
            if (patient_for_create != null && room_for_create != null)
            {
                string[] split = room_for_create.Content.ToString().Split(' ');
                //MessageBox.Show(split[1].ToString());
                int id_sobe = int.Parse(split[1]); //id za novu sobu

                string[] split1 = patient_for_create.Content.ToString().Split('|');
                int id_patient = int.Parse(split1[0]);

                int id_app = last_id + 1;
                last_id += 1;
                string[] split2 = time_for_create.Text.Split(':');
                string[] split3 = (date_for_create.SelectedDate.ToString().Split(' '))[0].Split('/');
                DateTime dt = new DateTime(int.Parse(split3[2]), int.Parse(split3[1]), int.Parse(split3[0]), int.Parse(split2[0]), int.Parse(split2[1]), 0);
                string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
                OracleConnection con = new OracleConnection(conString);
                OracleCommand cmd = con.CreateCommand();
                con.Open();

                int duration = termin_type == 1 ? 30 : 120;

                cmd.CommandText = "insert into appointment (id,durations_mins,date_time, room_id, patient_id, doctor_id, apptype_id, appstat_id) " +
                                                     "values(" + id_app.ToString() + ","+ duration +" , to_date('" + dt.ToString() + "', 'DD/MM/YYYY HH24:MI:SS'),"
                                                     + id_sobe.ToString() + "," + id_patient.ToString() + "," + this.id_doc.ToString() + ","+ termin_type +",1)";

                int a = cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesno dodato");
                con.Close();
                con.Dispose();

            }
        }

        private void TypeChecked(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == true)
            {
                termin_type = 1;
            }
            else
            {
                termin_type = 2;
            }
        }
    }
}
