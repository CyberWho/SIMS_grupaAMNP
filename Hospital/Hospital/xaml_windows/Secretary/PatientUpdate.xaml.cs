using Hospital.Model;
using System;
using System.Collections.Generic;
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
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;
using Hospital.Controller;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for PatientUpdate.xaml
    /// </summary>
    public partial class PatientUpdate : Window, INotifyPropertyChanged
    {

        int user_id = 0;
        int currentAllergyTypeId;
        string type;
        int patient_id;
        int health_record_id;
        int address_id;
        ObservableCollection<AllergyType> allergyTypes = new ObservableCollection<AllergyType>();
        AllergyTypeController allergyTypeController = new AllergyTypeController();
        AllergyController allergyController = new AllergyController();
        PatientController patientController = new PatientController();
        HealthRecordController healthRecordController = new HealthRecordController();
        AddressController addressController = new AddressController();
        #region NotifyProperties
        private string _id_address;
        private string _atype;
        public string Id_address
        {
            get
            {
                return _id_address;
            }
            set
            {
                if (value != _id_address)
                {
                    _id_address = value;
                    OnPropertyChanged("Id_address");
                }
            }
        }
        public string aType
        {
            get
            {
                return _atype;
            }
            set
            {
                if (value != _atype)
                {
                    _atype = value;
                    OnPropertyChanged("Izmeni_alergiju");
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

        public PatientUpdate(int current_user_id)
        {
            InitializeComponent();
            this.DataContext = this;
            if (user_id == 0)
            {
                this.user_id = current_user_id;
                this.patient_id = this.patientController.GetPatientByUserId(user_id).Id;
                this.health_record_id = this.healthRecordController.GetHealthRecordByPatientId(patient_id).Id;
                this.address_id = this.addressController.GetAddressByPatientId(patient_id).Id;
            }

            fill_data();
        }

        private void fill_data()
        {
            this.DataContext = this;

            ObservableCollection<AllergyType> allergyTypes = allergyTypeController.GetAllTypesByHealthRecordId(health_record_id);
            DataTable dt = new DataTable();

            dataGridAllergies.DataContext = dt;
            dataGridAllergies.ItemsSource = allergyTypes;
        }

        private void Sacuvaj_pacijenta(object sender, RoutedEventArgs e)
        {
            Window s = new SecretaryUI(this.user_id);
            s.Show();

            Model.Patient nPatient = new Model.Patient();

            /*string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            connection.Open();
            cmd.CommandText = "SELECT * FROM address, city, state WHERE address.id = " + int.Parse(Id_address) + " AND address.CITY_ID = city.ID AND city.STATE_ID = state.ID";
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();

            State state = new State
            {
                Id = int.Parse(reader.GetString(8)),
                Name = reader.GetString(9)
            };

            City city = new City
            {
                Id = int.Parse(reader.GetString(4)),
                Name = reader.GetString(5),
                PostalCode = reader.GetString(6),
                State = state
            };

            Address address = new Address
            {
                Id = int.Parse(reader.GetString(0)),
                Name = reader.GetString(1),
                // PostalCode = reader.GetString(2),
                City = city
            };

            nPatient.Address = address;*/

            Update(nPatient);

            /*connection.Close();
            connection.Dispose();*/
        }
        public void Update(Model.Patient uPatient)
        {
            string conString = "User Id = ADMIN; password = Passzacloud1.; Data Source = dbtim1_high;";
            OracleConnection connection = new OracleConnection(conString);
            OracleCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT id from patient WHERE user_id = " + user_id;
            connection.Open();
            OracleDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int patient_id = int.Parse(reader.GetString(0));

            //cmd.CommandText = "UPDATE patient SET address_id=:address_id WHERE ID = " + patient_id;

            //cmd.Parameters.Add("@address_id", uPatient.Address.Id);

            int rowsAffected = cmd.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

            this.Close();
        }
        // ovde
        private void Obrisi_alergen(object sender, RoutedEventArgs e)
        {
            _ = this.allergyController.DeleteAllergyByUserIdAndAllergyTypeId(user_id, currentAllergyTypeId);
            fill_data();
            refresh();
        }
        // i ovde
        private void Dodaj_alergiju(object sender, RoutedEventArgs e)
        {
            AllergyType alleryType = this.allergyTypeController.GetAllergyTypeByType(type);
            Allergy allergy = new Allergy();

            allergy.allergyType = alleryType;
            allergy.allergy_type_id = alleryType.Id;
            allergy.health_record_id = this.health_record_id;

            this.allergyController.AddAllergy(allergy);
            fill_data();
            refresh();
            ObservableCollection<AllergyType> allergyTypes = this.allergyTypeController.GetAllMissingAllergyTypesByUserId(user_id);
            ObservableCollection<String> types = new ObservableCollection<String>();

            foreach (AllergyType at in allergyTypes)
            {
                types.Add(at.Type);
            }

            this.selection.ItemsSource = types;
        }

        private void Izmeni_adresu(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = dataGridAllergies.SelectedCells[0];
            if (info != null)
            {
                if (info.Column.GetCellContent(info.Item) != null)
                {
                    var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
                    currentAllergyTypeId = int.Parse(content.ToString());

                    dataGridAllergies.UnselectAll();
                }
            }
        }

        private void selection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (selection.SelectedItem != null)
            {
                type = selection.SelectedItem.ToString();
            }

        }

        private void selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<AllergyType> allergyTypes = this.allergyTypeController.GetAllMissingAllergyTypesByUserId(user_id);
            ObservableCollection<String> types = new ObservableCollection<String>();

            foreach (AllergyType at in allergyTypes)
            {
                types.Add(at.Type);
            }

            this.selection.ItemsSource = types;
        }

        private void refresh()
        {
            ObservableCollection<AllergyType> allergyTypes = allergyTypeController.GetAllTypesByHealthRecordId(health_record_id);
            dataGridAllergies.ItemsSource = allergyTypes;

            allergyTypes = this.allergyTypeController.GetAllMissingAllergyTypesByUserId(user_id);
            ObservableCollection<String> types = new ObservableCollection<String>();

            foreach (AllergyType at in allergyTypes)
            {
                types.Add(at.Type);
            }

            this.selection.ItemsSource = types;
        }
    }
}
