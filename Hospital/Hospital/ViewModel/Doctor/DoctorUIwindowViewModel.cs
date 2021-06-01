using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.xaml_windows.Doctor;
using MVVM1;

namespace Hospital.ViewModel.Doctor
{
    class DoctorUIwindowViewModel: BindableBase
    {
        private BindableBase currentViewModel;

        private DoctorController doctorController = new DoctorController();

        private Window thisWindow;

        public MyICommand ReturnOptionCommand { get; set; } 
        public MyICommand GoToDrugOperationCommand { get; set; }

        private int id;
        private int id_doc;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public DoctorUIwindowViewModel(int doctors_id, Window window)
        {
            this.id = doctors_id;
            this.id_doc = doctorController.GetDoctorByUserId(id).Id;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.thisWindow = window;
        }

        public DoctorUIwindowViewModel()
        {
        }

        public void ReturnOption()
        {
            //logout
            //MessageBox.Show(id.ToString());
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

        private void GoToDrugOperation()
        {
            Window s = new DrugOperations(id, id_doc);
            s.Show();
            thisWindow.Close();
        }

    }
}
