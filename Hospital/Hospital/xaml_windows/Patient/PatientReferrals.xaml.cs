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

        public PatientReferrals(int userId,int healthRecordId)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
            updateDataGrid();
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(userId);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(userId);
            s.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(userId);
            s.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientHealthRecord(userId);
            s.Show();
            this.Close();
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(userId);
            s.Show();
            this.Close();
        }
        private void Predlozi_Click(object sender, RoutedEventArgs e)
        {
            /*int doctorId = int.Parse(doc_id_txt.Text);
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
                    //var s = new PatientNewAppointmentRecommendations(userId, startDate, endDate, doctorId);
                   // s.Show();
                  //  this.Close();
                }
            }*/
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
    }
}
