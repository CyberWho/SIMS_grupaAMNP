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
    /// Interaction logic for PatientUpdateAppointmentView.xaml
    /// </summary>
    public partial class PatientUpdateAppointmentView : Window
    {
        private int userId;
        private int appointmentId;
        public PatientUpdateAppointmentView(int userId,int appointmentId)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.PatientUpdateAppointmentViewModel(userId, appointmentId, this);
        }
    }
}
