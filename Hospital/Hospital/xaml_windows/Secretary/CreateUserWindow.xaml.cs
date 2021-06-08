using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for CreateUserWindow.xaml
    /// </summary>
    public partial class CreateUserWindow : Window
    {
        public AbstractUser user { get; set; }
        private _UserFactory factory = null;
        private bool doctorFlag = false;


        private string specialization;
        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private int room_id;
        private RoomController roomController = new RoomController();

        public CreateUserWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            user = new AbstractEmployee();
        }
        
        private void Doctor_OnChecked(object sender, RoutedEventArgs e)
        {
            doctorFlag = true;

            specLabel.Visibility = Visibility.Visible;
            roomLabel.Visibility = Visibility.Visible;
            specialization_selection.Visibility = Visibility.Visible;
            room_selection.Visibility = Visibility.Visible;
        }

        private void Patient_OnChecked(object sender, RoutedEventArgs e)
        {
            factory = new _PatientFactory
                (
                    id: 0,
                    username: user.username,
                    password: user.username.ToLower(),
                    name: user.name,
                    surname: user.surname,
                    phone_number: user.phone_number,
                    email: user.email,
                    jmbg: user.jmbg,
                    date_of_birth: user.date_of_birth,
                    patient_id: 0,
                    health_record_id: 0
                );
        }

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            if (doctorFlag)
            {
                int spec_id =  this.specializationContoller.GetSpecializationByType(specialization);
                factory = new _EmployeeFactory
                (
                    id: 0,
                    username: user.username,
                    password: user.username.ToLower(),
                    name: user.name,
                    surname: user.surname,
                    phone_number: user.phone_number,
                    email: user.email,
                    jmbg: user.jmbg,
                    date_of_birth: user.date_of_birth,
                    room_id: room_id,
                    specialization_id: spec_id,
                    employee_id: 0,
                    doctor_id: 0
                );
            }

            UserController userController = new UserController();
            userController.makeAbstractUser(factory.getAbstractUser());

        }

        private void specialization_selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Specialization> specializations = this.specializationContoller.GetAllSpecializations(false);
            ObservableCollection<String> specializationsTypes = new ObservableCollection<String>();

            foreach (Specialization s in specializations)
            {
                specializationsTypes.Add(s.Type);
            }

            this.specialization_selection.ItemsSource = specializationsTypes;
        }

        private void specialization_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (specialization_selection.SelectedItem != null)
            {
                specialization = specialization_selection.SelectedItem.ToString();
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

        private void room_selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (room_selection.SelectedItem != null)
            {
                room_id = int.Parse(room_selection.SelectedItem.ToString());
            }
        }
    }
}
