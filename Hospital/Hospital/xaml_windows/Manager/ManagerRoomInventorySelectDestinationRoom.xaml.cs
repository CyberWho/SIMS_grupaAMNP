using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomInventorySelectDestinationRoom.xaml
    /// </summary>
    public partial class ManagerRoomInventorySelectDestinationRoom : Window
    {
        int ManagerID;
        int RoomID;
        int ItemInRoomID;
        uint quantity;
        ItemType ItemInRoomType;
        ObservableCollection<Room> Rooms;
        Controller.RoomController roomController = new Controller.RoomController();
        Controller.InventoryItemController inventoryItemController = new Controller.InventoryItemController();
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();

        public ManagerRoomInventorySelectDestinationRoom(int mngrID, int roomID, int itemInRoomID, object itemType, uint quantity)
        {
            InitializeComponent();
            ManagerID = mngrID;
            RoomID = roomID;
            ItemInRoomID = itemInRoomID;
            ItemInRoomType = (ItemType) itemType;
            this.quantity = quantity;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        public void updateDataGrid()
        {
            this.DataContext = this;
            Rooms = roomController.GetAllRoomsExceptSource(RoomID);
            fillTable();

        }

        private void fillTable()
        {
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Rooms;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            moveBtn.IsEnabled = true;
        }

        private void moveBtn_Click(object sender, RoutedEventArgs e)
        {
            // provera da li je inventar statican ili dinamican
            if(ItemInRoomType == ItemType.EXPENDABLE)
            {
                if(itemInRoomController.MoveItem(ItemInRoomID, int.Parse(IIRID_txtbx.Text), quantity, null))
                {
                    MessageBox.Show("Uspesno premeštanje.");
                }
                else
                {
                    MessageBox.Show("Došlo je do greške prilikom prebacivanja.");
                }
            }
            else
            {
                Window pickDateWindow = new ManagerRoomsPickDate(ManagerID, ItemInRoomID, int.Parse(IIRID_txtbx.Text), quantity);
                pickDateWindow.Show();
                this.Close();
                return;
            }

            Window newWindow = new ManagerRoomsCRUD(ManagerID);
            newWindow.Show();
            this.Close();
        }
    }
}
