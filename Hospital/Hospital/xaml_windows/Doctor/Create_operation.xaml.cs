using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hospital.View.Doctor;
using MVVM1;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for Create_operation.xaml
    /// </summary>
    public partial class Create_operation : Window
    {
        private int id_doc_as_employee;
        private int id_doc;
        private int id_patient;
        private int id_room = -1;
        private int id_time_slot = -1;
        private DateTime time_of_operation = DateTime.Today.AddDays(1);

        //controllers
        private InventoryItemController inventoryItemController = new InventoryItemController();
        private AppointmentController appointmentController = new AppointmentController();
        private DoctorController doctorController = new DoctorController();
        private PatientController patientController = new PatientController();
        private RoomController roomController = new RoomController();
        private TimeSlotController timeSlotController = new TimeSlotController();

        public Create_operation(int id_doc_as_employee, int id_doc, int id_patient)
        {
            InitializeComponent();
            //datePickerOperation.DisplayDateStart = DateTime.Today.AddDays(1);
            this.id_doc_as_employee = id_doc_as_employee;
            this.id_doc = id_doc;
            this.id_patient = id_patient;
            FillEquipmentOptions();

            this.DataContext = this;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);
        }
     

        private void FillEquipmentOptions()
        {
            foreach (InventoryItem inventoryItem in inventoryItemController.GetAllInvenotryItemsByItemTypeId((int)ItemType.PERSISTENT))
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = inventoryItem.Id + "|" + inventoryItem.Name;
                lb_options.Items.Add(item);
            }

        }

        private void SwitchToSelected(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                lb_options.Items.Remove(lbi);
                lb_selected.Items.Add(lbi);
                lb_rooms.Items.Clear();
                id_room = -1;
                id_time_slot = -1;
            }
        }

        private void SwitchToOptions(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                lb_selected.Items.Remove(lbi);
                lb_options.Items.Add(lbi);
                lb_rooms.Items.Clear();
                id_room = -1;
                id_time_slot = -1;
            }
        }

        private ObservableCollection<InventoryItem> GetItemsFromUi()
        {
            ObservableCollection<InventoryItem> ret = new ObservableCollection<InventoryItem>();
            foreach (ListBoxItem lbi in lb_selected.Items)
            {
                String[] split = lbi.Content.ToString().Split('|');
                InventoryItem inventoryItem = new InventoryItem();
                inventoryItem.Id = int.Parse(split[0]);
                inventoryItem.Name = split[1];
                ret.Add(inventoryItem);
            }
            return ret;
        }

        private void FindRoomWithSelected(object sender, RoutedEventArgs e)
        {
            ObservableCollection<InventoryItem> inventoryItems = GetItemsFromUi();

            ObservableCollection<Room> rooms = roomController.findSuitableRoomsWithEquipment(new DateRange(DateTime.MaxValue, DateTime.MaxValue), inventoryItems);

            lb_rooms.Items.Clear();


            foreach (var room in rooms)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = "soba " + room.Id;
                lb_rooms.Items.Add(lbi);
            }

            if (rooms.Count == 0)
                MessageBox.Show("Nema soba za zadat kriterijum");

        }

        private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            time_of_operation = (DateTime) ((sender as DatePicker)).SelectedDate;
        }

        private void SelectedRoomChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                btn_trazi_sobe.IsEnabled = true;
                id_room = int.Parse(lbi.Content.ToString().Split(' ')[1]);
                //MessageBox.Show(id_room.ToString());
            }

        }

        private void findOperationTimes(object sender, RoutedEventArgs e)
        {
            ObservableCollection<TimeSlot> startTimes =
                roomController.findSuitableTimeSlotsForOperation(id_room, id_doc, id_patient, time_of_operation);
            foreach (TimeSlot timeSlot in startTimes)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = timeSlot.Id + "|" + timeSlot.StartTime;
                lb_operation_start.Items.Add(lbi);
            }

            if (startTimes.Count == 0)
                MessageBox.Show("Nema vremena pogodnih");
        }

        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new HealthRecordDoctorView(id_doc_as_employee, id_doc, id_patient);
            s.Show();
            this.Close();
        }

        private void createOperation(object sender, RoutedEventArgs e)
        {
            if (id_room != -1 && id_time_slot != -1)
            {
                int id_app = appointmentController.GetLastId() + 1;
                int duration = 120;
                DateTime dt = timeSlotController.GetTimeSlotById(id_time_slot).StartTime;
                Appointment newAppointment = new Appointment(id_app, duration, dt, AppointmentType.OPERATION,
                    AppointmentStatus.RESERVED, doctorController.GetDoctorById(id_doc), patientController.GetPatientById(id_patient), roomController.GetRoomById(id_room));
                appointmentController.ReserveAppointment(newAppointment);
                for (int i = 0; i < newAppointment.DurationInMinutes / 30; i++)
                {
                    timeSlotController.TakeTimeSlot(
                        timeSlotController.GetAppointmentTimeSlotByDateAndDoctorId(dt.AddMinutes(30 * i), id_doc));
                }

                lb_rooms.Items.Clear();
                lb_operation_start.Items.Clear();
                btn_trazi_sobe.IsEnabled = false;
                btn_zakazi_operaciju.IsEnabled = false;

                MessageBox.Show("Operacija kreirana");
            }
            else
            {
                MessageBox.Show("Operacija NIJE kreirana");
            }
        }

        private void TimeSlotChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                btn_zakazi_operaciju.IsEnabled = true;
                id_time_slot = int.Parse(lbi.Content.ToString().Split('|')[0]);
            }
        }

        /***************************
        ***
        Dodavanje navigacije
        ***
        ***************************/
        public MyICommand ReturnOptionCommand { get; set; }
        public MyICommand GoToDrugOperationCommand { get; set; }
        public MyICommand GoToAppointmentsCommand { get; set; }
        public MyICommand GoToCreateAppointmentCommand { get; set; }
        public MyICommand GoToScheduleCommand { get; set; }
        public MyICommand GoToPatientSearchCommand { get; set; }

        public void ReturnOption()
        {
            Window s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void GoToAppointments()
        {
            Window s = new Doctor_crud_appointments(id_doc_as_employee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateAppointment()
        {
            Window s = new Create_appointment(id_doc_as_employee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToSchedule()
        {
            Window s = new Schedule(id_doc_as_employee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToPatientSearch()
        {
            Window s = new SearchPatientMVVM(id_doc_as_employee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToDrugOperation() // Obradjuje se
        {

            Window s = new View.Doctor.DrugOperations(id_doc_as_employee, id_doc);
            s.Show();
            this.Close();
        }

        /***

     Drag & Drop
      lb_options lb_selected
      ***/


        Point LB1StartMousePos;
        Point LB2StartMousePos;

        private void LB1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LB1StartMousePos = e.GetPosition(null);
        }

        private void LB2_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LB2StartMousePos = e.GetPosition(null);
        }

        private void LB1_Drop(object sender, DragEventArgs e)
        {
            // This casts 'e.Data.GetData()' as a ListBoxItem and if it isn't null
            // then the code will "execute" sort of. basically, listItem will always be 
            // a ListBoxItem (atleast i think it will)
            if (e.Data.GetData(DataFormats.FileDrop) is ListBoxItem listItem)
            {
                lb_options.Items.Add(listItem);
            }
        }

        private void LB2_Drop(object sender, DragEventArgs e)
        {
            // This casts 'e.Data.GetData()' as a ListBoxItem and if it isn't null
            // then the code will "execute" sort of. basically, listItem will always be 
            // a ListBoxItem (atleast i think it will)
            if (e.Data.GetData(DataFormats.FileDrop) is ListBoxItem listItem)
            {
                lb_selected.Items.Add(listItem);
            }
        }

        private void LB1_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    // This gets the selected item
                    ListBoxItem selectedItem = (ListBoxItem)lb_options.SelectedItem;
                    // You need to remove it before adding it to another listbox.
                    // if  you dont, it throws an error (due to referencing between 2 listboxes)
                    lb_options.Items.Remove(selectedItem);

                    // The actual dragdrop thingy
                    // DragDropEffects.Copy... i dont think this matters but oh well.
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);

                    // This code will check if the listboxitem is inside a ListBox or not.
                    // This will stop the ListBoxItem you dragged from vanishing if you dont
                    // Drop it inside a listbox (drop it in the titlebar or something lol)

                    // ListBoxItems are objects obviously, and objects are passed and moved by reference.
                    // Any change to an object affects every reference. 'selectedItem' is a reference
                    // To LB2.SelectedItem, and they both will NEVER be different :)

                    if (selectedItem.Parent == null)
                    {
                        lb_options.Items.Add(selectedItem);
                    }
                }
                catch { }
            }
        }

        private void LB2_MouseMove(object sender, MouseEventArgs e)
        {
            Point mPos = e.GetPosition(null);

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(mPos.X) > SystemParameters.MinimumHorizontalDragDistance &&
                Math.Abs(mPos.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                try
                {
                    // This gets the selected item
                    ListBoxItem selectedItem = (ListBoxItem)lb_selected.SelectedItem;
                    // You need to remove it before adding it to another listbox.
                    // if  you dont, it throws an error (due to referencing between 2 listboxes)
                    lb_selected.Items.Remove(selectedItem);

                    // The actual dragdrop thingy
                    // DragDropEffects.Copy... i dont think this matters but oh well.
                    DragDrop.DoDragDrop(this, new DataObject(DataFormats.FileDrop, selectedItem), DragDropEffects.Copy);

                    // This code will check if the listboxitem is inside a ListBox or not.
                    // This will stop the ListBoxItem you dragged from vanishing if you dont
                    // Drop it inside a listbox (drop it in the titlebar or something lol)

                    // ListBoxItems are objects obviously, and objects are passed and moved by reference.
                    // Any change to an object affects every reference. 'selectedItem' is a reference
                    // To LB2.SelectedItem, and they both will NEVER be different :)

                    if (selectedItem.Parent == null)
                    {
                        lb_selected.Items.Add(selectedItem);
                    }
                }
                catch { }
            }
        }
    }


}
