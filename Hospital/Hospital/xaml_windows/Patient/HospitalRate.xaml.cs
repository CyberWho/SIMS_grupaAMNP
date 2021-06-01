using System.Drawing;
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
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public HospitalRate(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private bool DataValidation()
        {
            if (!ValidateRate()) return false;

            if (!ValidateDescription()) return false;

            return true;
        }

        private void ClearTextBlocks()
        {
            Block1.Text = "";
            Block.Text = "";
        }

        private bool ValidateDescription()
        {
            if (description_txt.Text == "")
            {
                //MessageBox.Show("Obavezno je da unesete opis ocene!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
                Block1.Text = "Obavezno je da unesete opis ocene!";
                return false;
            }

            return true;
        }

        private bool ValidateRate()
        {
            if (rate_txt.Text == null)
            {
                //MessageBox.Show("Obaveno je da unesete ocenu!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
                Block.Text = "Obavezno je da unesete ocenu!";
                return false;
            }

            return true;
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBlocks();
            if(DataValidation() == false) return;
            
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new Model.Doctor();
            doctor.Id = 0;
            Review review = new Review(int.Parse(rate_txt.Text), description_txt.Text, patient, doctor);
            new ReviewController().AddReview(review);
            MessageBox.Show("Hvala Vam sto ste popunili anketu o bolnici!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Information);
            
           
            this.Close();
        }

        private void HospitalRate_OnLoaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
    }
}
