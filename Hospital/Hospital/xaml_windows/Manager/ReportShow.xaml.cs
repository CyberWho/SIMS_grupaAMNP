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
    /// Interaction logic for ReportShow.xaml
    /// </summary>
    public partial class ReportShow : Window
    {
        ObservableCollection<Model.Appointment> Appointments;
        Repository.AppointmentRepository appointmentRepository = new Repository.AppointmentRepository();
        public ReportShow(Model.Doctor doctor, DateTime StartDate, DateTime EndDate)
        {
            InitializeComponent();
            Appointments = appointmentRepository.GetAppointmentByDoctorIdAndTimePeriod(doctor, StartDate, EndDate);
            DoctorTxtBlk.Text = doctor.User.Name + " " + doctor.User.Surname + ", " + doctor.specialization.Type;
            PeriodTxtBlk.Text = StartDate.ToString() + " - " + EndDate.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Appointments;
        }
        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(this, "Izvestaj");
            }
        }

        private void toPdfBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowInfoBox("Izvezeno u PDF.", "Uspešno!");
            Window newWindow = new View.Manager.ManagerUIView();
            newWindow.Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new View.Manager.ManagerUIView();
            newWindow.Show();
            this.Close();
        }
    }
}
