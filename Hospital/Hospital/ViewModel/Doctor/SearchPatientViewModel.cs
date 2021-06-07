using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.View.Doctor;
using Hospital.xaml_windows.Doctor;
using MVVM1;

namespace Hospital.ViewModel.Doctor
{
    class SearchPatientViewModel
    {
        private int id { set; get; }
        private int id_doc { set; get; }

        private int selected_patient_id = -1;

        private PatientController patientController = new PatientController();
        private ObservableCollection<Model.Patient> patients = null;

        public MyICommand returnOptionFrontCommand { get; set; }
        public MyICommand goToHealthRecordCommand { get; set; }

        private Window thisWindow;
        private ListBox lb_appointments;
        private Button btn_nazad;
        private Button btn_idi_na_karton;
        public SearchPatientViewModel(int id, int id_doc, Window window, ListBox lb, Button nazad, Button dalje)
        {
            this.id = id;
            this.id_doc = id_doc;
            this.thisWindow = window;
            this.lb_appointments = lb;
            this.btn_nazad = nazad;
            this.btn_idi_na_karton = dalje;
            patients = patientController.GetAllPatients();
            foreach (Model.Patient patient in patients)
            {
                ListBoxItem itm = new ListBoxItem();
                int i = patient.Id;
                int size = 3;
                itm.Content = patient.Id;
                while (i != 0)
                {
                    i /= 10;
                    size -= 1;
                }

                while (size-- != 0)
                {
                    itm.Content += " ";
                }
                itm.Content += patient.User.Name + " " + patient.User.Surname + "\nJMBG: " + patient.JMBG;
                lb_appointments.Items.Add(itm);
                itm.Height = 50;
                Separator sep = new Separator();
                sep.Height = 10;
                sep.MaxHeight = 10;
                lb_appointments.Items.Add(sep);

            }

            this.returnOptionFrontCommand = new MyICommand(ReturnOptionFront);
            this.goToHealthRecordCommand = new MyICommand(GoToHealthRecord);

            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);
        }

        private ListBoxItem lbi_selected;

        public ListBoxItem Lbi_selected
        {
            get { return lbi_selected; }
            set
            {
                lbi_selected = value;
                selected_patient_id = int.Parse(lbi_selected.Content.ToString().Split(' ')[0]);
                btn_idi_na_karton.IsEnabled = true;
            }
        }

        private void GoToHealthRecord()
        {
            if (selected_patient_id != -1)
            {
                Window s = new HealthRecordDoctorView(id, id_doc, selected_patient_id);
                s.Show();
                thisWindow.Close();
            }
        }

       /* void ChangeFocusedPatient(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                selected_patient_id = int.Parse(lbi.Content.ToString().Split(' ')[0]);
                //MessageBox.Show(selected_patient_id.ToString());
                btn_idi_na_karton.IsEnabled = true;
            }
        }*/

        private void ReturnOptionFront()
        {
            Window s = new DoctorUIwindow(id);
            s.Show();
            thisWindow.Close();
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
            thisWindow.Close();
        }

        private void GoToAppointments()
        {
            Window s = new Doctor_crud_appointments(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

        private void GoToCreateAppointment()
        {
            Window s = new Create_appointment(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

        private void GoToSchedule()
        {
            Window s = new Schedule(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

        private void GoToPatientSearch()
        {
            Window s = new SearchPatient(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

        private void GoToDrugOperation() // Obradjuje se
        {

            Window s = new View.Doctor.DrugOperations(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

    }
}
