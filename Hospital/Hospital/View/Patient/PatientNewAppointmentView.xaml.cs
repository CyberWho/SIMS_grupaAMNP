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
    /// Interaction logic for PatientNewAppointmentView.xaml
    /// </summary>
    public partial class PatientNewAppointmentView : Window
    {
        private int userId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientNewAppointmentViewModel patientNewAppointmentViewModel;
        public PatientNewAppointmentView(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            patientNewAppointmentViewModel = new PatientNewAppointmentViewModel(userId, tooltipChecked, this);
            this.DataContext = patientNewAppointmentViewModel;
            ToolTipChecked(tooltipChecked);
        }
        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientNewAppointmentViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                patientNewAppointmentViewModel.ToolTipChecked = false;
            }
        }
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientNewAppointmentViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientNewAppointmentViewModel.ToolTipChecked = false;
        }
    }
}
