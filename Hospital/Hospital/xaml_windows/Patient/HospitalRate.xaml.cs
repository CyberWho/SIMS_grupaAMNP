using System.Windows;
using Hospital.Model;
using Hospital.Controller;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for HospitalRate.xaml
    /// </summary>
    public partial class HospitalRate : Window
    {
        private int userId;
        private PatientController patientController = new PatientController();
        public HospitalRate(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new Model.Doctor();
            doctor.Id = 0;
            Review review = new Review(int.Parse(rate_txt.Text), description_txt.Text, patient, doctor);
            new ReviewController().AddReview(review);
            MessageBox.Show("Hvala Vam sto ste popunili anketu o bolnici!");
            
            this.Close();
        }
    }
}
