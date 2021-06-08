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
using static Globals;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        Controller.DoctorController doctorController = new Controller.DoctorController();
        ObservableCollection<Model.Doctor> Doctors;
        public Report()
        {
            InitializeComponent();
            Doctors = doctorController.GetAllDoctors();
            date_pckrStart.Text = DateTime.Now.ToString();
            date_pckrEnd.Text = DateTime.Now.ToString();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new View.Manager.ManagerUIView();
            newWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Doctors;
        }

        private void ShowReportBtn_Click(object sender, RoutedEventArgs e)
        {
            if(myDataGrid.SelectedItem == null)
            {
                ShowErrorBox("Morate izabrati doktora.");
                return;
            }
            DateTime StartDate = DateTime.Parse(date_pckrStart.Text);
            DateTime EndDate = DateTime.Parse(date_pckrEnd.Text); 
            if (DateTime.Compare(EndDate, StartDate) <= 0)
            {
                ShowErrorBox("Krajnje vreme mora biti posle početnog.");
                return;
            }
            Window newWindow = new ReportShow((Model.Doctor)(myDataGrid.SelectedItem), StartDate, EndDate);
            newWindow.Show();
            this.Close();
        }
    }
}
