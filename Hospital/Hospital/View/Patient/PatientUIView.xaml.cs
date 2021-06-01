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

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for PatientUIView.xaml
    /// </summary>
    public partial class PatientUIView : Window
    {
        private int userId;
        public PatientUIView(int userId)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.PatientUIViewModel(userId, this);
        }

    }
}
