using Hospital.Controller;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for PerscriptionGiving.xaml
    /// </summary>
    public partial class PerscriptionGiving : Window
    {
        HealthRecord healthRecord;
        int id_doc_as_emoloyee;
        int id_doc;
        int id_patient;

        DrugController drugController = new DrugController();
        ObservableCollection<Drug> drugs = null;
        Anamnesis anamnesis = null;
        Drug selected_drug = null;
        public PerscriptionGiving(HealthRecord healthRecord, int id_doc_as_emoloyee, int id_doc, int id_patient, Anamnesis anamnesis)
        {
            InitializeComponent();
            this.healthRecord = healthRecord;
            this.id_doc_as_emoloyee = id_doc_as_emoloyee;
            this.id_doc = id_doc;
            this.id_patient = id_patient;
            this.anamnesis = anamnesis;

            drugs = drugController.GetAllDrugs();
            foreach (Drug drug in drugs)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = drug.Id + " " + drug.Name + " " + drug.Grams;
                lb_drugs.Items.Add(itm);
            }

        }

        private void AddPerscriptionToDB(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(selected_drug.Name.ToString() + " dat kao recept");
            if (selected_drug != null)
            {
                Perscription perscription = new Perscription(-1, true, Perscription_description.Text, selected_drug, anamnesis);
                new PerscriptionController().AddPerscription(perscription);
            }
        }

        private void DrugChange(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            selected_drug = null;
            if (lbi != null)
            {
                int drug_id = int.Parse(lbi.Content.ToString().Split(' ')[0]);
                foreach (Drug drug in drugs)
                    if (drug.Id == drug_id)
                        selected_drug = drug;
            }
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new HealthRecordDoctorView(id_doc_as_emoloyee, id_doc, id_patient);
            s.Show();
            this.Close();
        }
    }
}
