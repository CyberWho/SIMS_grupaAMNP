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
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for UpdateNotification.xaml
    /// </summary>
    public partial class UpdateNotification : Window
    {
        private int current_notification_id;
        private SystemNotification systemNotification;
        private SystemNotificationsController systemNotificationsController = new SystemNotificationsController();

        public UpdateNotification(int id)
        {
            InitializeComponent();
            current_notification_id = id;
            systemNotification = this.systemNotificationsController.GetSystemNotificationById(id);
            not_title.Text = systemNotification.Name;
            not_desc.Text = systemNotification.Description;
            start_date.Text = systemNotification.creationDateTime.ToString();
            end_date.Text = systemNotification.expirationDateTime.ToString();
        }

        private void Update_Notification(object sender, RoutedEventArgs e)
        {
            systemNotification.Name = not_title.Text;
            systemNotification.Description = not_desc.Text;
            systemNotification.creationDateTime = DateTime.Parse(start_date.Text);
            systemNotification.expirationDateTime = DateTime.Parse(end_date.Text);

            this.systemNotificationsController.UpdateSystemNotification(systemNotification);
            this.Close();
        }
    }
}
