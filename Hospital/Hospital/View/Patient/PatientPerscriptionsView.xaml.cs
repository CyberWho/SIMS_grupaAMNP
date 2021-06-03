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
    /// Interaction logic for PatientPerscriptionsView.xaml
    /// </summary>
    public partial class PatientPerscriptionsView : Window
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientPerscriptionsViewModel patientPerscriptionsViewModel;
        public PatientPerscriptionsView(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            patientPerscriptionsViewModel =
                new PatientPerscriptionsViewModel(userId, healthRecordId, tooltipChecked, this);
            this.DataContext = patientPerscriptionsViewModel;
                ToolTipChecked(tooltipChecked);

        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientPerscriptionsViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                patientPerscriptionsViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientPerscriptionsViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientPerscriptionsViewModel.ToolTipChecked = false;
        }
    }
}
