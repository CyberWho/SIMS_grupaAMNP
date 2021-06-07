using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using static Globals;
using System;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerNewRenovation.xaml
    /// </summary>
    public partial class ManagerNewRenovation : Window
    {
        ObservableCollection<Room> SelectedRooms = new ObservableCollection<Room>();
        ObservableCollection<Room> AllRooms = new ObservableCollection<Room>();
        Controller.RenovationController renovationController = new Controller.RenovationController();
        readonly uint CANCEL = 0;
        uint NewArea = 0;
        public ManagerNewRenovation()
        {
            InitializeComponent();
            date_pckr.Text = DateTime.Now.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllItems();
            FillComboBox();
        }

        private void LoadAllItems()
        {
            AllRooms = renovationController.GetAllRoomsNotInRenovation();
            SelectDataContext();
        }

        private void SelectDataContext()
        {
            this.DataContext = this;
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = AllRooms;

            DataTable dtSelected = new DataTable();
            myDataGridSelected.DataContext = dtSelected;
            myDataGridSelected.ItemsSource = SelectedRooms;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectBtn.IsEnabled = true;
            deselectBtn.IsEnabled = false;
        }

        private void myDataGridSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            deselectBtn.IsEnabled = true;
            selectBtn.IsEnabled = false;
        }

        private void selectBtn_Click(object sender, RoutedEventArgs e)
        {
            Room SelectedRoom = (Room)myDataGrid.SelectedItem;
            AllRooms.Remove(SelectedRoom);
            SelectedRooms.Add(SelectedRoom);
            selectBtn.IsEnabled = false;
        }

        
        private void deselectBtn_Click(object sender, RoutedEventArgs e)
        {
            Room SelectedRoom = (Room)myDataGridSelected.SelectedItem;
            SelectedRooms.Remove(SelectedRoom);
            AllRooms.Add(SelectedRoom);
            deselectBtn.IsEnabled = false;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRenovations();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }

        private void FillComboBox()
        {
            type_cmbbx.Items.Add(new
            {
                Value = (int)RenovationType.REGULAR,
                Display = "Obična"
            });
            type_cmbbx.Items.Add(new
            {
                Value = (int)RenovationType.MERGE,
                Display = "Spajanje"
            });
            type_cmbbx.Items.Add(new
            {
                Value = (int)RenovationType.SPLIT,
                Display = "Razdvajanje"
            });
        }

        private void renovateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RenovationInputNotValid())
            {
                return;
            }
            else
            {
                string noOfRooms;
                if(SelectedRooms.Count == 1)
                {
                    noOfRooms = "";
                }
                else
                {
                    noOfRooms = SelectedRooms.Count.ToString() + " ";
                }
                ShowInfoBox("Renoviranje ove " + noOfRooms + "sobe je zakazano.");
                NewArea = 0;
                OpenActiveRenovations();
            }
        }

        private bool RenovationInputNotValid()
        {
            if (RenovationTypeNotSelected())
            {
                ShowErrorBox("Tip renovacije mora biti izabran!");
                return true;
            }
            if (SelectedRooms.Count < 1)
            {
                ShowErrorBox("Izaberite najmanje jednu prostorije za renoviranje.");
                return true;
            }
            if (SelectedTypeIsMerge())
            {
                if (SelectedRooms.Count == 1)
                {
                    ShowErrorBox("Za spajanje prostorija potrebno je da izaberete najmanje 2 prostorije.");
                    return true;
                }
                int floorOfFirstElement = (int)SelectedRooms.First().Floor;
                foreach (Room selectedRoom in SelectedRooms)
                {
                    if (selectedRoom.Floor != floorOfFirstElement)
                    {
                        ShowErrorBox("Nije moguće vršiti spajanje prostorija na različitim spratovima.");
                        return true;
                    }
                }
            }
            if (SelectedTypeIsSplit())
            {
                if (SelectedRooms.Count > 1)
                {
                    ShowErrorBox("Možete razdvojiti najviše jednu prostoriju u okviru jedne renovacije.");
                    return true;
                }
                if (NewArea > SelectedRooms.First().Area - 4)
                {
                    ShowErrorBox("Površina razdvojene prostorije ne sme biti veća od površine početne, a površina početne mora ostati bar 4 kv. metra.");
                    type_cmbbx.SelectedItem = null;
                    return true;
                }
            }
            if (renovationController.AddRenovation(GetRenovationFromXaml()) == null)
            {
                ShowErrorBox("Izaberite datum koji nije u prošlosti.");
                return true;
            }
            return false;
        }

        private Renovation GetRenovationFromXaml()
        {
            return new Renovation(-1, DateTime.Parse(date_pckr.Text), (RenovationType)type_cmbbx.SelectedValue, SelectedRooms, false, NewArea);
        }
        private bool RenovationTypeNotSelected()
        {
            return type_cmbbx.SelectedItem == null;
        }
        private void OpenActiveRenovations()
        {
            Window newWindow = new ManagerActiveRenovations();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }
        private bool SelectedTypeIsMerge()
        {
            return (RenovationType)type_cmbbx.SelectedValue == RenovationType.MERGE;
        }
        private bool SelectedTypeIsSplit()
        {
            if(type_cmbbx.SelectedItem != null)
                return (RenovationType)type_cmbbx.SelectedValue == RenovationType.SPLIT;
            return false;
        }

        private void type_cmbbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectedTypeIsSplit())
            {
                this.Topmost = false;
                NewArea = CreateQuantityInputBox();
                if (NewAreaNotValid())
                {
                    ShowErrorBox("Uneta površine nove prostorije mora biti veća od 0, a minimalno 4.");
                    type_cmbbx.SelectedItem = null;
                    return;
                }
            }
        }
        private uint CreateQuantityInputBox()
        {
            string prompt = "Unesite površinu nove prostorije: ";
            string title = "Razdvajanje prostorije";
            string answer = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "4");
            if (answer.Length == 0 || int.Parse(answer) == 0)
            {
                return CANCEL;
            }
            else
            {
                return uint.Parse(answer);
            }
        }
        private bool NewAreaNotValid()
        {
            return NewArea == CANCEL || NewArea < 4;
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {   
            type_cmbbx.SelectedItem = null;
            AllRooms = renovationController.GetAllRoomsNotInRenovation();
            SelectedRooms.Clear();
            deselectBtn.IsEnabled = false;
            selectBtn.IsEnabled = false;
            date_pckr.Text = DateTime.Now.ToString();
            NewArea = 0;
        }

        private void myDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(myDataGrid.SelectedItem != null) 
                selectBtn_Click(sender, e);
        }

        private void myDataGridSelected_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (myDataGridSelected.SelectedItem != null)
                deselectBtn_Click(sender, e);
        }
    }
}
