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
    /// Interaction logic for PatientRemindersView.xaml
    /// </summary>
    public partial class PatientRemindersView : Window
    {
        private int userId;
        private bool tooltipChecked;
        private ViewModel.Patient.PatientRemindersViewModel patientRemindersViewModel;
        public PatientRemindersView(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            patientRemindersViewModel = new PatientRemindersViewModel(userId, tooltipChecked, this);
            this.DataContext = patientRemindersViewModel;
            ToolTipChecked(tooltipChecked);
        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                patientRemindersViewModel.ToolTipChecked = true;

            }
            else
            {
                CheckBox.IsChecked = false;
                patientRemindersViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            patientRemindersViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            patientRemindersViewModel.ToolTipChecked = false;
        }
    }
}
