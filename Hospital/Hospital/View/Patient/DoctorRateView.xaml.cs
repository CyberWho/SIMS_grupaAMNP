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

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for DoctorRateView.xaml
    /// </summary>
    public partial class DoctorRateView : Window
    {
        private int userId;
        private int doctorId;
        public DoctorRateView(int userId,int doctorId)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.DoctorRateViewModel(userId, doctorId, this);

        }
    }
}
