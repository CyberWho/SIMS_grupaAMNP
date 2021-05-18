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
        private DispatcherTimerForReminder dispatcherTimerForReminder;

        public PersonalReminders(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            updateDataGrid();
            frequency_txt.ItemsSource = Enum.GetValues(typeof(PersonalReminderFrequency));
            Izmeni.IsEnabled = false;
            Obrisi.IsEnabled = false;
            Kreiraj.IsEnabled = true;
        }
      
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
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

        private int GetPersonalReminderId()
        {
            PersonalReminder personalReminder = (PersonalReminder) myDataGrid.SelectedValue;
            return personalReminder.Id;
        }

        private int GetReminderId()
        {
            PersonalReminder personalReminder = (PersonalReminder) myDataGrid.SelectedValue;
            return personalReminder.reminderId;
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            personalReminderController.DeletePersonalReminderById(GetPersonalReminderId());
            updateDataGrid();
        }

        private bool DataValidation()
        {
            if (!NameValidation()) return false;

            if (!DescriptionValidation()) return false;

            if (!AlarmTimeValidation()) return false;

            if (!FrequencyValidation()) return false;

            return true;
        }

        private bool FrequencyValidation()
        {
            if (frequency_txt.Text == null)
            {
                MessageBox.Show("Potrebno je da odaberete učestalost oglašavanja podsetnika!");
                return false;
            }

            return true;
        }

        private bool AlarmTimeValidation()
        {
            if (alarm_time_txt.Text == null)
            {
                MessageBox.Show("Potrebno je da unesete vreme oglašavanja podsetnika!");
                return false;
            }

            return true;
        }

        private bool DescriptionValidation()
        {
            if (description_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da unesete opis podsetnika!");
                return false;
            }

            return true;
        }

        private bool NameValidation()
        {
            if (name_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da unesete naziv podsetnika!");
                return false;
            }

            return true;
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            if(!DataValidation()) return;
            
            PersonalReminder personalReminder = personalReminderController.GetPersonalReminderById(GetPersonalReminderId());
           
            PersonalReminderFrequency frequency = (PersonalReminderFrequency)Enum.Parse(typeof(PersonalReminderFrequency), frequency_txt.SelectedValue.ToString());
            UpdatePersonalReminder(personalReminder, frequency);
            updateDataGrid();

        }

        private void UpdatePersonalReminder(PersonalReminder personalReminder, PersonalReminderFrequency frequency)
        {
            if (personalReminder.PersonalReminderFrequency == frequency)
            {
                if(frequency == PersonalReminderFrequency.ONLY_ONCE)
                {
                    SimpleReminderUpdate(personalReminder);
                } else
                {
                    switch(frequency)
                    {
                        case PersonalReminderFrequency.DAILY:
                            personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                            SimpleReminderUpdate(personalReminder);
                            personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                            personalReminderController.NewDailyReminder(personalReminder);
                            break;
                        case PersonalReminderFrequency.WEEKLY:
                            personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                            SimpleReminderUpdate(personalReminder);
                            personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                            personalReminderController.NewDailyReminder(personalReminder);
                            break;
                    }
                }
                
            }
            else
            {
                PersonalReminderFrequencyUpdate(personalReminder, frequency);


            }
        }

        private void SimpleReminderUpdate(PersonalReminder personalReminder)
        {
            Reminder reminder = new Reminder(name_txt.Text,description_txt.Text,DateTime.Parse(alarm_time_txt.Text),personalReminder.Id);
          
            reminderController.UpdateReminder(reminder);
        }
        private void PersonalReminderFrequencyUpdate(PersonalReminder personalReminder,PersonalReminderFrequency frequency)
        {
            switch (frequency)
            {
                case PersonalReminderFrequency.ONLY_ONCE:
                    SimpleReminderUpdate(personalReminder);
                    personalReminderController.GenerateOnlyOnceReminder(personalReminder);
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.ONLY_ONCE;
                    personalReminderController.UpdatePersonalReminderFrequency(personalReminder);
                    break;
                case PersonalReminderFrequency.DAILY:
                    personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                    SimpleReminderUpdate(personalReminder);
                    personalReminderController.NewDailyReminder(personalReminder);
                    personalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                    personalReminderController.UpdatePersonalReminderFrequency(personalReminder);
                    break;
                case PersonalReminderFrequency.WEEKLY:
                    personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                    SimpleReminderUpdate(personalReminder);
                    personalReminderController.NewWeeklyReminder(personalReminder);
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

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Izmeni.IsEnabled = true;
            Obrisi.IsEnabled = true;
            Kreiraj.IsEnabled = false;
        }
    }
}
