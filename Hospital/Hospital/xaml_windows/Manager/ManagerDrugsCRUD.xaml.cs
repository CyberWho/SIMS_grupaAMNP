using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
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
            drugController.UpdateDrug(GetChangedFields((Drug)myDataGrid.SelectedItem));
            updateDataGrid();
        }

        private Drug GetChangedFields(Drug drug)
        {
            if (!name_txtbx.Text.Equals(drug.Name))
            {
                drug.Name = name_txtbx.Text;
            }
            if (!price_txtbx.Text.Equals(drug.Price.ToString()))
            {
                drug.Price = uint.Parse(price_txtbx.Text);
            }
            if (!unit_txtbx.Text.Equals(drug.Unit))
            {
                drug.Unit = unit_txtbx.Text;
            }
            if (!dtype_cmbbx.Text.Equals(drug.drugType.Type)) 
            {
                drugTypeRepository.GetDrugTypeByType(dtype_cmbbx.Text);
            }
            if (!grams_txtbx.Text.Equals(drug.Grams.ToString())){
                drug.Grams = int.Parse(grams_txtbx.Text);
            }
            if (needsPrescription_cmbbx.Text.Equals("Potreban")) drug.NeedsPerscription = true;
            else drug.NeedsPerscription = false;

            return drug;
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            drugController.DeleteDrugById(((Drug)myDataGrid.SelectedItem).Id, ((Drug)myDataGrid.SelectedItem).InventoryItemID);
            updateDataGrid();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            myDataGrid.UnselectAll();
            ClearForm();
            ResetButtons();
        }
        private void ClearForm()
        {
            ClearTextBoxes();
            ClearComboBoxes();
        }
        private void ResetButtons()
        {
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }

        private void ClearTextBoxes()
        {
            name_txtbx.Text = "";
            price_txtbx.Text = "";
            unit_txtbx.Text = "";
            id_txtbx.Text = "";
            grams_txtbx.Text = "";
        }
        private void ClearComboBoxes()
        {
            dtype_cmbbx.SelectedItem = null;
            needsPrescription_cmbbx.SelectedItem = null;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Window w = new ManagerUI(2);
            w.Show();
            this.Close();
        }
    }
}
