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

namespace Hospital.xaml_windows.Patient
{
    /// <summary>
    /// Interaction logic for PatientReferrals.xaml
    /// </summary>
    public partial class PatientReferrals : Window
    {
        private int userId;
        private int healthRecordId;
        public PatientReferrals(int userId,int healthRecordId)
        {
            InitializeComponent();
            this.userId = userId;
            this.healthRecordId = healthRecordId;
        }
        private void MojProfil_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientInfo(userId);
            s.Show();
            this.Close();
        }

        private void MojiPregledi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientAppointments(userId);
            s.Show();
            this.Close();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientUI(userId);
            s.Show();
            this.Close();
        }
        private void Doktori_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ZdravstveniKarton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void MojiPodsetnici_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReminders(userId);
            s.Show();
            this.Close();
        }
    }
}
