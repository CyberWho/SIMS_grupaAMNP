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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Hospital.Model;

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for ReportCalendarView.xaml
    /// </summary>
    public partial class ReportCalendarView : Window
    {
        private int userId;
        private DateTime startTime;
        private DateTime endTime;
        private MedicalTreatment medicalTreatment;
        public ReportCalendarView(int userId,MedicalTreatment medicalTreatment,DateTime startTime,DateTime endTime)
        {
            InitializeComponent();
            this.DataContext =
                new ViewModel.Patient.ReportCalendarViewModel(userId, medicalTreatment, startTime, endTime, this);
        }
    }
}
