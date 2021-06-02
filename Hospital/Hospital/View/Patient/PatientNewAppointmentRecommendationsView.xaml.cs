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
    /// Interaction logic for PatientNewAppointmentRecommendationsView.xaml
    /// </summary>
    public partial class PatientNewAppointmentRecommendationsView : Window
    {
        private int userId;
        private DateTime startTime;
        private DateTime endTime;
        private int doctorId;
        private int priority = 0;
        private int referralForSpecialistId;
        private bool tooltipChecked;
        public PatientNewAppointmentRecommendationsView(int userId,DateTime startTime,DateTime endTime,int doctorId,int priority,int referralForSpecialist,bool tooltipChecked)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.PatientNewAppointmentRecommendationsViewModel(userId, startTime,
                endTime, doctorId, priority, referralForSpecialist, tooltipChecked, this);
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
