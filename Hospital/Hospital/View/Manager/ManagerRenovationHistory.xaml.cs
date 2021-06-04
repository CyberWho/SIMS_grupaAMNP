using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRenovationHistory.xaml
    /// </summary>
    public partial class ManagerRenovationHistory : Window
    {
        ObservableCollection<Renovation> Renovations = new ObservableCollection<Renovation>();
        ObservableCollection<RenovationDTO> RenovationDTOs = new ObservableCollection<RenovationDTO>();
        Controller.RenovationController renovationController = new Controller.RenovationController();
        public ManagerRenovationHistory()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllItems();
        }
        private void LoadAllItems()
        {
            RenovationDTOs.Clear();
            Renovations = renovationController.GetAllRenovations();
            foreach (Renovation renovation in Renovations)
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
    }
}
