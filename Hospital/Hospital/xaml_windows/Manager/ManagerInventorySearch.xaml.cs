using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
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

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerInventorySearch.xaml
    /// </summary>
    public partial class ManagerInventorySearch : Window
    {
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();
        ObservableCollection<ItemInRoom> ItemsInRoom;


        public ManagerInventorySearch()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllItems();
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
            btnCancel.IsEnabled = false;
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
        }

        private void type_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnCancel.IsEnabled = true;
        }
    }
}
