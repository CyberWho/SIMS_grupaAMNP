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
    /// Interaction logic for DoctorsView.xaml
    /// </summary>
    public partial class DoctorsView : Window
    {
        private int userId;
        private bool tooltipChecked;
        private ViewModel.Patient.DoctorsViewModel doctorsViewModel;
        public DoctorsView(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            doctorsViewModel = new DoctorsViewModel(userId, tooltipChecked, this);
            this.DataContext = doctorsViewModel;
            ToolTipChecked(tooltipChecked);
        }

        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
                doctorsViewModel.ToolTipChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
                doctorsViewModel.ToolTipChecked = false;
            }
        }
        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            doctorsViewModel.ToolTipChecked = true;
        }
        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            doctorsViewModel.ToolTipChecked = false;
        }

    }
}
