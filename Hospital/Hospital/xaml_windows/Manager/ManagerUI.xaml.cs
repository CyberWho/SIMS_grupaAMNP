using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        private void drugsBtnClick(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerDrugs();
            newWindow.Show();
            this.Close();
        }

        private void inventorySearchBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerInventorySearch();
            newWindow.Show();
            this.Close();
        }

        private void renovationsBtn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRenovations();
            newWindow.Show();
            this.Close();
        }

        private void btn_GotFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Color.FromArgb(255, (byte)16, (byte)93, (byte)151));
        }

        private void btn_LostFocus(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Background = new SolidColorBrush(Color.FromArgb(255, (byte)52, (byte)153, (byte)235));
        }

        private void logout_btn_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
