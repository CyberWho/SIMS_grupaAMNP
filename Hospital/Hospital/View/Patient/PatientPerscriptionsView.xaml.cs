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
        public PatientPerscriptionsView(int userId,int healthRecordId,bool tooltipChecked)
        {
            InitializeComponent();
            this.DataContext =
                new ViewModel.Patient.PatientPerscriptionsViewModel(userId, healthRecordId, tooltipChecked, this);
            ToolTipChecked(tooltipChecked);

        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            tooltipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            tooltipChecked = false;
        }
    }
}
