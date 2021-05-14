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
            int personalReminderId = reminderController.GetLastId();
            personalReminderId++;
            return personalReminderId;
        }

        private void Potvrda_Click(object sender, RoutedEventArgs e)
        {
            int newPersonalReminderId = GetNextPersonalReminderId();
            int newReminderId = GetNextReminderId();
            PersonalReminder personalReminder = new PersonalReminder();
            
            PersonalReminderFrequency frequency = (PersonalReminderFrequency)Enum.Parse(typeof(PersonalReminderFrequency), frequency_txt.SelectedValue.ToString());
            personalReminder.Id = newPersonalReminderId;
            personalReminder.Name = name_txt.Text;
            personalReminder.Description = description_txt.Text;
            personalReminder.AlarmTime = DateTime.Parse(alarm_time_txt.Text);
            personalReminder.reminderId = newReminderId;
            personalReminder.Patient = patientController.GetPatientByUserId(userId);
            personalReminder.PersonalReminderFrequency = frequency;
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
