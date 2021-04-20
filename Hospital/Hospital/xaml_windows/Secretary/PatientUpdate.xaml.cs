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
using Hospital.Repository;

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
        UserController userController = new UserController();
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
                /////////////////////////////////////// ovde

                User user = this.userController.GetUserById(this.user_id);
                if (!user.Username.Contains("guestUser"))
                {
                    this.address_id = this.addressController.GetAddressByPatientId(patient_id).Id;
                }
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
        private void Obrisi_alergen(object sender, RoutedEventArgs e)
        {
            _ = this.allergyController.DeleteAllergyByUserIdAndAllergyTypeId(user_id, currentAllergyTypeId);
            fill_data();
            refresh();
        }
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
