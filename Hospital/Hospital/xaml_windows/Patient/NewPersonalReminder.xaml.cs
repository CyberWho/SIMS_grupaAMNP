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
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for NewPersonalReminder.xaml
    /// </summary>
    public partial class NewPersonalReminder : Window
    {
        private int userId;
        private PatientController patientController = new PatientController();
        private ReminderController reminderController = new ReminderController();
        private PersonalReminderController personalReminderController = new PersonalReminderController();
        public NewPersonalReminder(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            frequency_txt.ItemsSource = Enum.GetValues(typeof(PersonalReminderFrequency));
        }
        private int GetNextReminderId()
        {
            int reminderId = reminderController.GetLastId();
            reminderId++;
            return reminderId;
        }
        private int GetNextPersonalReminderId()
        {
            int personalReminderId = personalReminderController.GetLastId();
            personalReminderId++;
            return personalReminderId;
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
            if (frequency_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da odaberete učestalost oglašavanja podsetnika!");
                return false;
            }

            return true;
        }

        private bool AlarmTimeValidation()
        {
            if (alarm_time_txt.Text == "")
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

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            if(DataValidation()==false) return;
            
            int newPersonalReminderId = GetNextPersonalReminderId();
            int newReminderId = GetNextReminderId();
            PersonalReminderFrequency frequency = (PersonalReminderFrequency)Enum.Parse(typeof(PersonalReminderFrequency), frequency_txt.SelectedValue.ToString());
            PersonalReminder personalReminder = new PersonalReminder(newPersonalReminderId, name_txt.Text, description_txt.Text, DateTime.Parse(alarm_time_txt.Text), frequency, newReminderId);
            personalReminder.Patient = patientController.GetPatientByUserId(userId);
            personalReminderController.AddPersonalReminder(personalReminder);
            CreateNewPersonalReminder(personalReminder, frequency);
            MessageBox.Show("Uspesno ste kreirali novi podsetnik!");
            var window = new PersonalReminders(userId);
            window.Show();
            this.Close();
        }

        private void CreateNewPersonalReminder(PersonalReminder personalReminder, PersonalReminderFrequency frequency)
        {
            switch (frequency)
            {
                case PersonalReminderFrequency.ONLY_ONCE:
                    personalReminderController.NewOnlyOnceReminder(personalReminder);
                    break;
                case PersonalReminderFrequency.DAILY:
                    personalReminderController.NewDailyReminder(personalReminder);
                    break;
                case PersonalReminderFrequency.WEEKLY:
                    personalReminderController.NewWeeklyReminder(personalReminder);
                    break;
            }
        }
    }

}
