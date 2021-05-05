using System.Windows;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerUI.xaml
    /// </summary>
    public partial class ManagerUI : Window
    {
        int id;
        public ManagerUI(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        private void roomBtnClick(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRoomsCRUD(id);
            newWindow.Show();
            this.Close();
        }
    }
}
