using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        private int id;
        private int current_notifcation_id;

        private ObservableCollection<SystemNotification> systemNotifications =
            new ObservableCollection<SystemNotification>();

        private SystemNotificationsController systemNotificationsController = new SystemNotificationsController();
        
        public Notifications(int id)
        {
            InitializeComponent();
            this.DataContext = this;
            Update();
        }

        private void Add_Notification(object sender, RoutedEventArgs e)
        {
            Window s = new CreateNotification(this.id);
            s.Show();

        }

        private void Update()
        {
            this.DataContext = this;
            systemNotifications = this.systemNotificationsController.GetAllSystemWideSystemNotifications();
            DataTable dt = new DataTable();
            notifications.DataContext = dt;
            notifications.ItemsSource = systemNotifications;
        }

        private void dataGridnotifications(object sender, SelectionChangedEventArgs e)
        {
            if (notifications.SelectedCells[0] != null)
            {
                var info = notifications.SelectedCells[0];
                if (info.Column.GetCellContent(info.Item) != null)
                {
                    var content = (info.Column.GetCellContent(info.Item) as TextBlock).Text;
                    current_notifcation_id = int.Parse(content);
                }
            }

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Delete_Notification(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li zaista zelite da obrisete obavestenje?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                MessageBox.Show("Niste obrisali obavestenje!");
            }
            else
            {
                this.systemNotificationsController.DeleteSystemNotificationById(current_notifcation_id);
                MessageBox.Show("Uspesno ste obrisali obavestenje!");
                Update();
            }

        }

        private void Update_Notification(object sender, RoutedEventArgs e)
        {
            Window s = new UpdateNotification(current_notifcation_id);
            s.Show();
        }
    }
}
