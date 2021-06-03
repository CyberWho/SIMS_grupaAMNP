using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Hospital.Controller;
using MVVM1;

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
                itm.Height = 50;
                Separator sep = new Separator();
                sep.Height = 10;
                sep.MaxHeight = 10;
                lb_appointments.Items.Add(sep);


            }
            this.DataContext = this;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);
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

        /***************************
        ***
        Dodavanje navigacije
        ***
        ***************************/
        public MyICommand ReturnOptionCommand { get; set; }
        public MyICommand GoToDrugOperationCommand { get; set; }
        public MyICommand GoToAppointmentsCommand { get; set; }
        public MyICommand GoToCreateAppointmentCommand { get; set; }
        public MyICommand GoToScheduleCommand { get; set; }
        public MyICommand GoToPatientSearchCommand { get; set; }

        public void ReturnOption()
        {
            Window s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void GoToAppointments()
        {
            Window s = new Doctor_crud_appointments(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateAppointment()
        {
            Window s = new Create_appointment(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToSchedule()
        {
            Window s = new Schedule(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToPatientSearch()
        {
            Window s = new SearchPatient(id, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToDrugOperation() // Obradjuje se
        {

            Window s = new View.Doctor.DrugOperations(id, id_doc);
            s.Show();
            this.Close();
        }

    }
}
