using System.Windows;
using System.Collections.ObjectModel;
using System.Data;
using Hospital.Model;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRenovations.xaml
    /// </summary>
    public partial class ManagerRenovations : Window
    {
        ObservableCollection<Renovation> Renovations = new ObservableCollection<Renovation>();
        Controller.RenovationController renovationController = new Controller.RenovationController();
        public ManagerRenovations()
        {
            InitializeComponent();
        }

        private void myDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
