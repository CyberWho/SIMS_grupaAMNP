using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using System.Collections.ObjectModel;
using Hospital.Model;
using MVVM1;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        private int id { set; get; }
        private int id_doc { set; get; }
        private AppointmentController appointmentContoller = new AppointmentController();
        private PatientController patientController = new PatientController();
        private ObservableCollection<Appointment> appointments;

        public Schedule(int id, int id_doc)
        {
            InitializeComponent();
            this.id = id;
            this.id_doc = id_doc;
            appointments = appointmentContoller.GetAllAppointmentsByDoctorId(this.id_doc);
            foreach (Appointment ap in appointments)
            {
               // MessageBox.Show(ap.Patient_Id.ToString());
                ListBoxItem itm = new ListBoxItem();
                ap.patient = patientController.GetPatientById(ap.Patient_Id);

                itm.Content = ap.Id.ToString() + "/" + ap.Patient_Id.ToString() + " " + ap.patient.User.Name + " " + ap.StartTime;

                lb_appointments.Items.Add(itm);

            }


            this.DataContext = this;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);
        }


        void PrintText(object sender, SelectionChangedEventArgs args)
        {
            more_info.Text = "";
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                int id_patient_split = int.Parse((lbi.Content.ToString().Split(' '))[0].Split('/')[1]);
                //more_info.Text += id_pat.ToString();
                foreach(Appointment ap in appointments)
                    if(ap.Patient_Id == id_patient_split)
                    {
                        more_info.Text += ap.patient.User.Name + " " +
                                          ap.patient.User.Surname + "\n" +
                                          ap.patient.JMBG + "\n" +
                                          ap.patient.DateOfBirth + "\n" +
                                          ap.patient.User.PhoneNumber + "\n" +
                                          ap.patient.User.EMail;
                        break;
                    }
            }
            else
            {
                more_info.Text = "";
            }
        }


        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorUI(this.id);
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
