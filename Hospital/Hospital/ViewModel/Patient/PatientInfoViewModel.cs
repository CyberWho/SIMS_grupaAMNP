using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.View.Patient;

namespace Hospital.ViewModel.Patient
{
    class PatientInfoViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public PatientInfoViewModel()
        {

        }

        private BindableBase currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }


        public PatientInfoViewModel(int userId, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            ShowPatientInfo();
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
        }

        private void ShowPatientInfo()
        {

            Model.Patient patient = new PatientController().GetPatientByUserId(userId);
            Username = patient.User.Username;
            Name = patient.User.Name;
            Surname = patient.User.Surname;
            PhoneNumber = patient.User.PhoneNumber;
            EMail = patient.User.EMail;
        }

        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnHomePage()
        {
            Window window = new PatientUIView(userId);
            window.Show();
            thisWindow.Close();
        }
    }
}
