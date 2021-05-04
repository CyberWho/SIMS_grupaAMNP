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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Hospital.xaml_windows.Doctor;
using Hospital.xaml_windows.Manager;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;
using Hospital.Controller;

using System.Collections.ObjectModel;
using Hospital.Model;
using Hospital.Service;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (OracleConfiguration.TnsAdmin == null)
                OracleConfiguration.TnsAdmin = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Oracle\network\admin\DBTIM1";
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {

            string user = Username.Text;
            string pass = Password.Password;

            if(new UserController().LoginUser(user, pass))
                this.Close();
            //MessageBox.Show(new Hospital.Repository.InventoryItemRepository().GetInventoryItemById(21).Name);


            /*DateTime dt = DateTime.MinValue;
            ObservableCollection<Room> rooms = new Hospital.Service.RoomService().GetAllRoomInFutureState(dt);

            string test = "";

            foreach (Room room in rooms)
            {
                test += "Soba " + room.Id + "\n";
                foreach (ItemInRoom itemInRoom in room.itemInRoom)
                {
                    test += "\t" + itemInRoom.inventoryItem.Name + "*" + itemInRoom.Quantity + " " + itemInRoom.Id + "\n";
                }
            }

            MessageBox.Show(test);

            dt = DateTime.Now;
            rooms = new Hospital.Service.RoomService().GetAllRoomInFutureState(dt);

            test = "";

            foreach (Room room in rooms)
            {
                test += "Soba " + room.Id + "\n";
                foreach (ItemInRoom itemInRoom in room.itemInRoom)
                {
                    test += "\t" + itemInRoom.inventoryItem.Name + "*" + itemInRoom.Quantity + " " + itemInRoom.Id + "\n";
                }
            }

            MessageBox.Show(test);*/

            /*ObservableCollection<InventoryItem> itemsNeeded = new ObservableCollection<InventoryItem>();
            InventoryItem krevet = new InventoryItem(21, "Krevet", 20000, "komad", ItemType.PERSISTENT);
            InventoryItem stolica = new InventoryItem(43, "Kafetin", 60000, "komad", ItemType.PERSISTENT);
            itemsNeeded.Add(krevet);
            itemsNeeded.Add(stolica);

            ObservableCollection<Room> goodRooms =
                new Hospital.Service.RoomService().findSuitableRoomsForOperation(
                    DateTime.Now, DateTime.MaxValue,itemsNeeded);

           string test = "Gas:\n";

            foreach (Room room in goodRooms)
            {
                test += "Soba " + room.Id + "\n";
                foreach (ItemInRoom itemInRoom in room.itemInRoom)
                {
                    test += "\t" + itemInRoom.inventoryItem.Name + "*" + itemInRoom.Quantity + " " + itemInRoom.Id + "\n";
                }
            }

            MessageBox.Show(test);*/


            /*ObservableCollection<TimeSlot> ret = new ObservableCollection<TimeSlot>();

            int num_of_time_slots_needed = 4;
            int time_slot_duration = 30;

            ObservableCollection<Appointment> takenAppointments =
                new ObservableCollection<Appointment>();

            Appointment a1 = new Appointment();
            a1.DurationInMinutes = 30;
            a1.StartTime = DateTime.MinValue;
            Appointment a2 = new Appointment();
            a2.DurationInMinutes = 30;
            a2.StartTime = DateTime.MinValue.Add(TimeSpan.FromMinutes(30));
            Appointment a3 = new Appointment();
            a3.DurationInMinutes = 30;
            a3.StartTime = DateTime.MinValue.Add(TimeSpan.FromMinutes(30 * 6));
            Appointment a4 = new Appointment();
            a4.DurationInMinutes = 30;
            a4.StartTime = DateTime.MinValue.Add(TimeSpan.FromMinutes(30 * 9));
            Appointment a5 = new Appointment();
            a5.DurationInMinutes = 30;
            a5.StartTime = DateTime.MinValue.Add(TimeSpan.FromMinutes(30 * 10));

            takenAppointments.Add(a1);
            takenAppointments.Add(a2);
            takenAppointments.Add(a3);
            takenAppointments.Add(a4);
            takenAppointments.Add(a5);
            
            ObservableCollection<DateTime> takeDateTimes = new ObservableCollection<DateTime>();
            foreach (Appointment appointment in takenAppointments)
                for (int i = 0; i < appointment.DurationInMinutes / 30; i++)
                    if (!takeDateTimes.Contains(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30))))
                        takeDateTimes.Add(appointment.StartTime.Add(TimeSpan.FromMinutes(i * 30)));
            string test = "";
            foreach (var VARIABLE in takeDateTimes)
            {
                test += "ovi se ne uzimaju u obzir kad se naidje " + VARIABLE.ToString() + "\n";
            }


            ObservableCollection<TimeSlot> doctorTimeSlots =
                new ObservableCollection<TimeSlot>();
            for (int i = 0; i < 12; i++)
            {
                TimeSlot ts = new TimeSlot();
                ts.StartTime = DateTime.MinValue.Add(TimeSpan.FromMinutes(30 * i));
                doctorTimeSlots.Add(ts);
                test += "ispituje se: " + ts.StartTime.ToString() + "\n";
            }



            for (int i = 0; i < doctorTimeSlots.Count - 3; i++)
            {
                test += "sad se gleda: " + doctorTimeSlots[i].StartTime.ToString() + "\n";
                bool valid_time_slot_set = true;
                for (int j = 0; j < num_of_time_slots_needed - 1; j++)
                {
                    
                    if (doctorTimeSlots[i + j].StartTime.Add(TimeSpan.FromMinutes(30)) !=
                        doctorTimeSlots[i + j + 1].StartTime ||
                        takeDateTimes.Contains(doctorTimeSlots[i + j].StartTime))
                    {
                        valid_time_slot_set = false;
                        break;
                    }
                }

                if (valid_time_slot_set)
                    ret.Add(doctorTimeSlots[i]);
            }

            string s = "";
            foreach (var VARIABLE in ret)
            {
                s += VARIABLE.StartTime.ToString() + "\n";
            }

            MessageBox.Show(test + "\nresernje:\n" + s);*/

            /*ObservableCollection<TimeSlot> ts =
                new RoomService().findSuitableTimeSlotsForOperation(1, 2, 7, new DateTime(2021, 4, 20));
            string s = "";
            foreach (var timeSlot in ts)
            {
                s += timeSlot.StartTime.ToString() + "\n";
            }

            MessageBox.Show(s);*/
            /*foreach (var itemInRoom in new Hospital.Repository.ItemInRoomRepository().GetAllItemsInRoomByRoomId(6))
            {
                MessageBox.Show(itemInRoom.Id.ToString());
            }*/
        }

    }
}
