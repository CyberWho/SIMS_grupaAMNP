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
    /// Interaction logic for PatientHealthRecord.xaml
    /// </summary>
    public partial class PatientHealthRecord : Window
    {
        private int healthRecordId;
        private int userId;
        public PatientHealthRecord(int userId,int healthRecordId)
        {
            this.healthRecordId = healthRecordId;
            this.userId = userId;
            InitializeComponent();
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

        private void MojiUputi_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientReferrals(userId,healthRecordId);
            s.Show();
            this.Close();
        }

        private void MojeAlergije_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MojeAnamneze_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MojeTerapije_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MojiRecepti_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
