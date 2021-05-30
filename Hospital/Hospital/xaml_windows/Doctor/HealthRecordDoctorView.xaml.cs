using System;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for HealthRecordDoctorView.xaml
    /// </summary>
    public partial class HealthRecordDoctorView : Window
    {
        private int id_doc;
        private int id_doc_as_user;
        private int id_patient;
        private HealthRecord healthRecord = null;
        private ObservableCollection<Appointment> appointments = null;
        private HealthRecordController healthRecordControleller = new HealthRecordController();
        private AppointmentController appointmentController = new AppointmentController();
        private PatientController patientController = new PatientController();
        private Model.Patient patient = null;
        private int selected_appointment_id = -1;
        private Anamnesis selected_anamensis = null;
        public HealthRecordDoctorView(int idDocAsUser, int id_doc, int id_patient)
        {
            InitializeComponent();
            this.id_doc = id_doc;
            this.id_doc_as_user = idDocAsUser;
            this.id_patient = id_patient;
            healthRecord = healthRecordControleller.GetHealthRecordByPatientId(id_patient);
            //MessageBox.Show(id_patient.ToString());
            appointments = appointmentController.GetAllReservedAppointmentsByPatientId(id_patient);
            patient = patientController.GetPatientByPatientId(id_patient);
            fillAppointmentsToUi();
        }

        private void fillAppointmentsToUi()
        {
            foreach (Appointment appointment in appointments)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = appointment.Id + " soba: " + appointment.Room_Id + " " + appointment.StartTime + " " + appointment.Type;
                lb_appointments.Items.Add(itm);
            }
        }

        private void ChangeAnamnesis(object sender, RoutedEventArgs e)
        {

            if (selected_anamensis != null)
            {
                selected_anamensis.Description = Anamnesis_Text_Box.Text;
                new AnamnesisController().UpdateAnamnesis(selected_anamensis);
            }
            else
            {
                Anamnesis toSave = new Anamnesis();
                toSave.healthRecord = healthRecord;
                foreach (Appointment appointment in appointments)
                    if (appointment.Id == selected_appointment_id)
                        toSave.appointment = appointment;
                toSave.Description = Anamnesis_Text_Box.Text;
                new AnamnesisController().NewAnamnesis(toSave);
                healthRecord.anamnesis.Add(toSave);
                selected_anamensis = toSave;
            }

        }

        void AppointmentChange(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                selected_appointment_id = int.Parse(lbi.Content.ToString().Split(' ')[0]);
                Anamnesis_Text_Box.Text = getSelectedAnamnesisDescription();
            }

        }

        private String getSelectedAnamnesisDescription()
        {
            selected_anamensis = null;
            foreach (Anamnesis anamnesis in healthRecord.anamnesis)
                if (anamnesis.appointment.Id == selected_appointment_id)
                {
                    selected_anamensis = anamnesis;
                    return anamnesis.Description;
                }

            return "Nema anamneze";
        }


        private void GoToPerscriptionGiving(object sender, RoutedEventArgs e)
        {
            if (selected_anamensis != null)
            {
                Window s = new PerscriptionGiving(healthRecord, id_doc_as_user, id_doc, id_patient, selected_anamensis);
                s.Show();
                this.Close();
            }
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new SearchPatient(id_doc_as_user, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateOperation(object sender, RoutedEventArgs e)
        {
            Window s = new Create_operation(id_doc_as_user, id_doc, id_patient);
            s.Show();
            this.Close();
        }

        private void GoToReferralGiving(object sender, RoutedEventArgs e)
        {
            if (selected_appointment_id != -1)
            {
                Window s = new SpecialistReferal(healthRecord, id_doc_as_user, id_doc, id_patient, selected_appointment_id);
                s.Show();
                this.Close();
            }
        }

        private void GoToClinicalTreatmentGiving(object sender, RoutedEventArgs e)
        {
            if (selected_appointment_id != -1)
            {
                Window s = new ClinicalTreatmentGiving(healthRecord, id_doc_as_user, id_doc, id_patient, selected_appointment_id);
                s.Show();
                this.Close();
            }
        }
    }
}
