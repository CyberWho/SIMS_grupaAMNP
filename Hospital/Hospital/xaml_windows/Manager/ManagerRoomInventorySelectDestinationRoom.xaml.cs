using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomInventorySelectDestinationRoom.xaml
    /// </summary>
    public partial class ManagerRoomInventorySelectDestinationRoom : Window
    {
        int ManagerID;
        int currentRoomId;
        int ItemInRoomID;
        ItemInRoom itemInRoom;
        Room destinationRoom;
        uint quantity;
        ObservableCollection<Room> Rooms;
        Controller.RoomController roomController = new Controller.RoomController();
        Controller.InventoryItemController inventoryItemController = new Controller.InventoryItemController();
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();

        public ManagerRoomInventorySelectDestinationRoom(int mngrID, int roomID, ItemInRoom item, uint quantity)
        {
            InitializeComponent();
            ManagerID = mngrID;
            itemInRoom = item;
            currentRoomId = roomID;
            this.quantity = quantity;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        public void updateDataGrid()
        {
            this.DataContext = this;
            Rooms = roomController.GetAllRoomsExceptSource(currentRoomId);
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
            destinationRoom = (Room)myDataGrid.SelectedItem;
            // provera da li je inventar statican ili dinamican
            if(itemInRoom.inventoryItem.Type == ItemType.EXPENDABLE)
            {
                if(itemInRoomController.MoveItem(itemInRoom, destinationRoom, quantity, null))
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
                Window pickDateWindow = new ManagerRoomsPickDate(ManagerID, itemInRoom, int.Parse(IIRID_txtbx.Text), quantity);
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
