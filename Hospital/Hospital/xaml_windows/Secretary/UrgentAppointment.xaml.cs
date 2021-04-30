using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for UrgentAppointment.xaml
    /// </summary>
    public partial class UrgentAppointment : Window
    {
        private int id;
        private string selectedSpecialization;
        private User user;
        private UserController userController = new UserController();
        private DoctorController doctorController = new DoctorController();        
        private SpecializationContoller specializationContoller = new SpecializationContoller();
        private AppointmentController appointmentController = new AppointmentController();

        public UrgentAppointment(int id)
        {
            InitializeComponent();
            this.id = id;
            this.DataContext = this;
            Update();
        }

        public void Update()
        {
            if (id > 0)
            {
                user = this.userController.GetUserById(id);
                
                PatName.Text = user.Name;
                Surname.Text = user.Surname;
                Username.Text = user.Username;
                PhoneNumber.Text = user.PhoneNumber;
                Email.Text = user.EMail;
            }
            else
            {
                user = this.userController.GuestUser();
            }

        }

        private void selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Specialization> specializations = this.specializationContoller.GetAllSpecializations();
            ObservableCollection<String> types = new ObservableCollection<string>();

            foreach (Specialization sp in specializations)
            {
                types.Add(sp.Type);
            }

            this.selection.ItemsSource = types;
        }

        private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selection.SelectedItem != null)
            {
                selectedSpecialization = selection.SelectedItem.ToString();
            }
        }

        private void Create_Urgent_Appointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();

            DateTime time = fix_time();
            
            appointment = this.appointmentController.ReserveAppointment(appointment);
        }

        private DateTime fix_time()
        {
            DateTime now = DateTime.Now;
            string time = now.ToString();
            string[] split1 = time.Split(' ');
            string[] split2 = split1[1].Split(':');
            int minutes = int.Parse(split2[1]);
            int seconds = int.Parse(split2[2]);
            
            if (now.Minute <= 15)
            {
                TimeSpan ts = new TimeSpan(0, minutes, seconds);
                now = now.Subtract(ts);
            }
            else if (now.Minute <= 45 && now.Minute >= 30)
            {
                TimeSpan ts = new TimeSpan(0, minutes - 30, seconds);
                now = now.Subtract(ts);
            }
            else if (now.Minute > 45)
            {
                TimeSpan ts = new TimeSpan(0, 60 - minutes, -seconds);
                now = now.Add(ts);
            }
            else
            {
                TimeSpan ts = new TimeSpan(0, 30 - minutes, -seconds);
                now = now.Add(ts);
            }

            return now;
        }
    }
}
