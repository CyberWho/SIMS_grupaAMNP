using System.Windows;
using System.Collections.ObjectModel;
using System.Data;
using Hospital.Model;
using System.Diagnostics;
using System;
using static Globals;
using System.Linq;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRenovations.xaml
    /// </summary>
    public partial class ManagerActiveRenovations : Window
    {
        ObservableCollection<Renovation> Renovations = new ObservableCollection<Renovation>();
        ObservableCollection<IRenovationDto> RenovationDTOs = new ObservableCollection<IRenovationDto>();
        Controller.RenovationController renovationController = new Controller.RenovationController();
        IRenovationDto selectedItem;

        public ManagerActiveRenovations()
        {
            InitializeComponent();
        }

        private void UpdateDataGrid()
        {
            this.DataContext = this;
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = RenovationDTOs;
        }

        private void myDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            
            if(myDataGrid.SelectedItem != null)
            {
                changeStartDate_btn.IsEnabled = true;
                selectedItem = (IRenovationDto)myDataGrid.SelectedItem;
                date_pckr.Text = selectedItem.renovation.StartDate.ToString();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllItems();
        }
        private void LoadAllItems()
        {
            RenovationDTOs.Clear();
            Renovations = renovationController.GetAllActiveRenovations();
            foreach(Renovation renovation in Renovations)
            {
                switch (renovation.Type)
                {
                    case RenovationType.MERGE:
                        RenovationDTOs.Add(new MergeRenovationDTO(renovation));
                        break;
                    case RenovationType.REGULAR:
                        RenovationDTOs.Add(new RegularRenovationDTO(renovation));
                        break;
                    case RenovationType.SPLIT:
                        RenovationDTOs.Add(new SplitRenovationDTO(renovation));
                        break;
                }
            }
            UpdateDataGrid();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRenovations();
            newWindow.Show();
            this.Close();
            newWindow.Topmost = true;
        }

        private void EndRenovation_Click(object sender, RoutedEventArgs e)
        {
            if (renovationController.EndRenovation(new Renovation((IRenovationDto)myDataGrid.SelectedItem)) == null)
            {
                ShowErrorBox("Neuspešan završetak renovacije.");
                return;
            }

            ShowInfoBox("Renovacija završena.", "Uspešno!");
            
            LoadAllItems();
        }

        private void changeStartDate_btn_Click(object sender, RoutedEventArgs e)
        {
            Renovation renovationToUpdate = new Renovation(selectedItem);
            selectedItem.renovation.StartDate = DateTime.Parse(date_pckr.Text);
            if (renovationController.ChangeStartDate(renovationToUpdate, DateTime.Parse(date_pckr.Text)) == null)
            {
                ShowErrorBox("Izaberite datum koji nije u prošlosti.");
            }
            else
            {
                ShowInfoBox("Uspešno ste pomerili datum za početak izabrane renovacije.", "Uspešno!");
            }
            LoadAllItems();
        }
    }
}
