using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Hospital.Service;
using Hospital.View.Doctor;
using MVVM1;

namespace Hospital.xaml_windows.Doctor
{
    /// <summary>
    /// Interaction logic for ClinicalTreatmentGiving.xaml
    /// </summary>
    public partial class ClinicalTreatmentGiving : Window
    {
        private int krevet_id = 21;

        HealthRecord healthRecord;
        int id_doc_as_emoloyee;
        int id_doc;
        int id_patient;
        private int selected_room_id;
        private int id_selected_doctor = -1;

        int selected_appointment_id = -1;



        private RefferalForClinicalTreatmentController refferalForClinicalTreatmentController = new RefferalForClinicalTreatmentController();
        private RoomController roomController = new RoomController();
        private InventoryItemController inventoryItemController = new InventoryItemController();

        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();

        public ClinicalTreatmentGiving(HealthRecord healthRecord, int id_doc_as_emoloyee, int id_doc, int id_patient, int selected_appointment_id)
        {
            InitializeComponent();
            this.healthRecord = healthRecord;
            this.id_doc_as_emoloyee = id_doc_as_emoloyee;
            this.id_doc = id_doc;
            this.id_patient = id_patient;
            this.selected_appointment_id = selected_appointment_id;

            this.DataContext = this;
            this.ReturnOptionCommand = new MyICommand(ReturnOption);
            this.GoToDrugOperationCommand = new MyICommand(GoToDrugOperation);
            this.GoToAppointmentsCommand = new MyICommand(GoToAppointments);
            this.GoToCreateAppointmentCommand = new MyICommand(GoToCreateAppointment);
            this.GoToScheduleCommand = new MyICommand(GoToSchedule);
            this.GoToPatientSearchCommand = new MyICommand(GoToPatientSearch);
        }


        private DateRange getDateRangeFromUi()
        {
            if (dp_startTime.SelectedDate == null || dp_endTime.SelectedDate == null)
            {
                MessageBox.Show("Datum nije izabran kako treba");
                return null;
            }

            DateTime startTime = (DateTime)dp_startTime.SelectedDate;
            DateTime endTime = (DateTime)dp_endTime.SelectedDate;

            if (startTime >= endTime)
            {
                MessageBox.Show("Krajnje vreme treba da bude vece od pocetnog");
                return null;
            }

            return new DateRange(startTime, endTime);
        }

        private void findSuitableRooms()
        {
            DateRange dateRange = getDateRangeFromUi();
            if (dateRange == null)
                return;

            ObservableCollection<Room> tmp = roomController.findSuitableRoomsWithEquipment(dateRange, getObservableCollectionWithBed());
            /*foreach (var VARIABLE in tmp)
            {
                MessageBox.Show(VARIABLE.Id.ToString());
            }*/
            fillSuitableRooms(tmp, dateRange);
        }

        private ObservableCollection<InventoryItem> getObservableCollectionWithBed()
        {
            ObservableCollection<InventoryItem> krevet = new ObservableCollection<InventoryItem>();
            krevet.Add(inventoryItemController.GetInventoryItemById(krevet_id));
            return krevet;
        }

        private void fillSuitableRooms(ObservableCollection<Room> rooms, DateRange dateRange)
        {
            this.rooms.Clear();
            foreach (Room room in rooms)
                foreach (ItemInRoom itemInRoom in room.itemInRoom)
                    if (itemInRoom.inventoryItem_id == krevet_id &&
                        itemInRoom.Quantity > refferalForClinicalTreatmentController.GetMaxTakenBeds(room.Id, dateRange))
                        this.rooms.Add(room);
        }

        private void fillRoomsToUi(ObservableCollection<Room> rooms)
        {
            foreach (Room room in rooms)
            {
                tb_tip_trazi.Visibility = Visibility.Hidden;
                ListBoxItem item = new ListBoxItem();
                item.Content = "Soba: " + room.Id;
                lb_rooms.Items.Add(item);
            }

        }
        private void ReturnOption(object sender, RoutedEventArgs e)
        {
            Window s = new HealthRecordDoctorView(id_doc_as_emoloyee, id_doc, id_patient);
            s.Show();
            this.Close();
        }

        private void FindRoomsWithBeds(object sender, RoutedEventArgs e)
        {
            findSuitableRooms();
            fillRoomsToUi(rooms);
        }



        private void lb_rooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            if (lbi != null)
            {
                BtnZakazi.IsEnabled = true;
                selected_room_id = int.Parse(lbi.Content.ToString().Split(' ')[1]);
                //MessageBox.Show(selected_room_id.ToString());
            }

        }

        private void startClinicalTreatment(object sender, RoutedEventArgs e)
        {
            DateRange dateRange = getDateRangeFromUi();
            if (dateRange == null || selected_room_id == -1)
                return;

            ClinicalTreatment nCT = new ClinicalTreatment(-1, dateRange.StartTime, dateRange.EndTime, selected_room_id,
                healthRecord.Id);
            refferalForClinicalTreatmentController.createClinicalTreatment(nCT);
            MessageBox.Show("Uspesno dodato bolnicko lecenje");
            selected_room_id = -1;
            BtnZakazi.IsEnabled = false;
            lb_rooms.Items.Clear();
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
            Window s = new Doctor_crud_appointments(id_doc_as_emoloyee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToCreateAppointment()
        {
            Window s = new Create_appointment(id_doc_as_emoloyee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToSchedule()
        {
            Window s = new Schedule(id_doc_as_emoloyee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToPatientSearch()
        {
            Window s = new SearchPatientMVVM(id_doc_as_emoloyee, id_doc);
            s.Show();
            this.Close();
        }

        private void GoToDrugOperation() // Obradjuje se
        {

            Window s = new View.Doctor.DrugOperations(id_doc_as_emoloyee, id_doc);
            s.Show();
            this.Close();
        }



    }
}
