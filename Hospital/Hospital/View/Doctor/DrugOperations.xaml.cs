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

namespace Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for DrugOperations.xaml
    /// </summary>
    public partial class DrugOperations : Window
    {
        public DrugOperations(int id, int id_doc)
        {
            InitializeComponent();
            this.DataContext = new ViewModel.Doctor.DrugOperationsViewModel(id, id_doc, this);
        }
    }
}
