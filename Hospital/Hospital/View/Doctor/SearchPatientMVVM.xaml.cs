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
using Hospital.ViewModel.Doctor;

namespace Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for SearchPatientMVVM.xaml
    /// </summary>
    public partial class SearchPatientMVVM : Window
    {
        public SearchPatientMVVM(int id, int id_doc)
        {
            InitializeComponent();
            this.DataContext = new SearchPatientViewModel(id, id_doc, this, lb_appointments, btn_nazad, btn_idi_na_karton);
        }
    }
}
