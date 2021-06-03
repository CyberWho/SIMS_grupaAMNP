using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.ViewModel.Secretary
{
    class DoctorProfileViewModel : BindableBase
    {
        public Model.Doctor doctor { get; set; }

        public ObservableCollection<Specialization> specializations { get; set; }
        public ObservableCollection<String> specializationsTypes { get; set; }
        public string selectedSpecialization { get; set; }

        public ObservableCollection<Room> rooms { get; set; }
        public ObservableCollection<int> room_ids { get; set; }
        public int selectedRoomId { get; set; }


        public DoctorProfileViewModel(Model.Doctor doctor)
        {
            this.doctor = doctor;
            loadSpecializations();
            loadRooms();
            deleteDoctor = new MyICommand(Delete_user);
            updateDoctor = new MyICommand(Update_user);
        }

        public MyICommand deleteDoctor { get; set; }
        public MyICommand updateDoctor { get; set; }
        public MyICommand freeDays { get; set; }
        public MyICommand createDoctor { get; set; }



        private DoctorController doctorController = new DoctorController();

        private UserController userController = new UserController();
        private EmployeeController employeeController = new EmployeeController();

        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private string specialization;
        private RoomController roomController = new RoomController();
        private int room_id;

        private int current_doctor_id;

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


        //public DoctorPopUp(Model.Doctor doctor)
        //{
        //    InitializeComponent();
        //    this.DataContext = this;

        //    if (doctor != null)
        //    {
        //        this.doctor = doctor;
        //        fill_user_data(this.doctor);
        //    }
        //    else
        //    {
        //        createDoctor.Visibility = Visibility.Visible;
        //        deleteDoctor.Visibility = Visibility.Hidden;
        //        updateDoctor.Visibility = Visibility.Hidden;
        //        freeDays.Visibility = Visibility.Hidden;
        //    }
        //}

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            Employee employee = makeEmployee();

            Model.Doctor doctor = new Model.Doctor();
            doctor.employee_id = employee.Id;
            doctor.room_id = room_id;
            doctor = this.doctorController.AddDoctor(doctor, specialization);
        }

        private void fill_user_data(Model.Doctor doctor)
        {
            NName = doctor.User.Name;
            Surname = doctor.User.Surname;
            Username = doctor.User.Username;
            PhoneNumber = doctor.User.PhoneNumber;
            Email = doctor.User.EMail;
            Salary = doctor.Salary.ToString();
        }

        private void Delete_user()
        {
            this.doctorController.DeleteDoctorById(current_doctor_id);
            //this.Close();
        }

        private void Update_user()
        {
            User user = parseUserData();
            Employee employee = new Employee();
            employee.User = user;
            employee.Salary = int.Parse(Salary);

            Model.Doctor doctor = new Model.Doctor();
            doctor.Id = current_doctor_id;

            employee.Id = this.employeeController.getEmployeeIdByDoctorId(current_doctor_id);

            _ = this.employeeController.UpdateEmployee(employee);
        }

        private Employee makeEmployee()
        {
            User user = makeUser();
            Role role = new Role(
                id: 1,
                roleType: "Doctor"
            );
            Employee employee = getEmployeeData(user, role);

            return this.employeeController.AddEmployee(employee);
        }

        private Employee getEmployeeData(User user, Role role)
        {
            Employee employee = new Employee();
            employee.Id = 0;
            employee.User = user;
            employee.role = role;
            employee.YearsOfService = 0;

            if (int.Parse(Salary) != null)
            {
                employee.Salary = int.Parse(Salary);
            }
            else
            {
                MessageBox.Show("Morate uneti iznos plate pri kreiranju lekara!");
            }


            return employee;
        }

        private User makeUser()
        {
            User user = parseUserData();
            return this.userController.newUser(user);
        }

        private User parseUserData()
        {
            User user = new User();

            user.Username = Username;
            user.Password = Username.ToLower();
            user.Name = NName;
            user.Surname = Surname;
            user.PhoneNumber = PhoneNumber;
            user.EMail = Email;

            return user;
        }

        private void getSpecialization()
        {
            if (selectedSpecialization != null)
            {
                
            }

        }

        private void loadSpecializations()
        {
            ObservableCollection<Specialization> specializations = this.specializationContoller.GetAllSpecializations(false);
            specializationsTypes = new ObservableCollection<String>();

            foreach (Specialization s in specializations)
            {
                specializationsTypes.Add(s.Type);
            }
        }

        private void getRoom()
        {
            
        }

        private void loadRooms()
        {
            RoomType rt = new RoomType(3, "Soba za preglede", null);
            this.rooms = this.roomController.GetAllRoomsByRoomType(rt);
            this.room_ids = new ObservableCollection<int>();

            foreach (Room r in rooms)
            {
                room_ids.Add(r.Id);
            }
        }

        private void manage_free_days(object sender, RoutedEventArgs e)
        {
            //Window s = new Secretary.FreeDays(current_doctor_id);
            //s.Show();
        }
    }
}
