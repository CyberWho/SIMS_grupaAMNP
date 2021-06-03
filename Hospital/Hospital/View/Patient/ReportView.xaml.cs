using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Window
    {
        private int userId;
        private ObservableCollection<Reminder> reminders;
        private MedicalTreatment medicalTreatment;
        private DateTime startTime;
        private DateTime endTime;
        public ReportView(int userId,ObservableCollection<Reminder> reminders,MedicalTreatment medicalTreatment,DateTime startTime,DateTime endTime)
        {
            InitializeComponent();
            this.DataContext =
                new ViewModel.Patient.ReportViewModel(userId, reminders, medicalTreatment, startTime, endTime, this);
        }
    }
}
