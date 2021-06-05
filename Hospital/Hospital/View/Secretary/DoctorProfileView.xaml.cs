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
using Hospital.ViewModel.Secretary;
using Hospital.xaml_windows.Secretary;

namespace Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for DoctorProfile.xaml
    /// </summary>
    public partial class DoctorProfileView : Window
    {
        public DoctorProfileView(Model.Doctor doctor)
        {
            InitializeComponent();
            this.DataContext = new DoctorProfileViewModel(this, doctor);
        }
    }
}