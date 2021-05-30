using Hospital.Controller;
using Hospital.Model;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for PerscriptionGiving.xaml
    /// </summary>
    public partial class PerscriptionGiving : Window
    {
        private HealthRecord _healthRecord;
        private int _idDocAsEmoloyee;
        private int _idDoc;
        private int _idPatient;

        DrugController _drugController = new DrugController();
        private ObservableCollection<Drug> _drugs = null;
        private Anamnesis _anamnesis = null;
        private Drug _selectedDrug = null;
        private ObservableCollection<int> _drugAllergyIds = null;
        public PerscriptionGiving(HealthRecord healthRecord, int idDocAsEmoloyee, int idDoc, int idPatient, Anamnesis anamnesis)
        {
            InitializeComponent();
            this._healthRecord = healthRecord;
            this._idDocAsEmoloyee = idDocAsEmoloyee;
            this._idDoc = idDoc;
            this._idPatient = idPatient;
            this._anamnesis = anamnesis;

            _drugAllergyIds = _drugController.getDrugAllergy(healthRecord.Id);
            _drugs = _drugController.GetAllDrugs();
            FillUi();
        }


        private void FillUi()
        {
            foreach (Drug drug in _drugs)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = drug.Id + " " + drug.Name + " " + drug.Grams;
                if (_drugAllergyIds.Contains(drug.Id))
                {
                    itm.Content += " ALERGIJA!";
                }
                lb_drugs.Items.Add(itm);
            }

        }

        private void AddPerscriptionToDb(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_selectedDrug.Name.ToString() + " dat kao recept");
            if (_selectedDrug != null)
            {
                Perscription perscription = new Perscription(-1, true, Perscription_description.Text, _selectedDrug, _anamnesis);
                new PerscriptionController().AddPerscription(perscription);
            }
        }

        private void DrugChange(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            _selectedDrug = null;
            if (lbi != null)
            {
                int drugId = int.Parse(lbi.Content.ToString().Split(' ')[0]);
                foreach (Drug drug in _drugs)
                    if (drug.Id == drugId)
                        _selectedDrug = drug;
            }
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new HealthRecordDoctorView(_idDocAsEmoloyee, _idDoc, _idPatient);
            s.Show();
            this.Close();
        }
    }
}
