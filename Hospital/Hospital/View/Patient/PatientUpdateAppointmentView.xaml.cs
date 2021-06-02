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
using Hospital.ViewModel.Patient;
using Hospital.xaml_windows.Patient;

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for PatientUpdateAppointmentView.xaml
    /// </summary>
    public partial class PatientUpdateAppointmentView : Window
    {
        private int userId;
        private int appointmentId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientUpdateAppointmentViewModel patientUpdateAppointmentViewModel;
        public PatientUpdateAppointmentView(int userId,int appointmentId,bool tooltipChecked)
        {
            InitializeComponent();
            patientUpdateAppointmentViewModel =
                new PatientUpdateAppointmentViewModel(userId, appointmentId, tooltipChecked, this);
            this.DataContext = patientUpdateAppointmentViewModel;
            ToolTipChecked(tooltipChecked);
        }
        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientUpdateAppointmentViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                patientUpdateAppointmentViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientUpdateAppointmentViewModel.ToolTipChecked = true;
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientUpdateAppointmentViewModel.ToolTipChecked = false;
        }
    }
}
