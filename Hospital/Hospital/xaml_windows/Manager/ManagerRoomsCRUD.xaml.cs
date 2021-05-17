using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomsCRUD.xaml
    /// </summary>
    public partial class ManagerRoomsCRUD : Window
    {
        int id;
        ObservableCollection<Room> Rooms;

        Controller.RoomController roomController = new Controller.RoomController();
        public ManagerRoomsCRUD(int id)
        {

            InitializeComponent();
            this.id = id;
        }

        public void updateDataGrid()
        {
            fillComboBox();
            this.DataContext = this;
            Rooms = roomController.GetAllRooms();
            fillTable();
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
        private void ShowInventory_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRoomInventory(id, GetIdFromForm());
            newWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.updateDataGrid();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(0);
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
            switch (state)
            {
                case 0:
                    if(roomController.AddRoom(GetRoomFromForm()) != null){
                        MessageBox.Show("Uspešan nov unos.");
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom novog unosa.");
                    }
                    break;
                case 1:
                    if(roomController.UpdateRoom(GetRoomFromForm()) != null)
                    {
                        MessageBox.Show("Red uspešno ažuriran.");
                    } 
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom ažuriranja prostorije.");
                    }

                    break;
                case 2:
                    if(roomController.DeleteRoomById(GetIdFromForm()))
                    MessageBox.Show("Uspešno brisanje.");
                    break;
            }
            this.updateDataGrid();
        }

        private int GetIdFromForm()
        {
            int formID = 0;
            if (!id_txtbx.Text.Equals(""))
            {
                formID = int.Parse(id_txtbx.Text);
            }
            return formID;
        }

        private Room GetRoomFromForm()
        {
            Room room = new Room();

            room.Id = GetIdFromForm();

            if (!floor_txtbx.Text.Equals(""))
            {
                room.Floor = int.Parse(floor_txtbx.Text);
            }
            if (!area_txtbx.Text.Equals(""))
            {
                room.Area = double.Parse(area_txtbx.Text);
            }
            if (!desc_txtbx.Text.Equals(""))
            {
                room.Description = desc_txtbx.Text;
            }

            room.roomType = roomController.GetRoomTypeByType(rtype_cmbbx.Text);
            
            return room;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           add_btn.IsEnabled = false;
           update_btn.IsEnabled = true;
           delete_btn.IsEnabled = true;
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            floor_txtbx.Text = "";
            area_txtbx.Text = "";
            desc_txtbx.Text = "";
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
        private void fillComboBox()
        {
            foreach (RoomType roomType in roomController.GetAllRoomTypes())
            {
                rtype_cmbbx.Items.Add(new
                {
                    Value = roomType.Id,
                    Display = roomType.Type
                });
            }
        }
        
        private void fillTable()
        {
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Rooms;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window w = new ManagerUI(2);
            w.Show();
            this.Close();
        }
    }
}
