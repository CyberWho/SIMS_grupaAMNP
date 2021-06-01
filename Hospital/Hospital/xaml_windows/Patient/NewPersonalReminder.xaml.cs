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
            FillComboBox();
        }
        private int GetNextReminderId()
        {
            int reminderId = reminderController.GetLastId();
            reminderId++;
            return reminderId;
        }

        private void FillComboBox()
        {
            frequency_txt.Items.Add(new
            {
                Value = (int)PersonalReminderFrequency.ONLY_ONCE,
                Display = "Samo jednom"
            });
            frequency_txt.Items.Add(new
            {
                Value = (int)PersonalReminderFrequency.DAILY,
                Display = "Svaki dan"
            });
            frequency_txt.Items.Add(new
            {
                Value = (int)PersonalReminderFrequency.WEEKLY,
                Display = "Jednom nedeljno"
            });
        }

        private bool CheckIfNextReminderIdIsCorrect(int nextReminderId)
        {
            int reminderId = reminderController.GetLastId();
            reminderId++;
            if (nextReminderId == reminderId) return true;
            return false;
        }

        
        private bool CheckIfNextPersonalReminderIdIsCorrect(int nextPersonalReminderId)
        {
            int personalReminderId = personalReminderController.GetLastId();
            personalReminderId++;
            while (nextPersonalReminderId == personalReminderId) return true;
            return false;
        }

        private int GetCorrectNextReminderId()
        {
            int reminderId = GetNextReminderId();
            while (!CheckIfNextReminderIdIsCorrect(reminderId))
            {
                reminderId = GetNextReminderId();
                
            }

            return reminderId;
        }
        private int GetCorrectNextPersonalReminderId()
        {
            int personalReminderId = GetNextPersonalReminderId();
            while (!CheckIfNextPersonalReminderIdIsCorrect(personalReminderId))
            {
                personalReminderId =  GetNextPersonalReminderId();
                
            }

            return personalReminderId;
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
                MessageBox.Show("Potrebno je da odaberete učestalost oglašavanja podsetnika!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool AlarmTimeValidation()
        {
            if (alarm_time_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da unesete vreme oglašavanja podsetnika!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool DescriptionValidation()
        {
            if (description_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da unesete opis podsetnika!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private bool NameValidation()
        {
            if (name_txt.Text == "")
            {
                MessageBox.Show("Potrebno je da unesete naziv podsetnika!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            if(DataValidation()==false) return;

            CreateNewPersonalReminder();
            MessageBox.Show("Uspesno ste kreirali novi podsetnik!","Zdravo korporacija",MessageBoxButton.OK,MessageBoxImage.Information);
            this.Close();
        }

        private void CreateNewPersonalReminder()
        {
            int newPersonalReminderId = GetCorrectNextPersonalReminderId();
            int newReminderId = GetCorrectNextReminderId();
            PersonalReminderFrequency frequency = (PersonalReminderFrequency) frequency_txt.SelectedValue;
            PersonalReminder personalReminder = new PersonalReminder(newPersonalReminderId, name_txt.Text, description_txt.Text,
                DateTime.Parse(alarm_time_txt.Text), frequency, newReminderId);
            personalReminder.Patient = patientController.GetPatientByUserId(userId);
            personalReminderController.AddPersonalReminder(personalReminder);
            CreateNewPersonalReminder(personalReminder, frequency);
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
