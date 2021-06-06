using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.Model;
using System.Windows;
using System.Windows.Controls;
using Hospital.View.Secretary;
using Hospital.xaml_windows.Patient;
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
        public MyICommand ViewNotifications { get; set; }
        public MyICommand PrintReport { get; set; }
        public MyICommand DemoCommand { get; set; }

        private Window thisWindow;

        public SecretaryUIViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            CurrentViewModel = usersViewModel;
            this.ViewDoctors = new MyICommand(SeeAllDoctors);
            this.UsersView = new MyICommand(SeeAllUsers);
            this.GuestAccount = new MyICommand(GuestUser);
            this.UrgentAppointment = new MyICommand(CreateUrgentAppointment);
            this.ViewNotifications = new MyICommand(Notifications);
            this.PrintReport = new MyICommand(Report);
            this.DemoCommand = new MyICommand(demo);
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

        private void Notifications()
        {
            Window s = new xaml_windows.Secretary.Notifications(0);
            s.Show();
        }

        private void Report()
        {
            Window s = new Report();
            s.Show();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(s, "Izvestaj");
            }
        }

        private async void demo()
        {
            if (MessageBox.Show("Upravo ste pokrenuli demo koji pokazuje kreiranje korisnika! Da li zelite da pokrenete demo?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Demo je prekinut!");
            }
            else
            {
                AutoClosingMessageBox.Show("Demo se nastavlja, i prvi korak jeste otvaranje prozora pacijenata. Prozor se otvara klikom na drugo dugme, dugme 'Pacijenti'", 5000);
                await Task.Delay(1000);
                Window usersWindow = new UsersView();
                usersWindow.Show();
                await Task.Delay(1000);

                AutoClosingMessageBox.Show(
                    "Prozor sa pregledom korisnika je uspesno otvoren. Sledeci korak za kreiranje korisnika izvrsava se klikom na dugme: 'Kreirajte korisnika'", 5000);
                await Task.Delay(1000);
                usersWindow.Close();

                Window userProfile = new UserProfileView(null, true);
                userProfile.Show();
                await Task.Delay(1000);

                

                usersWindow = new UsersView(true);

                AutoClosingMessageBox.Show("Korisnik je uspesno kreiran, i sada cete to i videti.", 5000);
                usersWindow.Show();

                await Task.Delay(5000);
                usersWindow.Close();





            }
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
