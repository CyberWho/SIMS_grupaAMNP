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
    /// Interaction logic for ClinicalTreatmentReferralsView.xaml
    /// </summary>
    public partial class ClinicalTreatmentReferralsView : Window
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private ClinicalTreatmentReferralsViewModel clinicalTreatmentReferralsViewModel;
        public ClinicalTreatmentReferralsView(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            clinicalTreatmentReferralsViewModel =
                new ClinicalTreatmentReferralsViewModel(userId, healthRecordId, tooltipChecked, this);
            this.DataContext = clinicalTreatmentReferralsViewModel;
            ToolTipChecked(tooltipChecked);
        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                clinicalTreatmentReferralsViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                clinicalTreatmentReferralsViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            clinicalTreatmentReferralsViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            clinicalTreatmentReferralsViewModel.ToolTipChecked = false;
        }
    }
}
