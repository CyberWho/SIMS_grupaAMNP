using Hospital.View.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Hospital.Controller;
using Hospital.Model;
using Hospital.xaml_windows.Patient;
using Hospital.xaml_windows.Secretary;

namespace Hospital.ViewModel.Patient
{
    class PatientAppointmentsViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        private bool tooltipChecked;
        private BindableBase currentViewModel;
        public MyICommand HomePage { get; set; }
        public MyICommand MyProfile { get; set; }
        public MyICommand MyAppointments { get; set; }
        public MyICommand MyReminders { get; set; }
        public MyICommand MyHealthRecord { get; set; }
        public MyICommand ShowDoctors { get; set; }
        public MyICommand LogOut { get; set; }
        public MyICommand ShowNotifications { get; set; }
        public MyICommand ToolTipsOn { get; set; }
        public MyICommand SelectionChanged { get; set; }
        public MyICommand Update { get; set; }
        public MyICommand New { get; set; }
        public MyICommand Delete { get; set; }
        public DataGrid myDataGrid { get; set; }
        public Appointment selectedItem { get; set; }

        private PatientController patientController = new PatientController();
        private AppointmentController appointmentController = new AppointmentController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;
        private PatientLogsController patientLogsController = new PatientLogsController();
        public ObservableCollection<Appointment> Appointments { get; set; }
        public BindableBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public PatientAppointmentsViewModel()
        {

        }

        public PatientAppointmentsViewModel(int userId,bool tooltipChecked, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            this.tooltipChecked = tooltipChecked;
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
            HomePage = new MyICommand(OnHomePage);
            MyProfile = new MyICommand(OnMyProfile);
            MyAppointments = new MyICommand(OnMyAppointments);
            Update = new MyICommand(OnUpdate);
            Delete = new MyICommand(OnDelete);
            New = new MyICommand(OnNew);
            MyHealthRecord = new MyICommand(OnHealthRecord);
            SelectionChanged = new MyICommand(OnSelectionChanged);
            LogOut = new MyICommand(OnLogOut);
            updateDataGrid();
        }
        private void OnHealthRecord()
        {
            Window window = new PatientHealthRecordView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private void OnLogOut()
        {
            Window window = new MainWindow();
            window.Show();
            thisWindow.Close();
        }
        private void OnSelectionChanged()
        {
            
        }

        private void OnNew()
        {
            Window window = new PatientNewAppointmentView(userId, tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnDelete()
        {
            appointmentController.CancelAppointmentById(GetAppointmentId());
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            patientLogsController.IncrementLogCounterByPatientId(patient.Id);
            CheckIfPatientIsBlocked(patient.Id);
            updateDataGrid();
        }
        private void CheckIfPatientIsBlocked(int patientId)
        {
            if (patientLogsController.CheckIfPatientIsBlockedByPatientId(patientId))
            {
                ShowPatientIsBlocked(patientId);

            }
        }

        private void ShowPatientIsBlocked(int patientId)
        {
            MessageBox.Show("Blokirani ste do daljnjeg zbog previse malicioznih aktivnosti!");
            appointmentController.DeleteAllReservedAppointmentsByPatientId(patientId);
            var windowLogOut = new MainWindow();
            windowLogOut.Show();
            thisWindow.Close();
        }

        private void OnUpdate()
        {
            Appointment appointment = new Appointment();

            int patientId = getPatientId();
            appointment = appointmentController.GetAppointmentById(GetAppointmentId());
            var hours = (appointment.StartTime - DateTime.Now).TotalHours;
            //DateValidationForUpdate(hours, patientId, GetAppointmentId());
            Window window = new PatientUpdateAppointmentView(userId, appointment.Id,tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
        private int GetAppointmentId()
        {
            return selectedItem.Id;
        }
        private void DateValidationForUpdate(double hours, int patientId, int appointmentId)
        {
            if (hours > 24)
            {
                //ShowPatientUpdateAppointment(patientId, appointmentId);
            }
            else
            {
                MessageBox.Show("Nije moguce promeniti vreme odrzavanja termina jer je ostalo manje od 24h", "Zdravo korporacija", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private int getPatientId()
        {

            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            return patient.Id;
        }

        private void updateDataGrid()
        {
            Model.Patient patient = new PatientController().GetPatientByUserId(userId);
            Appointments = appointmentController.GetAllReservedAppointmentsByPatientId(patient.Id);

        }
        private void OnMyProfile()
        {
            Window window = new PatientInfoView(userId,tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnHomePage()
        {
            Window window = new PatientUIView(userId,tooltipChecked);
            window.Show();
            thisWindow.Close();
        }

        private void OnMyAppointments()
        {
            Window window = new PatientAppointmentsView(userId,tooltipChecked);
            window.Show();
            thisWindow.Close();
        }
    }
}
