using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class HospitalRateViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public MyICommand RateHospital { get; set; }
        private string _descriptionError;
        public string DescriptionError
        {
            get { return _descriptionError; }
            set
            {
                SetProperty(ref _descriptionError, value);
            }
        }
        private string _rateError;


        public string RateError
        {
            get { return _rateError; }
            set
            {
                SetProperty(ref _rateError, value);
            }
        }

        public string Rate { get; set; }
        public string Description { get; set; }
        public HospitalRateViewModel()
        {

        }

        public HospitalRateViewModel(int userId,Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            RateHospital = new MyICommand(OnRate);
        }

        private void OnRate()
        {
            ClearTextBlocks();
            if (DataValidation() == false) return;

            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new Model.Doctor();
            doctor.Id = 0;
            Review review = new Review(int.Parse(Rate), Description, patient, doctor);
            new ReviewController().AddReview(review);
            MessageBox.Show("Hvala Vam sto ste popunili anketu o bolnici!", "Zdravo korporacija", MessageBoxButton.OK, MessageBoxImage.Information);


            thisWindow.Close();
        }
        private bool DataValidation()
        {
            if (!ValidateRate()) return false;

            if (!ValidateDescription()) return false;

            return true;
        }
        private bool ValidateDescription()
        {
            if (Description == null)
            {
                //MessageBox.Show("Obavezno je da unesete opis ocene!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
                this.DescriptionError = "Obavezno je da unesete opis ocene!";
                return false;
            }

            return true;
        }

        private bool ValidateRate()
        {
            if (Rate == null)
            {
                //MessageBox.Show("Obaveno je da unesete ocenu!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
                this.RateError = "Obavezno je da unesete ocenu!";
                return false;
            }

            return true;
        }

        private void ClearTextBlocks()
        {
            this.DescriptionError = "";
            this.RateError = "";
        }
    }
}
