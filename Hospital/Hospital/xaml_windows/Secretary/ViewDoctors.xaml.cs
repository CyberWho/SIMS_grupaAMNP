﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;
using Hospital.View.Secretary;
using Hospital.ViewModel.Secretary;

// kt5
namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for ViewDoctors.xaml
    /// </summary>
    public partial class ViewDoctors : Window, INotifyPropertyChanged
    {
        private DoctorController doctorController = new DoctorController();
        private UserController userController = new UserController();
        private EmployeeController employeeController = new EmployeeController();

        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private string specialization;
        private RoomController roomController = new RoomController();
        private int room_id;

        private int current_doctor_id;

        private ObservableCollection<Model.Doctor> doctors;

        public ViewDoctors()
        {
            InitializeComponent();
            this.DataContext = this;

            doctors = this.doctorController.GetAllDoctors();
            dataGridDoctors.ItemsSource = doctors;
        }

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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = dataGridDoctors.SelectedCells[0];
            if (info != null && info.Column.GetCellContent(info.Item) != null)
            {
                var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
                current_doctor_id = int.Parse(content);
                Model.Doctor doctor = this.doctorController.GetDoctorById(current_doctor_id);

                //DoctorProfileViewModel p = new ViewModel.Secretary.DoctorProfileViewModel(doctor);
                Window s = new DoctorPopUp(doctor);
                s.Show();
                

                dataGridDoctors.UnselectAll();
            }
        }

        private void Add_user(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorPopUp(null);
            s.Show();
        }
        
    }
}
