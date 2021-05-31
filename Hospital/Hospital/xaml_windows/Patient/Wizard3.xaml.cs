using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for Wizard3.xaml
    /// </summary>
    public partial class Wizard3 : Window
    {
        private int userId;
        private DoctorController doctorController = new DoctorController();
        private ObservableCollection<Model.Doctor> doctors = new ObservableCollection<Model.Doctor>();
        public Wizard3(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            cancel.IsEnabled = false;
            myDataGrid_Update();
        }
        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new Wizard2(userId);
            window.Show();
            this.Close();
        }
        private void myDataGrid_Update()
        {
            this.DataContext = this;
            doctors = doctorController.GetAllDoctors();
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = doctors;
        }
        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
