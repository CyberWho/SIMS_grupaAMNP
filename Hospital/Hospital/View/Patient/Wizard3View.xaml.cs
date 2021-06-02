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

namespace Hospital.View.Patient
{
    /// <summary>
    /// Interaction logic for Wizard3View.xaml
    /// </summary>
    public partial class Wizard3View : Window
    {
        private int userId;
        public Wizard3View(int userId)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Patient.Wizard3ViewModel(userId, this);
        }
    }
}
