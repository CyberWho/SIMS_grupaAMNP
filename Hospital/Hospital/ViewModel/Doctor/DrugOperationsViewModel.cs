using System;
using System.Collections.ObjectModel;
using System.Resources;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.View.Doctor;
using Hospital.xaml_windows.Doctor;
using MVVM1;

namespace Hospital.ViewModel.Doctor
{
    public class DrugOperationsViewModel : BindableBase
    {
        private int id;
        private int id_doc;

        private String rejectText;

        private Window thisWindow;

        private BindableBase currentViewModel;
        private DrugController drugController = new DrugController();

        public ObservableCollection<Drug> drugsApproved { get; set; }
        private Drug selectedDrugApproved;

        public ObservableCollection<Drug> drugsPending { get; set; }
        private Drug selectedDrugPending;

        public MyICommand ReturnOptionCommand { get; set; }
        public MyICommand RejectDrugCommand { get; set; }
        public MyICommand ApproveDrugCommand { get; set; }

        public DrugOperationsViewModel(int id, int id_doc, Window window)
        {
            this.id = id;
            this.id_doc = id_doc;
            this.thisWindow = window;

            ReturnOptionCommand = new MyICommand(ReturnOption);
            RejectDrugCommand = new MyICommand(RejectDrug);
            ApproveDrugCommand = new MyICommand(ApproveDrug);

            drugsApproved = new ObservableCollection<Drug>();
            drugsPending = new ObservableCollection<Drug>();

            foreach (Drug drug in drugController.GetAllDrugs())
            {
                if (drug.Status != DrugStatus.REJECTED)
                {
                    if (drug.Status == DrugStatus.APPROVED)
                        drugsApproved.Add(drug);
                    else
                        drugsPending.Add(drug);
                }
            }


            this.ReturnOptionStartCommand = new MyICommand(ReturnStartOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);

        }

        public DrugOperationsViewModel()
        {

        }
        public String RejectText
        {
            get { return rejectText; }
            set
            {
                rejectText = value;
            }

        }

        public Drug SelectedDrugApproved
        {
            get { return selectedDrugApproved; }
            set
            {
                selectedDrugApproved = value;
                //ovako nesto DeleteCommand.RaiseCanExecuteChanged();

            }
        }

        public Drug SelectedDrugPending
        {
            get { return selectedDrugPending; }
            set
            {
                selectedDrugPending = value;
                //ovako nesto DeleteCommand.RaiseCanExecuteChanged();

            }
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }


        private void ReturnOption()
        {
            Window s = new DoctorUIwindow(this.id);
            s.Show();
            thisWindow.Close();
        }

        private void RejectDrug()
        {
            if (selectedDrugPending != null)
            {
                Drug tmp = SelectedDrugPending;
                tmp.Status = DrugStatus.REJECTED;
                drugController.UpdateDrugNoInventoryPart(tmp);
                drugController.RejectDrug(tmp.Id, id_doc, rejectText);
                drugsPending.Remove(tmp);
            }
            else
            {
                MessageBox.Show("Prvo izaberite lek za odbijanje (srednja kolona)");
            }
        }

        private void ApproveDrug()
        {

            if (selectedDrugPending != null)
            {
                Drug tmp = SelectedDrugPending;
                tmp.Status = DrugStatus.REJECTED;
                drugController.UpdateDrugNoInventoryPart(tmp);
                drugsPending.Remove(tmp);
                drugsApproved.Add(tmp);
            }
            else
            {
                MessageBox.Show("Prvo izaberite lek za odobravanje (srednja kolona)");
            }

        }

        /*********
        navigacija
        ********/
        public MyICommand ReturnOptionStartCommand { get; set; }
        public MyICommand GoToDrugOperationCommand { get; set; }
        public MyICommand GoToAppointmentsCommand { get; set; }
        public MyICommand GoToCreateAppointmentCommand { get; set; }
        public MyICommand GoToScheduleCommand { get; set; }
        public MyICommand GoToPatientSearchCommand { get; set; }

        public void ReturnStartOption()
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