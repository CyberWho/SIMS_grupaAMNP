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
using Xceed.Wpf.Toolkit.Core.Converters;

namespace Hospital.ViewModel.Secretary
{
    class DoctorProfileViewModel : BindableBase
    {
        #region attributes

        private Window thisWindow;

        public Model.Doctor doctor { get; set; }
        private bool isNull;

        public ObservableCollection<Specialization> specializations { get; set; }
        public ObservableCollection<String> specializationsTypes { get; set; }
        public string selectedSpecialization { get; set; }

        public ObservableCollection<Room> rooms { get; set; }
        public ObservableCollection<int> room_ids { get; set; }
        public int selectedRoomId { get; set; }

        private DoctorController doctorController = new DoctorController();

        private UserController userController = new UserController();
        private EmployeeController employeeController = new EmployeeController();

        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private string specialization;
        private RoomController roomController = new RoomController();
        private int room_id;

        private int current_doctor_id;


        public MyICommand deleteDoctor { get; set; }
        public MyICommand updateDoctor { get; set; }
        public MyICommand freeDays { get; set; }
        public MyICommand createDoctor { get; set; }

        #endregion


        public DoctorProfileViewModel(Window window, Model.Doctor doctor = null)
        {
            if (doctor != null)
            {
                isNull = false;
                this.doctor = doctor;
                current_doctor_id = this.doctor.Id;
                fill_user_data(doctor);
            }
            else
            {
                isNull = true;
                loadSpecializations();
                loadRooms();
            }

            this.thisWindow = window;
            deleteDoctor = new MyICommand(Delete_user, Can_delete);
            updateDoctor = new MyICommand(Update_user, Can_update);
            freeDays = new MyICommand(Manage_free_days, Can_view_free_days);
            createDoctor = new MyICommand(Create_user, Can_create);
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

        #region validations
        private bool Can_create()
        {
            return this.isNull;
        }

        private bool Can_delete()
        {
            return !this.isNull;
        }
        private bool Can_update()
        {
            return !this.isNull;
        }

        private bool Can_view_free_days()
        {
            return !this.isNull;
        }
        #endregion

        private void Create_user()
        {
            Employee employee = makeEmployee();

            Model.Doctor doctor = new Model.Doctor();
            doctor.employee_id = employee.Id;
            doctor.room_id = getRoomId();
            doctor = this.doctorController.AddDoctor(doctor, getSpecialization());
            this.doctor = doctor;
            MessageBox.Show("Uspesno ste kreirali lekara!");
            thisWindow.Close();
        }
        
        private void Delete_user()
        {
            if (MessageBox.Show("Da li zaista zelite da obrisete lekara?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Niste obrisali lekara!");
            }
            else
            {
                this.doctorController.DeleteDoctorById(current_doctor_id);
                MessageBox.Show("Uspesno ste obrisali lekara!");
                thisWindow.Close();
            }
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

            MessageBox.Show("Uspesno ste izmenili podatke lekara");
            thisWindow.Close();
        }
        private void Manage_free_days()
        {
            Window s = new xaml_windows.Secretary.FreeDays(current_doctor_id);
            s.Show();
            thisWindow.Close();
        }

        #region helper functions, data loading

        private void fill_user_data(Model.Doctor doctor)
        {
            NName = doctor.User.Name;
            Surname = doctor.User.Surname;
            Username = doctor.User.Username;
            PhoneNumber = doctor.User.PhoneNumber;
            Email = doctor.User.EMail;
            Salary = doctor.Salary.ToString();
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
        private User makeUser()
        {
            User user = parseUserData();
            return this.userController.newUser(user);
        }
        private User parseUserData()
        {
            User user = new User(
                    Username, 
                    Username.ToLower(),
                    NName,
                    Surname, 
                    PhoneNumber, 
                    Email);

            return user;
        }
        private Employee getEmployeeData(User user, Role role)
        {
            Employee employee = new Employee(
                    0,
                    int.Parse(Salary),
                    0,
                    user,
                    role);

            return employee;
        }
        private string getSpecialization()
        {
            if (selectedSpecialization != null)
            {
                return selectedSpecialization;
            }

            return "";
        }
        private int getRoomId()
        {
            if (selectedRoomId != null)
            {
                return selectedRoomId;
            }

            return 0;
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
        #endregion

    }
}
