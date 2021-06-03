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

        public MyICommand ViewDoctors { get; set; }

        private Window thisWindow;

        public SecretaryUIViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = usersViewModel;
            this.ViewDoctors = new MyICommand(SeeAllDoctors);
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

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "user":
                    CurrentViewModel = usersViewModel;
                    break;
                case "doctor_view":
                    CurrentViewModel = doctorViewModel;
                    break;
            }
        }

    }
}
