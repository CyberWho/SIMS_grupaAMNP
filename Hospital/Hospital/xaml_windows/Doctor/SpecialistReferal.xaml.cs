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
using Hospital.Model;
using Hospital.Controller;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for SpecialistReferal.xaml
    /// </summary>
    public partial class SpecialistReferal : Window
    {
        HealthRecord healthRecord;
        int id_doc_as_emoloyee;
        int id_doc;
        int id_patient;

        private int id_selected_doctor = -1;

        int selected_appointment_id = -1;

        private ObservableCollection<Model.Doctor> doctors = null;
        private DoctorController doctorController = new DoctorController();
        private RefferalForSpecialistController refferalForSpecialistController = new RefferalForSpecialistController();

        public SpecialistReferal(HealthRecord healthRecord, int id_doc_as_emoloyee, int id_doc, int id_patient, int selected_appointment_id)
        {
            InitializeComponent();
            this.healthRecord = healthRecord;
            this.id_doc_as_emoloyee = id_doc_as_emoloyee;
            this.id_doc = id_doc;
            this.id_patient = id_patient;
            this.selected_appointment_id = selected_appointment_id;
            this.doctors = doctorController.GetAllDoctors();
            FillDoctorsToUi();
        }

        public void FillDoctorsToUi()
        {
            foreach (Model.Doctor doctor in doctors)
            {
                if(doctor.Id == this.id_doc)
                    continue;
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = doctor.Id + "|" + doctor.User.Name + " " + doctor.User.Surname + " " +
                              doctor.specialization.Type;
                lb_doctors.Items.Add(lbi);
            }

        }

        private void GiveReferral(object sender, RoutedEventArgs e)
        {
            if (id_selected_doctor != -1)
            {
                ReferralForSpecialist referralForSpecialist = new ReferralForSpecialist();
                referralForSpecialist.doctor_id = this.id_selected_doctor;
                referralForSpecialist.Description = tb_description.Text;
                referralForSpecialist.appointment_id = this.selected_appointment_id;
                referralForSpecialist.healthRecord_id = this.healthRecord.Id;
                refferalForSpecialistController.AddReferral(referralForSpecialist);
            }
        }

        private void ReturnOpetion(object sender, RoutedEventArgs e)
        {
            Window s = new HealthRecordDoctorView(id_doc_as_emoloyee, id_doc, id_patient);
            s.Show();
            this.Close();
        }

        private void DoctorSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                id_selected_doctor = int.Parse(lbi.Content.ToString().Split('|')[0]);
            }
        }
    }
}
