using Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomInventory.xaml
    /// </summary>
    public partial class ManagerRoomInventory : Window
    {
        int ManagerID;
        readonly uint CANCEL = 0;
        Room currentRoom;
        ObservableCollection<ItemInRoom> ItemsInRoom;
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();

        public ManagerRoomInventory(int mngrID, Room room)
        {
            InitializeComponent();
            ManagerID = mngrID;
            currentRoom = room;
            roomID_txtbx.Text = room.Id.ToString();
        }

        private void MoveInventory_Click(object sender, RoutedEventArgs e)
        {
            uint quantity = CreateQuantityInputBox();
            if (quantity == CANCEL)
            {
                return;
            }
            else if (quantity > ((ItemInRoom)myDataGrid.SelectedItem).Quantity)
            {
                MessageBox.Show("Izaberite broj koji je manji ili jednak trenutnoj količini u prostoriji.");
                return;
            }
            else
            {
                GoToNextWindow(quantity);
                
                this.Close();
            }
            
        }

        private void GoToNextWindow(uint quantity)
        {
            Window newWindow = new ManagerRoomInventorySelectDestinationRoom(ManagerID, (int)currentRoom.Id, (ItemInRoom)myDataGrid.SelectedItem, quantity);
            newWindow.Show();
        }

        private uint CreateQuantityInputBox()
        {
            string prompt = "Unesite količinu: ";
            string title = "Premeštanje inventara";
            string answer = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "1");
            if (answer.Length == 0 || int.Parse(answer) == 0)
            {
                return CANCEL;
            }
            else
            {
                return uint.Parse(answer);
            }
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        public void updateDataGrid()
        {
            this.DataContext = this;
            
            ItemsInRoom = itemInRoomController.GetAllItemsInRoomByRoomId((int)currentRoom.Id);
            fillTable();
            
        }

        private void fillTable()
        {
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = ItemsInRoom;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new View.Manager.RoomsCRUDView();
            newWindow.Show();
            this.Close();
        }

        private void roomID_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
        }

        private void roomID_txtbx_LostFocus(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
