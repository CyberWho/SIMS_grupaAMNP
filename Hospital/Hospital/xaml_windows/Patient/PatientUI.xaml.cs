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
    /// Interaction logic for PatientUI.xaml
    /// </summary>
    public partial class PatientUI : Window
    {
        int id;
        ReminderController reminderController = new ReminderController();
        PatientController patientController = new PatientController();
        
        public PatientUI(int id)
        {
            InitializeComponent();
            this.id = id;
            
            
        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(id);
            s.Show();
            this.Close();
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(id);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(id);
            s.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(id);
            s.Show();
            this.Close();
        }
    }
}
