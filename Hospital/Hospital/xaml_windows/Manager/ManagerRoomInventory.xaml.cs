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
        int RoomID;
        readonly uint CANCEL = 0;
        ObservableCollection<ItemInRoom> ItemsInRoom;
        Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();

        public ManagerRoomInventory(int mngrID, int roomID)
        {
            InitializeComponent();
            ManagerID = mngrID;
            RoomID = roomID;
            roomNo_txtbx.Text = this.RoomID.ToString();
        }

        private void MoveInventory_Click(object sender, RoutedEventArgs e)
        {
            uint quantity = CreateQuantityInputBox();
            MessageBox.Show("IIR ID: " + IIRNo_txtbx.Text);
            if (quantity == CANCEL)
            {
                return;
            }
            else if (quantity > itemInRoomController.GetItemInRoomById(int.Parse(IIRNo_txtbx.Text)).Quantity)
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
            Window newWindow = new ManagerRoomInventorySelectDestinationRoom(ManagerID, RoomID, int.Parse(IIRNo_txtbx.Text), Enum.Parse(typeof(ItemType), IIRType_txtbx.Text), quantity);
            newWindow.Show();
        }

        private uint CreateQuantityInputBox()
        {
            String prompt = "Unesite količinu: ";
            String title = "Premeštanje inventara";
            String answer = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "1");
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
            
            ItemsInRoom = itemInRoomController.GetAllItemsInRoomByRoomId(RoomID);
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
            Window newWindow = new ManagerRoomsCRUD(ManagerID);
            newWindow.Show();
            
            this.Close();
        }
    }
}
