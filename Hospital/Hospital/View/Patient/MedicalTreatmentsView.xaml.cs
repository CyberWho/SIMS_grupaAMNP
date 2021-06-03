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
    /// Interaction logic for MedicalTreatmentsView.xaml
    /// </summary>
    public partial class MedicalTreatmentsView : Window
    {
        private int userId;
        private int healthRecordId;
        private bool tooltipChecked;
        private ViewModel.Patient.MedicalTreatmenstViewModel medicalTreatmenstViewModel;
        public MedicalTreatmentsView(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            medicalTreatmenstViewModel = new MedicalTreatmenstViewModel(userId, healthRecordId, tooltipChecked, this);
            this.DataContext = medicalTreatmenstViewModel;
            ToolTipChecked(tooltipChecked);
        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                medicalTreatmenstViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                medicalTreatmenstViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            medicalTreatmenstViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            medicalTreatmenstViewModel.ToolTipChecked = false;
        }
    }
}
