using System;
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

        }

        private void Add_user(object sender, RoutedEventArgs e)
        {
            Employee employee = makeEmployee();

            Model.Doctor doctor = new Model.Doctor();
            doctor.employee_id = employee.Id;
            doctor.room_id = room_id;
            doctor = this.doctorController.AddDoctor(doctor, specialization); 

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


            employee.Salary = int.Parse(Salary);



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

        private void Delete_user(object sender, RoutedEventArgs e)
        {

        }

        private void Update_user(object sender, RoutedEventArgs e)
        {
            User user = parseUserData();
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            doctors = this.doctorController.GetAllDoctors();
            dataGridDoctors.ItemsSource = doctors;

            //foreach (Control control in page.Children)
            //{
            //    if (control.GetType() == typeof(TextBox))
            //    {
            //        ((TextBox)control).Text = String.Empty;
            //    }
            //}
        }

        private void specialization_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (specialization_selection.SelectedItem != null)
            {
                specialization = specialization_selection.SelectedItem.ToString();
            }

        }

        private void specialization_selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Specialization> specializations = this.specializationContoller.GetAllSpecializations();
            ObservableCollection<String> specializationsTypes = new ObservableCollection<String>();

            foreach (Specialization s in specializations)
            {
                specializationsTypes.Add(s.Type);
            }

            this.specialization_selection.ItemsSource = specializationsTypes;
        }

        private void room_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (room_selection.SelectedItem != null)
            {
                room_id = int.Parse(room_selection.SelectedItem.ToString());
            }

        }

        private void room_selection_loaded(object sender, RoutedEventArgs e)
        {
            RoomType rt = new RoomType(3, "Soba za preglede", null);
            ObservableCollection<Room> rooms = this.roomController.GetAllRoomsByRoomType(rt);
            ObservableCollection<int> roomsIds = new ObservableCollection<int>();

            foreach (Room r in rooms)
            {
                roomsIds.Add(r.Id);
            }

            this.room_selection.ItemsSource = roomsIds;
        }
    }
}
