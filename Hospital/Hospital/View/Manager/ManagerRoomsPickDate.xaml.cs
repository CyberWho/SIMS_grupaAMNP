using Hospital.Model;
using System;
using System.Windows;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomsPickDate.xaml
    /// </summary>
    public partial class ManagerRoomsPickDate : Window
    {
        int ManagerID;
        ItemInRoom itemInRoom;
        Room destinationRoom;
        DateTime currentDate;
        uint Quantity;

        Controller.RoomController roomController = new Controller.RoomController();
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();
        Controller.ReservedItemController reservedItemController = new Controller.ReservedItemController();

        public ManagerRoomsPickDate(int managerID, ItemInRoom item, Room room, uint quantity)
        {
            InitializeComponent();
            currentDate = DateTime.Now;
            ManagerID = managerID;
            itemInRoom = item;
            destinationRoom = room;
            Quantity = quantity;
            date_pckr.Text = DateTime.Now.ToString();
        }

        private void potvrdaBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dateTime = DateTime.Parse(date_pckr.Text);
            ReservedItem newReservedItem = new ReservedItem(0, dateTime, destinationRoom, itemInRoom);
            reservedItemController.AddReservedItem(newReservedItem);
            Window newWindow = new ManagerRoomsCRUD(ManagerID);
            newWindow.Show();
            newWindow.Topmost = true;
            this.Close();
        }
    }
}
