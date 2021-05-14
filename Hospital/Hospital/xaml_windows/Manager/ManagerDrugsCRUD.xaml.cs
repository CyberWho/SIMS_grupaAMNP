using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerDrugs.xaml
    /// </summary>
    public partial class ManagerDrugs : Window
    {

        ObservableCollection<Drug> Drugs;
        Controller.DrugController drugController = new Controller.DrugController();
        Repository.DrugTypeRepository drugTypeRepository = new Repository.DrugTypeRepository();

        public ManagerDrugs()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fillComboBox();
            this.updateDataGrid();
        }

        public void updateDataGrid()
        {
            this.DataContext = this;
            Drugs = drugController.GetAllDrugs();
            fillTable();
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void fillComboBox()
        {
            foreach (DrugType drugType in drugTypeRepository.GetAllDrugTypes())
            {
                dtype_cmbbx.Items.Add(new
                {
                    Value = drugType.Id,
                    Display = drugType.Type
                });
            }
            needsPrescription_cmbbx.Items.Add(new
            {
                Value = true,
                Display = "Potreban"
            });
            needsPrescription_cmbbx.Items.Add(new
            {
                Value = false,
                Display = "Nije potreban"
            });

        }

        private void fillTable()
        {
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Drugs;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            add_btn.IsEnabled = false;
            update_btn.IsEnabled = true;
            delete_btn.IsEnabled = true;
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            bool needsPrescription = false;

            if (needsPrescription_cmbbx.Text.Equals("Potreban")) needsPrescription = true;

            Drug newDrug = new Drug(int.Parse(grams_txtbx.Text), DrugStatus.PENDING, needsPrescription, drugTypeRepository.GetDrugTypeByType(dtype_cmbbx.Text));
            newDrug.Name = name_txtbx.Text;
            newDrug.Price = uint.Parse(price_txtbx.Text);
            newDrug.Unit = unit_txtbx.Text;
            newDrug.Type = ItemType.EXPENDABLE;

            drugController.AddDrug(newDrug);

            updateDataGrid();
            clear_btn_Click(null, null);
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            Drug drug = (Drug)myDataGrid.SelectedItem;
            drugController.UpdateDrug((Drug)myDataGrid.SelectedItem);
            Trace.WriteLine("DRUG TO UPDATE:");
            Trace.WriteLine("\tID: " + drug.Id);
            Trace.WriteLine("\tINV_ID: " + drug.InventoryItemID);
            Trace.WriteLine("\tName: " + drug.Name);
            updateDataGrid();
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            drugController.DeleteDrugById(((Drug)myDataGrid.SelectedItem).Id, ((Drug)myDataGrid.SelectedItem).InventoryItemID);
            updateDataGrid();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            name_txtbx.Text = "";
            price_txtbx.Text = "";
            unit_txtbx.Text = "";
            id_txtbx.Text = "";
            grams_txtbx.Text = "";
            dtype_cmbbx.SelectedItem = null;
            needsPrescription_cmbbx.SelectedItem = null;
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
    }
}
