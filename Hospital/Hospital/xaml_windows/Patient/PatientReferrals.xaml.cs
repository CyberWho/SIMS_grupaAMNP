using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Controller;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientReferrals.xaml
    /// </summary>
    public partial class PatientReferrals : Window
    {
        private int userId;
        private int healthRecordId;
        ObservableCollection<ReferralForSpecialist> ReferralForSpecialists = new ObservableCollection<ReferralForSpecialist>();
        ReminderController reminderController = new ReminderController();
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        PatientController patientController = new PatientController();

        public PatientReferrals(int userId,int healthRecordId)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            updateDataGrid();
        }
        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Hospital.Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            reminders = reminderController.GetAllFutureRemindersByPatientId(patient.Id);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (Reminder reminder in reminders)
            {
                if ((reminder.AlarmTime - now).Minutes == 0)
                {
                    MessageBox.Show(reminder.Description);
                }
            }
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
            window.Show();
            this.Close();
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientReminders(userId);
            window.Show();
            this.Close();
        }
        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            int doctorId = int.Parse(doc_id_txt.Text);
            DateTime startDate = DateTime.Parse(date_txt.Text);
            DateTime endDate = DateTime.Parse(date_end_txt.Text);
            if (endDate <= startDate)
            {
                MessageBox.Show("Nije moguce da oznacite vremenski interval gde je krajnji datum manji od pocetnog!");
            }
            else
            {
                var dayDifference = (endDate - startDate).TotalDays;
                if (dayDifference > 5)
                {
                    MessageBox.Show("Interval ne sme biti duzi od 5 dana!");
                }
                else
                {
                    var window = new PatientNewAppointmentRecommendations(userId, startDate, endDate, doctorId, 0, int.Parse(ref_id_txt.Text));
                    window.Show();
                    this.Close();
                }
            }
        }
        private void updateDataGrid()
        {

            this.DataContext = this;
            ReferralForSpecialists = new RefferalForSpecialistController().GetReferralForSpecialistsByHealthRecordId(healthRecordId);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = ReferralForSpecialists;



        }
        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {



        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
