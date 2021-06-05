using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.Model;
using System.Windows;
using Hospital.View.Secretary;
using Hospital.xaml_windows.Secretary;

namespace Hospital.ViewModel.Secretary
{
    public class SecretaryUIViewModel : BindableBase
    {
        public MyICommand<string> NavCommand { get; private set; }
        private UsersViewModel usersViewModel = new UsersViewModel();
        private DoctorViewModel doctorViewModel = new DoctorViewModel();

        private CreateNotificationViewModel createNotificationViewModel = new CreateNotificationViewModel();
        private BindableBase currentViewModel;

        private UserController userController = new UserController();

        public MyICommand ViewDoctors { get; set; }
        public MyICommand UsersView { get; set; }
        public MyICommand GuestAccount { get; set; }
        public MyICommand UrgentAppointment { get; set; }

        private Window thisWindow;

        public SecretaryUIViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = usersViewModel;
            this.ViewDoctors = new MyICommand(SeeAllDoctors);
            this.UsersView = new MyICommand(SeeAllUsers);
            this.GuestAccount = new MyICommand(GuestUser);
            this.UrgentAppointment = new MyICommand(CreateUrgentAppointment);
        }

        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set { SetProperty(ref currentViewModel, value); }
        }

        public void SeeAllDoctors()
        {
            Window s = new DoctorsView();
            s.Show();
        }

        public void SeeAllUsers()
        {
            Window s = new UsersView();
            s.Show();
        }
        
        public void GuestUser()
        {
            Window s = new UserProfileView(this.userController.GuestUser());
            s.Show();
        }

        public void CreateUrgentAppointment()
        {

            Window s = new UrgentAppointment(0);
            s.Show();
        }


        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "users":
                    CurrentViewModel = usersViewModel;
                    break;
                case "doctor_view":
                    CurrentViewModel = doctorViewModel;
                    break;
            }
        }

    }
}
