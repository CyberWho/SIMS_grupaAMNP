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

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for DoctorToManager.xaml
    /// </summary>
    public partial class DoctorToManager : Window
    {
        private UserController userController = new UserController();
        //private User user;
        private IRoleDescriptior user;
        private int id;
        public DoctorToManager(int id)
        {
            InitializeComponent();
            this.id = id;
            user = userController.GetUserById(id);
            user = new Model.Doctor(11, user);
        }

        private void BecomeSecretary(object sender, RoutedEventArgs e)
        {
            user = new Model.Secretary(8, user);
            btn_s.IsEnabled = false;
        }

        private void BecomeManager(object sender, RoutedEventArgs e)
        {
            user = new Model.Manager(7, user);
            btn_u.IsEnabled = false;

        }

        private void UpdateState(object sender, RoutedEventArgs e)
        {
            tb_state.Text = user.describeMyRole() + "\n" + user.howMuchAmIPaid();
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            Window s = new DoctorToManager(this.id);
            s.Show();
            this.Close();
        }
    }
}
