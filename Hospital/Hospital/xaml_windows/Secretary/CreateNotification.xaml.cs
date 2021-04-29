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
    /// Interaction logic for CreateNotification.xaml
    /// </summary>
    public partial class CreateNotification : Window
    {
        private int id;
        public SystemNotification systemNotification;
        public SystemNotificationsController systemNotificationsController = new SystemNotificationsController();

       public CreateNotification(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Make_notification(object sender, RoutedEventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            if (start_date.Text.Equals(""))
            {
                startDate = DateTime.Now;
            }
            else
            {
                startDate = DateTime.Parse(start_date.Text);
            }

            if (end_date.Text.Equals(""))
            {
                endDate = startDate.AddDays(1);
            }
            else
            {
                endDate = DateTime.Parse(end_date.Text);
            }

            //MessageBox.Show(startDate.ToString());
            //MessageBox.Show(endDate.ToString());

            String notificationTitle = not_title.Text;
            String notificationDescription = not_desc.Text;

            // 0 here means that the id will be assigned in the repository layer as i shouldn't know the last available id in the db
            // the last parameter in the constructor tells the repository that the notification is system wide, and that all the users should see it
            // this also means that only SystemNotifications with this field, when set to true, will be shown in the notice board
            systemNotification =
                new SystemNotification(0, startDate, endDate, notificationTitle, notificationDescription, true);

            this.systemNotificationsController.AddSystemNotification(systemNotification);
        }
    }
}
