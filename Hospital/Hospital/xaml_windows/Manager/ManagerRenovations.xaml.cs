using System.Windows;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRenovations.xaml
    /// </summary>
    public partial class ManagerRenovations : Window
    {
        ObservableCollection<Model.Renovation> Renovations = new ObservableCollection<Model.Renovation>();
        public ManagerRenovations()
        {
            InitializeComponent();
        }

        private void myDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
