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
using Hospital.ViewModel.Doctor;

namespace Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorUIwindow.xaml
    /// </summary>
    public partial class DoctorUIwindow : Window
    {
        public DoctorUIwindow(int doctors_id)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Doctor.DoctorUIwindowViewModel(doctors_id, this);
            
        }

    }
}
