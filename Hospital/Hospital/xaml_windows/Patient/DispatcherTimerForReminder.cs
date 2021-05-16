using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Hospital.Controller;
using Hospital.Model;

namespace Hospital.xaml_windows.Patient
{
    public class DispatcherTimerForReminder
    {
        private PatientController patientController;
        private int userId;
        private ReminderController reminderController;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;

        public DispatcherTimerForReminder(int userId)
        {
            this.userId = userId;
            dispatcherTimer = new DispatcherTimer();
            patientController = new PatientController();
            reminderController = new ReminderController();
            dispatcherTimer.Tick += dispatherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
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
                    Thread.Sleep(3000);
                }
            }
        }
    }
}