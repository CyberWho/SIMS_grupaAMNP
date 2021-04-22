using Hospital.Model;
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

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomsPickDate.xaml
    /// </summary>
    public partial class ManagerRoomsPickDate : Window
    {
        int ManagerID;
        int ItemInRoomID;
        int DestinationRoomID;
        uint Quantity;
        Controller.RoomController roomController = new Controller.RoomController();
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();
        Controller.ReservedItemController reservedItemController = new Controller.ReservedItemController();

        public ManagerRoomsPickDate(int managerID, int itemInRoomID, int destinationRoomID, uint quantity)
        {
            InitializeComponent();
            managerID = managerID;
            ItemInRoomID = itemInRoomID;
            DestinationRoomID = destinationRoomID;
            Quantity = quantity;
        }

        private void potvrdaBtn_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dateTime = DateTime.Parse(date_txt.Text);
            ReservedItem newReservedItem = new ReservedItem(0, dateTime, roomController.GetRoomById(DestinationRoomID), itemInRoomController.GetItemInRoomById(ItemInRoomID));
            reservedItemController.AddReservedItem(newReservedItem);
            Window newWindow = new ManagerRoomsCRUD(ManagerID);
            newWindow.Show();
            this.Close();
        }
    }
}
