using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for DrugOperations.xaml
    /// </summary>
    public partial class DrugOperations : Window
    {
        private int id;
        private int id_doc;

        private int selected_drug_approved = -1;
        private int selected_drug_pending = -1;

        private ListBoxItem lbi_selected_drug_approved = null;
        private ListBoxItem lbi_selected_drug_pending = null;

        private ObservableCollection<Drug> drugs = new ObservableCollection<Drug>();

        private DrugController drugController = new DrugController();

        public DrugOperations(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;
            drugs = drugController.GetAllDrugs();
            fillUiLB();

        }

        //filler
        public void fillUiLB()
        {
            foreach (Drug drug in drugs)
            {
                //MessageBox.Show(drug.Name.ToString() + " " + drug.Status.ToString());
                if (drug.Status != DrugStatus.REJECTED)
                {

                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Content = drug.Id + "|" + drug.Name + " " + drug.drugType.Type + " " + drug.Grams +
                                  (drug.NeedsPerscription ? " potreban recept" : "");
                    if (drug.Status == DrugStatus.APPROVED)
                        lb_confirmed.Items.Add(lbi);
                    else
                        lb_unconfirmed.Items.Add(lbi);
                }
            }
        }

        private void NeedForRecipeChange(object sender, RoutedEventArgs e)
        {
            if (selected_drug_approved != -1)
            {
                foreach (Drug drug in drugs)
                    if (drug.Id == selected_drug_approved)
                    {
                        int needsPerscription = drug.NeedsPerscription ? 1 : 0;
                        // MessageBox.Show(needsPerscription.ToString());
                        drug.NeedsPerscription = !drug.NeedsPerscription;

                        needsPerscription = drug.NeedsPerscription ? 1 : 0;

                        // MessageBox.Show(needsPerscription.ToString());

                        lbi_selected_drug_approved.Content = drug.Id + "|" + drug.Name + " " + drug.drugType.Type + " " + drug.Grams +
                                                             (drug.NeedsPerscription ? " potreban recept" : "");

                        drugController.UpdateDrugNoInventoryPart(drug);
                        break;
                    }
            }

        }

        private void SelectedApprovedDrugFocusChange(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                lbi_selected_drug_approved = lbi;
                selected_drug_approved = int.Parse(lbi.Content.ToString().Split('|')[0]);
            }

        }

        private void SelectedPendingDrugFocusChange(object sender, RoutedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                lbi_selected_drug_pending = lbi;
                selected_drug_pending = int.Parse(lbi.Content.ToString().Split('|')[0]);
            }

        }

        private void ApproveDrug(object sender, RoutedEventArgs e)
        {
           //MessageBox.Show(lbi_selected_drug_pending.Content.ToString());

            if (selected_drug_pending != -1)
            {
                foreach (Drug drug in drugs)
                    if (drug.Id == selected_drug_pending)
                    {
                        drug.Status = DrugStatus.APPROVED;
                        lb_unconfirmed.Items.Remove(lbi_selected_drug_pending);
                        lb_confirmed.Items.Add(lbi_selected_drug_pending);
                        lbi_selected_drug_pending = null;
                        drugController.UpdateDrugNoInventoryPart(drug);
                        break;
                    }

            }

            selected_drug_pending = -1;
        }

        private void RejectDrug(object sender, RoutedEventArgs e)
        {
            if (selected_drug_pending != -1)
            {
                foreach (Drug drug in drugs)
                    if (drug.Id == selected_drug_pending)
                    {
                        drug.Status = DrugStatus.REJECTED;
                        lb_unconfirmed.Items.Remove(lbi_selected_drug_pending);
                        lbi_selected_drug_pending = null;
                        drugController.UpdateDrugNoInventoryPart(drug);
                        drugController.RejectDrug(drug.Id, id_doc, tb_rejection.Text);
                        break;
                    }

            }
            selected_drug_pending = -1;
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
            s.Show();
            this.Close();
        }
    }
}
