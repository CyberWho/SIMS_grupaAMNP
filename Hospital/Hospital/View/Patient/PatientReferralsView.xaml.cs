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
    /// Interaction logic for PatientReferralsView.xaml
    /// </summary>
    public partial class PatientReferralsView : Window
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientReferralsViewModel patientReferralsViewModel;
        public PatientReferralsView(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            patientReferralsViewModel = new PatientReferralsViewModel(userId, healthRecordId, tooltipChecked, this);
            this.DataContext = patientReferralsViewModel;
            ToolTipChecked(tooltipChecked);

        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientReferralsViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                patientReferralsViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientReferralsViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientReferralsViewModel.ToolTipChecked = false;
        }
    }
}
