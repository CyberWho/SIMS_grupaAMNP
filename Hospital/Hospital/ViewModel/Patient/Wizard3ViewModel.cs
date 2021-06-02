using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hospital.Controller;
using Hospital.View.Patient;

namespace Hospital.ViewModel.Patient
{
    class Wizard3ViewModel : BindableBase
    {
        private int userId;
        private Window thisWindow;
        public MyICommand Undo { get; set; }
        public MyICommand Next { get; set; }
        public MyICommand Cancel { get; set; }
        public ObservableCollection<Model.Doctor> doctors { get; set; }
        public Wizard3ViewModel()
        {

        }

        public Wizard3ViewModel(int userId, Window thisWindow)
        {
            this.userId = userId;
            this.thisWindow = thisWindow;
            Undo = new MyICommand(OnUndo);
            Next = new MyICommand(OnNext);
            Cancel = new MyICommand(OnCancel);
            doctors = new DoctorController().GetAllDoctors();
        }
        private void OnCancel()
        {
            Window window = new PatientUIView(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnNext()
        {
            Window window = new PatientUIView(userId);
            window.Show();
            thisWindow.Close();
        }

        private void OnUndo()
        {
            Window window = new Wizar2View(userId);
            window.Show();
            thisWindow.Close();
        }
    }
}
