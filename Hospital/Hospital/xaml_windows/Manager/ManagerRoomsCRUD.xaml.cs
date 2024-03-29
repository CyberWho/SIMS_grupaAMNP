﻿using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Hospital.xaml_windows.Manager
{
    /// <summary>
    /// Interaction logic for ManagerRoomsCRUD.xaml
    /// </summary>
    public partial class ManagerRoomsCRUD : Window
    {
        int id;
        ObservableCollection<Room> Rooms;

        Controller.RoomController roomController = new Controller.RoomController();
        public ManagerRoomsCRUD(int id)
        {

            InitializeComponent();
            this.id = id;
        }

        public void updateDataGrid()
        {
            fillComboBox();
            this.DataContext = this;
            Rooms = roomController.GetAllRooms();
            fillTable();
            add_btn.IsEnabled = true;
            update_btn.IsEnabled = false;
            delete_btn.IsEnabled = false;
        }
        private void ShowInventory_Click(object sender, RoutedEventArgs e)
        {
            Window newWindow = new ManagerRoomInventory(id, (Room)myDataGrid.SelectedItem);
            newWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnablePrimaryButtons();
            this.updateDataGrid();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(0);
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(1);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            this.CUD(2);
        }
        private void CUD(int state)
        {
            switch (state)
            {
                case 0:
                    if(roomController.AddRoom(GetRoomFromForm()) != null){
                        MessageBox.Show("Uspešan nov unos.");
                    }
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom novog unosa.");
                    }
                    break;
                case 1:
                    if(roomController.UpdateRoom(GetRoomFromForm()) != null)
                    {
                        MessageBox.Show("Red uspešno ažuriran.");
                    } 
                    else
                    {
                        MessageBox.Show("Došlo je do greške prilikom ažuriranja prostorije.");
                    }

                    break;
                case 2:
                    if(roomController.DeleteRoomById(GetIdFromForm()))
                    MessageBox.Show("Uspešno brisanje.");
                    break;
            }
            this.updateDataGrid();
        }

        private int GetIdFromForm()
        {
            return int.Parse(id_txtbx.Text);
        }
        private Room GetRoomFromForm()
        {
            Room room = new Room();

            room.Id = GetIdFromForm();

            if (!floor_txtbx.Text.Equals(""))
            {
                room.Floor = int.Parse(floor_txtbx.Text);
            }
            if (!area_txtbx.Text.Equals(""))
            {
                room.Area = double.Parse(area_txtbx.Text);
            }
            if (!desc_txtbx.Text.Equals(""))
            {
                room.Description = desc_txtbx.Text;
            }

            room.roomType = roomController.GetRoomTypeByType(rtype_cmbbx.Text);
            
            return room;
        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableSecondaryButtons();
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            /*floor_txtbx.Text = "";
            area_txtbx.Text = "";
            desc_txtbx.Text = "";
            id_txtbx.Text = "";
            rtype_cmbbx.SelectedItem = null;*/
            myDataGrid.SelectedItem = null;
            EnablePrimaryButtons();
        }
        private void fillComboBox()
        {
            foreach (RoomType roomType in roomController.GetAllRoomTypes())
            {
                rtype_cmbbx.Items.Add(new
                {
                    Value = roomType.Id,
                    Display = roomType.Type
                });
            }
        }
        
        private void fillTable()
        {
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Rooms;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Window w = new ManagerUI(2);
            w.Show();
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
    }
}
