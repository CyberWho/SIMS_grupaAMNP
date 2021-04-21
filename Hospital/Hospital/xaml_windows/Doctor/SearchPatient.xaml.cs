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
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for SearchPatient.xaml
    /// </summary>

    public partial class SearchPatient : Window
    {
        private int id { set; get; }
        private int id_doc { set; get; }

        private int selected_patient_id = -1;

        private PatientController patientController = new PatientController();
        private ObservableCollection<Model.Patient> patients = null;

        public SearchPatient(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;
            patients = patientController.GetAllPatients();
            foreach (Model.Patient patient in patients)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = patient.Id + " - " + patient.User.Name + " " + patient.User.Surname + "\nJMBG: " + patient.JMBG;
                lb_appointments.Items.Add(itm);

            }

        }

        private void GoToHealthRecord(object sender, RoutedEventArgs e)
        {
            if (selected_patient_id != -1)
            {
                Window s = new HealthRecordDoctorView(id, id_doc, selected_patient_id);
                s.Show();
                this.Close();
            }
        }

        void ChangeFocusedPatient(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                selected_patient_id = int.Parse(lbi.Content.ToString().Split(' ')[0]);
                //MessageBox.Show(selected_patient_id.ToString());

            }
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(id);
            s.Show();
            this.Close();
        }
    }
}
