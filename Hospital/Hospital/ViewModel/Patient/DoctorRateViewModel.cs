using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using Hospital.xaml_windows.Patient;

namespace Hospital.ViewModel.Patient
{
    class DoctorRateViewModel : BindableBase
    {
        private int userId;
        private int doctorId;
        private Window thisWindow;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string Specialization { get; set; }
        public string Rate { get; set; }
        public MyICommand RateDoctor { get; set; }
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

        public DoctorRateViewModel()
        {

        }

        public DoctorRateViewModel(int userId, int doctorId,Window thisWindow)
        {
            this.userId = userId;
            this.doctorId = doctorId;
            this.thisWindow = thisWindow;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            RateDoctor = new MyICommand(OnRateDoctor);
            ShowDoctorInformations(doctorId);
        }

        private void OnRateDoctor()
        {
            ClearTextBlocks();
            if (DataValidation() == false) return;
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new DoctorController().GetDoctorById(doctorId);
            Review review = new Review(int.Parse(Rate), Description, patient, doctor);
            new ReviewController().AddReview(review);
            MessageBox.Show("Uspesno ste ocenili doktora " + doctor.User.Name + " " + doctor.User.Surname, "Zdravo korporacija", MessageBoxButton.OK, MessageBoxImage.Information);

            thisWindow.Close();

        }
        private Boolean DataValidation()
        {
            if (!RateValidation()) return false;

            if (!DescriptionValidation()) return false;

            return true;
        }
        private bool DescriptionValidation()
        {
            if (Description == null)
            {
                this.DescriptionError = "Obavezno je da date komentar ocene!";
                return false;
            }

            return true;
        }

        private bool RateValidation()
        {
            if (Rate == null)
            {
                this.RateError= "Obavezno je dodeliti ocenu doktoru!";
                return false;
            }

            return true;
        }

        private void ClearTextBlocks()
        {
            DescriptionError = "";
            
            RateError = "";
        }

        private void ShowDoctorInformations(int doctorId)
        {
            Model.Doctor doctor = new Model.Doctor();
            doctor = new DoctorController().GetDoctorById(doctorId);
            Name = doctor.User.Name;
            Surname = doctor.User.Surname;
            Specialization = doctor.specialization.Type;
            ClearTextBlocks();
        }

    }
}
