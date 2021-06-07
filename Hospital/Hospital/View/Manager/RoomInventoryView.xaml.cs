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

namespace Hospital.View.Manager
{
    /// <summary>
    /// Interaction logic for RoomInventoryView.xaml
    /// </summary>
    public partial class RoomInventoryView : Window
    {
        private ViewModel.Manager.RoomsInventoryViewModel roomsInventoryViewModel;
        public RoomInventoryView(Model.Room _selectedRoom)
        {
            InitializeComponent();
            roomsInventoryViewModel = new ViewModel.Manager.RoomsInventoryViewModel(this, _selectedRoom);
            this.DataContext = roomsInventoryViewModel;
        }
        private void roomID_txtbx_GotFocus(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
        }

        private void roomID_txtbx_LostFocus(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
