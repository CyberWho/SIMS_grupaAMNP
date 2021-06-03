using System;
using System.Windows;
using Hospital.Controller;
using Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;
using Hospital.View.Patient;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientReminders.xaml
    /// </summary>
    public partial class PatientReminders : Window
    {
        private int userId;
        private bool tooltipChecked;
        private ReminderController reminderController = new ReminderController();
        private ObservableCollection<Reminder> Reminders = new ObservableCollection<Reminder>();
        private PatientController patientController = new PatientController();
        private DispatcherTimerForReminder dispatcherTimerForReminder;

        public PatientReminders(int userId,bool tooltipChecked)
        {
            InitializeComponent();
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            updateDataGrid();
            ToolTipChecked(tooltipChecked);
        }
        private void ToolTipChecked(bool tooltipChecked)
        {
            if (tooltipChecked == true)
            {
                CheckBox.IsChecked = true;
            }
            else
            {
                CheckBox.IsChecked = false;
            }
        }
        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, true);
            tooltipChecked = true;
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new RemindersView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUIView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfoView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointmentsView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void updateDataGrid()
        {
            this.DataContext = this;
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            Reminders = reminderController.GetAllRemindersByPatientId(patient.Id);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = Reminders;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new DoctorsView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecordView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Notifications_Click(object sender, RoutedEventArgs e)
        {
            var window = new Notifications(userId,tooltipChecked);
            window.Show();
            this.Close();
        }
        private void Undo_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new RemindersView(userId,tooltipChecked);
            window.Show();
            this.Close();
        }

        private void CheckBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            this.SetValue(ToolTipBehavior.ToolTipEnabledProperty, false);
            tooltipChecked = false;
        }
    }
}
