using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;
using Xceed.Wpf.Toolkit.Core;
using PatientNewAppointment = Hospital.xaml_windows.Secretary.PatientNewAppointment;

namespace Hospital.ViewModel.Secretary
{
    class UserViewModel : BindableBase
    {
        #region attributes

        private Window thisWindow;
        private int current_user_id;
        public User user { get; set; }
        private bool isNull;

        private UserController userController = new UserController();

        public MyICommand deleteUser { get; set; }
        public MyICommand updateUser { get; set; }
        public MyICommand createUser { get; set; }
        public MyICommand viewApps { get; set; }
        public MyICommand viewAllergies { get; set; }

        #endregion

        #region NotifyProperties
        private string _username;
        private string _nname;
        private string _surname;
        private string _phonenumber;
        private string _email;
        private string _salary;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        public string NName
        {
            get
            {
                return _nname;
            }
            set
            {
                if (value != _nname)
                {
                    _nname = value;
                    OnPropertyChanged("NName");
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                if (value != _phonenumber)
                {
                    _phonenumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value != _salary)
                {
                    _salary = value;
                    OnPropertyChanged("Salary");
                }
            }
        }
        #endregion
        #region PropertyChangedNotifier
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        public UserViewModel(Window window, bool demoFlag, User user = null)
        {
            this.thisWindow = window;
            if (demoFlag)
            {
                demoFunc();

            }
            else
            {
                if (user != null)
                {
                    isNull = false;
                    this.user = user;
                    current_user_id = this.user.Id;
                    fill_user_data(user);
                }
                else
                {
                    isNull = true;
                }
                this.thisWindow = window;
                this.deleteUser = new MyICommand(Delete_user, Can_delete);
                this.updateUser = new MyICommand(Update_user, Can_update);
                this.createUser = new MyICommand(Create_user, Can_create);
                this.viewApps = new MyICommand(View_apps, Can_view_apps);
                this.viewAllergies = new MyICommand(View_alergies, Can_view_allergies);
            }
        }

        private async void demoFunc()
        {
            AutoClosingMessageBox.Show(
                "Sledi popunjavanje regija za unos podataka. U odgovarajuce regije uneti odgovarajuce podatke. Demo ce popuniti neophodne podatke, imajte na umu da program sam generise lozinku koja odgovara korisnickom imenu napisanom malim slovima", 5000);

            await Task.Delay(1000);
            User demoUser = new User(
                    1000,
                    "demo username",
                    "demo username",
                    "demo ime",
                    "demo prezime",
                    "12345",
                    "demo@demo.demo"
                );
            NName = demoUser.Name;
            await Task.Delay(1000);
            Surname = demoUser.Surname;
            await Task.Delay(1000);
            Username = demoUser.Username;
            await Task.Delay(1000);
            PhoneNumber = demoUser.PhoneNumber;
            await Task.Delay(1000);
            Email = demoUser.EMail;
            await Task.Delay(1000);

            AutoClosingMessageBox.Show(
                "Uneti podaci se smatraju dobro unetim i sada ih je potrebno sacuvati. Podaci se cuvaju klikom na dugme: 'Kreirajte korisnika'.", 5000);

            await Task.Delay(3000);


            this.thisWindow.Close();

        }

        private void View_alergies()
        {
            Window s = new PatientUpdate(current_user_id);
            s.Show();

        }

        private bool Can_view_allergies()
        {
            return this.user != null;
        }

        private void Delete_user()
        {
            if (MessageBox.Show("Da li zaista zelite da obrisete korisnika?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Niste obrisali korisnika!");
            }
            else
            {
                this.userController.DeleteUserById(current_user_id);
                MessageBox.Show("Uspesno ste obrisali korisnika!");
                thisWindow.Close();
            }
        }

        private bool Can_delete()
        {
            return this.user != null;
        }

        private void Update_user()
        {
            User user = parseUserData();
            this.userController.UpdateUser(user);
            MessageBox.Show("Uspesno ste izmenili podatke korisnika!");
            this.thisWindow.Close();
        }
        private bool Can_update()
        {
            return this.user != null;
        }

        private void Create_user()
        {
            User user = parseUserData();
            user.Id = 0;
            this.user = this.userController.newUser(user);
            this.current_user_id = this.user.Id;
        }
        private bool Can_create()
        {
            return this.user == null;
        }

        private void View_apps()
        {
            Window s = new PatientAppointment(current_user_id, true);
            s.Show();
            this.thisWindow.Close();
        }

        private bool Can_view_apps()
        {
            return this.user != null;
        }

        private void Create_appointment()
        {
            Window s = new PatientNewAppointment(current_user_id, true);
            s.Show();
            this.thisWindow.Close();
        }
        private bool Can_create_appointment()
        {
            return this.user != null;
        }

        private User parseUserData()
        {
            User user = new User(
                this.current_user_id,
                Username,
                Username.ToLower(),
                NName,
                Surname,
                PhoneNumber,
                Email);

            return user;
        }

        private void fill_user_data(User user)
        {
            NName = user.Name;
            Surname = user.Surname;
            Username = user.Username;
            PhoneNumber = user.PhoneNumber;
            Email = user.EMail;
        }

    }
}
