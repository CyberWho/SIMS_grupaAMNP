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
using Hospital.Model;
using Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PersonalReminders.xaml
    /// </summary>
    public partial class PersonalReminders : Window
    {
        int userId;
        private ReminderController reminderController = new ReminderController();
        
        private PatientController patientController = new PatientController();
        private PersonalReminderController personalReminderController = new PersonalReminderController();
        private ObservableCollection<PersonalReminder> personalReminders = new ObservableCollection<PersonalReminder>();
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        public PersonalReminders(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            updateDataGrid();
            frequency_txt.ItemsSource = Enum.GetValues(typeof(PersonalReminderFrequency));
            
        }
        private void dispatherTimer_Tick(object sender, EventArgs e)
        {
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();
            Model.Patient patient = new Model.Patient();
            patient = patientController.GetPatientByUserId(userId);
            reminders = reminderController.GetAllFutureRemindersByPatientId(patient.Id);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(-now.Millisecond);
            foreach (Reminder reminder in reminders)
            {
                if ((reminder.AlarmTime - now).Minutes == 0)
                {
                    MessageBox.Show(reminder.Description);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var window = new Reminders(userId);
            window.Show();
            this.Close();
        }
        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientUI(userId);
            window.Show();
            this.Close();
        }
        private void updateDataGrid()
        {
            this.DataContext = this;
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            personalReminders = personalReminderController.GetAllPersonalRemindersByPatientId(patient.Id);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = personalReminders;
        }


        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientInfo(userId);
            window.Show();
            this.Close();
        }
        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientAppointments(userId);
            window.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {
            var window = new Doctors(userId);
            window.Show();
            this.Close();
        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {
            var window = new PatientHealthRecord(userId);
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
            var window = new Notifications(userId);
            window.Show();
            this.Close();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            personalReminderController.DeletePersonalReminderById(int.Parse(id_txt.Text));
            updateDataGrid();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            PersonalReminder personalReminder = personalReminderController.GetPersonalReminderById(int.Parse(id_txt.Text));
            PersonalReminderFrequency frequency = (PersonalReminderFrequency)Enum.Parse(typeof(PersonalReminderFrequency), frequency_txt.SelectedValue.ToString());
            if(personalReminder.PersonalReminderFrequency == frequency)
            {
                SimpleReminderUpdate(personalReminder);
            } else 
            {
                SimpleReminderUpdate(personalReminder);
                PersonalReminderFrequencyUpdate(personalReminder, frequency);
                
            }
            updateDataGrid();

        }

        private void SimpleReminderUpdate(PersonalReminder personalReminder)
        {
            Reminder reminder = new Reminder();
            reminder.Name = name_txt.Text;
            reminder.Description = description_txt.Text;
            reminder.AlarmTime = DateTime.Parse(alarm_time_txt.Text);
            reminder.personalReminderId = personalReminder.Id;
            reminderController.UpdateReminder(reminder);
        }
        private void PersonalReminderFrequencyUpdate(PersonalReminder personalReminder,PersonalReminderFrequency frequency)
        {
            switch (frequency)
            {
                case PersonalReminderFrequency.ONLY_ONCE:
                    personalReminderController.GenerateOnlyOnceReminder(personalReminder);
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.ONLY_ONCE;
                    personalReminderController.UpdatePersonalReminderFrequency(personalReminder);
                    break;
                case PersonalReminderFrequency.DAILY:
                    personalReminderController.GenerateDailyReminder(personalReminder);
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                    personalReminderController.UpdatePersonalReminderFrequency(personalReminder);
                    break;
                case PersonalReminderFrequency.WEEKLY:
                    personalReminderController.GenerateWeeklyReminder(personalReminder);
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.WEEKLY;
                    personalReminderController.UpdatePersonalReminderFrequency(personalReminder);
                    break;
            }
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewPersonalReminder(userId);
            window.Show();
            this.Close();
        }
    }
}
