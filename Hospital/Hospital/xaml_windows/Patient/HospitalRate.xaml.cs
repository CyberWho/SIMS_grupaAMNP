﻿using System;
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
        PatientController patientController = new PatientController();
        public HospitalRate(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            Review review = new Review();
            review.Rate = int.Parse(rate_txt.Text);
            review.Description = description_txt.Text;
            review.patient = patientController.GetPatientByUserId(userId);
            Hospital.Model.Doctor doctor = new Model.Doctor();
            review.doctor = doctor;
            review.doctor.Id = 0;
            new ReviewController().AddReview(review);
            MessageBox.Show("Hvala Vam sto ste popunili anketu o bolnici!");
            
            this.Close();
        }
    }
}
