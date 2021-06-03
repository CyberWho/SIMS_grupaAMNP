using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.View.Patient;

namespace Hospital.ViewModel.Patient
{
    class WizardHomeViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        public MyICommand Undo { get; set; }
        public MyICommand Next { get; set; }
        public MyICommand Cancel { get; set; }
        public bool CanUndo { get; set; }
        public WizardHomeViewModel()
        {

        }

        public WizardHomeViewModel(int userId, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            Undo = new MyICommand(OnUndo);
            Next = new MyICommand(OnNext);
            Cancel = new MyICommand(OnCancel);
            CanUndo = false;
        }

        private void OnCancel()
        {
            Window window = new PatientUIView(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnNext()
        {
            Window window = new Wizar2View(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnUndo()
        {
            throw new NotImplementedException();
        }
    }
}
