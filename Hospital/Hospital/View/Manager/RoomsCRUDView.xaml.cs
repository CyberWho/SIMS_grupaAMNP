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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Globals;

namespace Hospital.View.Manager
{
    /// <summary>
    /// Interaction logic for RoomsCRUD.xaml
    /// </summary>
    public partial class RoomsCRUDView : Window
    {
        private ViewModel.Manager.RoomsCRUDViewModel roomsCRUDViewModel;
        public RoomsCRUDView()
        {
            InitializeComponent();
            roomsCRUDViewModel = new ViewModel.Manager.RoomsCRUDViewModel(this);
            this.DataContext = roomsCRUDViewModel;
            EnablePrimaryButtons();
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableSecondaryButtons();
            if (myDataGrid.SelectedItem == null)
                EnablePrimaryButtons();
        }
        public void EnablePrimaryButtons()
        {
            add_btn.IsEnabled = true;
            add_txtblk.Effect = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = 330,
                ShadowDepth = 3,
                BlurRadius = 4
            };
            update_btn.IsEnabled = false;
            update_txtblk.Effect = null;
            delete_btn.IsEnabled = false;
            delete_txtblk.Effect = null;
        }
        public void EnableSecondaryButtons()
        {
            add_btn.IsEnabled = false;
            add_txtblk.Effect = null;
            DropShadowEffect shadow = new DropShadowEffect
            {
                Color = Colors.Black,
                Direction = 330,
                ShadowDepth = 3,
                BlurRadius = 4
            };
            update_btn.IsEnabled = true;
            update_txtblk.Effect = shadow;
            delete_btn.IsEnabled = true;
            delete_txtblk.Effect = shadow;
        }
        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            EnablePrimaryButtons();
        }
    }
}
