using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerInventorySearch.xaml
    /// </summary>
    public partial class ManagerInventorySearch : Window
    {
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();
        Controller.RoomController roomController = new Controller.RoomController();
        ObservableCollection<ItemInRoom> ItemsInRoom;


        public ManagerInventorySearch()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllItems();
            FillComboBoxes();
        }
        private void FillComboBoxes()
        {

            type_cmbbx.Items.Add(new
            {
                Value = (int)ItemType.EXPENDABLE,
                Display = "Potrošna"
            });
            type_cmbbx.Items.Add(new
            {
                Value = (int)ItemType.PERSISTENT,
                Display = "Trajna"
            });

            foreach (int id in roomController.GetAllRoomIDs())
            {
                room_cmbbx.Items.Add(new
                {
                    Value = id,
                    Display = "Soba " + id.ToString()
                });
            }            
        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            ItemsInRoom = itemInRoomController.SearchByName(search_txtbx.Text);
            updateDataGrid();
        }
        public void updateDataGrid()
        {
            this.DataContext = this;
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = ItemsInRoom;
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            btnCancel.IsEnabled = false;
            search_txtbx.Text = "";
            room_cmbbx.SelectedItem = null;
            type_cmbbx.SelectedItem = null;
            LoadAllItems();
        }

        private void LoadAllItems()
        {
            ItemsInRoom = itemInRoomController.LoadAllItems();
            Trace.WriteLine("ItemsInRoomLength: " + ItemsInRoom.Count.ToString());
            updateDataGrid();
        }


        private void search_txtbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnCancel.IsEnabled = true;
            ItemsInRoom = itemInRoomController.SearchByName(search_txtbx.Text);
            updateDataGrid();
        }

        private void type_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCancel.IsEnabled = true;
            if(type_cmbbx.SelectedItem != null)
            {
                ItemsInRoom = itemInRoomController.GetAllItemsInRoomByItemType((ItemType)type_cmbbx.SelectedValue);
                updateDataGrid();
            }
        }
        private void room_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (room_cmbbx.SelectedItem != null)
            {
                ItemsInRoom = itemInRoomController.GetAllItemsInRoomByRoomId(int.Parse(room_cmbbx.SelectedValue.ToString()));
                updateDataGrid();
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            itemInRoomController.ResetGotAllItemsInRoomFlag();
            Window w = new ManagerUI(2);
            w.Show();
            this.Close();
        }

       
    }
}
