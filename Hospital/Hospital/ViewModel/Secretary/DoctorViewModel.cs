using Hospital.Controller;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.View.Secretary;
using Hospital.xaml_windows.Secretary;
using Xceed.Wpf.Toolkit.Core;

namespace Hospital.ViewModel.Secretary
{
    public class DoctorViewModel : BindableBase
    {
        
        public ObservableCollection<Model.Doctor> doctors { get; set; }
        public Model.Doctor selectedtDoctor { get; set; }

        private DoctorController doctorController = new DoctorController();

        

        private UserController userController = new UserController();
        private EmployeeController employeeController = new EmployeeController();

        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private string specialization;
        private RoomController roomController = new RoomController();
        private int room_id;

        private int current_doctor_id;

        public MyICommand addDoctorCommand { get; set; }
        public MyICommand openDoctorCommand { get; set; }


        #region NotifyProperties

        public Model.Doctor SelectedDoctor
        {
            get { return selectedtDoctor; }
            set
            {
                selectedtDoctor = value;
                openDoctorCommand.RaiseCanExecuteChanged();
            }
        }


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
        #endregion

        public DoctorViewModel()
        {
            this.doctors = this.doctorController.GetAllDoctors();
            this.addDoctorCommand = new MyICommand(Add_user);
            this.openDoctorCommand = new MyICommand(Open_doctor, Can_open);
        }

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var info = dataGridDoctors.SelectedCells[0];
            //if (info != null && info.Column.GetCellContent(info.Item) != null)
            //{
            //    var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
            //    current_doctor_id = int.Parse(content);
            //    Model.Doctor doctor = this.doctorController.GetDoctorById(current_doctor_id);

            //    //DoctorProfileViewModel p = new ViewModel.Secretary.DoctorProfileViewModel(doctor);
            //    Window s = new DoctorPopUp(doctor);
            //    s.Show();


            //    dataGridDoctors.UnselectAll();
            //}
        }


        private void Add_user()
        {
            Window s;
            if (selectedtDoctor == null)
            {
                s = new DoctorProfileView(null);
            }

            s = new DoctorProfileView(selectedtDoctor);
            s.Show();
        }

        private bool Can_open()
        {
            return this.selectedtDoctor != null;
        }

        private void Open_doctor()
        {
            MessageBox.Show("AAAAAAAAAAAAAAAAAA");
            Window s = new DoctorProfileView(selectedtDoctor);
            s.Show();
        }

    }
}
