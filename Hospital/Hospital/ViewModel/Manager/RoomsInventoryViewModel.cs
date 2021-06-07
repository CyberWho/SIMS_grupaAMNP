using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.ViewModel.Manager
{
    class RoomsInventoryViewModel : BindableBase
    {
        private Window currentWindow;
        readonly uint CANCEL = 0;
        public Model.Room SelectedRoom { get; set; }
        private Controller.ItemInRoomController itemInRoomController = new Controller.ItemInRoomController();
        public MyICommand Back { get; set; }
        public MyICommand MoveInventory { get; set; }
        public Model.ItemInRoom SelectedItem { get; set; }
        public ObservableCollection<Model.ItemInRoom> AllItemsInRoom;
        public ObservableCollection<Model.ItemInRoom> _itemsInRoom;
        public ObservableCollection<Model.ItemInRoom> ItemsInRoom
        {
            get => _itemsInRoom;
            set
            {
                SetProperty(ref _itemsInRoom, value);
            }
        }
        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public RoomsInventoryViewModel() { }
        public RoomsInventoryViewModel(Window window, Model.Room _selectedRoom)
        {
            currentWindow = window;
            SelectedRoom = _selectedRoom;
            LoadAllItems();
            InstanceMyCommands();
        }
        private void LoadAllItems()
        {
            AllItemsInRoom = itemInRoomController.GetAllItemsInRoomByRoomId((int)SelectedRoom.Id);
            ItemsInRoom = AllItemsInRoom;

        }
        private void InstanceMyCommands()
        {
            Back = new MyICommand(OnBack);
            MoveInventory = new MyICommand(OnMoveInventory);
        }
        private void OnBack()
        {
            Window newWindow = new View.Manager.RoomsCRUDView();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnMoveInventory()
        {
            uint quantity = CreateQuantityInputBox();
            if (quantity == CANCEL)
            {
                return;
            }
            else if (quantity > SelectedItem.Quantity)
            {
                MessageBox.Show("Izaberite broj koji je manji ili jednak trenutnoj količini u prostoriji.");
                return;
            }
            else
            {
                GoToNextWindow(quantity);

                currentWindow.Close();
            }
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
        private void GoToNextWindow(uint quantity)
        {
            Window newWindow = new xaml_windows.Manager.ManagerRoomInventorySelectDestinationRoom(2, (int)SelectedRoom.Id, SelectedItem, quantity);
            newWindow.Show();
        }
    }
}
