using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace Hospital.xaml_windows.Secretary
{
    /// <summary>
    /// Interaction logic for FreeDays.xaml
    /// </summary>
    public partial class FreeDays : Window
    {
        private int doctor_id;
        private Model.FreeDays freeDays;
        private FreeDaysController freeDaysController = new FreeDaysController();
        private DoctorController doctorController = new DoctorController();

        private Model.Doctor doctor;
        private string type_fd;

        public FreeDays(int doctor_id)
        {
            InitializeComponent();
            this.doctor_id = doctor_id;
            string doctor_name = "Lekar: ";
            doctor = this.doctorController.GetDoctorById(doctor_id);
            doctor_name += doctor.User.Name + " " + doctor.User.Surname;
            this.doctor_name.ContentStringFormat = doctor_name;
        }

        private void Make_Free_Days(object sender, RoutedEventArgs e)
        {
            String description = not_desc.Text.Remove(0, 22);

            DateRange dateRange = parseDateRange();

            FreeDaysStatus status = FreeDaysStatus.APPROVED;

            freeDays = new 
                Model.FreeDays(
                    0, 
                    status,
                    dateRange,
                    description,
                    doctor,
                    doctor_id
                );

            this.freeDaysController.AddFreeDays(freeDays);
            this.Close();
        }

        private void type_selection_changed(object sender, SelectionChangedEventArgs e)
        {
            if (type.SelectedItem != null)
            {
                type_fd = type.SelectedItem.ToString();
            }
        }

        private void type_selection_loaded(object sender, RoutedEventArgs e)
        {
            ObservableCollection<string> types = new ObservableCollection<string>();
            types.Add("Slobodni dani");
            types.Add("Godisnji odmor");

            this.type.ItemsSource = types;
        }

        private DateRange parseDateRange()
        {
            DateTime startDate;
            DateTime endDate;

            // date handling, dates suck

            if (start_date.Text.Equals(""))
            {
                startDate = DateTime.Now;
                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 7, 0, 0);
            }
            else
            {
                startDate = DateTime.Parse(start_date.Text);
            }

            if (end_date.Text.Equals(""))
            {
                endDate = startDate.AddDays(1);
            }
            else
            {
                endDate = DateTime.Parse(end_date.Text);
            }

            DateRange dateRange = new DateRange(startDate, endDate);

            return dateRange;
        }
    }
}
