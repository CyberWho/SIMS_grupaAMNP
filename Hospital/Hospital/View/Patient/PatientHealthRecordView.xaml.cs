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
    /// Interaction logic for PatientHealthRecordView.xaml
    /// </summary>
    public partial class PatientHealthRecordView : Window
    {
        private int userId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientHealthRecordViewModel patientHealthRecordViewModel;
        public PatientHealthRecordView(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            patientHealthRecordViewModel = new PatientHealthRecordViewModel(userId, tooltipChecked, this);
            this.DataContext = patientHealthRecordViewModel;
            ToolTipChecked(tooltipChecked);

        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientHealthRecordViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                patientHealthRecordViewModel.ToolTipChecked = false;
            }
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientHealthRecordViewModel.ToolTipChecked = true;
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientHealthRecordViewModel.ToolTipChecked = false;
        }
    }
}
