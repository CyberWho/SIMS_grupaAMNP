using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;
using Oracle.ManagedDataAccess.Client;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryUI.xaml
    /// </summary>
    public partial class SecretaryUI : Window, INotifyPropertyChanged
    {
        int id;
        int current_user_id;

        UserController userController = new UserController();
        PatientController patientController = new PatientController();
        HealthRecordController healthRecordController = new HealthRecordController();
        private WorkHoursController workHoursController = new WorkHoursController();
        private TimeSlotController timeSlotController = new TimeSlotController();

        public System.Collections.IEnumerable Patients { get; set; }

        User secretary { get; set; }
        #region NotifyProperties
        private string _username;
        private string _nname;
        private string _surname;
        private string _phonenumber;
        private string _email;
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

        // ispravljeno
        public SecretaryUI(int id)
        {
            InitializeComponent();
            this.DataContext = this;

            this.id = id;

            //Window t = new test();
            //t.Show();

            // this.workHoursController.AddWorkHours(workHours: new WorkHours());
            // this.timeSlotController.GenerateTimeSlots();
            // this.userController.MakeDoctorUser();

            ObservableCollection<User> users = this.userController.GetAllUsers();
            dataGridPatients.ItemsSource = users;
        }
        // TODO: ispraviti
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var p = new Profile(id);
            p.Show();

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            // dobijam konkretnog sekretara, on ce sigurno postojati jer je uspesno ulogovan i sigurno je sekretar
            cmd.CommandText = "SELECT * FROM users WHERE ID = " + id;
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            secretary = new User();
            secretary.Id = int.Parse(reader.GetString(0));
            secretary.Username = reader.GetString(1);
            secretary.Password = reader.GetString(2);
            secretary.Name = reader.GetString(3);
            secretary.Surname = reader.GetString(4);
            secretary.PhoneNumber = reader.GetString(5);
            secretary.EMail = reader.GetString(6);

            connection.Close();
            connection.Dispose();
        }
        // TODO: ispraviti
        private void Delete_user(object sender, RoutedEventArgs e)
        {
           /* string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();

            connection.Open();

            cmd.CommandText = "DELETE FROM patient where user_id = " + current_user_id;
            int patientRowsAffected = cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM users WHERE id = " + current_user_id;
            int userRowsAffected = cmd.ExecuteNonQuery();

            MessageBox.Show("Uspesno izmenjeno " + userRowsAffected.ToString() + " redova u bazi!");

            connection.Close();
            connection.Dispose();*/
           User user = new UserController().GetUserById(current_user_id);
           new Executer(user, new Modify(), new UserCommand(user, Model.Action.DELETE));
            this.Refresh(sender, e);
        }
        // ispravljeno
        private void Update_user(object sender, RoutedEventArgs e)
        {
            User uUser = new User();
            uUser.Id = current_user_id;
            uUser.Username = Username;
            uUser.Name = NName;
            uUser.Surname = Surname;
            uUser.PhoneNumber = PhoneNumber;
            uUser.EMail = Email;

            //this.Update(uUser);
            User user = new UserController().GetUserById(current_user_id);
            new Executer(user, new Modify(), new UserCommand(uUser, Model.Action.UPDATE));
            this.Refresh(sender, e);
            // KADA SE KORISTI LISTVIEW NE KREIRA SE NPR NEW ROOM OBJEKAT NEGO SAMO OBJEKAT NEW {} I TO JE TO
        }
        // TODO: ispraviti
        private void Add_user(object sender, RoutedEventArgs e)
        {
            Window s = new PatientCreate(current_user_id);
            s.Show();

            User nUser = new User();
            nUser.Username = Username;
            nUser.Name = NName;
            nUser.Surname = Surname;
            nUser.PhoneNumber = PhoneNumber;
            nUser.EMail = Email;

            //MessageBox.Show(nUser.Name);

            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT MAX(id) FROM users";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            int max_id = int.Parse(reader.GetString(0));
            int nUser_id = max_id + 1;

            nUser.Id = nUser_id;
            nUser.Password = Username.ToLower();

            cmd.CommandText = "INSERT INTO users (id, username, password, name, surname, phone_number, email) VALUES " +
                "(:id, :username, :password, :name, :surname, :phone_number, :email)";

            cmd.Parameters.Add("@id", nUser.Id);
            cmd.Parameters.Add("@username", nUser.Username);
            cmd.Parameters.Add("@password", nUser.Password);
            cmd.Parameters.Add("@name", nUser.Name);
            cmd.Parameters.Add("@surname", nUser.Surname);
            cmd.Parameters.Add("@phone_number", nUser.PhoneNumber);
            cmd.Parameters.Add("@email", nUser.EMail);

            cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
           
            this.Close();
        }
        // TODO: ispraviti
        public void Update(User uUser)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE users set username=:username, " +
                "name=:name, " +
                "surname=:surname, " +
                "phone_number=:phone_number, " +
                "email=:email " +
                "WHERE ID = " + current_user_id;

            cmd.Parameters.Add("@username", uUser.Username);
            cmd.Parameters.Add("@name", uUser.Name);
            cmd.Parameters.Add("@surname", uUser.Surname);
            cmd.Parameters.Add("@phone_number", uUser.PhoneNumber);
            cmd.Parameters.Add("@email", uUser.EMail);

            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
        }
        // TODO: ispraviti
        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dataGridPatients.SelectedCells[0] != null)
            {
                var info = dataGridPatients.SelectedCells[0];
                if (info.Column.GetCellContent(info.Item) != null)
                {
                    var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
                    current_user_id = int.Parse(content.ToString());

                    //MessageBox.Show(current_user_id.ToString());

                    string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
                    OracleConnection connection = new OracleConnection(conString);
                    connection.Open();
                    OracleCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM users WHERE id = " + current_user_id;
                    OracleDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    Username = reader.GetString(1);
                    if (Username.Contains("guestUser"))
                    {
                        
                    }
                    else
                    {
                        NName = reader.GetString(3);
                        Surname = reader.GetString(4);
                        PhoneNumber = reader.GetString(5);
                        Email = reader.GetString(6);
                    }

                    connection.Close();
                    connection.Dispose();

                    dataGridPatients.UnselectAll();
                }
            }

        }
        // ispravljeno
        private void Refresh(object sender, RoutedEventArgs e)
        {
            ObservableCollection<User> users = this.userController.GetAllUsers();
            dataGridPatients.ItemsSource = users;

            foreach (Control control in page.Children)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    ((TextBox)control).Text = String.Empty;
                }
            }
        }
        private void User_record(object sender, RoutedEventArgs e)
        {
            User user = this.userController.GetUserById(current_user_id);
            Model.Patient patient = this.patientController.GetPatientByUserId(current_user_id);
            HealthRecord healthRecord = this.healthRecordController.GetHealthRecordByPatientId(patient.Id);

            Window sp = new PatientUpdate(current_user_id);
            sp.Show();


        }
        private void Add_appointment(object sender, RoutedEventArgs e)
        {
            Window s = new PatientAppointment(this.patientController.GetPatientByUserId(current_user_id).Id);
            s.Show();
        }

        private void Guest_user(object sender, RoutedEventArgs e)
        {
            _ = this.userController.GuestUser();
            this.Refresh(sender, e);
        }

        private void Urgent_Appointment(object sender, RoutedEventArgs e)
        {
            Window s = new UrgentAppointment(current_user_id);
            s.Show();
        }

        private void Pregled_termina(object sender, RoutedEventArgs e)
        {

        }
        
        private void Notifications(object sender, RoutedEventArgs e)
        {
            Window s = new Notifications(this.id);
            s.Show();
        }

        private void View_Doctors(object sender, RoutedEventArgs e)
        {
            Window s = new ViewDoctors();
            s.Show();
        }

        private void NewAbstractUser(object sender, RoutedEventArgs e)
        {
            Window s = new CreateUserWindow();
            s.Show();
            this.Close();
        }
    }
}
