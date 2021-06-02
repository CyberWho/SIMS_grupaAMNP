using Hospital.xaml_windows.Patient;
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

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for PatientUIView.xaml
    /// </summary>
    public partial class PatientUIView : Window
    {
        private int userId;
        private bool tooltipChecked;
        public PatientUIView(int userId,bool tooltipCheked = true)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.PatientUIViewModel(userId,tooltipCheked, this);
            ToolTipChecked(tooltipCheked);
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
