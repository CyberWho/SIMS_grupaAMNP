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
        ObservableCollection<RenovationDTO> RenovationDTOs = new ObservableCollection<RenovationDTO>();
        Controller.RenovationController renovationController = new Controller.RenovationController();
        RenovationDTO selectedItem;

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
                selectedItem = (RenovationDTO)myDataGrid.SelectedItem;
                date_pckr.Text = selectedItem.StartDate.ToString();
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
                RenovationDTOs.Add(new RenovationDTO(renovation));
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
            if (renovationController.EndRenovation(new Renovation((RenovationDTO)myDataGrid.SelectedItem)) == null)
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
            selectedItem.StartDate = DateTime.Parse(date_pckr.Text);
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
