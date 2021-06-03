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
using Hospital.View.Patient;
using Hospital.ViewModel.Patient;

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PersonalReminders.xaml
    /// </summary>
    public partial class PersonalReminders : Window
    {
        int userId;
        private Point startPoint = new Point();
        private bool tooltipChecked;
        private ReminderController reminderController = new ReminderController();

        private ObservableCollection<PersonalReminder> SelectedPersonalReminders =
            new ObservableCollection<PersonalReminder>();
        private PatientController patientController = new PatientController();
        private PersonalReminderController personalReminderController = new PersonalReminderController();
        private ObservableCollection<PersonalReminder> personalReminders = new ObservableCollection<PersonalReminder>();
        private DispatcherTimerForReminder dispatcherTimerForReminder;

        public PersonalReminders(int userId,bool tooltipChecked)
        {
            this.userId = userId;
            this.tooltipChecked = tooltipChecked;
            InitializeComponent();
            updateDataGrid();
            // FillComboBox();
            frequency_txt.ItemsSource = Enum.GetValues(typeof(PersonalReminderFrequency));
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcherTimerForReminder = new DispatcherTimerForReminder(userId);
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
        private void updateDataGrid()
        {
            this.DataContext = this;
            Model.Patient patient = patientController.GetPatientByUserId(userId);
            personalReminders = personalReminderController.GetAllPersonalRemindersByPatientId(patient.Id);
            DataTable dt = new DataTable();
            myDataGrid.DataContext = dt;
            myDataGrid.ItemsSource = personalReminders;
            DataTable dtSelected = new DataTable();
            myDataGridDrop.DataContext = dtSelected;
            SelectedPersonalReminders = new ObservableCollection<PersonalReminder>();
            myDataGridDrop.ItemsSource = SelectedPersonalReminders;
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
            var window = new NotificationsView(userId,tooltipChecked);
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

            PersonalReminderFrequency frequency = (PersonalReminderFrequency) frequency_txt.SelectedValue;
            UpdatePersonalReminder(personalReminder, frequency);
            updateDataGrid();

        }

        private void UpdatePersonalReminder(PersonalReminder personalReminder, PersonalReminderFrequency frequency)
        {
            PersonalReminderFrequencyUpdate(personalReminder,frequency);
        }

        private PersonalReminder SimpleReminderUpdate(PersonalReminder personalReminder)
        {
            Reminder reminder = new Reminder(name_txt.Text,description_txt.Text,DateTime.Parse(alarm_time_txt.Text),personalReminder.Id);
            reminderController.UpdateReminder(reminder);
            PersonalReminder newPersonalReminder = new PersonalReminder(personalReminder.Id, reminder.Name, reminder.Description, reminder.AlarmTime,
                personalReminder.PersonalReminderFrequency, personalReminder.reminderId);
            newPersonalReminder.Patient = patientController.GetPatientByUserId(userId);
            return newPersonalReminder;
        }
        private void PersonalReminderFrequencyUpdate(PersonalReminder personalReminder,PersonalReminderFrequency frequency)
        {
            switch (frequency)
            {
                case PersonalReminderFrequency.ONLY_ONCE:
                    personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                    PersonalReminder onlyOncePersonalReminder =  SimpleReminderUpdate(personalReminder);
                    personalReminderController.GenerateOnlyOnceReminder(onlyOncePersonalReminder);
                    onlyOncePersonalReminder.PersonalReminderFrequency = PersonalReminderFrequency.ONLY_ONCE;
                    personalReminderController.UpdatePersonalReminderFrequency(onlyOncePersonalReminder);
                    break;
                case PersonalReminderFrequency.DAILY:
                    personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                    PersonalReminder dailyPersonalReminder =  SimpleReminderUpdate(personalReminder);
                    personalReminderController.NewDailyReminder(dailyPersonalReminder);
                    dailyPersonalReminder.PersonalReminderFrequency = PersonalReminderFrequency.DAILY;
                    personalReminderController.UpdatePersonalReminderFrequency(dailyPersonalReminder);
                    break;
                case PersonalReminderFrequency.WEEKLY:
                    personalReminderController.DeleteAllRemindersExceptFirstReminder(personalReminder);
                    PersonalReminder weeklyPersonalReminder = SimpleReminderUpdate(personalReminder);
                    personalReminderController.NewWeeklyReminder(weeklyPersonalReminder);
                    weeklyPersonalReminder.PersonalReminderFrequency = PersonalReminderFrequency.WEEKLY;
                    personalReminderController.UpdatePersonalReminderFrequency(weeklyPersonalReminder);
                    break;
            }
        }

        private void Kreiraj_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewPersonalReminder(userId);
            window.Show();

        }

        private void myDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void myDataGridDrop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void MyDataGrid_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void MyDataGrid_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow dataGridRow =
                    FindAncestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (dataGridRow == null) return;

                // Find the data behind the ListViewItem
                PersonalReminder personalReminder = (PersonalReminder)myDataGrid.ItemContainerGenerator.
                    ItemFromContainer(dataGridRow);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", personalReminder);
                DragDrop.DoDragDrop(dataGridRow, dragData, DragDropEffects.Move);
            }
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
        private void MyDataGridDrop_OnDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MyDataGridDrop_OnDrop(object sender, DragEventArgs e)
        {
            SelectedPersonalReminders.Add((PersonalReminder)myDataGrid.SelectedItem);
            personalReminders.Remove((PersonalReminder) myDataGrid.SelectedItem);
            DeleteAll.IsEnabled = true;
        }


        private void DeleteAll_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (PersonalReminder personalReminder in SelectedPersonalReminders)
            {
                personalReminderController.DeletePersonalReminderById(personalReminder.Id);
                
            }

            updateDataGrid();
            DeleteAll.IsEnabled = false;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string str = "PersonalRemindersHelp";
            HelpProvider.ShowHelp(str, this);
        }
    }
}
