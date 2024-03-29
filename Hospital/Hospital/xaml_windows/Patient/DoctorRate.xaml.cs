﻿using System;
using System.Windows;
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for DoctorRate.xaml
    /// </summary>
    public partial class DoctorRate : Window, INotifyPropertyChanged
    {
        #region NotifyProperties
        private int _doctorId;
        private string _name;
        private string _surname;
        private string _specialization;
        public int Id
        {
            get
            {
                return _doctorId;
            }
            set
            {
                if (value != _doctorId)
                {
                    _doctorId= value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string NName
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("NName");
                }
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        public string Specialization
        {
            get
            {
                return _specialization;
            }
            set
            {
                if (value != _specialization)
                {
                    _specialization = value;
                    OnPropertyChanged("Specialization");
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
        private int userId;
        private int doctorId;
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        
        public DoctorRate(int userId,int doctorId)
        {
            InitializeComponent();
            this.userId = userId;
            this.doctorId = doctorId;
            this.DataContext = this;
            ShowDoctorInformations(doctorId);
        }

        private void ShowDoctorInformations(int doctorId)
        {
            Model.Doctor doctor = new Model.Doctor();
            doctor = new DoctorController().GetDoctorById(doctorId);
            Id = doctor.Id;
            NName = doctor.User.Name;
            Surname = doctor.User.Surname;
            Specialization = doctor.specialization.Type;
        }


        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }

        private Boolean DataValidation()
        {
            if (!RateValidation()) return false;

            if (!DescriptionValidation()) return false;

            return true;
        }

        private void ClearTextBlocks()
        {
            DescriptionBox.Text = "";
            RateBox.Text = "";
        }

        private bool DescriptionValidation()
        {
            if (description_txt.Text == "")
            {
               // MessageBox.Show("Obavezno je da date komentar ocene!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
               DescriptionBox.Text = "Obavezno je da date komentar ocene!";
               return false;
            }

            return true;
        }

        private bool RateValidation()
        {
            if (rate_txt.Text == null)
            {
               // MessageBox.Show("Obavezno je dodeliti ocenu doktoru!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Warning);
               RateBox.Text = "Obavezno je dodeliti ocenu doktoru!";
               return false;
            }

            return true;
        }

        private void OceniDoktora_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBlocks();
            if (DataValidation() == false) return;
           
            
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Model.Doctor doctor = new DoctorController().GetDoctorById(doctorId);
            Review review = new Review(int.Parse(rate_txt.Text), description_txt.Text, patient, doctor);
            new ReviewController().AddReview(review); 
            MessageBox.Show("Uspesno ste ocenili doktora " + doctor.User.Name + " " + doctor.User.Surname,"Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Information);

            this.Close();
            
            
        }
        

    }
}
