using System;
using System.Collections;
using System.Collections.Generic;
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
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerUI.xaml
    /// </summary>
    public partial class ManagerUI : Window
    {
        int id;
        OracleConnection con    = null;
        OracleCommand cmd       = null;
        OracleDataReader reader = null;
        int last_room_id;
        ArrayList room_types = new ArrayList();
        int selected_id = -1;
        bool combo_fill = false;

        public ManagerUI(int id)
        {

            InitializeComponent();
            this.id = id;

            //OracleConnection con = null;
            //OracleCommand cmd = null;
            //OracleDataReader reader = null;

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";

            con = new OracleConnection(conString);
            cmd = con.CreateCommand();
            
            Role mngr_role  = new Role();
            mngr_role.Id    = 2;
            mngr_role.RoleType  = "Manager";

            con.Open();
            cmd.CommandText = "SELECT * FROM employee LEFT OUTER JOIN users ON employee.user_id = users.id WHERE users.id = " + id.ToString();

            reader = cmd.ExecuteReader();
            reader.Read();

            User mngr_user = new User();
            mngr_user.Id           = reader.GetInt32(3);
            mngr_user.Username     = reader.GetString(6);
            mngr_user.Password     = reader.GetString(7);
            mngr_user.Name         = reader.GetString(8);
            mngr_user.Surname      = reader.GetString(9);
            mngr_user.PhoneNumber  = reader.GetString(10);
            mngr_user.EMail        = reader.GetString(11);

            Employee manager = new Employee();
            manager.SetRole(mngr_role);
            manager.User           = mngr_user;
            manager.Salary         = reader.GetInt32(1);
            manager.YearsOfService = reader.GetInt32(2);

            ArrayList rooms        = new ArrayList();
            

            cmd.CommandText = "SELECT * FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            reader = cmd.ExecuteReader();

            for (int i = 0; reader.Read(); i++) 
            {
                RoomType roomType = new RoomType
                {
                    Id   = reader.GetInt32(5),
                    Type = reader.GetString(6)
                };
                room_types.Add(roomType);
                rooms.Add(new Room(reader.GetInt32(0), reader.GetInt32(1), reader.GetDouble(2), reader.GetString(3), roomType));
                last_room_id = reader.GetInt32(0);
            }

            con.Close();
        }

        public void updateDataGrid()
        {
            try
            {
                con.Close();
            }
            catch (Exception e) { }

            con.Open();
            cmd.CommandText = "SELECT * FROM room_type";
            reader          = cmd.ExecuteReader();
            
            while (reader.Read() && !combo_fill)
            {
                //rtype_cmbbx.Items.Clear();
                rtype_cmbbx.Items.Add(new
                {
                    Value   = reader.GetString(0),
                    Display = reader.GetString(1),
                });
            }
            combo_fill = true;

            cmd.CommandText = "SELECT room.id, floor, area, description, rtype FROM room LEFT OUTER JOIN room_type ON room.rtype_id = room_type.id ORDER BY room.id";
            reader          = cmd.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(reader);
            myDataGrid.ItemsSource = dt.DefaultView;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Dispose();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(0);
            add_btn.IsEnabled = false;
            update_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(1);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(2);
        }
        private void CUD(int state)
        {
            String msg = "";
            String sql = "";

            switch (state)
            {
                case 0:
                    msg = "Row inserted sucesfully.";
                    sql = "INSERT INTO room VALUES(" + (last_room_id + 1).ToString() + ", "
                        + floor_txtbx.Text + ", " + area_txtbx.Text + ", '" + desc_txtbx.Text + "', " 
                        + rtype_cmbbx.SelectedValue.ToString() + ")";

                    break;
                case 1:
                    sql = "UPDATE room SET floor=" + floor_txtbx.Text + ", area=" + area_txtbx.Text 
                        + ", description='" + desc_txtbx.Text + "', rtype_id=" 
                        + rtype_cmbbx.SelectedValue.ToString() + " WHERE id=" + selected_id.ToString();
                    msg = "Row updated sucesfully.";
                    break;
                case 2:
                    sql = "DELETE FROM room WHERE id = " + selected_id.ToString();
                    msg = "Row deleted sucesfully.";
                    break;
            }
            try
            { 
                cmd.CommandText = sql;
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    this.updateDataGrid();
                }
            }
            catch (Exception e) { }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if(dr != null)
            {
                int rt_id = -1;
                floor_txtbx.Text = dr["floor"].ToString();
                area_txtbx.Text  = dr["area"].ToString();
                desc_txtbx.Text  = dr["description"].ToString();
                selected_id = Int32.Parse(dr["id"].ToString());
                foreach (RoomType rt in room_types)
                    if (rt.Type.Equals(dr["rtype"]) )
                        rt_id = rt.Id;
                rtype_cmbbx.SelectedValue = rt_id;

                add_btn.IsEnabled    = false;
                update_btn.IsEnabled = true;
                delete_btn.IsEnabled = true;
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            floor_txtbx.Text = "";
            area_txtbx.Text = "";
            desc_txtbx.Text = "";
            rtype_cmbbx.SelectedValue = null;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
            add_btn.IsEnabled = true;
        }
    }
}
