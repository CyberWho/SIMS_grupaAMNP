using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.View.Patient;

namespace Hospital.ViewModel.Patient
{
    class Wizard2ViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        public MyICommand Undo { get; set; }
        public MyICommand Next { get; set; }
        public MyICommand Cancel { get; set; }

        public Wizard2ViewModel()
        {

        }

        public Wizard2ViewModel(int userId, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            Undo = new MyICommand(OnUndo);
            Next = new MyICommand(OnNext);
            Cancel = new MyICommand(OnCancel);
        }
        private void OnCancel()
        {
            Window window = new PatientUIView(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnNext()
        {
            Window window = new Wizard3View(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnUndo()
        {
            Window window = new WizardHomeView(userId);
            window.Show();
            thisWindow.Close();
        }
    }
}
