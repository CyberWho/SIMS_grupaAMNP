using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using static Globals;

namespace Hospital.ViewModel.Manager
{
    class RoomsCRUDViewModel : BindableBase
    {
        private Window currentWindow;

        public ObservableCollection<Room> AllRooms;

        public ObservableCollection<Room> _rooms;
        public ObservableCollection<Room> Rooms
        {
            get => _rooms;
            set
            {
                SetProperty(ref _rooms, value);
            }
        }
        public ObservableCollection<RoomType> RoomTypes { get; set; }
        Controller.RoomController roomController = new Controller.RoomController();
        public string _currentPage = "1";
        public string CurrentPage
        {
            get => _currentPage;
            set
            {
                SetProperty(ref _currentPage, value);
            }
        }
        public int _numberOfRoomsPerPage;
        public int NumberOfRoomsPerPage
        {
            get => _numberOfRoomsPerPage;
            set
            {
                SetProperty(ref _numberOfRoomsPerPage, value);
                Paginate();
            }
        }

        public int MaxPageNumber;
        public Room _selectedRoom;
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                SetProperty(ref _selectedRoom, value);
                OnPropertyChanged("SelectedItem");
            }
        }
        public MyICommand Back { get; set; }
        public MyICommand Add { get; set; }
        public MyICommand Update { get; set; }
        public MyICommand Delete { get; set; }
        public MyICommand Clear { get; set; }
        public MyICommand RoomInventory { get; set; }
        public MyICommand NextPage { get; set; }
        public MyICommand PreviousPage { get; set; }
        public MyICommand Help { get; set; }
        private BindableBase currentViewModel;
        public BindableBase CurrenctViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public RoomsCRUDViewModel() { }
        public RoomsCRUDViewModel(Window window)
        {
            currentWindow = window;
            LoadAllItems();
            RoomTypes = roomController.GetAllRoomTypes();
            NumberOfRoomsPerPage = 10;
            GetMaxPageNumber();
            Paginate();
            InitializeSelectedRoom();
            InstanceMyCommands();
        }

        private void InstanceMyCommands()
        {
            Back = new MyICommand(OnBack);
            Add = new MyICommand(OnAdd);
            Update = new MyICommand(OnUpdate);
            Delete = new MyICommand(OnDelete);
            Clear = new MyICommand(OnClear);
            RoomInventory = new MyICommand(OnRoomInventory);
            NextPage = new MyICommand(OnNextPage);
            PreviousPage = new MyICommand(OnPreviousPage);
            Help = new MyICommand(OnHelp);
        }
        private void LoadAllItems()
        {
            AllRooms = roomController.GetAllRooms();
        }
        public void GetMaxPageNumber()
        {
            MaxPageNumber = AllRooms.Count / NumberOfRoomsPerPage;
            if (AllRooms.Count % NumberOfRoomsPerPage!= 0) 
                MaxPageNumber++; 
        }
        private void Paginate()
        {
            Rooms = new ObservableCollection<Room>(AllRooms.Skip(NumberOfRoomsPerPage * (int.Parse(CurrentPage) - 1)).Take(NumberOfRoomsPerPage));
        }
        private void OnBack()
        {
            Window newWindow = new View.Manager.ManagerUIView();
            newWindow.Show();
            currentWindow.Close();
        }
        private void OnAdd()
        {
            CUD(0);
        }
        private void OnUpdate()
        {
            CUD(1);
        }
        private void OnDelete()
        {
            CUD(2);
        }
        private void OnClear()
        {
            SelectedRoom = null;
            InitializeSelectedRoom();            
        }
        private void OnNextPage()
        {
            if (int.Parse(CurrentPage) + 1 > MaxPageNumber) return;
            CurrentPage = (int.Parse(CurrentPage) + 1).ToString();
            Paginate();
        }
        private void OnPreviousPage()
        {
            if (CurrentPage.Equals("1")) return;
            CurrentPage = (int.Parse(CurrentPage) - 1).ToString();
            Paginate();
        }
        private void InitializeSelectedRoom()
        {
            SelectedRoom = new Room();
            SelectedRoom.roomType = new RoomType(0, "", null);
        }
        private void OnRoomInventory()
        {
            Window newWindow = new View.Manager.RoomInventoryView(_selectedRoom);
            newWindow.Show();
            currentWindow.Close();
        }
        private void CUD(int state)
        {
            switch (state)
            {
                case 0:
                    if (roomController.AddRoom(_selectedRoom) != null)
                    {
                        MessageBox.Show("Uspešan nov unos.");
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom novog unosa.");
                    }
                    break;
                case 1:
                    if (roomController.UpdateRoom(_selectedRoom) != null)
                    {
                        MessageBox.Show("Red uspešno ažuriran.");
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom ažuriranja prostorije.");
                    }

                    break;
                case 2:
                    if (roomController.DeleteRoomById((int)_selectedRoom.Id))
                        MessageBox.Show("Uspešno brisanje.");
                    break;
            }
            LoadAllItems();
            InitializeSelectedRoom();
        }
        private void OnHelp()
        {
            string str = "ManagerUIHelp";
            System.Diagnostics.Process.Start("C:/Users/Pedja/source/repos/SIMS_grupaAMNP/Hospital/Hospital/Help/ManagerRoomsCRUDHelp.html");
        }
    }
}
